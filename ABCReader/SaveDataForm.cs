using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ABCReader {
    public partial class SaveDataForm : Form {
        private Engine abcEngine = null;
        private string currentDir = null;
        private Form1 parent = null;

        public SaveDataForm(Engine reader, string dir, Form1 form1) {
            InitializeComponent();
            abcEngine = reader;
            currentDir = dir;
            parent = form1;
        }

        private void SaveDataForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        public void updateCurrentDir(string dir) {
            currentDir = dir;
        }

        /// <summary>
        /// Wczytuje plik fasta z DNA i tworzy wynikowy z białkami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            string path = Tools.loadDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (path.Length < 2)
                return;

            parent.updateGloballyCurrentDir(parent.getDirectoryFromPath(path));

            if (path.Length > 3) {
                Dictionary<string, string> dane = abcEngine.LoadDNAFastaFile(path);
                bool onlyProteins = checkBox1.Checked;
                bool onlyWithSTOPcodon = checkBox1.Checked;
                int minSize = Convert.ToInt32(numericUpDown1.Value);
                bool onlyLongestSeq = false;
                bool allWithMinSize = true;
                if (radioButton1.Checked) {
                    onlyLongestSeq = true;
                    allWithMinSize = false;
                }
                int order = 1; //5'->3'
                if (radioButton3to5.Checked)
                    order = -1;
                else if (radioButtonBothDirections.Checked)
                    order = 0;

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dane.Keys.Count;
                progressBar1.Value = 0;

                abcEngine.SaveAllProteinsFromDNAFasta(path, dane, onlyProteins, onlyWithSTOPcodon, onlyLongestSeq, allWithMinSize,
                    minSize, order, progressBar1, true, checkBoxWriteAlsoDNAFile.Checked);
            }
        }

        /// <summary>
        /// Konwertuje wszystkie pliki fasta (bez "result" w nazwie) na osobne pliki sekwencji białkowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            string folder = Tools.OpenFolderDialog();
            if (folder == null)
                return;

            string[] allfiles = Directory.GetFiles(folder, "*.fasta", SearchOption.AllDirectories);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = allfiles.Length;
            progressBar1.Value = 0;
            foreach (string filePath in allfiles) {
                int index = filePath.LastIndexOf("\\");
                if(index > 0) {
                    string tmp = filePath.Substring(index);

                    if (tmp.Contains("result"))
                        break;
                }

                Dictionary<string, string> dane = abcEngine.LoadDNAFastaFile(filePath);
                bool onlyProteins = checkBox1.Checked;
                bool onlyWithSTOPcodon = checkBox1.Checked;
                int minSize = Convert.ToInt32(numericUpDown1.Value);
                bool onlyLongestSeq = false;
                bool allWithMinSize = true;
                if (radioButton1.Checked) {
                    onlyLongestSeq = true;
                    allWithMinSize = false;
                }
                int order = 1; //5'->3'
                if (radioButton3to5.Checked)
                    order = -1;
                else if (radioButtonBothDirections.Checked)
                    order = 0;

                abcEngine.SaveAllProteinsFromDNAFasta(filePath, dane, onlyProteins, onlyWithSTOPcodon, onlyLongestSeq, allWithMinSize,
                    minSize, order, progressBar1, false, checkBoxWriteAlsoDNAFile.Checked);
                progressBar1.Value++;
            }
        }
    }
}
