using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ABCReader {
    public partial class Form1 : Form {
        ConfigData configuration = new ConfigData();
        private bool debugMode = true; //TODO: DEBUG
        public enum LogType { ERROR, MONIT, NORMAL };
        public static Form1 guiManager = null;

        public DataTable dataTable_ProteinCompareBig = null;
        BindingSource bindingSource_ProteinCompareBig = null;
        public DataTable dataTable_ProteinCompareSmall = null;
        BindingSource bindingSource_ProteinCompareSmall = null;
        List<string> ignoredSequences_tabProt = null;

        public DataTable dataTable_TX_Main = null;
        BindingSource bindingSource_TX_Main = null;
        public DataTable dataTable_TX_Ignored = null;
        BindingSource bindingSource_TX_Rejected = null;

        private SaveDataForm saveForm = null;
        public bool dataDNAread = false;
        public bool dataProteinRead = false;
        public bool comboDNAOffline = false;
        public bool comboProteinOffline = false;
        public Dictionary<string, string> mainDB_DNAsequences = null;
        public Dictionary<string, ProteinFromDNA> mainDB_ProtSequences = null;
        private static Engine abcEngine = new Engine();
        private static BlastEngine blastEngine = new BlastEngine(abcEngine);

        static string currentDir = Environment.CurrentDirectory;

        public static SortedDictionary<string, Color> codonColorsDict = new SortedDictionary<string, Color>();
        public static SortedDictionary<string, Color> aminoColorsDict = new SortedDictionary<string, Color>();//kolorowanie kodonów
        public Form1() {
            guiManager = this;
            InitializeComponent();
            BuildSortDictionary(); //kolorowanie kodonów
            comboBox_tabBlastP_BlastDBname.SelectedIndex = 0;
            comboBox_tabTX_alignMethod.SelectedIndex = 0;
            comboBox_tabTX_comboSelectAlignForShowAll.SelectedIndex = 0;
            splitContainer_tabBlast.SplitterDistance = 700;
            richTextBox_tabLog.Font = new Font(FontFamily.GenericMonospace, 10);
            richTextBox_tabNotepad_Left.Font = new Font(FontFamily.GenericMonospace, 8);
            richTextBox_tabNotepad_Right.Font = new Font(FontFamily.GenericMonospace, 8);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, 8);

            tabControl_tabProtsBottom.SelectedTab = tabPage_22;

            foreach (TabPage page in tabControl1.TabPages) {
                SetTabHeader(page, SystemColors.Window);
            }
            if (saveForm == null) {
                saveForm = new SaveDataForm(abcEngine, currentDir, this);
            }

            ToolTipInit();
            InitDataGrid_BlastResults();
            InitDataGrid_referenceSequencesDB();
            InitDataGrid_tabProtCompareTableBig();
            InitDataGrid_tabProp_CompareTableSmall();
            InitDataGrid_tabTX();

            ignoredSequences_tabProt = new List<string>();

            if (debugMode) {
                numericUpDown_tabProt_minLength.Value = 1000;
            }

            loadConfig();
            initConfig();
        }



        /* *********************** *********************** ***********************
         * *********************** *****  TAB2: DNA   **** ***********************
         * *********************** *********************** ***********************/


        private void button_tabDNA_ReadFastaDNA_Click(object sender, EventArgs e) {
            LoadDNAsequencesToProgram();
        }

        private void button_tabDNA_SaveCodingDNAfile_Click(object sender, EventArgs e) {
            int selected = -1;
            if (comboDNAOffline == false && dataDNAread == true) {
                selected = comboBox_tabDNA_DNAlist.SelectedIndex;
                if (selected < 0)
                    return;
            }
            SaveSingleDecodedProtein(selected);
        }

        private void button_tabDNA_ShowSaveDataWindow_Click(object sender, EventArgs e) {
            saveForm.StartPosition = FormStartPosition.Manual;
            saveForm.Location = new Point(this.Location.X + 400, this.Location.Y + 200);
            saveForm.ShowDialog();
        }

        private void comboBox_tabDNA_DNAlist_SelectedIndexChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void checkBox_tabDNA_realProteins_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_ShowAllFrames_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_showFrame0_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_showFrame2_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_showFrame1_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_5to3_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_3to5_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }

        private void radioButton_tabDNA_BothDirections_CheckedChanged(object sender, EventArgs e) {
            showDNAdataOnComboBoxSelection();
        }



        /* *********************** *********************** ***********************
         * *********************** ***  TAB2: PROTEINS  ** ***********************
         * *********************** *********************** ***********************/



        private void button_tabProt_SearchProteinsInDNAs_Click(object sender, EventArgs e) {
            ScanFromProteinsFromDNAsequences();
        }

        private void button_tabProt_SaveProteinToFile_Click(object sender, EventArgs e) {
            if (dataProteinRead == false) {
                return;
            }
            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            updateGloballyCurrentDir(getDirectoryFromPath(fileName));

            abcEngine.SaveProteinsToFile(fileName, mainDB_ProtSequences, checkBox_tabProt_WriteAlsoDNAFile.Checked);
        }

        private void button_tabProt_SaveXML_Click(object sender, EventArgs e) {
            string fileName = Tools.saveDialog(currentDir, "XML files (*.xml)|*.xml|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            updateGloballyCurrentDir(getDirectoryFromPath(fileName));
            abcEngine.SaveXMLproteins(fileName, mainDB_ProtSequences, ignoredSequences_tabProt);
        }

        private void button_tabProt_LoadXML_Click(object sender, EventArgs e) {
            string fileName = Tools.loadDialog(currentDir, "XML files (*.xml)|*.xml|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            updateGloballyCurrentDir(getDirectoryFromPath(fileName));
            List<string> ignoredSequences_tabNew = null;
            Dictionary<string, ProteinFromDNA> nowySlownik = abcEngine.LoadXMLproteins(fileName, out ignoredSequences_tabNew);
            if (nowySlownik != null) {
                resetProgramForNewData(nowySlownik);
            }

            ignoredSequences_tabProt = ignoredSequences_tabNew;

            freeze_DGVProtsCompareBig = true;
            SearchRepeatedSimilarSequences();
            freeze_DGVProtsCompareBig = false;
        }

        private void button_tabProt_ReScanProteins_Click(object sender, EventArgs e) {
            freeze_DGVProtsCompareBig = true;
            SearchRepeatedSimilarSequences();
            freeze_DGVProtsCompareBig = false;
        }

        private void button_tabProt_removeDuplicates_Click(object sender, EventArgs e) {
            RemoveSameSequences();
        }

        private void comboBox_tabProt_ProteinsList_SelectedIndexChanged(object sender, EventArgs e) {
            showProteinDataOnComboBoxSelection();
        }

        private void radioButton_tabProts_comboUnsort_CheckedChanged(object sender, EventArgs e) {
            if (radioButton_tabProts_comboUnsort.Checked) {

                comboProteinOffline = true;
                comboBox_tabProt_ProteinsList.Items.Clear();
                comboBox_tabProt_ProteinsList.Sorted = false;
                foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                    comboBox_tabProt_ProteinsList.Items.Add(entry.Key);
                }
                comboProteinOffline = false;

            } else if (radioButton_tabProts_comboSortAlfa.Checked) {
                comboProteinOffline = true;
                comboBox_tabProt_ProteinsList.Sorted = true;
                comboProteinOffline = false;
            }
        }

        bool tokenBlockade = false;
        private void DGV_ProtsComp_Big_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (freeze_DGVProtsCompareBig)
                return;

            if (tokenBlockade == false) {
                tokenBlockade = true;
                dataGridView_Prots_SelectionResponse();
                tokenBlockade = false;
            }

        }

        private void DGV_ProtsComp_Big_MouseClick(object sender, MouseEventArgs e) {
            if (freeze_DGVProtsCompareBig)
                return;

            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right) {
                hitTestInfo = DGV_ProtsComp_Big.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    contextMenu_DGV_BigComp.Show(DGV_ProtsComp_Big, new Point(e.X, e.Y));

            }
        }

        private void DGV_ProtsComp_Big_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            try {
                var x = DGV_ProtsComp_Big.Rows[e.RowIndex].Cells[0].Value;
                if (x == null)
                    return;
                string ID = x.ToString();

                if (ignoredSequences_tabProt.Contains(ID)) {
                    DGV_ProtsComp_Big.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                    //dataGridView_ProtCompareBig.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            } catch (Exception) {

            }
        }

        private void DGV_ProtsComp_Big_SelectionChanged(object sender, EventArgs e) {
            if (freeze_DGVProtsCompareBig)
                return;

            if (tokenBlockade == false) {
                tokenBlockade = true;
                dataGridView_Prots_SelectionResponse();
                tokenBlockade = false;
            }
        }

        private void DGV_ProtsComp_Big_Sorted(object sender, EventArgs e) {
            freeze_DGVProtsCompareBig = false;
        }

        /// <summary>
        ///  Menu kontekstowe tabeli porównawczej - wysyłanie DNA do porównania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_PCSmall_CompDNA_Click(object sender, EventArgs e) {
            try {
                textBox_tabOther_Seq1.Text = currentClickedDNAseq;
                richTextBox_tabNotepad_Left.Clear();
                if (DGV_ProtsComp_Small.CurrentCell == null)
                    return;

                int row = DGV_ProtsComp_Small.CurrentCell.RowIndex;
                if (row > -1) {
                    string comparedDNAseq = DGV_ProtsComp_Small.Rows[row].Cells[5].Value.ToString();
                    textBox_tabOther_Seq2.Text = comparedDNAseq;
                }

                richTextBox_tabNotepad_Left.AppendText("Pierwsza sekwencja: " + currentClickedDNAprotID + Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText("Druga sekwencja: " + DGV_ProtsComp_Small.Rows[row].Cells[0].Value.ToString() + Environment.NewLine);

                Alignment();
            } catch (Exception) {

            }
        }

        /// <summary>
        ///  Menu kontekstowe tabeli porównawczej - wysyłanie białek do porównania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_PCSmall_CompProtSeq_Click(object sender, EventArgs e) {
            try {
                textBox_tabOther_Seq1.Text = currentClickedProtseq;
                richTextBox_tabNotepad_Left.Clear();
                if (DGV_ProtsComp_Small.CurrentCell == null)
                    return;

                int row = DGV_ProtsComp_Small.CurrentCell.RowIndex;
                if (row > -1) {
                    string comparedProtSeq = DGV_ProtsComp_Small.Rows[row].Cells[6].Value.ToString();
                    textBox_tabOther_Seq2.Text = comparedProtSeq;
                }
                richTextBox_tabNotepad_Left.AppendText("Pierwsza sekwencja: " + currentClickedDNAprotID + Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText("Druga sekwencja: " + DGV_ProtsComp_Small.Rows[row].Cells[0].Value.ToString() + Environment.NewLine);

                Alignment();
            } catch (Exception) {

            }
        }

        /// <summary>
        /// Menu kontekstowe tabeli porównawczej - wysyłanie DNA i białka do porównania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_PCSmall_CompDNAandProtSeqs_Click(object sender, EventArgs e) {
            string DNA1backup = "";
            string DNA2backup = "";
            try { //DNA:
                textBox_tabOther_Seq1.Text = currentClickedDNAseq;
                DNA1backup = currentClickedDNAseq;
                richTextBox_tabNotepad_Left.Clear();
                if (DGV_ProtsComp_Small.CurrentCell == null)
                    return;

                int row = DGV_ProtsComp_Small.CurrentCell.RowIndex;
                if (row > -1) {
                    string comparedDNAseq = DGV_ProtsComp_Small.Rows[row].Cells[5].Value.ToString();
                    textBox_tabOther_Seq2.Text = comparedDNAseq;
                    DNA2backup = comparedDNAseq;
                }

                richTextBox_tabNotepad_Left.AppendText("Pierwsza sekwencja: " + currentClickedDNAprotID + Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText("Druga sekwencja: " + DGV_ProtsComp_Small.Rows[row].Cells[0].Value.ToString() + Environment.NewLine);

                Alignment();
            } catch (Exception) {

            }

            try { //białka
                textBox_tabOther_Seq1.Text = currentClickedProtseq;
                richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" +
                    " * * * * * * * * * * * * * * *" + Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
                if (DGV_ProtsComp_Small.CurrentCell == null)
                    return;

                int row = DGV_ProtsComp_Small.CurrentCell.RowIndex;
                if (row > -1) {
                    string comparedProtSeq = DGV_ProtsComp_Small.Rows[row].Cells[6].Value.ToString();
                    textBox_tabOther_Seq2.Text = comparedProtSeq;
                }
                richTextBox_tabNotepad_Left.AppendText("Pierwsza sekwencja: " + currentClickedDNAprotID + Environment.NewLine);
                richTextBox_tabNotepad_Left.AppendText("Druga sekwencja: " + DGV_ProtsComp_Small.Rows[row].Cells[0].Value.ToString() + Environment.NewLine);

                Alignment();
            } catch (Exception) {

            }

            textBox_tabOther_Seq1.Text = DNA1backup;
            textBox_tabOther_Seq2.Text = DNA2backup;
        }

        /// <summary>
        /// Menu kontekstowe tabeli porównawczej - ignorowanie sekwencji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_PCSmall_IgnoreSequence_Click(object sender, EventArgs e) {
            try {
                List<int> selectedAlready = new List<int>();
                foreach (DataGridViewCell cell in DGV_ProtsComp_Small.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);

                    string ID = DGV_ProtsComp_Small.Rows[rowI].Cells[0].Value.ToString();
                    if (ignoredSequences_tabProt.Contains(ID) == false)
                        ignoredSequences_tabProt.Add(ID);
                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }
        }

        /// <summary>
        ///  Menu kontekstowe tabeli porównawczej - zaprzestanie ignorowania sekwencji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_PCSmall_StopIgnoring_Click(object sender, EventArgs e) {
            try {
                List<int> selectedAlready = new List<int>();
                foreach (DataGridViewCell cell in DGV_ProtsComp_Small.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);

                    string ID = DGV_ProtsComp_Small.Rows[rowI].Cells[0].Value.ToString();
                    if (ignoredSequences_tabProt.Contains(ID))
                        ignoredSequences_tabProt.Remove(ID);

                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Kliknięcie RMB - menu kontekstowe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_ProtsComp_Small_MouseClick(object sender, MouseEventArgs e) {
            if (freeze_DGVProtsCompareSmall)
                return;

            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right) {
                hitTestInfo = DGV_ProtsComp_Small.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    contextMenu_DGV_SmallComp.Show(DGV_ProtsComp_Small, new Point(e.X, e.Y));

            }
        }

        private void DGV_ProtsComp_Small_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            try {
                var x = DGV_ProtsComp_Small.Rows[e.RowIndex].Cells[0].Value;
                if (x == null)
                    return;
                string ID = x.ToString();

                if (ignoredSequences_tabProt.Contains(ID)) {
                    DGV_ProtsComp_Small.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            } catch (Exception) {

            }
        }

        /// <summary>
        /// Dodaj do ignorowanych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_DGV_BigComp_IgnoreSequence_Click(object sender, EventArgs e) {
            try {
                List<int> selectedAlready = new List<int>();
                foreach (DataGridViewCell cell in DGV_ProtsComp_Big.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);

                    string ID = DGV_ProtsComp_Big.Rows[rowI].Cells[0].Value.ToString();
                    if (ignoredSequences_tabProt.Contains(ID) == false)
                        ignoredSequences_tabProt.Add(ID);
                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }
        }

        private void contextMenu_DGV_BigComp_StopIgnoring_Click(object sender, EventArgs e) {
            try {
                List<int> selectedAlready = new List<int>();
                foreach (DataGridViewCell cell in DGV_ProtsComp_Big.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);

                    string ID = DGV_ProtsComp_Big.Rows[rowI].Cells[0].Value.ToString();
                    if (ignoredSequences_tabProt.Contains(ID))
                        ignoredSequences_tabProt.Remove(ID);

                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }
        }



        /* *********************** *********************** ***********************
         * *********************** ***  TAB3: BLASTP   *** ***********************
         * *********************** *********************** ***********************/


        /// <summary>
        /// Aktywuje blasta dla wszystkich wczytanych przez program w słowniku protsFromBlast sekwencji białkowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabBlastP_ActivateBlastPscan_Click(object sender, EventArgs e) {
            if (dataProteinRead == false) {
                return;
            }

            protsFromBlast = ReadBlastResults(5);
            if (protsFromBlast == null)
                return;

            freezeDataGridViewBlastResults = true;
            DataGridView_BlastResults_Fill(protsFromBlast, true);
            freezeDataGridViewBlastResults = false;
            removedResultsIDs.Clear();
        }

        /// <summary>
        /// Zapis wyników programu BlastP.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabBlastP_Save1_Click(object sender, EventArgs e) {
            if (mainDB_ProtSequences == null || dataTable_BlastTable.Rows.Count == 0)
                return;
            SaveBLastResultsToFile();
        }

        private void button_tabBlastP_RefreshDGV_Click(object sender, EventArgs e) {
            if (protsFromBlast != null)
                DataGridView_BlastResults_Fill(protsFromBlast, false);
        }

        /// <summary>
        /// Konwersja liczby do zmiennej double po upuszczeniu textBoxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_tabBlastP_maxEvalue_Leave(object sender, EventArgs e) {
            double eval = 0.0;
            try {
                string code = textBox_tabBlastP_maxEvalue.Text.Replace('.', ',');
                eval = Convert.ToDouble(code);
                textBox_tabBlastP_maxEvalue.Text = eval.ToString();
                textBox_tabBlastP_maxEvalue.BackColor = System.Drawing.SystemColors.Window;
            } catch (Exception) {
                MessageBox.Show("Nieprawidłowa wartość, przywrócono 0.");
                textBox_tabBlastP_maxEvalue.Text = "0";
                textBox_tabBlastP_maxEvalue.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        /// <summary>
        /// Sprawdzanie, czy wpisywana liczba (także w notacji naukowej) spełnia wymagane kryteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_tabBlastP_maxEvalue_TextChanged(object sender, EventArgs e) {
            double eval = 0.0;
            try {
                string code = textBox_tabBlastP_maxEvalue.Text;
                code = code.Replace('.', ',');
                if (code.Length > 0) {
                    int e1 = textBox_tabBlastP_maxEvalue.Text.IndexOf("e");
                    int e2 = textBox_tabBlastP_maxEvalue.Text.LastIndexOf("e");
                    if (e1 != e2) {
                        throw new Exception();
                    }
                    if (code.Substring(code.Length - 1).Equals("-") || code.Substring(code.Length - 1).Equals("+")) {
                        return;
                    }
                    if (e1 != -1 && e1 == code.Length - 1) {
                        code += "0";
                    }
                }
                eval = Convert.ToDouble(code);
                textBox_tabBlastP_maxEvalue.BackColor = System.Drawing.SystemColors.Window;
            } catch (Exception) {
                textBox_tabBlastP_maxEvalue.BackColor = System.Drawing.Color.Red;
            }
        }

        private void DGV_Blast_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (freezeDGViewBlast)
                return;
            dataGridView_Blast_SelectionResponse();
        }

        private void DGV_Blast_SelectionChanged(object sender, EventArgs e) {
            if (freezeDGViewBlast)
                return;
            dataGridView_Blast_SelectionResponse();
        }

        /// <summary>
        /// Kliknięcie RMB - menu kontekstowe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_Blast_MouseClick(object sender, MouseEventArgs e) {
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right) {
                hitTestInfo = DGV_Blast.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    contextMenu_DGV_Blast.Show(DGV_Blast, new Point(e.X, e.Y));
            }
        }

        private void contextMenu_DGV_Blast_RemoveRow_Click(object sender, EventArgs e) {
            try {
                freezeDGViewBlast = true;
                List<int> selectedAlready = new List<int>();
                List<string> selectedIDs = new List<string>();
                foreach (DataGridViewCell cell in DGV_Blast.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);
                    selectedIDs.Add(DGV_Blast.Rows[rowI].Cells[0].Value.ToString());
                }

                foreach (string s in selectedIDs) {
                    if (removedResultsIDs.Contains(s) == false)
                        removedResultsIDs.Add(s);
                    foreach (DataRow row in dataTable_BlastTable.Rows) {
                        if (row[0].Equals(s)) {
                            dataTable_BlastTable.Rows.Remove(row);
                            break;
                        }
                    }
                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }

            freezeDGViewBlast = false;
        }



        /* *********************** *********************** ***********************
         * *********************** **  TAB4: BLAST DB  *** ***********************
         * *********************** *********************** ***********************/



        private void comboBox_tabDB_BaseSelection_SelectedIndexChanged(object sender, EventArgs e) {
            int select = comboBox_tabDB_BaseSelection.SelectedIndex;

            if (dataTable_BlastDB.Rows.Count > 0) {
                DialogResult result = MessageBox.Show("Wszelkie nieskompilowane zmiany w aktualnie otwartej liście\n" +
                "zostaną stracone. Wczytać listę sekwencji?", "Wczytywanie sekwencji referencyjnych", MessageBoxButtons.YesNo);
                switch (result) {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        return;
                }
            }
            LoadBlast_refDB(select);
        }

        private void DGV_blastDBs_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dataGridView_refDB_SelectionResponse();
        }

        private void DGV_blastDBs_SelectionChanged(object sender, EventArgs e) {
            dataGridView_refDB_SelectionResponse();
        }

        private void button_tabRefDB_EditRow_Click(object sender, EventArgs e) {
            EditReferenceDBSequence();
        }

        private void button_tabRefDB_AddNewProt_Click(object sender, EventArgs e) {
            AddNewSequenceToReferenceDB();
        }

        private void button_tabRefDB_CompileDB_Click(object sender, EventArgs e) {
            CompileReferenceDB();

            button_tabRefDB_CompileDB.BackColor = System.Drawing.Color.Transparent;
        }

        private void button_tabRefDB_AddFastaFile_Click(object sender, EventArgs e) {
            LoadFastaToReferenceDB();
        }

        private void button_tabRefDB_RemoveSeq_Click(object sender, EventArgs e) {
            RemoveReferenceSequenceByID();
        }

        private void button_tabRefDB_ClearFields_Click(object sender, EventArgs e) {
            textBox_tabRefDB_seqID.Clear();
            textBox_tabRefDB_sequence.Clear();
        }



        /* *********************** *********************** ***********************
         * *********************** ***  TAB: NOTEPAD   *** ***********************
         * *********************** *********************** ***********************/



        private void button_tabNotepad_AlignNW_Click(object sender, EventArgs e) {
            Alignment();
        }

        private void button_tabNotepad_RemoveDuplicates_Click(object sender, EventArgs e) {
            RemoveDuplicatedSequencesFromFile();
        }


        private void button_tabNotepad_BlastN_Click(object sender, EventArgs e) {
            AlignV2();
        }

        private void button_tabNotepad_ClearTBoxes_Click(object sender, EventArgs e) {
            textBox_tabOther_Seq1.Clear();
            textBox_tabOther_Seq2.Clear();
            richTextBox_tabNotepad_Left.Clear();
        }




        /* *********************** *********************** ***********************
         * *********************** ***  TAB: TranslX   *** ***********************
         * *********************** *********************** ***********************/




        private void button_tabTX_alignFromBlast_Click(object sender, EventArgs e) {
            InitializeTXdataBase(1);
        }

        private void button_tabTX_alignFromProts_Click(object sender, EventArgs e) {
            InitializeTXdataBase(0);
        }

        private void button_tabTX_runTX_Click(object sender, EventArgs e) {
            ActivateTranslatorXProcess();
        }

        private void richTextBox_tabTX_results_ContentsResized(object sender, ContentsResizedEventArgs e) {
            if (flagRTBcontent == false) {
                //richTextBox_tabTX_results.RightMargin = TextRenderer.MeasureText(templateStr, this.richTextBox_tabTX_results.Font).Width;
            }
        }

        private void button_tabTX_ShowFull_Click(object sender, EventArgs e) {

            ShowResultInRTB_Mono();
        }

        private void numericUpDown_tabTX_font_ValueChanged(object sender, EventArgs e) {
            int value = Convert.ToInt32(numericUpDown_tabTX_font.Value);
            richTextBox_tabTX_results.Font = new Font(FontFamily.GenericMonospace, value);
        }
        private void button_tabTX_ShowAlignment_Click(object sender, EventArgs e) {
            resetTab4_TransX_Data();
        }

        bool doNotTroll = false;
        public int lastScrollValue = 0;
        private void hScrollBar_tabTX_Scroll(object sender, ScrollEventArgs e) {
            //if(doNotTroll) {
            //    doNotTroll = false;
            //    return;
            //}
            //int start = Convert.ToInt32(hScrollBar1.Value);
            //ShowNumberLinesInRTB(start, false);
        }

        private void hScrollBar_tabTX_MouseCaptureChanged(object sender, EventArgs e) {
            if (doNotTroll) {
                doNotTroll = false;
                return;
            }

            numericUpDown_tabTX_font.Focus();
            int start = Convert.ToInt32(hScrollBar_tabTX.Value);
            if (radioButton_tabTX_showDNA.Checked)
                ShowResultInRTB(start);
            else
                ShowResultProtInRTB(start);
            doNotTroll = true;
        }

        private void hScrollBar_tabTX_ValueChanged(object sender, EventArgs e) {
            //return;
            if (doNotTroll) {
                doNotTroll = false;
                return;
            }
            if (hScrollBar_tabTX.Value == lastScrollValue)
                return;

            numericUpDown_tabTX_font.Focus();
            int start = Convert.ToInt32(hScrollBar_tabTX.Value);
            ShowNumberLinesInRTB(start, false);
            lastScrollValue = hScrollBar_tabTX.Value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            saveConfig();
        }

        private void button_tabTX_loadFromFile_Click(object sender, EventArgs e) {
            loadTXalignmentFile();
            InitScrollBar();
        }

        private void numericUpDown_tabTX_frameSize_ValueChanged(object sender, EventArgs e) {
            hScrollBar_tabTX.LargeChange = Convert.ToInt32(numericUpDown_tabTX_frameSize.Value);
        }

        private void checkBoxM_CheckedChanged(object sender, EventArgs e) {
            updateSelectedAlignment(0, checkBoxM.Checked);
        }

        private void checkBoxC_CheckedChanged(object sender, EventArgs e) {
            updateSelectedAlignment(1, checkBoxC.Checked);
        }

        private void checkBoxF_CheckedChanged(object sender, EventArgs e) {
            updateSelectedAlignment(2, checkBoxF.Checked);
        }

        private void checkBoxT_CheckedChanged(object sender, EventArgs e) {
            updateSelectedAlignment(3, checkBoxT.Checked);
        }

        private void checkBoxP_CheckedChanged(object sender, EventArgs e) {
            updateSelectedAlignment(4, checkBoxP.Checked);
        }

        private void button_tabTX_getTXdata_Click(object sender, EventArgs e) {
            if(DGV_tabTX_Main.Rows.Count > 0) {
                textBox2.Text = "";
                foreach (DataRow row in dataTable_TX_Main.Rows) {
                    textBox2.AppendText(row[0] + Environment.NewLine);
                    textBox2.AppendText(row[1] + Environment.NewLine);
                }
            }
        }

        private void checkBox_ColorTrigger_CheckedChanged(object sender, EventArgs e) {
            if(checkBox_ColorTrigger.Checked) {
                updateColorArrays();
            } else {
                color_AminoAcids.Clear();
                color_Codons.Clear();
            }
        }

        private void checkBox_aminoAnyone_CheckedChanged(object sender, EventArgs e) {
            try {
                CheckBox cb = sender as CheckBox;
                string letter = cb.Text.Substring(0, 1);
                if(cb.Checked) {
                    Color c;
                    aminoColorsDict.TryGetValue(letter, out c);
                    ((CheckBox)sender).ForeColor = c;
                } else {
                    ((CheckBox)sender).ForeColor = SystemColors.ControlText;
                }

                if (checkBox_ColorTrigger.Checked) {
                    updateColorArrays();
                } else {
                    color_AminoAcids.Clear();
                    color_Codons.Clear();
                }

            } catch (Exception) {

            }
        }


        private void button_tabTX_saveMuscle_Click(object sender, EventArgs e) {
            if(loadedAlignment[0] == false) {
                MessageBox.Show("Brak alignmentu algorytmu Muscle.");
                return;
            }

            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            SaveAlignmentToFile(fileName, alignmentDataTX_DNA[0]);
        }

        private void SaveAlignmentToFile(string fileName, Dictionary<string, string> dictionary) {
            string[] names = Engine.getFileNameInfo(fileName);

            string newFileName = names[2] + names[0] + "_Prot" + names[1];
            FileStream fileStream = new FileStream(newFileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            try {
                //subText = Ribosome.DNAToAminoAcidSpecial(subText);
                foreach (KeyValuePair<string, string> entry in dictionary) {
                    if (checkBox1.Checked) {
                        try {
                            string decoded = Ribosome.DNAToAminoAcidSpecial(entry.Value);

                            int start = Convert.ToInt32(numericUpDown1.Value) - 1;
                            int stop = Convert.ToInt32(numericUpDown2.Value) - 1;
                            if (start > stop)
                                stop = start + 1;
                            int howMany = stop - start + 1; //!!! +1
                            int textSize = decoded.Length;

                            if (start >= textSize) {
                                MessageBox.Show("Błąd zapisu, nr początkowego kodonu/białka większy niż zakres sekwencji!");
                                writer.Close();
                                return;
                            }

                            string toSave = "";
                            if (start + howMany > textSize) {
                                toSave = decoded.Substring(start); //max
                            } else {
                                toSave = decoded.Substring(start, howMany);
                            }

                            string nameID = Engine.GetShortID(entry.Key);
                            writer.WriteLine(nameID);
                            writer.WriteLine(toSave);
                        } catch (Exception exc222) {
                            MessageBox.Show("Błąd zapisu, nieprawidłowe numery kolumn.");
                            writer.Close();
                            return;
                        }

                    } else {
                        string nameID = Engine.GetShortID(entry.Key);
                        writer.WriteLine(nameID);
                        writer.WriteLine(Ribosome.DNAToAminoAcidSpecial(entry.Value));
                    }
                }

            } catch (Exception exc) {

            }
            writer.Close();

            newFileName = names[2] + names[0] + "_DNA" + names[1];
            fileStream = new FileStream(newFileName, FileMode.Create);
            writer = new StreamWriter(fileStream);
            try {
                foreach (KeyValuePair<string, string> entry in dictionary) {
                    if (checkBox1.Checked) {
                        try {
                            int start = Convert.ToInt32(numericUpDown1.Value);
                            int stop = Convert.ToInt32(numericUpDown2.Value);
                            if (start > stop)
                                stop = start + 1;
                            int howMany = stop - start + 1; //!!! +1
                            string align = entry.Value;
                            int textSize = align.Length;

                            if(start*3 >= textSize) {
                                MessageBox.Show("Błąd zapisu, nr początkowego kodonu/białka większy niż zakres sekwencji!");
                                writer.Close();
                                return;
                            }

                            string toSave = "";
                            if(start*3 + howMany*3 > textSize) {
                                toSave = align.Substring(start * 3); //max
                            } else {
                                toSave = align.Substring(start * 3, howMany * 3);
                            }

                            string nameID = Engine.GetShortID(entry.Key);
                            writer.WriteLine(nameID);
                            writer.WriteLine(toSave);

                        } catch (Exception exc222) {
                            MessageBox.Show("Błąd zapisu, nieprawidłowe numery kolumn.");
                            writer.Close();
                            return;
                        }

                    } else {
                        string nameID = Engine.GetShortID(entry.Key);
                        writer.WriteLine(nameID);
                        writer.WriteLine(entry.Value);
                    }  
                }

            } catch (Exception exc) {

            }
            writer.Close();
        }

        private void button_tabTX_saveClustalW_Click(object sender, EventArgs e) {
            if (loadedAlignment[1] == false) {
                MessageBox.Show("Brak alignmentu algorytmu ClustalW.");
                return;
            }

            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            SaveAlignmentToFile(fileName, alignmentDataTX_DNA[1]);
        }

        private void button_tabTX_saveMafft_Click(object sender, EventArgs e) {
            if (loadedAlignment[2] == false) {
                MessageBox.Show("Brak alignmentu algorytmu Mafft.");
                return;
            }

            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            SaveAlignmentToFile(fileName, alignmentDataTX_DNA[3]);
        }

        private void button_tabTX_saveTCoffee_Click(object sender, EventArgs e) {
            if (loadedAlignment[3] == false) {
                MessageBox.Show("Brak alignmentu algorytmu T-Coffee.");
                return;
            }

            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            SaveAlignmentToFile(fileName, alignmentDataTX_DNA[3]);
        }

        private void button_tabTX_savePrank_Click(object sender, EventArgs e) {
            if (loadedAlignment[4] == false) {
                MessageBox.Show("Brak alignmentu algorytmu Prank.");
                return;
            }

            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            SaveAlignmentToFile(fileName, alignmentDataTX_DNA[4]);
        }

        private void richTextBox_tabTX_results_MouseUp(object sender, MouseEventArgs e) {
            if (richTextBox_tabTX_results.SelectedText.Length > 0) {
                // Show the Copy, Paste, Cut Buttons...
                int lineLength = richTextBox_tabTX_results.Lines[0].Length;
                int selStart = richTextBox_tabTX_results.SelectionStart % lineLength;
                int selectionLength = richTextBox_tabTX_results.SelectionLength;
                if(selectionLength >= lineLength-selStart) {
                    richTextBox_tabTX_results.Select(0, 10);
                    return;
                }


                int size = richTextBox_tabTX_results.Lines.Length;
                
                
                int sel2 = richTextBox_tabTX_results.SelectionStart;
                int x = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            showAllInRTB(comboBox_tabTX_comboSelectAlignForShowAll.SelectedIndex);
        }
    }
}