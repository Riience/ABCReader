using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {
        private string templateStr = ""; // margines
        public bool flagRTBcontent = true; //flaga ustawiania marginesu (raz)
        public Dictionary<string, string>[] alignmentDataTX_DNA = new Dictionary<string, string>[] { //Muscle, ClustalW, MafFt, T-Coffee, Prank
            new Dictionary<string, string>(), new Dictionary<string, string>(), new Dictionary<string, string>(),
            new Dictionary<string, string>(), new Dictionary<string, string>()
        };
        public Dictionary<string, string>[] alignmentDataTX_Prot = new Dictionary<string, string>[] { //Muscle, ClustalW, MafFt, T-Coffee, Prank
            new Dictionary<string, string>(), new Dictionary<string, string>(), new Dictionary<string, string>(),
            new Dictionary<string, string>(), new Dictionary<string, string>()
        };

        //private List<bool> selectedAlignment = new List<bool>();
        private bool[] selectedAlignment = new bool[5];
        private bool[] loadedAlignment = new bool[5];
        private bool anyAlignmentAvailable = false;
        public int AlignWindowDecision = -1;

        private List<string> color_AminoAcids = new List<string>();
        private List<string> color_Codons = new List<string>();

        private void InitDataGrid_tabTX() {
            dataTable_TX_Main = new DataTable();
            bindingSource_TX_Main = new BindingSource();
            bindingSource_TX_Main.DataSource = dataTable_TX_Main;
            DGV_tabTX_Main.DataSource = bindingSource_TX_Main;
            dataTable_TX_Main.Columns.Add(new DataColumn("SequenceID", typeof(string)));
            dataTable_TX_Main.Columns.Add(new DataColumn("DNA", typeof(string)));
            dataTable_TX_Main.Columns.Add(new DataColumn("Prot", typeof(string)));
            DGV_tabTX_Main.Columns[0].Width = 300;
            DGV_tabTX_Main.Columns[1].Width = 50;
            DGV_tabTX_Main.Columns[2].Width = 50;

            dataTable_TX_Ignored = new DataTable();
            bindingSource_TX_Rejected = new BindingSource();
            bindingSource_TX_Rejected.DataSource = dataTable_TX_Ignored;
            DGV_tabTX_Ignored.DataSource = bindingSource_TX_Rejected;
            dataTable_TX_Ignored.Columns.Add(new DataColumn("SequenceID", typeof(string)));
            dataTable_TX_Ignored.Columns.Add(new DataColumn("DNA", typeof(string)));
            dataTable_TX_Ignored.Columns.Add(new DataColumn("Prot", typeof(string)));
            DGV_tabTX_Ignored.Columns[0].Width = 300;
            DGV_tabTX_Ignored.Columns[1].Width = 50;
            DGV_tabTX_Ignored.Columns[2].Width = 50;
        }

        private void InitializeTXdataBase(int fromWhere) {
            if(fromWhere == 0) { //tab2: białka
                if (mainDB_ProtSequences == null)
                    return;
                if (mainDB_ProtSequences.Count == 0)
                    return;

                foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                    if (ignoredSequences_tabProt.Contains(entry.Key)) {
                        dataTable_TX_Ignored.Rows.Add(entry.Key, entry.Value.lvl2_DNAcodingSequence, entry.Value.peptideSequence);
                    } else {
                        dataTable_TX_Main.Rows.Add(entry.Key, entry.Value.lvl2_DNAcodingSequence, entry.Value.peptideSequence);
                    }
                }

            } else if (fromWhere == 1) { //tab3: blastP
                if (mainDB_ProtSequences == null)
                    return;
                if (mainDB_ProtSequences.Count == 0)
                    return;
                if (protsFromBlast == null)
                    return;
                if (protsFromBlast.Count == 0)
                    return;

                double maxEval = 1;
                double minCover = 1;
                try {
                    maxEval = Convert.ToDouble(textBox_tabBlastP_maxEvalue.Text.Replace('.', ','));
                    minCover = Convert.ToInt32(numericUpDown_tabBlastP_minCoverage.Value);
                } catch (Exception) {
                    AddLogLineEnter("Błąd inicjalizacji maxEval lub minCover. Przyjęto wartości: 1 i 1.", LogType.ERROR);
                }

                foreach (KeyValuePair<string, BlastData> entry in protsFromBlast) {
                    if (entry.Value.evalue > maxEval || entry.Value.qcovhsp < minCover) {
                        ProteinFromDNA prot = null;
                        mainDB_ProtSequences.TryGetValue(entry.Key, out prot);
                        if(prot != null)
                            dataTable_TX_Ignored.Rows.Add(entry.Key, prot.lvl2_DNAcodingSequence, prot.peptideSequence);
                    } else {
                        ProteinFromDNA prot = null;
                        mainDB_ProtSequences.TryGetValue(entry.Key, out prot);
                        if (prot != null)
                            dataTable_TX_Main.Rows.Add(entry.Key, prot.lvl2_DNAcodingSequence, prot.peptideSequence);
                    }
                }
            }
        }

        /// <summary>
        /// Przygotowanie danych do programu translatorX z głównej tabeli białek (bez ignorowanych).
        /// </summary>
        private void ActivateTranslatorXProcess() {
            if (dataTable_TX_Main.Rows.Count == 0) {
                MessageBox.Show("Brak sekwencji do porównania!");
                return;
            }
            string path = Environment.CurrentDirectory + "\\blastwork\\";

            //tworzenie pliku
            try {
                FileStream fileStream = new FileStream(path + "inputTX01.fasta", FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                foreach(DataRow row in dataTable_TX_Main.Rows) {
                    writer.WriteLine(row[0]);
                    writer.WriteLine(row[1]);
                }
                writer.Close();
            } catch (Exception exc) {
                MessageBox.Show("Błąd zapisu pliku wejściowego dla translatorX!" + Environment.NewLine + exc.Message);
                return;
            }

            if (File.Exists(path + "resultTx.txt.nt_ali.fasta")) {
                File.Delete(path + "resultTx.txt.nt_ali.fasta");
            }

            StartTranslatorX();
        }

        private void StartTranslatorX() {
            string path = Environment.CurrentDirectory + "\\blastwork\\";
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = path + "translatorX.exe";
            if (comboBox_tabTX_alignMethod.SelectedIndex == 0)
                proc.StartInfo.Arguments = "-i inputTX01.fasta -o resultTx.txt -p M";
            else if (comboBox_tabTX_alignMethod.SelectedIndex == 1)
                proc.StartInfo.Arguments = "-i inputTX01.fasta -o resultTx.txt -p C";
            else if (comboBox_tabTX_alignMethod.SelectedIndex == 2)
                proc.StartInfo.Arguments = "-i inputTX01.fasta -o resultTx.txt -p F";
            proc.EnableRaisingEvents = true;
            proc.Exited += new EventHandler(myProcess_Exited);
            proc.Start();
        }

        /// <summary>
        /// Proces aktywowany po zakończeniu pracy TranslatorX.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myProcess_Exited(object sender, System.EventArgs e) {
            string path = Environment.CurrentDirectory + "\\blastwork\\";
            this.Invoke((Action)delegate
            {
                if (comboBox_tabTX_alignMethod.SelectedIndex == 0) { //muscle
                    alignmentDataTX_DNA[0] = abcEngine.LoadDNAFastaFile(path + "resultTx.txt.nt_ali.fasta");
                    //NormalizeAlignment(alignmentDataTX_DNA, 0);

                    checkBoxM.Enabled = true;
                    if (anyAlignmentAvailable == false) {
                        checkBoxM.Checked = true;
                        updateSelectedAlignment(0, true);
                    }
                    updateLoadedAlignment(0, true);
                } else if (comboBox_tabTX_alignMethod.SelectedIndex == 1) {//clustalW
                    alignmentDataTX_DNA[1] = abcEngine.LoadDNAFastaFile(path + "resultTx.txt.nt_ali.fasta");
                    //NormalizeAlignment(alignmentDataTX_DNA, 1);

                    checkBoxC.Enabled = true;
                    if (anyAlignmentAvailable == false) {
                        checkBoxC.Checked = true;
                        updateSelectedAlignment(1, true);
                    }

                    updateLoadedAlignment(1, true);
                } else if (comboBox_tabTX_alignMethod.SelectedIndex == 2) {//mafft
                    alignmentDataTX_DNA[2] = abcEngine.LoadDNAFastaFile(path + "resultTx.txt.nt_ali.fasta");
                    //NormalizeAlignment(alignmentDataTX_DNA, 2);

                    checkBoxF.Enabled = true;
                    if (anyAlignmentAvailable == false) {
                        checkBoxF.Checked = true;
                        updateSelectedAlignment(1, true);
                    }

                    updateLoadedAlignment(2, true);
                }

                InitScrollBar();
            });
            MessageBox.Show("TranslatorX zakończył pracę");
        }

        /// <summary>
        /// Pokazuje tylko pierwszą linię zawierającą numery aminokwasów w białkach.
        /// </summary>
        /// <param name="start">Nr początkowego aminokwasu.</param>
        /// <param name="showAll">true - pokazuje wszystkie od 1 do ostatniego</param>
        private void ShowNumberLinesInRTB(int start, bool showAll) {
            richTextBox_tabTX_results.Clear();
            Color background = richTextBox_tabTX_results.SelectionBackColor;
            int value = Convert.ToInt32(numericUpDown_tabTX_font.Value);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, value);

            if (showAll) {
                start = 0;
            }
            Color colorX = Color.White;
            try {
                int frame = Convert.ToInt32(numericUpDown_tabTX_frameSize.Value);

                int loaded = -1;
                bool found = false;
                foreach(bool state in loadedAlignment) { //znajdź pierwszy załadowany alignment
                    loaded++;
                    if (state) {
                        found = true;
                        break;
                    }
                        
                }
                if (!found)
                    return;

                foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[loaded]) {
                    string id = entry.Key;
                    string seq = entry.Value;
                    int sizeOfAlignment = seq.Length;
                    if (showAll) {
                        frame = sizeOfAlignment / 3;
                    }

                    if (sizeOfAlignment - (start * 3) < frame) {
                        start = sizeOfAlignment - (3 * frame);
                    }

                    string spaces = "";
                    for (int i = 0; i < 60; i++)
                        spaces += " ";
                    richTextBox_tabTX_results.AppendText(spaces);

                    Color back1 = Color.LightGray;
                    for (int i = 0; i < frame; i++) {
                        if (i % 2 == 0)
                            richTextBox_tabTX_results.SelectionBackColor = back1;
                        else
                            richTextBox_tabTX_results.SelectionBackColor = background;
                        richTextBox_tabTX_results.AppendText(getStdString4("" + (start + i + 1)));
                    }
                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    //richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    return;
                }
            } catch (Exception exc2) {
                AddLogLine("Błąd wyświetlania w ShowNumberLinesInRTB(...).", LogType.ERROR);
                AddLogLine(exc2.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Pokazuje część alignmentu w RTB.
        /// </summary>
        /// <param name="start">int, numer pierwszego kodonu do pokazania</param>
        private void ShowResultInRTB(int start) {
            richTextBox_tabTX_results.Clear();
            int fontSize = Convert.ToInt32(numericUpDown_tabTX_font.Value);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, fontSize);

            flagRTBcontent = true;
            Color background = richTextBox_tabTX_results.SelectionBackColor;
            int frame = Convert.ToInt32(numericUpDown_tabTX_frameSize.Value);

            int loaded = -1;
            bool found = false;
            foreach (bool state in loadedAlignment) { //znajdź pierwszy załadowany alignment
                loaded++;
                if (state) {
                    found = true;
                    break;
                }

            }
            if (!found)
                return;

            int howMany = 0;
            for(int i=0; i<5; i++) {
                if (selectedAlignment[i])
                    howMany++;
            }

            if (frame > 100) {
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Maximum = alignmentDataTX_DNA[loaded].Count * howMany;
            }

            bool tokenOnce = true;
            Color colorX = Color.White;
            try {
                int selected = -1;
                for(int sel=0; sel<5; sel++) {
                    selected++;
                    if (selectedAlignment[sel] == false)
                        continue;

                    foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[selected]) {
                        string id = entry.Key;
                        string seq = entry.Value;

                        if (tokenOnce) {
                            int sizeOfAlignment = seq.Length;
                            if (sizeOfAlignment - (start * 3) < frame) { //
                                start = sizeOfAlignment - (3 * frame);
                            }
                            tokenOnce = false;

                            string spaces = "";
                            switch (selected) {
                                case 0:
                                    spaces = "    Muscle alignment   ";
                                    break;
                                case 1:
                                    spaces = "    ClustalW alignment   ";
                                    break;
                                case 2:
                                    spaces = "    MAFFT alignment   ";
                                    break;
                                case 3:
                                    spaces = "    T-Coffee alignment   ";
                                    break;
                                case 4:
                                    spaces = "    Prank alignment   ";
                                    break;

                            }
                            int s_length = spaces.Length;
                            for (int i = 0; i < 60 - s_length; i++)
                                spaces += " ";
                            richTextBox_tabTX_results.AppendText(spaces);

                            Color back1 = Color.LightGray;
                            for (int i = 0; i < frame; i++) {
                                if (i % 2 == 0)
                                    richTextBox_tabTX_results.SelectionBackColor = back1;
                                else
                                    richTextBox_tabTX_results.SelectionBackColor = background;
                                richTextBox_tabTX_results.AppendText(getStdString4("" + (start + i + 1)));
                            }
                            richTextBox_tabTX_results.AppendText(Environment.NewLine);
                            //richTextBox_tabTX_results.AppendText(Environment.NewLine);
                        }

                        if (id.Length < 60) {
                            int idSize = id.Length;
                            for (int i = 0; i < 60 - idSize; i++)
                                id += " ";
                        }
                        richTextBox_tabTX_results.SelectionBackColor = background;
                        richTextBox_tabTX_results.AppendText(id);

                        string subText = "";
                        try {
                            subText = seq.Substring(start * 3, frame * 3);
                        } catch (Exception) {
                            subText = seq.Substring(start * 3);
                        }

                        try {
                            if (frame * 3 > subText.Length)
                                frame = subText.Length / 3;

                            var list = Enumerable.Range(0, subText.Length / 3).Select(i => subText.Substring(i * 3, 3)).ToList();
                            //subText = string.Join(" ", list);

                            if (checkBox_ColorTrigger.Checked) {
                                for (int n = 0; n < frame; n++) {
                                    if(color_Codons.Contains(list[n])) {
                                        codonColorsDict.TryGetValue(list[n], out colorX);
                                        richTextBox_tabTX_results.SelectionBackColor = colorX;
                                        richTextBox_tabTX_results.AppendText(list[n] + " ");
                                        richTextBox_tabTX_results.SelectionBackColor = background;
                                    } else {
                                        //codonColorsDict.TryGetValue(list[n], out colorX);
                                        //richTextBox_tabTX_results.SelectionBackColor = colorX;
                                        richTextBox_tabTX_results.AppendText(list[n] + " ");
                                    }
                                }
                            } else {
                                for (int n = 0; n < frame; n++) {
                                    codonColorsDict.TryGetValue(list[n], out colorX);
                                    richTextBox_tabTX_results.SelectionBackColor = colorX;
                                    richTextBox_tabTX_results.AppendText(list[n] + " ");
                                }
                            }


                        } catch (Exception exc) {
                            AddLogLineEnter("Błąd zakresu ramki.", LogType.ERROR);
                            AddLogLineEnter(exc.Message, LogType.ERROR);
                        }
                        richTextBox_tabTX_results.AppendText(Environment.NewLine);

                        if (frame > 100)
                            toolStripProgressBar1.Value++;
                    }

                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    Application.DoEvents();
                } //dla każdego wskazanego do wyświetlenia


            } catch (Exception exc2) {
                AddLogLine("Błąd wyświetlania w ShowResultInRTB(...).", LogType.ERROR);
                AddLogLine(exc2.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Pokazuje alignment białkowy w kolorze.
        /// </summary>
        /// <param name="start">int, numer pierwszego kodonu do pokazania.</param>
        private void ShowResultProtInRTB(int start) {
            richTextBox_tabTX_results.Clear();
            int fontSize = Convert.ToInt32(numericUpDown_tabTX_font.Value);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, fontSize);
            flagRTBcontent = true;
            Color background = richTextBox_tabTX_results.SelectionBackColor;
            int frame = Convert.ToInt32(numericUpDown_tabTX_frameSize.Value);

            int loaded = -1;
            bool found = false;
            foreach (bool state in loadedAlignment) { //znajdź pierwszy załadowany alignment
                loaded++;
                if (state) {
                    found = true;
                    break;
                }

            }
            if (!found)
                return;

            int howMany = 0;
            for (int i = 0; i < 5; i++) {
                if (selectedAlignment[i])
                    howMany++;
            }

            if (frame > 100) {
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Maximum = alignmentDataTX_DNA[loaded].Count* howMany;
            }

            bool tokenOnce = true;
            Color colorX = Color.White;
            try {
                int selected = -1;
                for (int sel = 0; sel < 5; sel++) {
                    selected++;
                    if (selectedAlignment[sel] == false)
                        continue;

                    foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[selected]) {
                        string id = entry.Key;
                        string seq = entry.Value;

                        if (tokenOnce) {
                            int sizeOfAlignment = seq.Length;
                            if (sizeOfAlignment - (start * 3) < frame) {
                                start = sizeOfAlignment - (3 * frame);
                            }
                            tokenOnce = false;

                            string spaces = "";
                            switch (selected) {
                                case 0:
                                    spaces = "    Muscle alignment   ";
                                    break;
                                case 1:
                                    spaces = "    ClustalW alignment   ";
                                    break;
                                case 2:
                                    spaces = "    MAFFT alignment   ";
                                    break;
                                case 3:
                                    spaces = "    T-Coffee alignment   ";
                                    break;
                                case 4:
                                    spaces = "    Prank alignment   ";
                                    break;

                            }

                            int s_length = spaces.Length;
                            for (int i = 0; i < 60 - s_length; i++)
                                spaces += " ";
                            richTextBox_tabTX_results.AppendText(spaces);

                            Color back1 = Color.LightGray;
                            for (int i = 0; i < frame; i++) {
                                if (i % 2 == 0)
                                    richTextBox_tabTX_results.SelectionBackColor = back1;
                                else
                                    richTextBox_tabTX_results.SelectionBackColor = background;
                                richTextBox_tabTX_results.AppendText(getStdString4("" + (start + i + 1)));
                            }
                            richTextBox_tabTX_results.AppendText(Environment.NewLine);
                            //richTextBox_tabTX_results.AppendText(Environment.NewLine);
                        }

                        if (id.Length < 60) {
                            int idSize = id.Length;
                            for (int i = 0; i < 60 - idSize; i++)
                                id += " ";
                        }
                        richTextBox_tabTX_results.SelectionBackColor = background;
                        richTextBox_tabTX_results.AppendText(id);

                        string subText = "";
                        try {
                            subText = seq.Substring(start * 3, frame * 3);
                        } catch (Exception) {
                            subText = seq.Substring(start * 3);
                        }

                        try {
                            if (frame * 3 > subText.Length)
                                frame = subText.Length / 3;

                            subText = Ribosome.DNAToAminoAcidSpecial(subText);
                            char[] aminoTable = subText.ToArray<char>();

                            if (checkBox_ColorTrigger.Checked) {
                                for (int n = 0; n < frame; n++) {
                                    if (color_AminoAcids.Contains(""+aminoTable[n])) {
                                        aminoColorsDict.TryGetValue(""+aminoTable[n], out colorX);
                                        richTextBox_tabTX_results.SelectionBackColor = colorX;
                                        richTextBox_tabTX_results.AppendText(" " + aminoTable[n] + "  ");
                                        richTextBox_tabTX_results.SelectionBackColor = background;
                                    } else {
                                        richTextBox_tabTX_results.AppendText(" " + aminoTable[n] + "  ");
                                    }
                                }
                            } else {
                                for (int n = 0; n < frame; n++) {
                                    aminoColorsDict.TryGetValue(aminoTable[n] + "", out colorX);
                                    richTextBox_tabTX_results.SelectionBackColor = colorX;
                                    richTextBox_tabTX_results.AppendText(" " + aminoTable[n] + "  ");
                                }
                            }

                            
                        } catch (Exception exc) {
                            AddLogLineEnter("Błąd zakresu ramki.", LogType.ERROR);
                            AddLogLineEnter(exc.Message, LogType.ERROR);
                        }
                        richTextBox_tabTX_results.AppendText(Environment.NewLine);
                        Application.DoEvents();
                        if (frame > 100)
                            toolStripProgressBar1.Value++;
                    }
                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    tokenOnce = true;
                }
            } catch (Exception exc2) {
                AddLogLine("Błąd wyświetlania w ShowResultInRTB(...).", LogType.ERROR);
                AddLogLine(exc2.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Pokazuje całościowy alignment bez kolorów.
        /// </summary>
        /// <param name="selectedForView">int, numer 0-4 alignmentu do pokazania</param>
        private void showAllInRTB(int selectedForView) {
            richTextBox_tabTX_results.Clear();
            int fontSize = Convert.ToInt32(numericUpDown_tabTX_font.Value);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, fontSize);
            flagRTBcontent = true;
            Color background = richTextBox_tabTX_results.SelectionBackColor;

            if (loadedAlignment[selectedForView] == false)
                return;

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = alignmentDataTX_DNA[selectedForView].Count;

            bool tokenOnce = true;
            Color colorX = Color.White;
            try {
                foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[selectedForView]) {
                    string id = entry.Key;
                    string seq = entry.Value;

                    int sizeOfAlignment = 0;
                    if (radioButton_tabTX_showDNA.Checked)
                        sizeOfAlignment = seq.Length;
                    else {
                        seq = Ribosome.DNAToAminoAcidSpecial(seq);
                        sizeOfAlignment = seq.Length;
                        Application.DoEvents();
                    }

                    if (flagRTBcontent) { //margines RTB
                        flagRTBcontent = false;
                        if (radioButton_tabTX_showDNA.Checked) {
                            templateStr = seq + id + id;
                        }
                        else {
                            templateStr = seq + seq + id + id;
                        }
                            
                        richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, 12);
                        richTextBox_tabTX_results.RightMargin = TextRenderer.MeasureText(templateStr, this.richTextBox_tabTX_results.Font).Width;
                        richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, fontSize);
                    }

                    if (tokenOnce) {
                        tokenOnce = false;
                        string spaces = "";
                        switch (selectedForView) {
                            case 0:
                                spaces = "    Muscle alignment   ";
                                break;
                            case 1:
                                spaces = "    ClustalW alignment   ";
                                break;
                            case 2:
                                spaces = "    MAFFT alignment   ";
                                break;
                            case 3:
                                spaces = "    T-Coffee alignment   ";
                                break;
                            case 4:
                                spaces = "    Prank alignment   ";
                                break;

                        }
                        int s_length = spaces.Length;
                        for (int i = 0; i < 60 - s_length; i++)
                            spaces += " ";
                        richTextBox_tabTX_results.AppendText(spaces);


                        Color back1 = Color.LightGray;
                        string numbersLine = "";
                        if (radioButton_tabTX_showDNA.Checked) { //DNA
                            for (int i = 0; i < sizeOfAlignment; i++) {
                                if (i % 90 != 0)
                                    continue;
                                string numberCod = "" + ((i / 3)+1);
                                int numberLen = numberCod.Length;
                                numbersLine += numberCod;
                                for (int j = 0; j < (120 - numberLen); j++)
                                    numbersLine += " ";
                            }
                        } else { //białko
                            for (int i = 0; i < sizeOfAlignment; i++) {
                                if (i % 30 != 0)
                                    continue;
                                string numberCod = "" + (i+1);
                                int numberLen = numberCod.Length;
                                numbersLine += numberCod;
                                for (int j = 0; j < (60 - numberLen); j++)
                                    numbersLine += " ";
                            }
                        }
                        richTextBox_tabTX_results.AppendText(numbersLine);
                        richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    }

                    if (id.Length < 55) {
                        int idSize = id.Length;
                        for (int i = 0; i < 55 - idSize; i++)
                            id += " ";
                    }
                    richTextBox_tabTX_results.SelectionBackColor = background;
                    richTextBox_tabTX_results.AppendText(id);

                    if (radioButton_tabTX_showDNA.Checked) { //DNA
                        try {
                            string newSeq = "";
                            var list = Enumerable.Range(0, seq.Length / 3).Select(i => seq.Substring(i * 3, 3)).ToList();
                            foreach (string s in list) {
                                newSeq += (s + " ");
                            }
                            richTextBox_tabTX_results.AppendText(newSeq);

                        } catch (Exception exc) {
                            AddLogLineEnter("Błąd zakresu ramki.", LogType.ERROR);
                            AddLogLineEnter(exc.Message, LogType.ERROR);
                        }
                    } else { //białko
                        try {
                            string newSeq = "";
                            char[] charTable = seq.ToCharArray();
                            foreach (char c in charTable) {
                                newSeq += (c + " ");
                            }
                            richTextBox_tabTX_results.AppendText(newSeq);

                        } catch (Exception exc) {
                            AddLogLineEnter("Błąd zakresu ramki.", LogType.ERROR);
                            AddLogLineEnter(exc.Message, LogType.ERROR);
                        }
                        
                    }

                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    toolStripProgressBar1.Value++;
                    Application.DoEvents();

                }

                richTextBox_tabTX_results.AppendText(Environment.NewLine);
            } catch (Exception exc2) {
                AddLogLine("Błąd wyświetlania w ShowResultInRTB(...).", LogType.ERROR);
                AddLogLine(exc2.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Pokazuje czarno-biały obraz całości dopasowania.
        /// </summary>
        private void ShowResultInRTB_Mono() {
            richTextBox_tabTX_results.Clear();
            Color background = richTextBox_tabTX_results.SelectionBackColor;

            int loaded = -1;
            bool found = false;
            foreach (bool state in loadedAlignment) { //znajdź pierwszy załadowany alignment
                loaded++;
                if (state) {
                    found = true;
                    break;
                }

            }
            if (!found)
                return;

            int howMany = 0;
            for (int i = 0; i < 5; i++) {
                if (selectedAlignment[i])
                    howMany++;
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = alignmentDataTX_DNA[loaded].Count* howMany;

            bool tokenOnce = true;
            flagRTBcontent = true;
            Color colorX = Color.White;
            try {
                int selected = -1;
                for (int sel = 0; sel < 5; sel++) {
                    selected++;
                    if (selectedAlignment[sel] == false)
                        continue;

                    foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[selected]) {
                        string id = entry.Key;
                        string seq = entry.Value;
                        int sizeOfAlignment = seq.Length;

                        if (flagRTBcontent) { //margines RTB
                            flagRTBcontent = false;
                            templateStr = seq + id + id;
                            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, 12);
                            richTextBox_tabTX_results.RightMargin = TextRenderer.MeasureText(templateStr, this.richTextBox_tabTX_results.Font).Width;

                            int fontSize = Convert.ToInt32(numericUpDown_tabTX_font.Value);
                            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, fontSize);
                        }

                        if (tokenOnce) {
                            tokenOnce = false;
                            string spaces = "";
                            for (int i = 0; i < 55; i++)
                                spaces += " ";
                            richTextBox_tabTX_results.AppendText(spaces);

                            Color back1 = Color.LightGray;
                            for (int i = 0; i < sizeOfAlignment / 3; i++) {
                                if (i % 2 == 0)
                                    richTextBox_tabTX_results.SelectionBackColor = back1;
                                else
                                    richTextBox_tabTX_results.SelectionBackColor = background;
                                richTextBox_tabTX_results.AppendText(getStdString4("" + i));
                            }
                            richTextBox_tabTX_results.AppendText(Environment.NewLine);
                            //richTextBox_tabTX_results.AppendText(Environment.NewLine);
                        }


                        if (id.Length < 55) {
                            int idSize = id.Length;
                            for (int i = 0; i < 55 - idSize; i++)
                                id += " ";
                        }
                        richTextBox_tabTX_results.SelectionBackColor = background;
                        richTextBox_tabTX_results.AppendText(id);

                        int proteins = sizeOfAlignment / 3;

                        var list = Enumerable.Range(0, seq.Length / 3).Select(i => seq.Substring(i * 3, 3)).ToList();
                        seq = string.Join(" ", list);
                        richTextBox_tabTX_results.AppendText(seq + Environment.NewLine);
                        toolStripProgressBar1.Value++;
                    }
                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    richTextBox_tabTX_results.AppendText(Environment.NewLine);
                    tokenOnce = true;
                }
            } catch (Exception exc2) {
                AddLogLine("Błąd wyświetlania w ShowResultInRTB(...).", LogType.ERROR);
                AddLogLine(exc2.Message, LogType.ERROR);
            }
        }

        private string getStdString4(string number) {
            int size = number.Length;
            if (size >= 4)
                return number;

            for (int i = 0; i < 4 - size; i++)
                number += " ";

            return number;
        }

        private void InitScrollBar() {
            int loaded = -1;
            bool found = false;
            foreach (bool state in loadedAlignment) { //znajdź pierwszy załadowany alignment
                loaded++;
                if (state) {
                    found = true;
                    break;
                }

            }
            if (!found)
                return;

            if (alignmentDataTX_DNA[loaded].Count < 1)
                return;

            hScrollBar_tabTX.Value = 0;
            foreach (KeyValuePair<string, string> entry in alignmentDataTX_DNA[loaded]) {
                int size = entry.Value.Length;
                size /= 3;
                hScrollBar_tabTX.Maximum = size;
                break;
            }
        }

        private void loadTXalignmentFile() {
            string filePath = Tools.loadDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (filePath.Length < 2)
                return;

            bool lastFirstAlignState = anyAlignmentAvailable;

            AlignWindowDecision = -1;
            ChooseAlignForm caf = new ChooseAlignForm(this);
            caf.ShowDialog();

            if (AlignWindowDecision == -1)
                return;

            alignmentDataTX_DNA[AlignWindowDecision] = abcEngine.LoadDNAFastaFile(filePath);
            updateLoadedAlignment(AlignWindowDecision, true);
            //NormalizeAlignment(alignmentDataTX_DNA, AlignWindowDecision);

            switch (AlignWindowDecision) {
                case 0:
                    checkBoxM.Enabled = true;
                    if (lastFirstAlignState == false)
                        checkBoxM.Checked = true;
                    break;
                case 1:
                    checkBoxC.Enabled = true;
                    if (lastFirstAlignState == false)
                        checkBoxC.Checked = true;
                    break;
                case 2:
                    checkBoxF.Enabled = true;
                    if (lastFirstAlignState == false)
                        checkBoxF.Checked = true;
                    break;
                case 3:
                    checkBoxT.Enabled = true;
                    if (lastFirstAlignState == false)
                        checkBoxT.Checked = true;
                    break;
                case 4:
                    checkBoxP.Enabled = true;
                    if (lastFirstAlignState == false)
                        checkBoxP.Checked = true;
                    break;
                default:
                    break;
            }

            flagRTBcontent = true;
            richTextBox_tabTX_results.Clear();

            if(lastFirstAlignState == false) { //jeśli to pierwszy wczytany alignment
                foreach (KeyValuePair<string, string> seq in alignmentDataTX_DNA[AlignWindowDecision]) {
                    string ID = seq.Key;
                    string codingDNA = seq.Value;
                    codingDNA = codingDNA.Replace("-", "");
                    string protein = Ribosome.DNAToAminoAcid(codingDNA);
                    dataTable_TX_Main.Rows.Add(ID, codingDNA, protein);
                }
            }
        }

        private void updateSelectedAlignment(int whichOne, bool state) {
            if(whichOne > -1 && whichOne < 5) {
                selectedAlignment[whichOne] = state;
            }
        }

        private void updateLoadedAlignment(int whichOne, bool state) {
            if (whichOne > -1 && whichOne < 5) {
                loadedAlignment[whichOne] = state;
            }
            if (anyAlignmentAvailable == false)
                anyAlignmentAvailable = true;
        }

        private void NormalizeAlignment(Dictionary<string, string>[] alignmentDataTX, int alignWindowDecision) {

            //string[] newTable = alignmentDataTX[alignWindowDecision].Tr
            List<string> IDs = new List<string>();
            List<string> newSeqs = new List<string>();
            List<string> newProts = new List<string>();

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = alignmentDataTX[alignWindowDecision].Count;

            foreach (KeyValuePair<string, string> entry in alignmentDataTX[alignWindowDecision]) {
                string oldAlignDNA = entry.Value;
                string oldAlignProt = Ribosome.DNAToAminoAcidSpecial(oldAlignDNA);
                

                var list = Enumerable.Range(0, oldAlignDNA.Length / 3).Select(i => oldAlignDNA.Substring(i * 3, 3)).ToList();
                string newLine = string.Join(" ", list);
                IDs.Add(entry.Key);
                newSeqs.Add(newLine); //alignment

                //teraz białka:
                char[] aminoTable = oldAlignProt.ToArray<char>();
                string newProt = "";
                foreach(char letter in aminoTable) {
                    newProt += " " + letter + "  ";
                }
                newProts.Add(newProt);

                toolStripProgressBar1.Value++;
            }

            for(int i=0; i<IDs.Count; i++) {
                alignmentDataTX[alignWindowDecision][IDs[i]] = newSeqs[i];

                alignmentDataTX_Prot[alignWindowDecision].Add(IDs[i], newProts[i]);
            }

            
        }

        /// <summary>
        /// Aktualizacja tablicy kodonów/amino do kolorowania
        /// </summary>
        private void updateColorArrays() {
            color_AminoAcids.Clear();
            color_Codons.Clear();

            if(checkBox_aminoA.Checked) {
                color_AminoAcids.Add("A");
                color_Codons.Add("GCT");
                color_Codons.Add("GCC");
                color_Codons.Add("GCA");
                color_Codons.Add("GCG");
            }
            if (checkBox_aminoC.Checked) {
                color_AminoAcids.Add("C");
                color_Codons.Add("TGT");
                color_Codons.Add("TGC");
            }
            if (checkBox_aminoD.Checked) {
                color_AminoAcids.Add("D");
                color_Codons.Add("GAT");
                color_Codons.Add("GAC");
            }
            if (checkBox_aminoE.Checked) {
                color_AminoAcids.Add("E");
                color_Codons.Add("GAA");
                color_Codons.Add("GAG");
            }
            if (checkBox_aminoF.Checked) {
                color_AminoAcids.Add("F");
                color_Codons.Add("TTT");
                color_Codons.Add("TTC");
            }
            if (checkBox_aminoG.Checked) {
                color_AminoAcids.Add("G");
                color_Codons.Add("GGT");
                color_Codons.Add("GGC");
                color_Codons.Add("GGA");
                color_Codons.Add("GGG");
            }
            if (checkBox_aminoH.Checked) {
                color_AminoAcids.Add("H");
                color_Codons.Add("CAT");
                color_Codons.Add("CAC");
            }
            if (checkBox_aminoI.Checked) {
                color_AminoAcids.Add("I");
                color_Codons.Add("ATT");
                color_Codons.Add("ATC");
                color_Codons.Add("ATA");
            }
            if (checkBox_aminoK.Checked) {
                color_AminoAcids.Add("K");
                color_Codons.Add("AAA");
                color_Codons.Add("AAG");
            }
            if (checkBox_aminoL.Checked) {
                color_AminoAcids.Add("L");
                color_Codons.Add("TTA");
                color_Codons.Add("TTG");
                color_Codons.Add("CTT");
                color_Codons.Add("CTC");
                color_Codons.Add("CTA");
                color_Codons.Add("CTG");
            }
            if (checkBox_aminoM.Checked) {
                color_AminoAcids.Add("M");
                color_Codons.Add("ATG");
            }
            if (checkBox_aminoN.Checked) {
                color_AminoAcids.Add("N");
                color_Codons.Add("AAT");
                color_Codons.Add("AAC");
            }
            if (checkBox_aminoP.Checked) {
                color_AminoAcids.Add("P");
                color_Codons.Add("CCT");
                color_Codons.Add("CCC");
                color_Codons.Add("CCA");
                color_Codons.Add("CCG");
            }
            if (checkBox_aminoQ.Checked) {
                color_AminoAcids.Add("Q");
                color_Codons.Add("CAA");
                color_Codons.Add("CAG");
            }
            if (checkBox_aminoR.Checked) {
                color_AminoAcids.Add("R");
                color_Codons.Add("CGT");
                color_Codons.Add("CGC");
                color_Codons.Add("CGA");
                color_Codons.Add("CGG");
                color_Codons.Add("AGA");
                color_Codons.Add("AGG");
            }
            if (checkBox_aminoS.Checked) {
                color_AminoAcids.Add("S");
                color_Codons.Add("TCT");
                color_Codons.Add("TCC");
                color_Codons.Add("TCA");
                color_Codons.Add("TCG");
                color_Codons.Add("AGT");
                color_Codons.Add("AGC");
            }
            if (checkBox_aminoT.Checked) {
                color_AminoAcids.Add("T");
                color_Codons.Add("ACT");
                color_Codons.Add("ACC");
                color_Codons.Add("ACA");
                color_Codons.Add("ACG");
            }
            if (checkBox_aminoW.Checked) {
                color_AminoAcids.Add("W");
                color_Codons.Add("TGG");
            }
            if (checkBox_aminoY.Checked) {
                color_AminoAcids.Add("Y");
                color_Codons.Add("TAT");
                color_Codons.Add("TAC");
            }
            if (checkBox_aminoV.Checked) {
                color_AminoAcids.Add("V");
                color_Codons.Add("GTT");
                color_Codons.Add("GTC");
                color_Codons.Add("GTA");
                color_Codons.Add("GTG");
            }

            color_AminoAcids.Sort();
            color_Codons.Sort();
        }
    }
}
