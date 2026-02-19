using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {
        public DataTable dataTable_BlastTable = null;
        BindingSource bindingSource_BlastTable = null;
        Dictionary<string, BlastData> protsFromBlast = null;
        bool freezeDGViewBlast = false;
        List<String> removedResultsIDs = new List<string>();

        /// <summary>
        /// Wczytuje przetworzone białka do dataGridView.
        /// </summary>
        /// <param name="protsFromBlast">Słownik danych z białkami.</param>
        private void DataGridView_BlastResults_Fill(Dictionary<string, BlastData> protsFromBlast, bool all) {
            dataTable_BlastTable.Clear();
            foreach (KeyValuePair<string, BlastData> entry in protsFromBlast) {
                if(!all) {
                    try {
                        double maxEval = Convert.ToDouble(textBox_tabBlastP_maxEvalue.Text.Replace('.', ','));
                        int minCover = Convert.ToInt32(numericUpDown_tabBlastP_minCoverage.Value);

                        if (entry.Value.evalue > maxEval)
                            continue;

                        if (entry.Value.qcovhsp < minCover)
                            continue;

                    } catch (Exception) {

                    }
                }
                string sid = entry.Value.qseqid;
                string sseqid = entry.Value.sseqid;
                int size = entry.Value.nonBlast_SeqSize;
                double eval = entry.Value.evalue;
                double qcovhsp = entry.Value.qcovhsp;
                double pident = entry.Value.pident;
                int qstart = entry.Value.qstart;
                int qend = entry.Value.qend;
                int dbstart = entry.Value.sstart;
                int dbend = entry.Value.send;

                
                dataTable_BlastTable.Rows.Add(sid, sseqid, size, eval, qcovhsp, pident, qstart, qend, dbstart, dbend);
            }
        }

        /// <summary>
        /// Obsługa zmiany aktywnego wiersza w tabeli wyników BlastP (tab03).
        /// </summary>
        private void dataGridView_Blast_SelectionResponse() {
            if (freezeDataGridViewBlastResults)
                return;

            if (mainDB_ProtSequences == null)
                return;

            if (DGV_Blast.CurrentCell == null)
                return;

            int row = DGV_Blast.CurrentCell.RowIndex;
            int col = DGV_Blast.CurrentCell.ColumnIndex;

            if (row > -1) {
                string sId = DGV_Blast.Rows[row].Cells[0].Value.ToString();
                ProteinFromDNA protEntry;
                if (!mainDB_ProtSequences.TryGetValue(sId, out protEntry)) {
                    return;
                }
                string dna = protEntry.DNAsequence;
                int howMany = (int)numericUpDown_tabBlastP_CompSet.Value;
                string DBname = Get_refDBname(comboBox_tabBlastP_BlastDBname.SelectedIndex);

                List<BlastData> lista = null;
                if (checkBox2Convert.Checked)
                    lista = blastEngine.GetVector(protEntry, sId, howMany, 1, DBname, true);
                else
                    lista = blastEngine.GetVector(protEntry, sId, howMany, 1, DBname, false);

                richTextBox_tabBlastP_blastView.Clear();
                richTextBox_tabBlastP_blastView.Font = new Font(FontFamily.GenericMonospace, 8);

                PrintBlastTable(richTextBox_tabBlastP_blastView, lista);

                richTextBox_tabBlastP_blastView.AppendText(Environment.NewLine);
                richTextBox_tabBlastP_blastView.AppendText(sId + Environment.NewLine);
                richTextBox_tabBlastP_blastView.AppendText(protEntry.lvl2_DNAcodingSequence + Environment.NewLine);
                richTextBox_tabBlastP_blastView.AppendText(Environment.NewLine);
                richTextBox_tabBlastP_blastView.AppendText(protEntry.peptideSequence + Environment.NewLine);

                protEntry.lvl2_mainHistogram = DNAtools.GetSeqHistogram(protEntry.lvl2_DNAcodingSequence);
                protEntry.lvl2_avgHistValue = DNAtools.GetHistAvg(protEntry.lvl2_mainHistogram);
                chart2.ChartAreas[0].AxisX.LineWidth = 6;
                chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                chart2.Series[0].Points.Clear();

                chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                for (int i = 0; i < 64; i++) {
                    chart2.Series[0].Points.AddXY(Ribosome.COD_SORTED[i], protEntry.lvl2_mainHistogram[i]);
                }

            }
        }

        /// <summary>
        /// Wysyłanie sekwencji białkowych do BlastP oraz przygotowanie słownika wyników.
        /// </summary>
        /// <param name="packetSize"></param>
        /// <returns>Słownik ID-BlastDane wyników z BlastP.</returns>
        private Dictionary<string, BlastData> ReadBlastResults(int packetSize) {
            if (mainDB_ProtSequences == null)
                return null;

            Dictionary<string, BlastData> resultDictionary = new Dictionary<string, BlastData>();

            try {
                int proteinsNumber = 0;
                List<string> ids = new List<string>();
                List<ProteinFromDNA> prots = new List<ProteinFromDNA>();
                foreach (KeyValuePair<string, ProteinFromDNA> entry in mainDB_ProtSequences) {
                    if (ignoredSequences_tabProt.Contains(entry.Key))
                        continue;

                    ids.Add(entry.Key);
                    prots.Add(entry.Value);
                    proteinsNumber++;
                }
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = (proteinsNumber / packetSize) + 1;
                toolStripProgressBar1.Value = 0;
                int counter = 0;
                Dictionary<string, ProteinFromDNA> protsToBlast = new Dictionary<string, ProteinFromDNA>();
                for (int i = 0; i < proteinsNumber; i++) {
                    Application.DoEvents();
                    protsToBlast.Add(ids[i], prots[i]);
                    counter++;

                    if (counter == packetSize || i + 1 == proteinsNumber) {
                        counter = 0;
                        string DBname = Get_refDBname(comboBox_tabBlastP_BlastDBname.SelectedIndex);
                        Dictionary<string, BlastData> blastResults = blastEngine.GetBlastData(protsToBlast, 1, 1, DBname);

                        foreach (var result in blastResults) {
                            string id = result.Key;
                            try {
                                int i1 = id.IndexOf("_size")+5;
                                int i2 = id.IndexOf("_start");
                                int realSize = i2 - i1;
                                string size = id.Substring(id.IndexOf("size") + 4, realSize);
                                result.Value.nonBlast_SeqSize = Convert.ToInt32(size);
                            } catch (Exception) {
                                AddLogLine("Błąd konwersji długości sekwencji.", LogType.ERROR);
                            }
                        }


                        foreach (var result in blastResults) {
                            resultDictionary.Add(result.Key, result.Value);
                        }
                        toolStripProgressBar1.Value++;
                        protsToBlast.Clear();
                    }
                }

                if (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
                    toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;

                return resultDictionary;

            } catch (Exception e) {
                AddLogLineEnter("Błąd przetwarzania danych przez program BlastN.", Form1.LogType.ERROR);
                AddLogLineEnter("Kod błędu: " + e.Message, Form1.LogType.ERROR);
                return null;
            }
        }


        /// <summary>
        /// Inicjalizacja tablicy danych programu BlastP.
        /// </summary>
        private void InitDataGrid_BlastResults() {
            dataTable_BlastTable = new DataTable();
            bindingSource_BlastTable = new BindingSource();
            bindingSource_BlastTable.DataSource = dataTable_BlastTable;
            DGV_Blast.DataSource = bindingSource_BlastTable;
            dataTable_BlastTable.Columns.Add(new DataColumn("SequenceID", typeof(string))); //0
            dataTable_BlastTable.Columns.Add(new DataColumn("DB_SequenceID", typeof(string))); //1
            dataTable_BlastTable.Columns.Add(new DataColumn("SeqSize", typeof(int))); //2
            dataTable_BlastTable.Columns.Add(new DataColumn("Eval", typeof(double))); //3
            dataTable_BlastTable.Columns.Add(new DataColumn("Cover", typeof(double))); //4
            dataTable_BlastTable.Columns.Add(new DataColumn("Ident", typeof(double))); //5
            dataTable_BlastTable.Columns.Add(new DataColumn("Qstart", typeof(int))); //6
            dataTable_BlastTable.Columns.Add(new DataColumn("Qend", typeof(int)));  //7
            dataTable_BlastTable.Columns.Add(new DataColumn("DBstart", typeof(int))); //8
            dataTable_BlastTable.Columns.Add(new DataColumn("DBend", typeof(int))); //9
            DGV_Blast.Columns[0].Width = 250;
            DGV_Blast.Columns[1].Width = 200;
            DGV_Blast.Columns[2].Width = 50;
            DGV_Blast.Columns[3].Width = 70;
            DGV_Blast.Columns[4].Width = 50;
            DGV_Blast.Columns[5].Width = 50;
            DGV_Blast.Columns[6].Width = 50;
            DGV_Blast.Columns[7].Width = 50;
            DGV_Blast.Columns[8].Width = 50;
            DGV_Blast.Columns[9].Width = 50;
        }

        /// <summary>
        /// Zapis wyników z programu BlastP (z tabeli wyników).
        /// </summary>
        private void SaveBLastResultsToFile() {
            try {
                List<string> saveIds = new List<string>();
                List<string> saveDNASeq = new List<string>();
                List<string> saveProtSeq = new List<string>();

                foreach (DataRow row in dataTable_BlastTable.Rows) {
                    string sId = row[0].ToString();

                    double sEval = 1.0; //domyślnie dla sekwencji
                    double sCover = 0.0; //domyślnie dla sekwencji
                    double maxEval = 0.0; //domyślny próg
                    int minCover = 70; //domyślny próg
                    try {
                        sEval = Convert.ToDouble(row[3].ToString());
                        sCover = Convert.ToInt32(row[4].ToString());
                        string code = textBox_tabBlastP_maxEvalue.Text.Replace('.', ',');
                        maxEval = Convert.ToDouble(code);
                        code = numericUpDown_tabBlastP_minCoverage.Value.ToString();
                        minCover = Convert.ToInt32(code);

                    } catch (Exception exc) {
                        AddLogLineEnter("Błąd pobierania wartości eval / cover. Sekwencja: "+ sId, LogType.ERROR);
                        AddLogLineEnter("" + exc.Message, Form1.LogType.ERROR);
                    }
                    

                    if (sEval <= maxEval && sCover >= minCover) { //kryteria zapisu
                        ProteinFromDNA protEntry = null;
                        if (!mainDB_ProtSequences.TryGetValue(sId, out protEntry)) {
                            continue;
                        }

                        saveIds.Add(sId);
                        saveDNASeq.Add(protEntry.lvl2_DNAcodingSequence);
                        saveProtSeq.Add(protEntry.peptideSequence);
                    }
                }

                string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
                if (fileName.Length < 2)
                    return;

                FileStream fileStream = new FileStream(fileName + "_prot.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);
                try {
                    for (int i = 0; i < saveIds.Count; i++) {
                        string nameID = Engine.GetShortID(saveIds[i]);
                        /*
                        string nameID = saveIds[i];
                        nameID = nameID.Substring(0, nameID.IndexOf("_start"));
                        string tmp = nameID.Substring(nameID.IndexOf("_size")+5);
                        if(tmp.Length<4) {
                            int size = tmp.Length;
                            for (int ii = 0; ii < 4 - size; ii++)
                                tmp = "0" + tmp;

                            nameID = nameID.Substring(0, nameID.IndexOf("_size")+5);
                            nameID = nameID + tmp;
                        }
                        */
                        writer.WriteLine(nameID);
                        writer.WriteLine(saveProtSeq[i]);
                    }

                } catch (Exception e) {
                    AddLogLineEnter("Błąd zapisu pliku "+ fileName + "_prot.txt", LogType.ERROR);
                    AddLogLineEnter("Kod błędu: " + e.Message, LogType.ERROR);
                }
                writer.Close();

                fileStream = new FileStream(fileName + "_DNA.txt", FileMode.Create);
                writer = new StreamWriter(fileStream);
                try {
                    for (int i = 0; i < saveIds.Count; i++) {
                        string nameID = Engine.GetShortID(saveIds[i]);
                        /*
                        string nameID = saveIds[i];
                        nameID = nameID.Substring(0, nameID.IndexOf("_start"));
                        string tmp = nameID.Substring(nameID.IndexOf("_size") + 5);
                        if (tmp.Length < 4) {
                            int size = tmp.Length;
                            for (int ii = 0; ii < 4 - size; ii++)
                                tmp = "0" + tmp;

                            nameID = nameID.Substring(0, nameID.IndexOf("_size") + 5);
                            nameID = nameID + tmp;
                        }*/

                        writer.WriteLine(nameID);
                        writer.WriteLine(saveDNASeq[i]);
                    }

                } catch (Exception e) {
                    AddLogLineEnter("Błąd zapisu pliku " + fileName + "_DNA.txt", LogType.ERROR);
                    AddLogLineEnter("Kod błędu: " + e.Message, LogType.ERROR);
                }
                writer.Close();

            } catch (Exception exc) {
                AddLogLineEnter("Ogólny błąd zapisu wyników BlastP.", LogType.ERROR);
                AddLogLineEnter("Kod błędu: "+exc.Message, LogType.ERROR);
                MessageBox.Show("Explosion. Error :) " + exc.Message);
            }
        }
    }
}
