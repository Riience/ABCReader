using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCReader {
    partial class Form1 {

        private void ChangeTabLogColor(LogType type) {
            if (type == LogType.ERROR) {
                SetTabHeader(tabControl1.TabPages[3], Color.Red);
            } else if (type == LogType.MONIT) {
                SetTabHeader(tabControl1.TabPages[3], Color.Orange);
            }
        }

        public void AddLogLine(string line, LogType type) {
            richTextBox_tabLog.AppendText(line);

            ChangeTabLogColor(type);
        }

        public void AddLogLineEnter(string line, LogType type) {
            richTextBox_tabLog.AppendText(line + Environment.NewLine);

            ChangeTabLogColor(type);
        }

        /// <summary>
        /// Pokazuje kolorowaną wersję alignmentu N-W.
        /// </summary>
        /// <param name="seq1">Pierwsza sekwencja.</param>
        /// <param name="seq2">Druga sekwencja.</param>
        private void ShowAlignmentInColor(string seq1, string seq2) {
            int length1 = seq1.Length;
            int length2 = seq2.Length;
            if (length1 != length2) {
                MessageBox.Show("uneven sequences!");
                return;
            }

            Color oldFontColor = richTextBox_tabNotepad_Left.SelectionColor;

            int lineLength = 150;
            for (int i = 0; i < length1;) {
                if (seq1.Length <= lineLength) {
                    char[] stmp1 = seq1.ToCharArray();
                    char[] stmp2 = seq2.ToCharArray();

                    for (int j = 0; j < stmp1.Length; j++) {
                        if (stmp1[j] == stmp2[j]) {
                            richTextBox_tabNotepad_Left.SelectionColor = Color.Red;
                        } else {
                            richTextBox_tabNotepad_Left.SelectionColor = oldFontColor;
                        }
                        richTextBox_tabNotepad_Left.AppendText("" + stmp1[j]);
                    }
                    richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
                    for (int j = 0; j < stmp2.Length; j++) {
                        if (stmp1[j] == stmp2[j]) {
                            richTextBox_tabNotepad_Left.SelectionColor = Color.Red;
                        } else {
                            richTextBox_tabNotepad_Left.SelectionColor = oldFontColor;
                        }
                        richTextBox_tabNotepad_Left.AppendText("" + stmp2[j]);
                    }
                    richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);

                    break;
                } else {
                    string tmp1 = seq1.Substring(0, lineLength);
                    string tmp2 = seq2.Substring(0, lineLength);

                    char[] stmp1 = tmp1.ToCharArray();
                    char[] stmp2 = tmp2.ToCharArray();
                    for (int j = 0; j < stmp1.Length; j++) {
                        if (stmp1[j] == stmp2[j]) {
                            richTextBox_tabNotepad_Left.SelectionColor = Color.Red;
                        } else {
                            richTextBox_tabNotepad_Left.SelectionColor = oldFontColor;
                        }
                        richTextBox_tabNotepad_Left.AppendText("" + stmp1[j]);
                    }
                    richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
                    for (int j = 0; j < stmp2.Length; j++) {
                        if (stmp1[j] == stmp2[j]) {
                            richTextBox_tabNotepad_Left.SelectionColor = Color.Red;
                        } else {
                            richTextBox_tabNotepad_Left.SelectionColor = oldFontColor;
                        }
                        richTextBox_tabNotepad_Left.AppendText("" + stmp2[j]);
                    }
                    richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);
                    richTextBox_tabNotepad_Left.AppendText(Environment.NewLine);

                    seq1 = seq1.Substring(lineLength);
                    seq2 = seq2.Substring(lineLength);
                    i += lineLength;
                }
            }
        }
    }
}
