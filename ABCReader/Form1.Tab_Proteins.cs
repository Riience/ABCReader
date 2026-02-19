using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {
        static bool freeze_DGVProtsCompareBig = false;
        static bool freeze_DGVProtsCompareSmall = false;
        string currentClickedDNAseq = "";
        string currentClickedDNAprotID = "";
        string currentClickedProtseq = "";


        /// <summary>
        /// Inicjalizacja tablicy danych białkowych (porównywanie).
        /// </summary>
        private void InitDataGrid_tabProtCompareTableBig() { //duża tabela podobieństwa
            dataTable_ProteinCompareBig = new DataTable();
            bindingSource_ProteinCompareBig = new BindingSource();
            bindingSource_ProteinCompareBig.DataSource = dataTable_ProteinCompareBig;
            DGV_ProtsComp_Big.DataSource = bindingSource_ProteinCompareBig;
            dataTable_ProteinCompareBig.Columns.Add(new DataColumn("SequenceID", typeof(string)));
            dataTable_ProteinCompareBig.Columns.Add(new DataColumn("N size:", typeof(int)));
            dataTable_ProteinCompareBig.Columns.Add(new DataColumn("P size:", typeof(int)));
            dataTable_ProteinCompareBig.Columns.Add(new DataColumn("HistAvg", typeof(double)));
            DGV_ProtsComp_Big.Columns[0].Width = 300;
            DGV_ProtsComp_Big.Columns[1].Width = 70;
            DGV_ProtsComp_Big.Columns[2].Width = 70;
            DGV_ProtsComp_Big.Columns[3].Width = 80;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N4";
            this.DGV_ProtsComp_Big.Columns[3].DefaultCellStyle = style;
        }

        private void InitDataGrid_tabProp_CompareTableSmall() { //mała tabela podobieństwa
            dataTable_ProteinCompareSmall = new DataTable();
            bindingSource_ProteinCompareSmall = new BindingSource();
            bindingSource_ProteinCompareSmall.DataSource = dataTable_ProteinCompareSmall;
            DGV_ProtsComp_Small.DataSource = bindingSource_ProteinCompareSmall;
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("SequenceID", typeof(string)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Cz-value", typeof(double)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("BlastN", typeof(double)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("N size:", typeof(int)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("P size:", typeof(int)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("DNA", typeof(string)));
            dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Prot", typeof(string)));
            DGV_ProtsComp_Small.Columns[0].Width = 300;
            DGV_ProtsComp_Small.Columns[1].Width = 80;
            DGV_ProtsComp_Small.Columns[2].Width = 80;
            DGV_ProtsComp_Small.Columns[3].Width = 50;
            DGV_ProtsComp_Small.Columns[4].Width = 50;
            DGV_ProtsComp_Small.Columns[5].Width = 200;
            DGV_ProtsComp_Small.Columns[6].Width = 200;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N4";
            this.DGV_ProtsComp_Small.Columns[1].DefaultCellStyle = style;
            this.DGV_ProtsComp_Small.Columns[2].DefaultCellStyle = style;
        }

        /// <summary>
        /// Główna metoda szukająca białek z sekwencji DNA wczytanych wcześniej.
        /// </summary>
        private void ScanFromProteinsFromDNAsequences() {
            if (dataDNAread) {
                resetTab2Data();
                resetTab3Data();
                resetTab4_TransX_Data();

                bool onlyProteins = checkBox_tabProt_startFromMET.Checked;
                bool onlyWithSTOPcodon = checkBox_tabProt_onlyWithSTOP.Checked;
                int minSize = Convert.ToInt32(numericUpDown_tabProt_minLength.Value);
                bool onlyLongestSeq = false;
                bool allWithMinSize = true;
                if (radioButton_tabProt_only1Longest.Checked) {
                    onlyLongestSeq = true;
                    allWithMinSize = false;
                }
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = mainDB_DNAsequences.Count;
                toolStripProgressBar1.Value = 0;

                int order = 1; //5'->3'
                if (radioButton_tabProt_3to5.Checked)
                    order = -1;
                else if (radioButton_tabProt_BothDirections.Checked)
                    order = 0;



                mainDB_ProtSequences = abcEngine.getAllProteinsFromDNA(mainDB_DNAsequences, onlyProteins, onlyWithSTOPcodon, onlyLongestSeq,
                    allWithMinSize, minSize, order, toolStripProgressBar1, true);

                if (mainDB_ProtSequences.Keys.Count == 0)
                    return;

                // !!!!! main secondary data structures:
                foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                    bool kierunek = entry.Value._5to3;
                    if (kierunek == true) {
                        string dna = entry.Value.DNAsequence;
                        entry.Value.lvl2_DNAcodingSequence = dna.Substring(entry.Value.startingNucleotide - 1, entry.Value.peptideSeqLength * 3);
                    } else {
                        string dna = Ribosome.GetComplementaryDNA(entry.Value.DNAsequence, true);
                        entry.Value.lvl2_DNAcodingSequence = dna.Substring(entry.Value.startingNucleotide - 1, entry.Value.peptideSeqLength * 3);
                    }

                    entry.Value.lvl2_proteinID = entry.Key; //nadaj trwałe ID białkom
                }

                comboBox_tabProt_ProteinsList.Items.Clear();
                int counter = 0;
                comboProteinOffline = true;
                foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                    comboBox_tabProt_ProteinsList.Items.Add(entry.Key);
                    counter++;
                }
                comboProteinOffline = false;
                dataProteinRead = true;

                groupBox_tabProt_proteinViewer.Text = "Lista sekwencji białkowych:" + counter;
            }
        }

        /// <summary>
        /// Usuwanie duplikatów sekwencji oraz mniejszych zawierających się w dłuższych.
        /// </summary>
        private void RemoveSameSequences() {
            if (mainDB_ProtSequences == null)
                return;
            if (mainDB_ProtSequences.Count == 0)
                return;

            List<string> duplikaty = new List<string>();

            //Dictionary<string, ProteinFromDNA> nowySlownik = new Dictionary<string, ProteinFromDNA>();

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = mainDB_ProtSequences.Count;

            List<string> removeKeys = new List<string>();
            foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                toolStripProgressBar1.Value++;
                string ID = entry.Key;
                string DNA = "";

                if (radioButton3.Checked)
                    DNA = entry.Value.lvl2_DNAcodingSequence;
                else
                    DNA = entry.Value.DNAsequence;

                //if(ID.Equals(">VMXJ-2007174_PROT_53_orf0_size1503_start1051_#12")) {
                 //   int x1 = 1;
                //}

                bool cancel = false;
                foreach (string dup in removeKeys) {
                    if (ID.Equals(dup)) { //nie uwzględniaj tych które są do odrzucenia
                        cancel = true;
                        break;
                    }
                }
                if (cancel) { //nie uwzględniaj tych które są do odrzucenia
                    continue;
                }

                foreach (KeyValuePair<string, ProteinFromDNA> entry2 in mainDB_ProtSequences) {
                    string ID2 = entry2.Key;
                   // if(ID2.Equals(">VMXJ-2007173_PROT_53_orf0_size1503_start463_#47") ||
                     //   ID2.Equals(">VMXJ-2007175_PROT_53_orf2_size1503_start300_#67")) {
                       // int x2 = 2;
                    //}

                    if (ID.Equals(ID2))
                        continue;

                    string secondDNA = "";
                    if (radioButton3.Checked)
                        secondDNA = entry2.Value.lvl2_DNAcodingSequence;
                    else
                        secondDNA = entry2.Value.DNAsequence;

                    if (DNA.Contains(secondDNA)) {
                        duplikaty.Add("Removed: "+ID2 + " (exists in " + ID+")");
                        removeKeys.Add(ID2);
                    }
                }
            }

            if (duplikaty.Count == 0)
                return;

            AddLogLineEnter(" ******* Raport usuwania sekwencji ******* ", LogType.NORMAL);
            foreach (string s in duplikaty) {
                AddLogLineEnter(s, LogType.NORMAL);
            }
            label_tabProt_LastRemovedNumber.Text = "Ostatnio usuniętych: "+ duplikaty.Count;

            foreach (string remID in removeKeys) {
                mainDB_ProtSequences.Remove(remID);
                comboBox_tabProt_ProteinsList.Items.Remove(remID);
            }

            resetTab2TablesData(); //reset tabeli porównywania
            richTextBox_tabProts_protView1.Clear();
            richTextBox_tabProts_proteinBlastView.Clear();
            comboBox_tabProt_ProteinsList.Items.Clear();
            comboProteinOffline = true;
            foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                comboBox_tabProt_ProteinsList.Items.Add(entry.Key);
            }
            groupBox_tabProt_proteinViewer.Text = "Lista sekwencji białkowych: " + mainDB_ProtSequences.Count();
            comboProteinOffline = false;
        }


        /// <summary>
        /// Obsługa zmiany aktywnego wiersza w tabeli białek (tab02). Metoda wyszukuje podobne sekwencje.
        /// </summary>
        private void dataGridView_Prots_SelectionResponse() {
            if (mainDB_ProtSequences == null)
                return;

            if (DGV_ProtsComp_Big.CurrentCell == null)
                return;

            int row = DGV_ProtsComp_Big.CurrentCell.RowIndex;
            int col = DGV_ProtsComp_Big.CurrentCell.ColumnIndex;

            if (row > -1) {
                string sId = DGV_ProtsComp_Big.Rows[row].Cells[0].Value.ToString();
                ProteinFromDNA protEntry;
                if (!mainDB_ProtSequences.TryGetValue(sId, out protEntry)) {
                    return;
                }

                chart_tabProt_1.ChartAreas[0].AxisX.LineWidth = 6;
                chart_tabProt_1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                chart_tabProt_1.Series[0].Points.Clear();
                chart_tabProt_1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                chart_tabProt_1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                for (int i = 0; i < 64; i++) {
                    chart_tabProt_1.Series[0].Points.AddXY(Ribosome.COD_SORTED[i], protEntry.lvl2_mainHistogram[i]);
                }

                dataTable_ProteinCompareSmall.Clear();
                freeze_DGVProtsCompareSmall = true; //nie da się skutecznie klikać po małej tabeli
                //miara podobieństwa
                int minCzValue = Convert.ToInt32(numericUpDown_tabProt_minCzValue.Value);
                try {
                    List<Tuple<double, string[]>> similarCandidatesList = new List<Tuple<double, string[]>>();

                    foreach (KeyValuePair<string, ProteinFromDNA> scanEntry in mainDB_ProtSequences) {
                        if (protEntry.Equals(scanEntry.Value))
                            continue;

                        double value = DNAtools.GetCzekanowskiValue(protEntry.lvl2_mainHistogram, scanEntry.Value.lvl2_mainHistogram);
                        value = (value / 30.5) * 100.0;
                        if (value > minCzValue) {
                            string[] something = new string[] { scanEntry.Value.lvl2_proteinID, scanEntry.Value.lvl2_DNAcodingSequence };
                            similarCandidatesList.Add(new Tuple<double, string[]>(value, something));
                        }
                    }

                    similarCandidatesList.Sort((x, y) => y.Item1.CompareTo(x.Item1)); //sortuj od największego podobieństwa
                    richTextBox_tabProt_SimiliarInfo.Clear();
                    richTextBox_tabProt_SimiliarInfo.Font = new Font(FontFamily.GenericMonospace, 8);
                    richTextBox_tabProt_SimiliarInfo.AppendText("Similar sequences: " + similarCandidatesList.Count + Environment.NewLine);
                    richTextBox_tabProt_SimiliarInfo.AppendText(protEntry.lvl2_proteinID);

                    if(ignoredSequences_tabProt.Contains(protEntry.lvl2_proteinID)) {
                        Color oldColor = richTextBox_tabProt_SimiliarInfo.SelectionColor;
                        Font oldFont = richTextBox_tabProt_SimiliarInfo.SelectionFont;

                        richTextBox_tabProt_SimiliarInfo.SelectionColor = Color.Red;
                        richTextBox_tabProt_SimiliarInfo.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Bold);
                        richTextBox_tabProt_SimiliarInfo.AppendText("    (sekwencja oznaczona jako ignorowana)"+Environment.NewLine);
                        richTextBox_tabProt_SimiliarInfo.SelectionColor = oldColor;
                        richTextBox_tabProt_SimiliarInfo.SelectionFont = oldFont;
                    }
                    


                    richTextBox_tabProt_SimiliarInfo.AppendText(Environment.NewLine);
                    richTextBox_tabProt_SimiliarInfo.AppendText(protEntry.lvl2_DNAcodingSequence + Environment.NewLine);
                    richTextBox_tabProt_SimiliarInfo.AppendText(Environment.NewLine);
                    richTextBox_tabProt_SimiliarInfo.AppendText(protEntry.peptideSequence + Environment.NewLine);

                    currentClickedDNAseq = protEntry.lvl2_DNAcodingSequence;
                    currentClickedDNAprotID = protEntry.lvl2_proteinID;
                    currentClickedProtseq = protEntry.peptideSequence;

                    toolStripProgressBar1.Value = 0;
                    toolStripProgressBar1.Maximum = similarCandidatesList.Count;

                    List<CompareDGrivResults> wyniki = new List<CompareDGrivResults>();
                    foreach (Tuple<double, string[]> tuple in similarCandidatesList) {
                        toolStripProgressBar1.Value++;

                        ProteinFromDNA similarOne;
                        if (!mainDB_ProtSequences.TryGetValue(tuple.Item2[0], out similarOne)) {
                            continue;
                        }

                        string refDNA = protEntry.lvl2_DNAcodingSequence;
                        string similarDNA = similarOne.lvl2_DNAcodingSequence;

                        double similarityNW = -1;
                        if (!freeze_DGVProtsCompareBig) {
                            similarityNW = blastEngine.EvaluateBlastNident(refDNA, similarDNA);
                        }
                        Application.DoEvents();
                        CompareDGrivResults wynik = new CompareDGrivResults();
                        wynik.L1seq = similarOne.lvl2_proteinID;
                        wynik.L2czVal = tuple.Item1;
                        wynik.L3NWval = similarityNW;
                        wynik.L4Nsize = similarOne.lvl2_DNAcodingSequenceSize;
                        wynik.L5Psize = similarOne.peptideSeqLength;
                        wynik.L6dna = similarOne.lvl2_DNAcodingSequence;
                        wynik.L7prot = similarOne.peptideSequence;
                        wyniki.Add(wynik);

                        //dataTable_ProteinCompareSmall.Rows.Add(similarOne.lvl2_protID, tuple.Item1, similarityNW, similarOne.lvl2_codingSeqSize,
                        //similarOne.aminoSize, similarOne.lvl1_codingSequence, similarOne.aminoSequence);
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("SequenceID", typeof(string)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Cz-value", typeof(double)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("N-W ident", typeof(double)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("N size:", typeof(int)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("P size:", typeof(int)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("DNA", typeof(string)));
                        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Prot", typeof(string)));
                    }

                    foreach(CompareDGrivResults wynik in wyniki) {
                        dataTable_ProteinCompareSmall.Rows.Add(wynik.L1seq, wynik.L2czVal, wynik.L3NWval, wynik.L4Nsize,
                            wynik.L5Psize, wynik.L6dna, wynik.L7prot);
                    }
                } catch (Exception e) {
                    AddLogLineEnter("Błąd przetwarzania danych.", Form1.LogType.ERROR);
                    AddLogLineEnter("Kod błędu: " + e.Message, Form1.LogType.ERROR);
                }
            }
            freeze_DGVProtsCompareSmall = false;
        }

        /// <summary>
        /// Wysyłanie danych sekwencji białkowej wybranej z lewego dużego DGV oraz podobnej doń z małego po prawej DGV do logu.
        /// </summary>
        public void SendDataToLog() {
            textBox_tabOther_Seq1.Text = currentClickedDNAseq;
            richTextBox_tabLog.Clear();
            if (DGV_ProtsComp_Small.CurrentCell == null)
                return;

            int row = DGV_ProtsComp_Small.CurrentCell.RowIndex;
            if(row>-1) {
                string comparedDNAseq = DGV_ProtsComp_Small.Rows[row].Cells[5].Value.ToString();
                textBox_tabOther_Seq2.Text = comparedDNAseq;
            }
        }

        /// <summary>
        /// Wypełnia prawy DGV danymi o sekwencjach białkowych.
        /// </summary>
        private void SearchRepeatedSimilarSequences() {
            if (mainDB_ProtSequences == null)
                return;

            dataTable_ProteinCompareBig.Clear();
            foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                string DNAseq = entry.Value.DNAsequence;

                //string codingSequence = DNAseq.Substring(entry.Value.startingNucleotide-1, entry.Value.lvl2_codingSeqSize);
                entry.Value.lvl2_mainHistogram = DNAtools.GetSeqHistogram(entry.Value.lvl2_DNAcodingSequence);
                entry.Value.lvl2_avgHistValue = DNAtools.GetHistAvg(entry.Value.lvl2_mainHistogram);
                dataTable_ProteinCompareBig.Rows.Add(entry.Key, entry.Value.lvl2_DNAcodingSequenceSize, entry.Value.peptideSeqLength, entry.Value.lvl2_avgHistValue);
            }
        }

        /// <summary>
        /// Wyświetlanie danych o białku w zakładce II : w lewym i prawym podoknie.
        /// </summary>
        /// <param name="protID">Identyfikator sekwencji.</param>
        /// <param name="proteinFromDNA">Sekwencja DNA.</param>
        private void showProteinDataOnTab02(string protID, ProteinFromDNA proteinFromDNA) {
            //RICHTEXTBOX2 (left, protein textbox)
            richTextBox_tabProts_protView1.Clear();
            richTextBox_tabProts_protView1.Font = new Font(FontFamily.GenericMonospace, 8);
            richTextBox_tabProts_protView1.SelectionColor = Color.Black;
            if (checkBox_tabProt_startFromMET.Checked) {
                richTextBox_tabProts_protView1.AppendText("Sekwencja białkowa od Met do STOP" + Environment.NewLine);
            } else {
                richTextBox_tabProts_protView1.AppendText("Sekwencja aminokwasowa rodzialana kodonem STOP" + Environment.NewLine);
            }
            richTextBox_tabProts_protView1.AppendText(Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText("Długość sekwencji: " + proteinFromDNA.peptideSeqLength + Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText("Pozycja pierwszego kodonu: " + proteinFromDNA.startingNucleotide + Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText("Start kodon (MET): " + proteinFromDNA.codonStart.ToString() + Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText("Stop kodon: " + proteinFromDNA.codonStop.ToString() + Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText("" + protID + Environment.NewLine);
            richTextBox_tabProts_protView1.AppendText(Environment.NewLine);
            tab02_AddColorPeptide_TextBoxLeft(proteinFromDNA);

            if (checkBox_tabProt_ShowDNA.Checked) {
                richTextBox_tabProts_protView1.AppendText(Environment.NewLine);
                richTextBox_tabProts_protView1.AppendText("Sekwencja kodująca DNA:" + Environment.NewLine);
                richTextBox_tabProts_protView1.AppendText("" + protID + Environment.NewLine);
                tab02_AddColorDNA_TextBoxRight(proteinFromDNA);
            }
            //RICHTEXTBOX3 (right, DNA textbox)

            richTextBox_tabProts_proteinBlastView.Clear();
            richTextBox_tabProts_proteinBlastView.Font = new Font(FontFamily.GenericMonospace, 8);
            richTextBox_tabProts_proteinBlastView.SelectionColor = Color.Black;
            int howMany = Convert.ToInt32(numericUpDown_tabProts_MaxHitsForBlastP.Value);

            List<BlastData> lista = null;
            if (checkBox2Convert.Checked)
                lista = blastEngine.GetVector(proteinFromDNA, protID, howMany, 1, "DB_all.fasta", true);
            else
                lista = blastEngine.GetVector(proteinFromDNA, protID, howMany, 1, "DB_all.fasta", false);
            PrintBlastTable(richTextBox_tabProts_proteinBlastView, lista);
        }

        /// <summary>
        /// Wyświetla wybraną sekwencję DNA dla białka.
        /// </summary>
        /// <param name="proteinFromDNA">Obiekt białka / sekwencji aminokwasowej (DNA w obiekcie).</param>
        private void tab02_AddColorDNA_TextBoxRight(ProteinFromDNA proteinFromDNA) {
            Color oldBackground = richTextBox_tabProts_protView1.SelectionBackColor;
            Color oldFontColor = richTextBox_tabProts_protView1.SelectionColor;
            Font selectionFont = richTextBox_tabProts_protView1.SelectionFont;

            string DNA = proteinFromDNA.DNAsequence;
            if (proteinFromDNA._5to3 == false) {
                DNA = Ribosome.GetComplementaryDNA(DNA, true);
            }
            char[] seqTmp = DNA.ToCharArray();
            //string space = " ";
            int start = proteinFromDNA.startingNucleotide - 1;
            int stop = start + (proteinFromDNA.peptideSeqLength * 3) - 3;

            for (int i = 0; i < seqTmp.Length; i++) {
                if (i == start) {
                    richTextBox_tabProts_protView1.SelectionColor = Color.Red;
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Bold);
                    richTextBox_tabProts_protView1.AppendText("" + seqTmp[i]);
                } else if (i == stop - 1) {
                    richTextBox_tabProts_protView1.AppendText("" + seqTmp[i]);
                    richTextBox_tabProts_protView1.SelectionColor = oldFontColor;
                    //jeszcze boldem powyższe
                    if (i + 3 < seqTmp.Length) {
                        richTextBox_tabProts_protView1.AppendText("" + seqTmp[i + 1] + seqTmp[i + 2] + seqTmp[i + 3]);
                        i += 3;
                    }
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Regular);
                } else {
                    richTextBox_tabProts_protView1.AppendText("" + seqTmp[i]);
                }
            }
        }

        /// <summary>
        /// Wyświetla wybrane białko z listy.
        /// </summary>
        /// <param name="protein">Obiekt białka lub sekwencji aminokwasowej.</param>
        private void tab02_AddColorPeptide_TextBoxLeft(ProteinFromDNA protein) {
            Color background = richTextBox_tabProts_protView1.SelectionBackColor;
            Color selectionColor = richTextBox_tabProts_protView1.SelectionColor;
            Font selectionFont = richTextBox_tabProts_protView1.SelectionFont;

            char[] seqTmp = protein.peptideSequence.ToCharArray();
            string space = "";
            for (int i = 0; i < seqTmp.Length; i++) {
                string sign = "" + seqTmp[i];
                if (seqTmp[i] == 'M') {
                    richTextBox_tabProts_protView1.SelectionColor = Color.Red;
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Bold);
                    richTextBox_tabProts_protView1.AppendText(sign + space);
                    richTextBox_tabProts_protView1.SelectionColor = selectionColor;
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Regular);
                    continue;
                } else if (seqTmp[i] == '*') {
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Bold);
                    richTextBox_tabProts_protView1.AppendText("*" + space);
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Regular);
                    continue;
                } else if (seqTmp[i] == 'X') {
                    richTextBox_tabProts_protView1.SelectionBackColor = Color.Green;
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Bold);
                    richTextBox_tabProts_protView1.AppendText(sign + space);
                    richTextBox_tabProts_protView1.SelectionBackColor = background;
                    richTextBox_tabProts_protView1.SelectionFont = new Font(richTextBox_tabProts_protView1.Font, FontStyle.Regular);
                    continue;
                }
                richTextBox_tabProts_protView1.AppendText(sign + space);

            }
            richTextBox_tabProts_protView1.AppendText(Environment.NewLine);
            richTextBox_tabProts_protView1.SelectionBackColor = background;
            richTextBox_tabProts_protView1.SelectionFont = selectionFont;
        }

        /// <summary>
        /// Pokazuje histogram aminokwasów sekwencji białkowej.
        /// </summary>
        private void showProteinDataOnComboBoxSelection() {
            if (comboProteinOffline == false && dataProteinRead == true) {
                int selected = comboBox_tabProt_ProteinsList.SelectedIndex;
                if (selected < 0)
                    return;

                string seqID = comboBox_tabProt_ProteinsList.Items[selected].ToString();
                ProteinFromDNA entry = null;
                mainDB_ProtSequences.TryGetValue(seqID, out entry);

                if (entry == null)
                    return;

                showProteinDataOnTab02(seqID, entry);
                //showProteinDataOnTab02(daneBialek.Keys.ToArray()[selected], daneBialek.Values.ToArray()[selected]);

                int[] histo = abcEngine.GetAminoNumbers(mainDB_ProtSequences.Values.ToArray()[selected]);

                chart_tabProt_1.ChartAreas[0].AxisX.LineWidth = 6;
                chart_tabProt_1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                chart_tabProt_1.Series[0].Points.Clear();

                chart_tabProt_1.Series[0].Points.AddXY("A", histo[0]);
                chart_tabProt_1.Series[0].Points.AddXY("C", histo[1]);
                chart_tabProt_1.Series[0].Points.AddXY("D", histo[2]);
                chart_tabProt_1.Series[0].Points.AddXY("E", histo[3]);
                chart_tabProt_1.Series[0].Points.AddXY("F", histo[4]);

                chart_tabProt_1.Series[0].Points.AddXY("G", histo[5]);
                chart_tabProt_1.Series[0].Points.AddXY("H", histo[6]);
                chart_tabProt_1.Series[0].Points.AddXY("I", histo[7]);
                chart_tabProt_1.Series[0].Points.AddXY("K", histo[8]);
                chart_tabProt_1.Series[0].Points.AddXY("L", histo[9]);

                chart_tabProt_1.Series[0].Points.AddXY("M", histo[10]);
                chart_tabProt_1.Series[0].Points.AddXY("N", histo[11]);
                chart_tabProt_1.Series[0].Points.AddXY("P", histo[12]);
                chart_tabProt_1.Series[0].Points.AddXY("Q", histo[13]);
                chart_tabProt_1.Series[0].Points.AddXY("R", histo[14]);

                chart_tabProt_1.Series[0].Points.AddXY("S", histo[15]);
                chart_tabProt_1.Series[0].Points.AddXY("T", histo[16]);
                chart_tabProt_1.Series[0].Points.AddXY("W", histo[17]);
                chart_tabProt_1.Series[0].Points.AddXY("Y", histo[18]);
                chart_tabProt_1.Series[0].Points.AddXY("V", histo[19]);

                chart_tabProt_1.Series[0].Points.AddXY("X", histo[22]);
            }
        }
    }

    public class CompareDGrivResults {
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("SequenceID", typeof(string)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Cz-value", typeof(double)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("N-W ident", typeof(double)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("N size:", typeof(int)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("P size:", typeof(int)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("DNA", typeof(string)));
        //dataTable_ProteinCompareSmall.Columns.Add(new DataColumn("Prot", typeof(string)));
        public string L1seq;
        public double L2czVal;
        public double L3NWval;
        public int L4Nsize;
        public int L5Psize;
        public string L6dna;
        public string L7prot;
    }
}
