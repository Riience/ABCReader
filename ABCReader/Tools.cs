using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCReader {
    static class Tools {
        /// <summary>
        /// Otwiera dialog wczytywania pliku, zwraca ścieżkę do pliku.
        /// </summary>
        /// <returns>plik z pełną ścieżką dostępu doń</returns>
        public static string loadDialog(string currentDir, string mask) {
            if (mask.Length < 3)
                mask = "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = currentDir;
                openFileDialog.Filter = mask;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        public static string saveDialog(string currentDir, string mask) {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            if (mask.Length < 3)
                mask = "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {

                saveFileDialog.InitialDirectory = currentDir;
                saveFileDialog.Filter = mask;
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = saveFileDialog.FileName;
                }
            }
            return filePath;
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        public static string OpenFolderDialog() {
            using (var fbd = new FolderBrowserDialog()) {
                
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);

                    return fbd.SelectedPath;
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
            return null;
        }
    }
}
