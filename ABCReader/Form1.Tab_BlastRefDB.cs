using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {
        public DataTable dataTable_BlastDB = null;
        BindingSource bindingSource_BlastDB = null;
        static bool freezeDataGridViewBlastResults = false;

        /// <summary>
        /// Wczytywanie sekwencji referencyjnych do tabeli dataGridView.
        /// </summary>
        /// <param name="select">Nr wybranego wiersza.</param>
        private void LoadBlast_refDB(int select) {
            if(select < 0) {
                return;
            }

            string DBname = Get_refDBname(select);
            try {
                dataTable_BlastDB.Clear();

                string path = Environment.CurrentDirectory + "\\blastwork\\" + DBname;
                List<string[]> dane = abcEngine.LoadFastaFile_DNA(path);
                foreach(string[] s in dane) {
                    dataTable_BlastDB.Rows.Add(s[0], s[1]);
                }
                label8.Text = "Liczba sekwencji referencyjnych w bazie "+ DBname+": "+ dataTable_BlastDB.Rows.Count;
            } catch (Exception e) {
                AddLogLineEnter("Błąd odczytu sekwencji referencyjnych.", LogType.ERROR);
                AddLogLineEnter("Kod błędu: "+e.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Wczytywanie sekwencji z pliku Fasta do zbioru referencyjnego.
        /// </summary>
        private void LoadFastaToReferenceDB() {
            if (dataTable_BlastDB.Rows.Count == 0) {
                MessageBox.Show("Brak otwartej bazy sekwencji referencyjnych.");
                return;
            }

            try {
                string path = Tools.loadDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
                List<string[]> dane = abcEngine.LoadFastaFile_DNA(path);

                if (dane.Count < 1)
                    return;

                Dictionary<string, string> noweSekwencje = new Dictionary<string, string>();
                foreach (string[] s in dane) {
                    noweSekwencje.Add(s[0], s[1]);
                }
               
                List<string> refIDs = new List<string>();
                List<string> refSeqs = new List<string>();
                foreach (DataRow row in dataTable_BlastDB.Rows) {
                    refIDs.Add(row[0].ToString());
                    refSeqs.Add(row[1].ToString());
                }

                bool duplicates = false;
                List<string> dupList = new List<string>();
                List<string> nameChangedList = new List<string>();

                Random rand = new Random();

                foreach(KeyValuePair<string, string> entry in noweSekwencje) {
                    bool clearToAdd = true;
                    string entryID = entry.Key;
                    for(int i=0; i<refIDs.Count; i++) {
                        if(entryID.Equals(refIDs[i])) { //to samo id
                            if (entry.Value.Replace("*","").Equals(refSeqs[i].Replace("*", ""))) { //ta sama sekwencja
                                duplicates = true;
                                clearToAdd = false;
                                dupList.Add(entry.Key);
                                break;
                            } else { //to samo ID, ale inna sekwencja
                                duplicates = true;
                                string oldId = entryID;
                                entryID += "_r"+rand.Next(9999999);
                                nameChangedList.Add(oldId + "->" + entryID);
                                break;
                            }
                        } else if (entry.Value.Equals(refSeqs[i])) { //inne ID, ta sama sekwencja
                            duplicates = true;
                            clearToAdd = false;
                            dupList.Add(entry.Key);
                            break;
                        }
                    }

                    if (clearToAdd) {
                        dataTable_BlastDB.Rows.Add(entryID, entry.Value);
                    }
                }

                if(duplicates) {
                    MessageBox.Show("Wystąpiły powtórzenia, informacje w zakładce Logu.");
                    AddLogLineEnter("****************************************************************************", LogType.NORMAL);
                    AddLogLineEnter("Sekwencje odrzucone ze względu na powtórzenie kodu białka:", LogType.NORMAL);
                    foreach (string s in dupList) {
                        AddLogLineEnter(s, LogType.NORMAL);
                    }
                    AddLogLineEnter("Sekwencje dodane ze zmienioną nazwą:", LogType.NORMAL);
                    foreach (string s in nameChangedList) {
                        AddLogLineEnter(s, LogType.NORMAL);
                    }
                    AddLogLineEnter("****************************************************************************", LogType.NORMAL);
                }
            } catch (Exception exc) {
                AddLogLineEnter("Błąd w czasie dodawania nowych sekwencji.", LogType.ERROR);
                AddLogLineEnter("Kod błędu: " + exc.Message, LogType.ERROR);
            }

        }

        /// <summary>
        /// Rekompilacja instniejącej bazy danych sekwencji.
        /// </summary>
        private void CompileReferenceDB() {
            if (dataTable_BlastDB.Rows.Count == 0) {
                MessageBox.Show("Brak otwartej bazy sekwencji referencyjnych.");
                return;
            }
            int selectedIndex = comboBox_tabDB_BaseSelection.SelectedIndex;
            if (selectedIndex < 0)
                return;

            string DBname = Get_refDBname(selectedIndex);
            if (dataTable_BlastDB.Rows.Count > 0) {
                DialogResult dialogBox = MessageBox.Show("Uwaga: kompilacja oznacza zastąpienie plików bazy "
                    +DBname+"\naktualnie wyświetlaną obok listą sekwencji. Kontynuować?", "Kompilacja bazy sekwencji referencyjnych", MessageBoxButtons.YesNo);
                switch (dialogBox) {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        return;
                }
            }
            //SAVE NEW FILE
            string path = Environment.CurrentDirectory + "\\blastwork\\";

            FileStream fileStream = new FileStream(path+DBname, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            try {
                foreach (DataRow row in dataTable_BlastDB.Rows) {
                    writer.WriteLine(row[0]);
                    writer.WriteLine(row[1]);
                }
            } catch (Exception e) {
                AddLogLineEnter("!!! Krytyczny błąd zapisu pliku " + DBname + 
                    "\nZalecane ręczne przywrócenie kopii zapasowej bazy.", LogType.ERROR);
                AddLogLineEnter("Kod błędu: " + e.Message, LogType.ERROR);
                MessageBox.Show("!!! Krytyczny błąd zapisu pliku " + DBname +
                    "\nZalecane ręczne przywrócenie kopii zapasowej bazy.");
                return;
            }
            writer.Close();

            //RECOMPILE REFERENCE DATABASE
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = path + "makeblastdb.exe";
            proc.StartInfo.Arguments = "-in " + DBname + " -dbtype prot -parse_seqids";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();

            string vector = proc.StandardOutput.ReadToEnd();
            DialogResult result = MessageBox.Show(vector, "Raport kompilacji", MessageBoxButtons.OK);

            proc.WaitForExit();
            proc.Close();
        }

        /// <summary>
        /// Metoda próbuje dodać do tabeli nową, ręcznie wprowadzoną sekwencję referencyjną.
        /// </summary>
        private void AddNewSequenceToReferenceDB() {
            if (dataTable_BlastDB.Rows.Count == 0) {
                MessageBox.Show("Brak otwartej bazy sekwencji referencyjnych.");
                return;
            }

            string sID = textBox_tabRefDB_seqID.Text;
            string sequence = textBox_tabRefDB_sequence.Text;

            if(checkCorrectness(sID, sequence, false)) {
                dataTable_BlastDB.Rows.Add(sID, sequence);
            }
        }

        /// <summary>
        /// Sprawdza prawidłowość nazwy i powtarzalność sekwencji zmienianej / dodawanej ręcznie.
        /// </summary>
        /// <param name="sID">Identyfikator sekwencji musi być unikalny.</param>
        /// <param name="seq">Sekwencja nie może się powtarzać.</param>
        /// <param name="onlyEdit">True: nie będzie sprawdzana identyczność ID/sekwencji.</param>
        /// <returns></returns>
        private bool checkCorrectness(string sID, string seq, bool onlyEdit) {
            if (sID.Length == 0) {
                MessageBox.Show("Błąd: brak identyfikatora sekwencji.");
                return false;
            }
            if (!sID.Substring(0, 1).Equals(">")) {
                MessageBox.Show("Błąd: nieprawidłowy identyfikator ('>' musi być początkowym symbolem).");
                return false;
            }
            if (seq.Length == 0) {
                MessageBox.Show("Błąd: brak sekwencji do dodania.");
                return false;
            }

            bool invalidLetters = Regex.IsMatch(seq, @"^[a-zA-Z*]+$");
            if (!invalidLetters) {
                MessageBox.Show("Błąd: nieprawidłowe znaki w sekwencji białkowej!");
                return false;
            }

            if (onlyEdit == true)
                return true; //brak dalszego sprawdzania identyczności

            seq = seq.Replace("*", "");
            foreach (DataRow row in dataTable_BlastDB.Rows) {
                if (row[0].Equals(sID)) {
                    MessageBox.Show("Błąd: sekwencja o podanym ID już istnieje!");
                    return false;
                }
                if (row[1].ToString().Replace("*","").Equals(seq)) {
                    MessageBox.Show("Błąd: sekwencja o takiej samej strukturze już istnieje!");
                    return false;
                }
            }

            return true;
        }

        private void RemoveReferenceSequenceByID() {
            if (DGV_blastDBs.CurrentCell == null)
                return;

            try {
                List<int> selectedAlready = new List<int>();
                foreach (DataGridViewCell cell in DGV_blastDBs.SelectedCells) {
                    int rowI = cell.RowIndex;
                    if (selectedAlready.Contains(rowI)) {
                        continue;
                    }
                    selectedAlready.Add(rowI);
                    string selectedID = DGV_blastDBs.Rows[rowI].Cells[0].Value.ToString();

                    foreach (DataRow row in dataTable_BlastDB.Rows) { //szukaj pozycji sekwencji w bazie... 
                        if (row[0].Equals(selectedID)) {  //...po starym ID
                            dataTable_BlastDB.Rows.Remove(row);
                            break;
                        }
                    }
                }
            } catch (Exception exc) {
                AddLogLineEnter(exc.Message, LogType.ERROR);
            }

            /*
            int selectedRow = dataGridView_blastDBs.CurrentCell.RowIndex;
            if (selectedRow > -1) {
                string selectedID = dataGridView_blastDBs.Rows[selectedRow].Cells[0].Value.ToString();


                DialogResult dialogBox = MessageBox.Show("Usunąć sekwencję o ID: "+ selectedID+" z listy?", "Usunięcie sekwencji referencyjnej", MessageBoxButtons.YesNo);
                switch (dialogBox) {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        return;
                }


                foreach (DataRow row in dataTable_BlastDB.Rows) { //szukaj pozycji sekwencji w bazie... 
                    if (row[0].Equals(selectedID)) {  //...po starym ID
                        dataTable_BlastDB.Rows.Remove(row);
                        return;
                    }
                }
            }
            */
        }

        /// <summary>
        /// Edycja wybranego wiersza tablicy sekwencji referencyjnych.
        /// </summary>
        private void EditReferenceDBSequence() {
            if (DGV_blastDBs.CurrentCell == null)
                return;

            int selectedRow = DGV_blastDBs.CurrentCell.RowIndex;
            if (selectedRow > -1) {
                string selectedID = DGV_blastDBs.Rows[selectedRow].Cells[0].Value.ToString();
                string sID = textBox_tabRefDB_seqID.Text;
                string sequence = textBox_tabRefDB_sequence.Text;

                if(checkCorrectness(sID, sequence, true)) {
                    foreach (DataRow row in dataTable_BlastDB.Rows) { //szukaj pozycji sekwencji w bazie... 
                        if (row[0].Equals(selectedID)) {  //...po starym ID
                            row[0] = sID;
                            row[1] = sequence;
                            button_tabRefDB_CompileDB.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Aktualizacja textboxów ID i dane sekwencji na podstawie wybranego wiersza tabeli.
        /// </summary>
        private void dataGridView_refDB_SelectionResponse() {
            if (DGV_blastDBs.CurrentCell == null)
                return;

            int selectedRow = DGV_blastDBs.CurrentCell.RowIndex;
            //int col = dataGridView_blastDBs.CurrentCell.ColumnIndex;

            if (selectedRow > -1) {
                string sId = DGV_blastDBs.Rows[selectedRow].Cells[0].Value.ToString();
                string sequence = DGV_blastDBs.Rows[selectedRow].Cells[1].Value.ToString();

                textBox_tabRefDB_seqID.Text = sId;
                textBox_tabRefDB_sequence.Text = sequence;
            }
        }

        /// <summary>
        /// Inicjalizacja tablicy baz danych BlastP - konstruktor.
        /// </summary>
        private void InitDataGrid_referenceSequencesDB() {
            dataTable_BlastDB = new DataTable();
            bindingSource_BlastDB = new BindingSource();
            bindingSource_BlastDB.DataSource = dataTable_BlastDB;
            DGV_blastDBs.DataSource = bindingSource_BlastDB;
            dataTable_BlastDB.Columns.Add(new DataColumn("Identyfikator", typeof(string)));
            dataTable_BlastDB.Columns.Add(new DataColumn("Sekwencja referencyjna", typeof(string)));
            DGV_blastDBs.Columns[0].Width = 165;
            DGV_blastDBs.Columns[1].Width = 600;
        }

        public static string Get_refDBname(int index) {
            switch (index) {
                case 0:
                    return "DB_all.fasta";
                case 1:
                    return "DB_PDR.fasta";
                case 2:
                    return "DB_MDR.fasta";
                case 3:
                    return "DB_MRP.fasta";
                case 4:
                    return "DB_WBC.fasta";
                case 5:
                    return "DB_user.fasta";
                default:
                    return "DB_all.fasta";
            }
        }
    }
}
