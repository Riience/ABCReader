using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        private void resetTab1Data() {
            dataDNAread = false;
            mainDB_DNAsequences = null;
            richTextBox_tabDNA_DNAview.Clear();
            richTextBox_tabProts_protView1.Clear();
            richTextBox_tabProts_proteinBlastView.Clear();
            comboBox_tabDNA_DNAlist.Items.Clear();
            groupBox_tabDNA_top_viewOptions.Text = "Podgląd sekwencji (0 wczytanych)";
        }

        private void resetTab2Data() {
            mainDB_ProtSequences = null;
            dataProteinRead = false;
            richTextBox_tabProts_protView1.Clear();
            richTextBox_tabProts_proteinBlastView.Clear();
            comboBox_tabProt_ProteinsList.Items.Clear();
            groupBox_tabProt_proteinViewer.Text = "Lista sekwencji białkowych: 0";

            ignoredSequences_tabProt.Clear();

            resetTab2TablesData();
        }

        private void resetTab2TablesData() {
            dataTable_ProteinCompareBig.Clear();
            dataTable_ProteinCompareSmall.Clear();
            richTextBox_tabProt_SimiliarInfo.Clear();
        }

        private void resetTab3Data() {
            dataTable_BlastTable.Clear();
            richTextBox_tabBlastP_blastView.Clear();
            removedResultsIDs.Clear();
        }

        private void resetTab4_TransX_Data() {
            flagRTBcontent = true;
            richTextBox_tabTX_results.Clear();
            dataTable_TX_Main.Clear();
            dataTable_TX_Ignored.Clear();


            alignmentDataTX_DNA[0].Clear();
            alignmentDataTX_DNA[1].Clear();
            alignmentDataTX_DNA[2].Clear();
            alignmentDataTX_DNA[3].Clear();
            alignmentDataTX_DNA[4].Clear();

            alignmentDataTX_Prot[0].Clear();
            alignmentDataTX_Prot[1].Clear();
            alignmentDataTX_Prot[2].Clear();
            alignmentDataTX_Prot[3].Clear();
            alignmentDataTX_Prot[4].Clear();

            for (int i=0; i<5; i++) {
                selectedAlignment[i] = false;
                loadedAlignment[i] = false;
            }
            anyAlignmentAvailable = false;
            lastScrollValue = 0;

            checkBoxM.Enabled = false;
            checkBoxM.Checked = false;
            checkBoxC.Enabled = false;
            checkBoxC.Checked = false;
            checkBoxF.Enabled = false;
            checkBoxF.Checked = false;
            checkBoxT.Enabled = false;
            checkBoxT.Checked = false;
            checkBoxP.Enabled = false;
            checkBoxP.Checked = false;
        }

        /// <summary>
        /// Wczytuje konfigurację kontrolek z pliku config.data lub tworzy nowy.
        /// </summary>
        private void loadConfig() {
            if (File.Exists("config.dat")) {
                try {
                    string[] lines = System.IO.File.ReadAllLines("config.dat");
                    foreach(string line in lines) {
                        if(line.Contains("<tab1MetStop>")) {
                            if(line.Contains("False"))
                                configuration.tab1_DNA_metStart = false;
                            else
                                configuration.tab1_DNA_metStart = true;
                        } else if (line.Contains("<tab1sortSeq>")) {
                            if (line.Contains("False"))
                                configuration.tab1_sortSequences = false;
                            else
                                configuration.tab1_sortSequences = true;
                        } else if (line.Contains("<tab2startMet>")) {
                            if (line.Contains("False"))
                                configuration.tab2_DNA_metStart = false;
                            else
                                configuration.tab2_DNA_metStart = true;
                        } else if (line.Contains("<tab2stopCodon>")) {
                            if (line.Contains("False"))
                                configuration.tab2_DNA_codonStop = false;
                            else
                                configuration.tab2_DNA_codonStop = true;
                        } else if (line.Contains("<tab2protMinLength>")) {
                            string tmp = line.Substring(line.IndexOf(">")+1);
                            try {
                                configuration.tab2_minProtSize = Convert.ToInt32(tmp);
                            } catch (Exception) {
                            }
                        } else if (line.Contains("<tab3maxEvalue>")) {
                            string tmp = line.Substring(line.IndexOf(">")+1);
                            try {
                                configuration.tab3_maxEvalue = Convert.ToDouble(tmp);
                            } catch (Exception) {
                            }
                        } else if (line.Contains("<tab3minCover>")) {
                            string tmp = line.Substring(line.IndexOf(">")+1);
                            try {
                                configuration.tab3_minCover = Convert.ToInt32(tmp);
                            } catch (Exception) {
                            }
                        } else if (line.Contains("<tab4fontSize>")) {
                            string tmp = line.Substring(line.IndexOf(">")+1);
                            try {
                                configuration.tab4_fontSize = Convert.ToInt32(tmp);
                            } catch (Exception) {
                            }
                        } else if (line.Contains("<tab4frameSize>")) {
                            string tmp = line.Substring(line.IndexOf(">")+1);
                            try {
                                configuration.tab4_frameSize = Convert.ToInt32(tmp);
                            } catch (Exception) {
                            }
                        }
                    }

                } catch (Exception exc) {
                    AddLogLine("Błąd odczytu pliku config.dat.", LogType.ERROR);
                    AddLogLine(exc.Message, LogType.ERROR);
                }
            } else {
                saveConfig();
            }

        }

        /// <summary>
        /// Ustawia wybrane kontrolki wg konfiguracji wczytanej z pliku.
        /// </summary>
        private void initConfig() {
            checkBox_tabDNA_realProteins.Checked = configuration.tab1_DNA_metStart;
            checkBox_tabDNA_SortDNAbyLength.Checked = configuration.tab1_sortSequences;

            checkBox_tabProt_startFromMET.Checked = configuration.tab2_DNA_metStart;
            checkBox_tabProt_onlyWithSTOP.Checked = configuration.tab2_DNA_codonStop;
            numericUpDown_tabProt_minLength.Value = configuration.tab2_minProtSize;

            textBox_tabBlastP_maxEvalue.Text = configuration.tab3_maxEvalue.ToString();
            numericUpDown_tabBlastP_minCoverage.Value = configuration.tab3_minCover;

            numericUpDown_tabTX_font.Value = configuration.tab4_fontSize;
            numericUpDown_tabTX_frameSize.Value = configuration.tab4_frameSize;
        }

        private void saveConfig() {

            try {
                FileStream fileStream = new FileStream("config.dat", FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                writer.WriteLine("<tab1MetStop>" + checkBox_tabDNA_realProteins.Checked);
                writer.WriteLine("<tab1sortSeq>" + checkBox_tabDNA_SortDNAbyLength.Checked);
                writer.WriteLine("<tab2startMet>" + checkBox_tabProt_startFromMET.Checked);
                writer.WriteLine("<tab2stopCodon>" + checkBox_tabProt_onlyWithSTOP.Checked);
                writer.WriteLine("<tab2protMinLength>" + numericUpDown_tabProt_minLength.Value);
                writer.WriteLine("<tab3maxEvalue>" + textBox_tabBlastP_maxEvalue.Text);
                writer.WriteLine("<tab3minCover>" + numericUpDown_tabBlastP_minCoverage.Value);
                writer.WriteLine("<tab4fontSize>" + numericUpDown_tabTX_font.Value);
                writer.WriteLine("<tab4frameSize>" + numericUpDown_tabTX_frameSize.Value);
                //writer.WriteLine("");
                //writer.WriteLine("");
                //writer.WriteLine("");

                writer.Close();
            } catch (Exception exc) {
                AddLogLineEnter("Błąd zapisu pliku config.dat.", LogType.ERROR);
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }
        }

        public void updateGloballyCurrentDir(string dir) {
            if (dir == null)
                return;

            currentDir = dir;
            saveForm.updateCurrentDir(dir);
        }

        public string getDirectoryFromPath(string path) {
            //string newSaveName = saveFileName + ".txt"; //for safety
            try {
                int sep = path.LastIndexOf("\\") + 1;
                path = path.Substring(0, sep);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                return null;
            }
            return path;
        }

        /// <summary>
        /// Wypisuje tabelę wyników z BlastP na zadanym obiekcie RichTextBox.
        /// </summary>
        /// <param name="rtb">Obiekt RichTextBox</param>
        /// <param name="lista">Lista obiektów BlastData - wyników z BlastP</param>
        private void PrintBlastTable(RichTextBox rtb, List<BlastData> lista) {
            
            try {
                string spaces = "";
                int nameSpaces = 40;
                for (int i = 0; i < nameSpaces; i++)
                    spaces += " ";
                rtb.AppendText(spaces + "Evalue:   Cover: Ident:    Length:" + Environment.NewLine);

                foreach (BlastData entry in lista) {
                    string DBid = entry.sseqid;
                    int letters = DBid.Length;
                    for (int i = letters; i < nameSpaces; i++) {
                        DBid += " ";
                    }

                    string ev = entry.evalue.ToString();
                    letters = ev.Length;
                    for (int i = letters; i < 10; i++) {
                        ev += " ";
                    }
                    string cover = entry.qcovhsp.ToString() + "%";
                    letters = cover.Length;
                    for (int i = letters; i < 7; i++) {
                        cover += " ";
                    }
                    string ident = entry.pident.ToString() + "%";
                    letters = ident.Length;
                    for (int i = letters; i < 10; i++) {
                        ident += " ";
                    }
                    //rtb.AppendText("" + DBid + "" + ev + "" + cover + "" + ident + "" + entry.length + Environment.NewLine);
                }
            } catch (Exception e) {
                var st = new StackTrace(e, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(e.Message + " xxxx " +line);
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabControl1.TabPages[3]) { //resetuj kolor logu
                SetTabHeader(tabControl1.TabPages[3], SystemColors.Window);
            }
        }

        private void SetTabHeader(TabPage page, Color color) {
            TabColors[page] = color;
            tabControl1.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e) {
            using (Brush br = new SolidBrush(TabColors[tabControl1.TabPages[e.Index]])) {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                //Rectangle rect = e.Bounds;
                //rect.Offset(0, 1);
                //rect.Inflate(0, -1);
                //e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                //e.DrawFocusRectangle();
            }
        }

        private void AlignV2() {
            string a1, a2 = "";

            a1 = textBox_tabOther_Seq1.Text.ToUpper();
            a2 = textBox_tabOther_Seq2.Text.ToUpper(); ;

            bool clear1 = Ribosome.IsCleanDNA(a1, true);
            bool clear2 = Ribosome.IsCleanDNA(a2, true);

            if (a1.Length < 3 || a2.Length < 3)
                return;

            if (clear1 == false || clear2 == false) {
                MessageBox.Show("Nieprawidłowe znaki w kodzie DNA. BlastN nie może zostać uruchomiony.");
                return;
            }


            richTextBox_tabNotepad_Right.Clear();
            string path = Environment.CurrentDirectory + "\\blastwork\\";
            using (StreamWriter writer = new StreamWriter(new FileStream(path + "f1.fa", FileMode.Create))) {
                writer.WriteLine(">Seq1");
                writer.WriteLine(a1);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(path + "f2.fa", FileMode.Create))) {
                writer.WriteLine(">Seq2");
                writer.WriteLine(a2);
            }

            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = path + "blastn.exe";
            proc.StartInfo.Arguments = "-query f1.fa -subject f2.fa";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            string vector = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            proc.Close();

            richTextBox_tabNotepad_Right.AppendText(vector+Environment.NewLine);
        }

        private void Alignment() {
            string a1, a2 = "";

            a1 = textBox_tabOther_Seq1.Text;
            a2 = textBox_tabOther_Seq2.Text;

            string[] res = null;
            if (radioButton_tabNotepad_NW.Checked) {
                res = BioinfCoreAlgorithms.NeedlemanWunsch(a1, a2);
            } else {
               // res = BioinfCoreAlgorithms.SmithWatermanAlign(a1, a2, -4, 5, -3);
            }

            int points = 0;
            int size = res[0].Length;
            char[] seq1ch = res[0].ToCharArray();
            char[] seq2ch = res[1].ToCharArray();
            for (int i = 0; i < size; i++) {
                if (seq1ch[i] == seq2ch[i])
                    points++;
            }

            richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
            double res111 = (double)points / (double)size;
            richTextBox_tabNotepad_Left.AppendText("Identyczność: " + res111.ToString() + Environment.NewLine);
            ShowAlignmentInColor(res[0], res[1]);

        }

        /// <summary>
        /// Skanowanie katalogu na pliku blastout.fasta i usuwanie wszystkich duplikatów sekwencji w nich.
        /// </summary>
        private void RemoveDuplicatedSequencesFromFile() {
            string folder = Tools.OpenFolderDialog();
            if (folder == null)
                return;

            string[] allFiles = Directory.GetFiles(folder, "*.fasta", SearchOption.AllDirectories);

            Dictionary<string, string> uniqDict = new Dictionary<string, string>();

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = allFiles.Length;

            foreach (string path in allFiles) {
                toolStripProgressBar1.Value++;
                string[] currentFile = Engine.getFileNameInfo(path);
                string allowedF1 = textBox1.Text.Replace(".fasta", "");
                string allowedF2 = textBox_tabOther_Seq1.Text.Replace(".fasta", "");
                string allowedF3 = textBox_tabOther_Seq2.Text.Replace(".fasta", "");
                string allowedF4 = textBox4.Text.Replace(".fasta", "");

                bool go_on = false;

                if (currentFile[0].Equals(allowedF1))
                    go_on = true;
                else if (currentFile[0].Equals(allowedF2))
                    go_on = true;
                else if (currentFile[0].Equals(allowedF3))
                    go_on = true;
                else if (currentFile[0].Equals(allowedF3))
                    go_on = true;

                if (go_on == false)
                    continue;


                List<string[]> danezPlikuDNAFasta = abcEngine.LoadFastaFile_DNA(path);

                try {
                    if (currentFile[1].Equals(".fasta") == false)
                        currentFile[1] = ".fasta";

                    string newFileName = currentFile[2] + currentFile[0] + "_Unique" + currentFile[1];
                    string rejFileName = currentFile[2] + currentFile[0] + "_RemovedSeqs.txt";
                    StreamWriter writerNewFasta = new StreamWriter(new FileStream(newFileName, FileMode.Create));
                    StreamWriter writerNewRejected = new StreamWriter(new FileStream(rejFileName, FileMode.Create));

                    foreach (string[] idAndSeq in danezPlikuDNAFasta) {
                        if(uniqDict.ContainsKey(idAndSeq[1])) { //jest już taka sekwencja
                            string seqTag = null;
                            uniqDict.TryGetValue(idAndSeq[1], out seqTag);
                            if(seqTag != null) {
                                writerNewRejected.WriteLine(idAndSeq[0]+" istnieje jako " +seqTag);
                            }
                        } else {
                            string tmpPath = currentFile[2].Substring(0, currentFile[2].Length - 1);
                            string tmpDir = tmpPath.Substring(tmpPath.LastIndexOf("\\"));
                            string newTag = ""+ idAndSeq[0]+" ("+ tmpDir+"\\"+ currentFile[0]+currentFile[1]+")";
                            uniqDict.Add(idAndSeq[1], newTag); //klucz: sekwencja, tag: info gdzie
                            writerNewFasta.WriteLine(idAndSeq[0]);
                            writerNewFasta.WriteLine(idAndSeq[1]);
                        }
                    }
                    writerNewFasta.Close();
                    writerNewRejected.Close();
                } catch (Exception exc) {
                    AddLogLine("Błąd zapisu pliku: " + exc.Message, LogType.ERROR);
                }
            }
        }

        private void resetProgramForNewData(Dictionary<string, ProteinFromDNA> nowySlownik) {
            resetTab1Data();
            resetTab2Data();
            resetTab3Data();

            mainDB_ProtSequences = nowySlownik;
            dataDNAread = true;
            dataProteinRead = true;

            if (mainDB_DNAsequences == null)
                mainDB_DNAsequences = new Dictionary<string, string>();
            else
                mainDB_DNAsequences.Clear();

            //dane białek:
            comboProteinOffline = true;
            comboBox_tabProt_ProteinsList.Items.Clear();
            foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                comboBox_tabProt_ProteinsList.Items.Add(entry.Key);
                mainDB_DNAsequences.Add(entry.Value.DNAseqID, entry.Value.DNAsequence);
            }
            comboProteinOffline = false;
            groupBox_tabProt_proteinViewer.Text = "Lista sekwencji białkowych:" + mainDB_ProtSequences.Count;

            //dane DNA:
            if (checkBox_tabDNA_SortDNAbyLength.Checked)
                mainDB_DNAsequences = mainDB_DNAsequences.OrderByDescending(x => x.Value.Length).ToDictionary(x => x.Key, x => x.Value);
            //ze względu na potencjalną konieczność posortowania sekwencji DNA, oddzielnie:
            if (mainDB_DNAsequences != null && mainDB_DNAsequences.Keys.Count > 0) {
                comboDNAOffline = true;
                comboBox_tabDNA_DNAlist.Items.Clear();
                foreach (KeyValuePair<string, string> entry in mainDB_DNAsequences) {
                    comboBox_tabDNA_DNAlist.Items.Add(entry.Key + " (size: " + entry.Value.ToString().Length + ")");
                }
                comboDNAOffline = false;
                groupBox_tabDNA_top_viewOptions.Text = "Podgląd sekwencji (" + mainDB_DNAsequences.Keys.Count + " wczytanych)";
            }
        }

        private static void BuildSortDictionary() {
            codonColorsDict.Add("TTT", Color.FromArgb(130, 130, 170));
            codonColorsDict.Add("TTC", Color.FromArgb(130, 130, 170));
            codonColorsDict.Add("TTA", Color.Green);
            codonColorsDict.Add("TTG", Color.Green);
            codonColorsDict.Add("CTT", Color.Green);
            codonColorsDict.Add("CTC", Color.Green);
            codonColorsDict.Add("CTA", Color.Green);
            codonColorsDict.Add("CTG", Color.Green);

            codonColorsDict.Add("TCT", Color.Orange);
            codonColorsDict.Add("TCC", Color.Orange);
            codonColorsDict.Add("TCA", Color.Orange);
            codonColorsDict.Add("TCG", Color.Orange);
            codonColorsDict.Add("AGT", Color.Orange);
            codonColorsDict.Add("AGC", Color.Orange);
            codonColorsDict.Add("TAT", Color.FromArgb(82, 82, 170));
            codonColorsDict.Add("TAC", Color.FromArgb(82, 82, 170));

            codonColorsDict.Add("TGT", Color.FromArgb(230, 230, 0));
            codonColorsDict.Add("TGC", Color.FromArgb(230, 230, 0));
            codonColorsDict.Add("TGG", Color.PaleVioletRed);
            codonColorsDict.Add("CCT", Color.FromArgb(220, 150, 130));
            codonColorsDict.Add("CCC", Color.FromArgb(220, 150, 130));
            codonColorsDict.Add("CCA", Color.FromArgb(220, 150, 130));
            codonColorsDict.Add("CCG", Color.FromArgb(220, 150, 130));
            codonColorsDict.Add("CAT", Color.FromArgb(130, 130, 210));

            codonColorsDict.Add("CAC", Color.FromArgb(130, 130, 210));
            codonColorsDict.Add("CAA", Color.LightSkyBlue);
            codonColorsDict.Add("CAG", Color.LightSkyBlue);
            codonColorsDict.Add("CGT", Color.DodgerBlue);
            codonColorsDict.Add("CGC", Color.DodgerBlue);
            codonColorsDict.Add("CGA", Color.DodgerBlue);
            codonColorsDict.Add("CGG", Color.DodgerBlue);
            codonColorsDict.Add("AGA", Color.DodgerBlue);

            codonColorsDict.Add("AGG", Color.DodgerBlue);
            codonColorsDict.Add("ATT", Color.FromArgb(95, 130, 95));
            codonColorsDict.Add("ATC", Color.FromArgb(95, 130, 95));
            codonColorsDict.Add("ATA", Color.FromArgb(95, 130, 95));
            codonColorsDict.Add("ATG", Color.FromArgb(230, 225, 98));
            codonColorsDict.Add("ACT", Color.DarkGoldenrod);
            codonColorsDict.Add("ACC", Color.DarkGoldenrod);
            codonColorsDict.Add("ACA", Color.DarkGoldenrod);

            codonColorsDict.Add("ACG", Color.DarkGoldenrod);
            codonColorsDict.Add("AAT", Color.FromArgb(0, 170, 170));
            codonColorsDict.Add("AAC", Color.FromArgb(0, 170, 170));
            codonColorsDict.Add("AAA", Color.FromArgb(68, 74, 255));
            codonColorsDict.Add("AAG", Color.FromArgb(68, 74, 255));
            codonColorsDict.Add("GTT", Color.FromArgb(127, 162, 127));
            codonColorsDict.Add("GTC", Color.FromArgb(127, 162, 127));
            codonColorsDict.Add("GTA", Color.FromArgb(127, 162, 127));

            codonColorsDict.Add("GTG", Color.FromArgb(127, 162, 127));
            codonColorsDict.Add("GCT", Color.LightGray);
            codonColorsDict.Add("GCC", Color.LightGray);
            codonColorsDict.Add("GCA", Color.LightGray);
            codonColorsDict.Add("GCG", Color.LightGray);
            codonColorsDict.Add("GAT", Color.DarkRed);
            codonColorsDict.Add("GAC", Color.DarkRed);
            codonColorsDict.Add("GAA", Color.Red);

            codonColorsDict.Add("GAG", Color.Red);
            codonColorsDict.Add("GGT", Color.FromArgb(235, 235, 235));
            codonColorsDict.Add("GGC", Color.FromArgb(235, 235, 235));
            codonColorsDict.Add("GGA", Color.FromArgb(235, 235, 235));
            codonColorsDict.Add("GGG", Color.FromArgb(235, 235, 235));
            codonColorsDict.Add("TGA", Color.White);
            codonColorsDict.Add("TAG", Color.White);
            codonColorsDict.Add("TAA", Color.White);
            codonColorsDict.Add("---", Color.White);


            aminoColorsDict.Add("F", Color.FromArgb(130, 130, 170));
            aminoColorsDict.Add("L", Color.Green);
            aminoColorsDict.Add("S", Color.Orange);
            aminoColorsDict.Add("Y", Color.FromArgb(82, 82, 170));
            aminoColorsDict.Add("C", Color.FromArgb(230, 230, 0));
            aminoColorsDict.Add("W", Color.PaleVioletRed);
            aminoColorsDict.Add("P", Color.FromArgb(220, 150, 130));
            aminoColorsDict.Add("H", Color.FromArgb(130, 130, 210));
            aminoColorsDict.Add("Q", Color.LightSkyBlue);
            aminoColorsDict.Add("R", Color.DodgerBlue);
            aminoColorsDict.Add("I", Color.FromArgb(95, 130, 95));
            aminoColorsDict.Add("M", Color.FromArgb(230, 225, 98));
            aminoColorsDict.Add("T", Color.DarkGoldenrod);
            aminoColorsDict.Add("N", Color.FromArgb(0, 170, 170));
            aminoColorsDict.Add("K", Color.FromArgb(68, 74, 255));
            aminoColorsDict.Add("V", Color.FromArgb(127, 162, 127));
            aminoColorsDict.Add("A", Color.LightGray);
            aminoColorsDict.Add("D", Color.DarkRed);
            aminoColorsDict.Add("E", Color.Red);
            aminoColorsDict.Add("G", Color.FromArgb(235, 235, 235));
            aminoColorsDict.Add("*", Color.White);
            aminoColorsDict.Add("-", Color.White);
        }

        private static Color getCodonColor(string codon) {
            switch (codon) {
                case "TTT": //Phe
                case "TTC":
                    return Color.FromArgb(130, 130, 170);
                case "TTA": //Leu
                case "TTG":
                case "CTT":
                case "CTC":
                case "CTA":
                case "CTG":
                    return Color.Green;
                case "TCT": //Ser
                case "TCC":
                case "TCA":
                case "TCG":
                case "AGT":
                case "AGC":
                    return Color.Orange;
                case "TAT": //Tyr
                case "TAC":
                    return Color.FromArgb(82, 82, 170);
                case "TGT": //Cys
                case "TGC":
                    return Color.Gold;
                case "TGG": //Trp
                    return Color.PaleVioletRed;
                case "CCT": //Pro
                case "CCC":
                case "CCA":
                case "CCG":
                    return Color.FromArgb(220, 150, 130);
                case "CAT": //His
                case "CAC":
                    return Color.FromArgb(130, 130, 210);
                case "CAA": //Gln
                case "CAG":
                    return Color.LightSkyBlue;
                case "CGT": //Arg
                case "CGC":
                case "CGA":
                case "CGG":
                case "AGA":
                case "AGG":
                    return Color.DodgerBlue;
                case "ATT": //Ile
                case "ATC":
                case "ATA":
                    return Color.FromArgb(95, 130, 95);
                case "ATG": //Met
                    return Color.FromArgb(230, 225, 98);
                case "ACT": //Thr
                case "ACC":
                case "ACA":
                case "ACG":
                    return Color.DarkGoldenrod;
                case "AAT": //Asn
                case "AAC":
                    return Color.FromArgb(0, 170, 170);
                case "AAA": //Lys
                case "AAG":
                    return Color.FromArgb(68, 74, 255);
                case "GTT": //Val
                case "GTC":
                case "GTA":
                case "GTG":
                    return Color.FromArgb(127, 162, 127);
                case "GCT": //Ala
                case "GCC":
                case "GCA":
                case "GCG":
                    return Color.Gray;
                case "GAT": //Asp
                case "GAC":
                    return Color.DarkRed;
                case "GAA": //Glu
                case "GAG":
                    return Color.Red;
                case "GGT": //Gly
                case "GGC":
                case "GGA":
                case "GGG":
                    return Color.FromArgb(235, 235, 235);

                default:
                    return Color.White;
            }
        }
        private void ToolTipInit() {
            toolTip1.SetToolTip(this.button_tabDNA_ReadFastaDNA, "Wczytuje do programu sekwencję DNA z pliku fasta.");
            toolTip1.SetToolTip(this.checkBox_tabDNA_SortDNAbyLength, "Jeśli zaznaczone, sekwencje DNA z pliku fasta zostaną posortowane\nod największej.");
            toolTip1.SetToolTip(this.comboBox_tabDNA_DNAlist, "Po wczytaniu sekwencji pozwala wybrać jedną aby obejrzeć jej dekodowane sekwencje aminokwasowe / białka.");
            toolTip1.SetToolTip(this.checkBox_tabDNA_realProteins, "Jeśli zaznaczone, wyszukane zostaną tylko białka od aminokwasu MET, w innym wypadku/n" +
                "sekwencje będą rozdzielone tylko kodonem STOP.");
            toolTip1.SetToolTip(this.checkBox_tabDNA_ShowAlsoDNA, "Jeśli zaznaczone, na końcu zostanie wypisana oryginalna sekwencja DNA.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_ShowAllFrames, "Pokazywane są sekwencje białkowe z trzech ramek odczytu: +0, +1 oraz +2.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_showFrame0, "Pokazuje są sekwencje białkowe z ramki +0.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_showFrame1, "Pokazuje są sekwencje białkowe z ramki +1.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_showFrame2, "Pokazuje są sekwencje białkowe z ramki +2.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_5to3, "Pokazuje sekwencje białkowe czytane według 5'->3'.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_3to5, "Pokazuje sekwencje białkowe czytane według 3'->5'.");
            toolTip1.SetToolTip(this.radioButton_tabDNA_BothDirections, "Pokazuje sekwencje białkowe czytane najpierw według 5'->3' a następnie\n" +
                "przy komplementarnej sekwencji DNA czytanej 3'->5'.");
            toolTip1.SetToolTip(this.button_tabDNA_SaveCodingDNAfile, "Zapis do pliku informacji o białkach z 1 wybranej sekwencji DNA według schematu ustalonego obok przycisku.");
            toolTip1.SetToolTip(this.button_tabDNA_ShowSaveDataWindow, "Pokazuje okno zapisu danych ze wszystkich sekwencji DNA w pliku lub w katalogach (pliki fasta).");
            toolTip1.SetToolTip(this.button_tabProt_SearchProteinsInDNAs, "Przetwarza wszystkie wczytane wcześniej sekwencje DNA na białka / sekw. aminokwasowe według\n" +
                "ustalonych poniżej opcji.");
            toolTip1.SetToolTip(this.checkBox_tabProt_startFromMET, "Jeśli zaznaczone, uwzględnione będą tylko białka od aminokwasu MET, w innym wypadku/n" +
                "sekwencje będą rozdzielane tylko kodonem STOP.");
            toolTip1.SetToolTip(this.checkBox_tabProt_onlyWithSTOP, "Jeśli zaznaczone, uwzględniowe zostaną tylko sekwencje białkowe / aminokwasowe zakończone kodonem STOP.");
            toolTip1.SetToolTip(this.numericUpDown_tabProt_minLength, "Sekwencje białkowe poniżej takie długości nie zostaną uwzględnione.");
            toolTip1.SetToolTip(this.radioButton_tabProt_only1Longest, "Tylko 1 najdłuższa sekwencja będzie wybrana z jednego DNA.");
            toolTip1.SetToolTip(this.radioButton_tabProt_allLongerThan, "Z każdego DNA może powstać kilka sekwencji białkowych o ile są dłuższe niż ustalone minimum aminokwasów.");
            toolTip1.SetToolTip(this.radioButton_tabProt_5to3, "DNA będzie czytane tylko według wzorca 5'->3'");
            toolTip1.SetToolTip(this.radioButton_tabProt_3to5, "DNA będzie czytane tylko według wzorca 3'->5'");
            toolTip1.SetToolTip(this.radioButton_tabProt_BothDirections, "DNA będzie czytane według wzorca 5'->3' oraz 3'->5'");
            toolTip1.SetToolTip(this.comboBox_tabProt_ProteinsList, "Wybór przetworzonej wcześniej sekwencji białkowej.");
            toolTip1.SetToolTip(this.checkBox_tabProt_ShowBlastData, "Zaznaczenie tej opcji spowoduje uruchomienie BlastP oraz wyświetlenie wyników dla wybranej sekwencji.");
            toolTip1.SetToolTip(this.checkBox_tabProt_ShowDNA, "Zaznaczenie tej opcji spowoduje wyświetlenie sekwencji kodującej w DNA pod sekwencją białkową.");
            toolTip1.SetToolTip(this.checkBox_tabProt_WriteAlsoDNAFile, "Zapisuje także alternatywny do pliku z białkami plik kodujących je sekwencji DNA.");
            toolTip1.SetToolTip(this.button_tabProt_SaveProteinToFile, "Zapis danych wybranego białka do pliku.");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
            //toolTip1.SetToolTip(this.button1, "");
        }

    }
}
