using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ABCReader {
    partial class Form1 {

        /// <summary>
        /// Wczytywanie do programu sekwencji DNA z pliku FASTA.
        /// </summary>
        private void LoadDNAsequencesToProgram() {
            string path = Tools.loadDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            updateGloballyCurrentDir(getDirectoryFromPath(path));

            if (path.Length > 3) {
                resetTab1Data();
                resetTab2Data();
                resetTab3Data();
                resetTab4_TransX_Data();

                mainDB_DNAsequences = abcEngine.LoadDNAFastaFile(path);

                if (checkBox_tabDNA_SortDNAbyLength.Checked)
                    mainDB_DNAsequences = mainDB_DNAsequences.OrderByDescending(x => x.Value.Length).ToDictionary(x => x.Key, x => x.Value);
            }
            if (mainDB_DNAsequences != null && mainDB_DNAsequences.Keys.Count > 0) {
                dataDNAread = true;
                comboDNAOffline = true;
                comboBox_tabDNA_DNAlist.Items.Clear();
                foreach (KeyValuePair<string, string> entry in mainDB_DNAsequences) {
                    comboBox_tabDNA_DNAlist.Items.Add(entry.Key + " (size: " + entry.Value.ToString().Length + ")");
                }
                comboDNAOffline = false;
                groupBox_tabDNA_top_viewOptions.Text = "Podgląd sekwencji (" + mainDB_DNAsequences.Keys.Count + " wczytanych)";
            }
        }

        /// <summary>
        /// Zapis danych pojedyńczego łańcucha białkowego do pliku.
        /// </summary>
        /// <param name="selected">Numer wybranego łańcucha z listy w zakładce DNA.</param>
        private void SaveSingleDecodedProtein(int selected) {
            string fileName = Tools.saveDialog(currentDir, "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|All files (*.*)|*.*");
            if (fileName.Length < 2)
                return;

            updateGloballyCurrentDir(getDirectoryFromPath(fileName));

            int order = 1; //5'->3'
            if (radioButton_tabDNA_3to5.Checked)
                order = -1;
            else if (radioButton_tabDNA_BothDirections.Checked)
                order = 0;

            try {
                abcEngine.SaveSingleProtInfo(fileName, mainDB_DNAsequences.Keys.ToArray()[selected], mainDB_DNAsequences.Values.ToArray()[selected], checkBox_tabDNA_realProteins.Checked, false, order);
            } catch (Exception exc) {
                AddLogLineEnter("Błąd odczytu sekwencji referencyjnych.", LogType.ERROR);
                AddLogLineEnter("Kod błędu: " + exc.Message, LogType.ERROR);
            }
        }

        /// <summary>
        /// Główna metoda wypełniająca RichTextBox sekwencjami białkowymi lub tylko aminokwasowymi z pewnego DNA.
        /// </summary>
        /// <param name="DNAid">identyfikator sekwencji.</param>
        /// <param name="DNAsequence">sekwencja DNA.</param>
        private void tab01_ShowDNAandProteinsData(string DNAid, string DNAsequence) {
            richTextBox_tabDNA_DNAview.Clear();
            richTextBox_tabDNA_DNAview.Font = new Font(FontFamily.GenericMonospace, 8);// richTextBox1.Font.Size);
            richTextBox_tabDNA_DNAview.SelectionColor = Color.Black;
            if (checkBox_tabDNA_realProteins.Checked) {
                richTextBox_tabDNA_DNAview.AppendText("Tylko sekwencje białkowe od Met do STOP" + Environment.NewLine);
            } else {
                richTextBox_tabDNA_DNAview.AppendText("Sekwencje aminokwasowe rodzialane kodonem STOP" + Environment.NewLine);
            }
            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
            richTextBox_tabDNA_DNAview.AppendText("Sygnatura DNA z pliku: " + DNAid + Environment.NewLine);
            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);


            string framedDNAsequence = "";
            string framedCompDNAsequence = "";
            string compDNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
            int shiftLevel = 0;
            if (radioButton_tabDNA_showFrame0.Checked) {
                framedDNAsequence = DNAsequence;
                framedCompDNAsequence = compDNAsequence;
                shiftLevel = 0;
            } else if (radioButton_tabDNA_showFrame1.Checked) {
                framedDNAsequence = DNAsequence.Substring(1);
                framedCompDNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
                shiftLevel = 1;
            } else if (radioButton_tabDNA_showFrame2.Checked) {
                framedDNAsequence = DNAsequence.Substring(2);
                framedCompDNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
                shiftLevel = 2;
            }

            if (checkBox_tabDNA_realProteins.Checked) { //czy białka czy zwykłe amino
                if (radioButton_tabDNA_ShowAllFrames.Checked) { //wszystkie dane, auto-frame
                    if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        for (int frameShift = 0; frameShift < 3; frameShift++) {
                            richTextBox_tabDNA_DNAview.AppendText("5'->3' ramka odczytu +" + frameShift + ":" + Environment.NewLine);
                            string proteinSequence = Ribosome.DNAToAminoAcid(DNAsequence.Substring(frameShift));
                            tab01_AddColoredPeptide(proteinSequence);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                        }
                    }

                    if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        for (int frameShift = 0; frameShift < 3; frameShift++) {
                            richTextBox_tabDNA_DNAview.AppendText("3'->5' ramka odczytu +" + frameShift + ":" + Environment.NewLine);
                            string proteinSequence = Ribosome.DNAToAminoAcid(compDNAsequence.Substring(frameShift));
                            tab01_AddColoredPeptide(proteinSequence);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                        }
                    }
                } else { //tylko odpowiednia ramka odczytu, łańcuchy DNA zostały już zainicjalizowane wcześniej
                    if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        tab01_AddColoredPeptide(Ribosome.DNAToAminoAcid(framedDNAsequence));
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }
                    if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        tab01_AddColoredPeptide(Ribosome.DNAToAminoAcid(framedCompDNAsequence));
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }
                }
            } else { //nie tylko białka M->STOP ale wszystko rozdzielone przez STOP
                if (radioButton_tabDNA_ShowAllFrames.Checked) { //wszystkie dane, auto-frame
                    if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        for (int frameShift = 0; frameShift < 3; frameShift++) {
                            addBoldText("5'->3' ramka odczytu +" + frameShift + ":", true);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);

                            string aminoSequence = Ribosome.DNAToAminoAcid(DNAsequence.Substring(frameShift));
                            tab01_AddColoredAmino(aminoSequence);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                        }
                    }

                    if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        for (int frameShift = 0; frameShift < 3; frameShift++) {
                            addBoldText("3'->5' ramka odczytu +" + frameShift + ":", true);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                            string aminoSequence = Ribosome.DNAToAminoAcid(compDNAsequence.Substring(frameShift));
                            tab01_AddColoredAmino(aminoSequence);
                            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                        }
                    }
                } else {  //tylko odpowiednia ramka odczytu, łańcuchy DNA zostały już zainicjalizowane wcześniej
                    if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        tab01_AddColoredAmino(Ribosome.DNAToAminoAcid(framedDNAsequence));
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }

                    if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) {
                        tab01_AddColoredAmino(Ribosome.DNAToAminoAcid(framedCompDNAsequence));
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }
                }
            }

            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
            richTextBox_tabDNA_DNAview.AppendText("Podsumowanie:" + Environment.NewLine);

            string type = "_PROT_";
            if (radioButton_tabDNA_ShowAllFrames.Checked) { //wszystkie dane, auto-frame
                string longestSequence = "";
                int longestInFrame = 0;
                string longestID = "";

                if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) { //5'->3' lub oba kierunki
                    for (int frameShift = 0; frameShift < 3; frameShift++) {
                        addBoldText("5'->3' ramka odczytu +" + frameShift + ":", true);
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);

                        List<ProteinFromDNA> lista = null;
                        if (checkBox_tabDNA_realProteins.Checked) {
                            lista = abcEngine.GetCodedProteinsFromDNA(DNAid, DNAsequence, frameShift, true);
                            type = "_PROT5to3_";
                        } else {
                            lista = abcEngine.GetAllAminoSequencesFromDNA(DNAid, DNAsequence, frameShift, true);
                            type = "_AMINO5to3_";
                        }
                        int protCounterInFrame = 0;
                        foreach (ProteinFromDNA prot in lista) {
                            string tempID = DNAid + type + "orf" + prot.shiftLevel + "_size" + prot.peptideSeqLength + "_#" + protCounterInFrame;
                            if (prot.peptideSequence.Length > longestSequence.Length) { //zapamiętaj najdłuższą
                                longestSequence = prot.peptideSequence;
                                longestInFrame = frameShift;
                                longestID = tempID;
                            }
                            richTextBox_tabDNA_DNAview.AppendText(tempID + Environment.NewLine);
                            richTextBox_tabDNA_DNAview.AppendText(prot.peptideSequence + Environment.NewLine);
                            protCounterInFrame++;
                        }
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }
                }

                if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) { //3'->5' lub oba kierunki
                    for (int frameShift = 0; frameShift < 3; frameShift++) {
                        addBoldText("3'->5' ramka odczytu +" + frameShift + ":", true);
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);

                        List<ProteinFromDNA> lista = null;
                        if (checkBox_tabDNA_realProteins.Checked) {
                            lista = abcEngine.GetCodedProteinsFromDNA(DNAid, DNAsequence, frameShift, false);
                            type = "_PROT3to5_";
                        } else {
                            lista = abcEngine.GetAllAminoSequencesFromDNA(DNAid, DNAsequence, frameShift, false);
                            type = "_AMINO3to5_";
                        }
                        int protCounterInFrame = 0;
                        foreach (ProteinFromDNA prot in lista) {
                            string tempID = DNAid + type + "orf" + prot.shiftLevel + "size" + prot.peptideSeqLength + "_#" + protCounterInFrame;
                            if (prot.peptideSequence.Length > longestSequence.Length) { //zapamiętaj najdłuższą
                                longestSequence = prot.peptideSequence;
                                longestInFrame = frameShift;
                                longestID = tempID;
                            }
                            richTextBox_tabDNA_DNAview.AppendText(tempID + Environment.NewLine);
                            richTextBox_tabDNA_DNAview.AppendText(prot.peptideSequence + Environment.NewLine);
                            protCounterInFrame++;
                        }
                        richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                    }
                }
                richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText("Najdłuższa sekwencja (przesunięcie: +" + longestInFrame + ")" + Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(longestID + Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(longestSequence + Environment.NewLine);
            } else { //wybrana ramka
                string longestSequence = "";
                string longestID = "";

                if (radioButton_tabDNA_5to3.Checked || radioButton_tabDNA_BothDirections.Checked) { //5'->3' lub oba kierunki
                    if (checkBox_tabDNA_realProteins.Checked) {
                        type = "_PROT5to3_";
                    } else {
                        type = "_AMINO5to3_";
                    }

                    List<ProteinFromDNA> lista = null;
                    if (checkBox_tabDNA_realProteins.Checked)
                        lista = abcEngine.GetCodedProteinsFromDNA(DNAid, DNAsequence, shiftLevel, true);
                    else
                        lista = abcEngine.GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shiftLevel, true);

                    int protCounterInFrame = 0;
                    foreach (ProteinFromDNA prot in lista) {
                        string tempID = DNAid + type + "orf" + prot.shiftLevel + "_size" + prot.peptideSeqLength + "_#" + protCounterInFrame;

                        if (prot.peptideSequence.Length > longestSequence.Length) { //zapamiętaj najdłuższą
                            longestSequence = prot.peptideSequence;
                            longestID = tempID;
                        }
                        richTextBox_tabDNA_DNAview.AppendText(tempID + Environment.NewLine);
                        richTextBox_tabDNA_DNAview.AppendText(prot.peptideSequence + Environment.NewLine);
                        protCounterInFrame++;
                    }
                }

                if (radioButton_tabDNA_3to5.Checked || radioButton_tabDNA_BothDirections.Checked) { //5'->3' lub oba kierunki
                    if (checkBox_tabDNA_realProteins.Checked) {
                        type = "_PROT3to5_";
                    } else {
                        type = "_AMINO3to5_";
                    }

                    List<ProteinFromDNA> lista = null;
                    if (checkBox_tabDNA_realProteins.Checked)
                        lista = abcEngine.GetCodedProteinsFromDNA(DNAid, DNAsequence, shiftLevel, false);
                    else
                        lista = abcEngine.GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shiftLevel, false);

                    int protCounterInFrame = 0;
                    foreach (ProteinFromDNA prot in lista) {
                        string tempID = DNAid + type + "orf" + prot.shiftLevel + "_size" + prot.peptideSeqLength + "_#" + protCounterInFrame;

                        if (prot.peptideSequence.Length > longestSequence.Length) { //zapamiętaj najdłuższą
                            longestSequence = prot.peptideSequence;
                            longestID = tempID;
                        }
                        richTextBox_tabDNA_DNAview.AppendText(tempID + Environment.NewLine);
                        richTextBox_tabDNA_DNAview.AppendText(prot.peptideSequence + Environment.NewLine);
                        protCounterInFrame++;
                    }
                }
                richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText("Najdłuższa sekwencja: " + Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(longestID + Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(longestSequence + Environment.NewLine);
            }
            if (checkBox_tabDNA_ShowAlsoDNA.Checked) {
                richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(DNAid + Environment.NewLine);
                richTextBox_tabDNA_DNAview.AppendText(DNAsequence + Environment.NewLine);
            }
        }

        /// <summary>
        /// Dodaje do RichTextBox sekwencję białkową w kolorze.
        /// </summary>
        /// <param name="peptideSequence">sekwencja białkowa do wyświetlenia</param>
        private void tab01_AddColoredPeptide(string peptideSequence) {
            Color background = richTextBox_tabDNA_DNAview.SelectionBackColor;
            Font selectionFont = richTextBox_tabDNA_DNAview.SelectionFont;

            char[] seqTmp = peptideSequence.ToCharArray();
            string space = " ";
            bool decodeTrigger = false;
            int stop = 0;
            for (int i = 0; i < seqTmp.Length; i++) {
                string sign = "" + seqTmp[i];
                if (decodeTrigger == false && seqTmp[i] == 'M') {
                    richTextBox_tabDNA_DNAview.SelectionBackColor = Color.Red;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);

                    decodeTrigger = true;
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else if (decodeTrigger == true && seqTmp[i] == '*') {
                    richTextBox_tabDNA_DNAview.SelectionBackColor = background;
                    decodeTrigger = false;

                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    stop++;
                    richTextBox_tabDNA_DNAview.AppendText("STOP" + stop + space);
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else if (seqTmp[i] == '*') {
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    stop++;
                    richTextBox_tabDNA_DNAview.AppendText("STOP" + stop + space);
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else if (seqTmp[i] == 'X') {
                    Color back1 = richTextBox_tabDNA_DNAview.SelectionBackColor;
                    richTextBox_tabDNA_DNAview.SelectionBackColor = Color.Green;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);

                    richTextBox_tabDNA_DNAview.SelectionBackColor = back1;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else {
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);
                }
            }
            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);
            richTextBox_tabDNA_DNAview.SelectionBackColor = background;
            richTextBox_tabDNA_DNAview.SelectionFont = selectionFont;
        }

        /// <summary>
        /// Dodaje do RichTextBox sekwencję białkową w kolorze.
        /// </summary>
        /// <param name="aminoSequence">sekwencja białkowa do wyświetlenia</param>
        private void tab01_AddColoredAmino(string aminoSequence) {
            Color background = richTextBox_tabDNA_DNAview.SelectionBackColor;
            Font selectionFont = richTextBox_tabDNA_DNAview.SelectionFont;
            Color selectionColor = richTextBox_tabDNA_DNAview.SelectionColor;

            char[] seqTmp = aminoSequence.ToCharArray();
            string space = " ";
            int stop = 0;
            for (int i = 0; i < seqTmp.Length; i++) {
                string sign = "" + seqTmp[i];

                if (seqTmp[i] == '*') {
                    richTextBox_tabDNA_DNAview.SelectionBackColor = Color.Red;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    stop++;
                    richTextBox_tabDNA_DNAview.AppendText("STOP" + stop + space);
                    richTextBox_tabDNA_DNAview.SelectionBackColor = background;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else if (seqTmp[i] == 'M') {
                    richTextBox_tabDNA_DNAview.SelectionColor = Color.Red;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);
                    richTextBox_tabDNA_DNAview.SelectionColor = selectionColor;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else if (seqTmp[i] == 'X') {
                    Color back1 = richTextBox_tabDNA_DNAview.SelectionBackColor;
                    richTextBox_tabDNA_DNAview.SelectionBackColor = Color.Green;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);

                    richTextBox_tabDNA_DNAview.SelectionBackColor = back1;
                    richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Regular);
                } else {
                    richTextBox_tabDNA_DNAview.AppendText(sign + space);
                }
            }
            richTextBox_tabDNA_DNAview.AppendText(Environment.NewLine);

            richTextBox_tabDNA_DNAview.SelectionBackColor = background;
            richTextBox_tabDNA_DNAview.SelectionFont = selectionFont;
            richTextBox_tabDNA_DNAview.SelectionColor = selectionColor;
        }

        /// <summary>
        /// Dodaje tekst boldem do richTextBox_tab1_DNAview.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newLine"></param>
        private void addBoldText(string text, bool newLine) {
            Font backup = richTextBox_tabDNA_DNAview.SelectionFont;
            richTextBox_tabDNA_DNAview.SelectionFont = new Font(richTextBox_tabDNA_DNAview.Font, FontStyle.Bold);
            if (newLine)
                richTextBox_tabDNA_DNAview.AppendText(text + Environment.NewLine);
            else
                richTextBox_tabDNA_DNAview.AppendText(text);
            richTextBox_tabDNA_DNAview.SelectionFont = backup;
        }

        /// <summary>
        /// Odświeża RichTextBox danymi z sekwencji DNA wybranej aktualnie w ComboBox (jeśli jakaś w ogóle).
        /// </summary>
        private void showDNAdataOnComboBoxSelection() {
            if (comboDNAOffline == false && dataDNAread == true) {
                int selected = comboBox_tabDNA_DNAlist.SelectedIndex;
                if (selected < 0)
                    return;

                tab01_ShowDNAandProteinsData(mainDB_DNAsequences.Keys.ToArray()[selected], mainDB_DNAsequences.Values.ToArray()[selected]);
            }
        }
    }
}
