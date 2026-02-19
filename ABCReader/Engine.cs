using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ABCReader {
    public class Engine {
        /// <summary>
        /// Wczytuje plik multi-fasta do słownika programu.
        /// </summary>
        /// <param name="path">pełna ścieżka do pliku fasta</param>
        /// <returns>Dictionary<string, string> - identyfikator i sekwencja</returns>
        public Dictionary<string, string> LoadDNAFastaFile(string path) {
            Dictionary<string, string> slownik = new Dictionary<string, string>();
            Random rnd = new Random();
            try {
                string[] lines = System.IO.File.ReadAllLines(path);
                int linesNumber = lines.Length;
                for (int i = 0; i < linesNumber; i++) {
                    string line = lines[i];
                    if (i + 1 >= linesNumber)
                        break;

                    if (line.Contains(">")) {
                        string sequence = "";
                        while (i < linesNumber) {
                            i++;
                            sequence += lines[i];
                            if (i + 1 >= linesNumber)
                                break;
                            if (lines[i + 1].Contains(">"))
                                break;
                        }

                        if (slownik.ContainsKey(line)) {
                            slownik.Add(line + "_" + rnd.Next(100000), sequence);
                        }
                        else {
                            slownik.Add(line, sequence);
                        }
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return slownik;
        }

        /// <summary>
        /// Wczytuje plik fasta z sekwencjami DNA.
        /// </summary>
        /// <param name="path">Ścieżka dostępu do pliku.</param>
        /// <returns>Lista podwójnych ciągów znaków ID oraz sekwencja.</returns>
        public List<string[]> LoadFastaFile_DNA(string path) {
            try {
                string[] lines = System.IO.File.ReadAllLines(path);

                List<string[]> result = new List<string[]>();

                string sequence = "";
                string sID = "";
                int counter = -1;
                int linesRead = 0;
                foreach (string line in lines) {
                    linesRead++;
                    if ((line.Contains(">") && counter > -1)) {
                        string[] tuple = new string[2];
                        tuple[0] = sID;
                        tuple[1] = sequence;
                        result.Add(tuple);

                        sID = line;
                        counter++;
                        sequence = "";
                    } else if (line.Contains(">")) {
                        sID = line;
                        counter++;
                    } else {
                        sequence += line;
                        if (linesRead >= lines.Length) { //ostatnia linia
                            string[] tuple = new string[2];
                            tuple[0] = sID;
                            tuple[1] = sequence;
                            result.Add(tuple);

                           // break; //w sumie niepotrzebne, ale...
                        }
                    }
                }

                return result;
            } catch (Exception exc) {
                Form1.guiManager.AddLogLineEnter("Błąd: "+exc.Message, Form1.LogType.ERROR);
                return new List<string[]>(); //empty
            }

        }

        /// <summary>
        /// Zwraca listę wszystkich sekwencji aminokwasowych z DNA rozdzialonych kodonem STOP
        /// </summary>
        /// <param name="DNAid">identyfikator sekwencji DNA do dekodowania</param>
        /// <param name="DNAsequence">sekwencja DNA do dekodowania</param>
        /// <param name="shiftLevel">poziom przesunięcia ramki</param>
        /// <param name="order53">true jeśli sekwencja ma być dekodowana od 5' do 3'</param>
        /// <returns>lista sekwencji aminokwasowych rozdzielanych (tylko) kodonem STOP</returns>
        public List<ProteinFromDNA> GetAllAminoSequencesFromDNA(string DNAid, string DNAsequence, int shiftLevel, bool order53) {
            List<ProteinFromDNA> list = new List<ProteinFromDNA>();

            string cutSequence = "";
            if (order53) {
                cutSequence = DNAsequence.Substring(shiftLevel);
            } else {
                cutSequence = Ribosome.GetComplementaryDNA(DNAsequence, true).Substring(shiftLevel);
            }

            char[] proteinsSeq = Ribosome.DNAToAminoAcid(cutSequence).ToCharArray();
            string protSeqString = "";
            int size = 0;
            int start = 0;
            for (int i = 0; i < proteinsSeq.Length; i++) {
                protSeqString += proteinsSeq[i];
                size++;

                if (proteinsSeq[i] == '*') { //stop kodon
                    ProteinFromDNA amino = new ProteinFromDNA((start * 3) + 1 + shiftLevel, false, true, order53, size, DNAsequence, DNAid, protSeqString, shiftLevel);
                    list.Add(amino);

                    size = 0;
                    protSeqString = "";
                    start = i + 1;
                } else if (i + 1 == proteinsSeq.Length) {
                    ProteinFromDNA amino = new ProteinFromDNA((start * 3) + 1 + shiftLevel, false, false, order53, size, DNAsequence, DNAid, protSeqString, shiftLevel);
                    list.Add(amino);
                }
            }
            return list;
        }

        /// <summary>
        /// Zwraca listę wszystkich sekwencji białkowych z DNA rozdzialonych kodonem STOP, zaczynających się od Metioniny
        /// </summary>
        /// <param name="DNAid">identyfikator sekwencji DNA do dekodowania</param>
        /// <param name="DNAsequence">sekwencja DNA do dekodowania</param>
        /// <param name="shiftLevel">poziom przesunięcia ramki</param>
        /// <param name="order53">true jeśli sekwencja ma być dekodowana od 5' do 3'</param>
        /// <returns>lista sekwencji białkowych od Met do STOP</returns>
        public List<ProteinFromDNA> GetCodedProteinsFromDNA(string DNAid, string DNAsequence, int shiftLevel, bool order53) {
            List<ProteinFromDNA> list = new List<ProteinFromDNA>();

            string cutSequence = "";
            if (order53) {
                cutSequence = DNAsequence.Substring(shiftLevel);
            } else {
                cutSequence = Ribosome.GetComplementaryDNA(DNAsequence, true).Substring(shiftLevel);
            }

            //string cutSequence = DNAsequence.Substring(shiftLevel);
            char[] proteinsSeq = Ribosome.DNAToAminoAcid(cutSequence).ToCharArray();
            string protSeqString = "";
            int size = 0;
            int start = 0;

            bool startTrigger = false;
            for (int i = 0; i < proteinsSeq.Length; i++) {
                if (proteinsSeq[i] == 'M') {

                    if (startTrigger == false) {
                        startTrigger = true;
                        start = i * 3;
                        size = 0;
                        protSeqString = "";
                    }
                }

                if (startTrigger) {
                    protSeqString += proteinsSeq[i];
                    size++;

                    if (proteinsSeq[i] == '*') { //stop kodon
                        startTrigger = false;

                        ProteinFromDNA amino = new ProteinFromDNA((start + 1)+ shiftLevel, true, true, order53, size, DNAsequence, DNAid, protSeqString, shiftLevel);
                        list.Add(amino);
                    } else if (i + 1 == proteinsSeq.Length) { //koniec sekwencji
                        startTrigger = false;
                        ProteinFromDNA amino = new ProteinFromDNA((start + 1) + shiftLevel, true, false, order53, size, DNAsequence, DNAid, protSeqString, shiftLevel);
                        list.Add(amino);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="DNAsequences"></param>
        /// <param name="realProteins"></param>
        public void SaveAminoAcids(string fileName, Dictionary<string, string> DNAsequences, bool realProteins) {
            try {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);
                List<ProteinFromDNA> lista = null;
                int protNumber = 0;
                string tag = "";
                foreach (KeyValuePair<string, string> entry in DNAsequences) {
                    if (realProteins) {
                        lista = GetCodedProteinsFromDNA(entry.Key, entry.Value, 0, true);

                        tag = "aminoSeq";
                    }
                    else {
                        lista = GetAllAminoSequencesFromDNA(entry.Key, entry.Value, 0, true);
                        tag = "protSeq";
                    }
                    protNumber = 0;
                    foreach (ProteinFromDNA prot in lista) {
                        protNumber++;
                        writer.WriteLine(entry.Key + "_#" + protNumber + "_" + tag + "_size_" + prot.peptideSeqLength + "_start_" + prot.startingNucleotide);
                        writer.WriteLine(prot.peptideSequence);
                    }
                }
                writer.Close();
            }
            catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Błąd: " + e.Message, Form1.LogType.ERROR);
                MessageBox.Show(e.Message);
            }
        }


        /// <summary>
        /// Zwraca zbiorczą listę aminokwasów / białek dla przesunięć ramki odczytu 0, 1 i 2
        /// </summary>
        /// <param name="DNAid">identyfikator sekwencji DNA do dekodowania</param>
        /// <param name="DNAsequence">sekwencja DNA do dekodowania</param>
        /// <param name="realProts">true - prawdziwe białka od Met -> STOP</param>
        /// <param name="order">+1 : 5'->3'; -1 : 3'->5'; 0 lub inne: oba kierunki odczytu</param>
        /// <returns></returns>
        private List<ProteinFromDNA> getAllProteinsWithShifts(string DNAid, string DNAsequence, bool realProts, int order) {
            List<ProteinFromDNA> results = new List<ProteinFromDNA>();

            if (order == 1) { //5'->3'
                for (int shift = 0; shift < 3; shift++) {
                    if (realProts)
                        results.AddRange(GetCodedProteinsFromDNA(DNAid, DNAsequence, shift, true));
                    else
                        results.AddRange(GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shift, true));
                }
            } else if (order == -1) { //3'->5'
                for (int shift = 0; shift < 3; shift++) {
                    DNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
                    if (realProts)
                        results.AddRange(GetCodedProteinsFromDNA(DNAid, DNAsequence, shift, false));
                    else
                        results.AddRange(GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shift, false));
                }
            } else { //oba kierunki
                for (int shift = 0; shift < 3; shift++) {
                    if (realProts)
                        results.AddRange(GetCodedProteinsFromDNA(DNAid, DNAsequence, shift, true));
                    else
                        results.AddRange(GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shift, true));
                }

                DNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
                for (int shift = 0; shift < 3; shift++) {
                    DNAsequence = Ribosome.GetComplementaryDNA(DNAsequence, true);
                    if (realProts)
                        results.AddRange(GetCodedProteinsFromDNA(DNAid, DNAsequence, shift, false));
                    else
                        results.AddRange(GetAllAminoSequencesFromDNA(DNAid, DNAsequence, shift, false));
                }
            }
            return results;
        }

        /// <summary>
        /// Zapisuje do pliku dane białkowo-aminokwasowe z jednej, wskazanej sekwencji DNA.
        /// </summary>
        /// <param name="fileName">nazwa pliku do zapisu</param>
        /// <param name="DNAid">identyfikator sekwencji DNA do dekodowania</param>
        /// <param name="DNAsequence">sekwencja DNA do dekodowania</param>
        /// <param name="realProts">true - prawdziwe białka od Met -> STOP</param>
        /// <param name="onlyOne"></param>
        /// <param name="order">+1 : 5'->3'; -1 : 3'->5'; 0 lub inne: oba kierunki odczytu</param>
        public void SaveSingleProtInfo(string fileName, string DNAid, string DNAsequence, bool realProts, bool onlyOne, int order) {
            try {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);
                List<ProteinFromDNA> lista = getAllProteinsWithShifts(DNAid, DNAsequence, realProts, order);

                int protNumber = 0;
                int lastShift = -1;

                writer.WriteLine(DNAid);
                writer.WriteLine(DNAsequence);

                foreach (ProteinFromDNA prot in lista) {
                    if (lastShift == -1)
                        lastShift = prot.shiftLevel;

                    if(lastShift != prot.shiftLevel) {
                        protNumber = 0;
                        lastShift = prot.shiftLevel;
                    }
                    string stopCodonTag = "";
                    if (prot.codonStop == false)
                        stopCodonTag = "_NO_STOP_CODON_WARNING";
                    else
                        stopCodonTag = "";

                    string ID = GetProteinTag(prot.DNAseqID, realProts, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, prot.startingNucleotide,
                                    protNumber, stopCodonTag);

                   // string ID = DNAid + "_" + typeTag + "_" + orderTag + "_ramka+" + lastShift + "_dlugosc:" + prot.aminoSize + 
                   //     "_startN:" + prot.startingNucleotide + "_#" + protNumber + stopCodonTag;
                    writer.WriteLine(ID);
                    writer.WriteLine(prot.peptideSequence);
                    protNumber++;
                }

                writer.Close();
            }
            catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Błąd: " + e.Message, Form1.LogType.ERROR);
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Tworzy słownik białek / sekwencji aminokwasowych na podstawie listy sekwencji DNA i parametrów
        /// </summary>
        /// <param name="daneFasta">słownik sekwencji DNA</param>
        /// <param name="onlyRealProteins">true - tylko białka zaczynające się od MET</param>
        /// <param name="onlyWithSTOPcodon">true - tylko białka zakończone kodonem STOP</param>
        /// <param name="onlyOneLongestSequence">true - tylko 1 najdłuższa sekwencja na łańcuch DNA</param>
        /// <param name="allAboveMinLength">true - wszystkie z sekwencji DNA powyżej pewnej długości</param>
        /// <param name="minimumSeqLength">długość minimalnej dopuszczalnej sekwencji</param>
        /// <param name="order">długość minimalnej dopuszczalnej sekwencji</param>
        /// <param name="progressBar">obiekt paska postępu</param>
        /// <param name="update">true - update paska postępu</param>
        /// <returns></returns>
        public Dictionary<string, ProteinFromDNA> getAllProteinsFromDNA(Dictionary<string, string> daneFasta, bool onlyRealProteins,
            bool onlyWithSTOPcodon, bool onlyOneLongestSequence, bool allAboveMinLength, int minimumSeqLength, int order,
            ToolStripProgressBar progressBar, bool update) {

            Dictionary<string, ProteinFromDNA> proteinsDB = new Dictionary<string, ProteinFromDNA>();

            Random rnd = new Random();
            try {
                int counter = -1;
                foreach (KeyValuePair<string, string> entry in daneFasta) {
                    counter++;
                    Application.DoEvents();
                    List<ProteinFromDNA> peptidesList = getAllProteinsWithShifts(entry.Key, entry.Value, onlyRealProteins, order);

                    if (onlyOneLongestSequence) { //tylko białka: od Met do STOP
                        int longestSoFar = 0;
                        string longestID = "";
                        ProteinFromDNA longestProt = null;
                        foreach (ProteinFromDNA prot in peptidesList) {
                            if (onlyWithSTOPcodon && prot.codonStop == false) //czy jest kodon STOP
                                continue;

                            if (prot.peptideSeqLength < minimumSeqLength) // sprawdź minimalną długość
                                continue;

                            if (prot.peptideSeqLength > longestSoFar) {
                                longestSoFar = prot.peptideSeqLength;

                                longestID = GetProteinTag(prot.DNAseqID, onlyRealProteins, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, 
                                    prot.startingNucleotide, counter, "");
                                longestProt = prot;
                            }
                        }

                        if (longestSoFar > 0) {  //dodaj najdłuższe do listy zapisu:
                            if(proteinsDB.ContainsKey(longestID)) {
                                longestID += "_" + rnd.Next(1000000);
                            }
                            proteinsDB.Add(longestID, longestProt);
                        }

                    } else { //wszystkie sekwencje aminokwasowe
                        foreach (ProteinFromDNA prot in peptidesList) {
                            if (onlyWithSTOPcodon && prot.codonStop == false)   //czy jest kodon STOP
                                continue;

                            if (prot.peptideSeqLength < minimumSeqLength) // sprawdź minimalną długość
                                continue;

                            string protID = GetProteinTag(prot.DNAseqID, onlyRealProteins, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, 
                                prot.startingNucleotide, counter, "");

                            if (proteinsDB.ContainsKey(protID)) {
                                protID += "_" + rnd.Next(1000000);
                            }
                            proteinsDB.Add(protID, prot);
                        }
                    }
                    if (update)
                        progressBar.Value++;
                }
            } catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Błąd konwersji sekwencji:" + e.Message, Form1.LogType.ERROR);
                MessageBox.Show("Błąd konwersji sekwencji." + e.Message);
                return proteinsDB;
            }
            return proteinsDB;
        }

        /// <summary>
        /// Zapis sekwencji białkowych do pliku XML (pełen pakiet danych).
        /// </summary>
        /// <param name="fileName">Ścieżka dostępu do pliku.</param>
        /// <param name="daneBialek">Słownik białek (string, ProteinFromDNA).</param>
        public void SaveXMLproteins(string fileName, Dictionary<string, ProteinFromDNA> daneBialek, List<string> ignoredSequences_tabProt) {

            string currentID = "";
            try {
                string[] currentFile = getFileNameInfo(fileName);
                fileName = currentFile[2] + currentFile[0] + ".xml";

                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                foreach (KeyValuePair<string, ProteinFromDNA> entry in daneBialek) {
                    currentID = entry.Key;
                    writer.WriteLine("<UniqKey:"+entry.Key+">");
                    writer.WriteLine("   <DNA_ID:" + entry.Value.DNAseqID + ">");
                    writer.WriteLine("   <ProtID:" + entry.Value.lvl2_proteinID + ">");
                    writer.WriteLine("   <ProtSize:" + entry.Value.peptideSeqLength + ">");
                    writer.WriteLine("   <CodDNASize:" + entry.Value.lvl2_DNAcodingSequenceSize + ">");

                    writer.WriteLine("   <CodonStart:" + entry.Value.codonStart + ">");
                    writer.WriteLine("   <CodonStop:" + entry.Value.codonStop + ">");
                    writer.WriteLine("   <FrameShift:" + entry.Value.shiftLevel + ">");
                    writer.WriteLine("   <StartingN:" + entry.Value.startingNucleotide + ">");
                    writer.WriteLine("   <Order5_3:" + entry.Value._5to3 + ">");
                    writer.WriteLine("   <ProtSeq:" + entry.Value.peptideSequence + ">");
                    writer.WriteLine("   <DNASeq:" + entry.Value.DNAsequence + ">");
                    writer.WriteLine("   <CodingSeq:" + entry.Value.lvl2_DNAcodingSequence + ">");

                    if(ignoredSequences_tabProt.Contains(entry.Key)) {
                        writer.WriteLine("   <Ignored:yes>");
                    } else {
                        writer.WriteLine("   <Ignored:no>");
                    }

                    writer.WriteLine("</UniqKey>");
                }
                writer.WriteLine("<END_OF_FILE>");
                writer.Close();

            } catch (Exception exc) {
                Form1.guiManager.AddLogLineEnter("Krytyczny błąd zapisu danych XML dla sekwencji: "+currentID, Form1.LogType.ERROR);
                Form1.guiManager.AddLogLineEnter(exc.Message, Form1.LogType.ERROR);
                MessageBox.Show("Krytyczny błąd zapisu danych XML dla sekwencji: " + currentID);
            }

        }

        /// <summary>
        /// Wczytywanie wszystkich danych (DNA i białka) z pliku XML białek.
        /// </summary>
        /// <param name="fileName">Ścieżka dostępu do pliku.</param>
        /// <returns>Słownik białek (string, ProteinFromDNA).</returns>
        public Dictionary<string, ProteinFromDNA> LoadXMLproteins(string fileName, out List<string> ignoredSequences_tabProt) {
            Dictionary<string, ProteinFromDNA> slownik = new Dictionary<string, ProteinFromDNA>();
            ignoredSequences_tabProt = new List<string>();
            try {
                string[] lines = System.IO.File.ReadAllLines(fileName);

                ProteinFromDNA protein = null;
                string ID = "";
                List<string> entryLines = null;
                for (int i = 0; i < lines.Length; i++) {
                    if(lines[i].Contains("<UniqKey:")) {
                        entryLines = new List<string>();
                        ID = lines[i].Substring(lines[i].IndexOf(":>")+1);
                        ID = ID.Substring(0, ID.LastIndexOf(">"));
                        i++;
                        while(lines[i].Contains("</UniqKey>") == false) {
                            entryLines.Add(lines[i]);
                            i++;
                        }

                        int startN = -1;
                        bool codonStop = false;
                        bool codonStart = false;
                        bool order53 = false;
                        int aminoSeqSize = -1;
                        string DNAseq = "";
                        string DNAid = "";
                        string protSeq = "";
                        int shift = -1;
                        //poza konstruktorem:
                        int lvl2_codingDNASize = -1;
                        string lvl2_codingDNAseq = "";
                        string lvl2_protID = "";


                        foreach (string entry in entryLines) {
                            if (entry.Contains("<DNA_ID:")) {
                                DNAid = entry.Substring(entry.IndexOf(":")+1);
                                DNAid = DNAid.Substring(0, DNAid.LastIndexOf(">"));
                            } else if (entry.Contains("<ProtID:")) {
                                lvl2_protID = entry.Substring(entry.IndexOf(":")+1);
                                lvl2_protID = lvl2_protID.Substring(0, lvl2_protID.LastIndexOf(">"));
                            } else if (entry.Contains("<ProtSize:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                aminoSeqSize = Convert.ToInt32(tmp);
                            } else if (entry.Contains("<CodDNASize:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                lvl2_codingDNASize = Convert.ToInt32(tmp);
                            } else if (entry.Contains("<CodonStart:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                codonStart = Convert.ToBoolean(tmp);
                            } else if (entry.Contains("<CodonStop:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                codonStop = Convert.ToBoolean(tmp);
                            } else if (entry.Contains("<FrameShift:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                shift = Convert.ToInt32(tmp);
                            } else if (entry.Contains("<StartingN:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                startN = Convert.ToInt32(tmp);
                            } else if (entry.Contains("<Order5_3:")) {
                                string tmp = entry.Substring(entry.IndexOf(":") + 1);
                                tmp = tmp.Substring(0, tmp.LastIndexOf(">"));
                                order53 = Convert.ToBoolean(tmp);
                            } else if (entry.Contains("<ProtSeq:")) {
                                protSeq = entry.Substring(entry.IndexOf(":") + 1);
                                protSeq = protSeq.Substring(0, protSeq.LastIndexOf(">"));
                            } else if (entry.Contains("<DNASeq:")) {
                                DNAseq = entry.Substring(entry.IndexOf(":") + 1);
                                DNAseq = DNAseq.Substring(0, DNAseq.LastIndexOf(">"));
                            } else if (entry.Contains("<CodingSeq:")) {
                                lvl2_codingDNAseq = entry.Substring(entry.IndexOf(":") + 1);
                                lvl2_codingDNAseq = lvl2_codingDNAseq.Substring(0, lvl2_codingDNAseq.LastIndexOf(">"));
                            } else if (entry.Contains("<Ignored:yes>")) {
                                if(lvl2_protID.Length > 1)
                                    ignoredSequences_tabProt.Add(lvl2_protID);
                            }
                        }
                        protein = new ProteinFromDNA(startN, codonStart, codonStop, order53, aminoSeqSize, DNAseq, DNAid, protSeq, shift);
                        protein.lvl2_DNAcodingSequenceSize = lvl2_codingDNASize;
                        protein.lvl2_DNAcodingSequence = lvl2_codingDNAseq;
                        protein.lvl2_proteinID = lvl2_protID;
                        slownik.Add(ID, protein);
                        i--; 
                    }

                }
            } catch (Exception exc) {
                Form1.guiManager.AddLogLineEnter("Krytyczny błąd wczytywania danych do programu.", Form1.LogType.ERROR);
                Form1.guiManager.AddLogLineEnter(exc.Message, Form1.LogType.ERROR);
                return null;
            }
            return slownik;
        }
        /*
        x public int startingNucleotide = -1;  
        x public bool codonStart = false;
        x public bool codonStop = false;
        x public bool _5to3 = true;
        x public int aminoSize = 0;
        x public string DNAseq = "";
        x public string DNAid = "";
        x public string aminoSequence = "";
        x public int shiftLevel = 0;

        public string lvl1_codingSequence = "";
        x public string lvl2_protID = "";
        public List<int> lvl2_mainHistogram = null;
        public double lvl2_avgHistValue = 999999.99;
        public int lvl2_codingSeqSize = 0;
         */

        /// <summary>
        /// Zapis do pliku sekwencji amino-białkowych ze wszystkich sekwencji DNA.
        /// </summary>
        /// <param name="saveFileName">nazwa pliku z danymi DNA - będzie przerobiony na plik wyjściowy (pod inną nazwą)</param>
        /// <param name="daneFasta">słownik sekwencji DNA</param>
        /// <param name="onlyRealProteins">true - tylko białka zaczynające się od MET</param>
        /// <param name="onlyWithSTOPcodon">true - tylko białka zakończone kodonem STOP</param>
        /// <param name="onlyOneLongestSequence">true - tylko 1 najdłuższa sekwencja na łańcuch DNA</param>
        /// <param name="allAboveMinLength">true - wszystkie z sekwencji DNA powyżej pewnej długości</param>
        /// <param name="minimumSeqLength">długość minimalnej dopuszczalnej sekwencji</param>
        /// <param name="order">+1 : 5'->3'; -1 : 3'->5'; 0 lub inne: oba kierunki odczytu</param>
        /// <param name="progressBar">obiekt paska postępu</param>
        /// <param name="update">true - update paska postępu</param>
        /// <param name="DNAfileAlso">true - zapisuje także plik sekwencji dokujących białka (DNA)</param>
        public void SaveAllProteinsFromDNAFasta(string saveFileName, Dictionary<string, string> daneFasta, bool onlyRealProteins,
            bool onlyWithSTOPcodon, bool onlyOneLongestSequence, bool allAboveMinLength, int minimumSeqLength, int order,
            ProgressBar progressBar, bool update, bool DNAfileAlso) {

            string newSaveName = saveFileName + "_result.txt"; //for safety - zapamiętaj od razu nową nazwę
            string newSaveDNAname = saveFileName + "_resultDNA.txt";
            try {
                int sep = saveFileName.LastIndexOf("\\") + 1;
                string fileName = saveFileName.Substring(sep);
                string path = saveFileName.Substring(0, sep);

                sep = fileName.IndexOf(".");
                fileName = fileName.Substring(0, sep);
                newSaveDNAname = fileName + "_resultDNA.fasta";

                fileName = fileName + "_result.fasta";

                newSaveName = path + fileName;
                newSaveDNAname = path + newSaveDNAname;
            } catch (Exception e) {
                MessageBox.Show("Błąd konwersji nazwy pliku. Użycie nazwy domyślnej (+.txt)" + Environment.NewLine + e.Message);
            }

            List<String> saveBuffer = new List<string>();
            Dictionary<string, ProteinFromDNA> slownikZapisu = new Dictionary<string, ProteinFromDNA>();
            try {
                foreach (KeyValuePair<string, string> entry in daneFasta) {
                    int counter = -1;
                    Application.DoEvents();
                    List<ProteinFromDNA> peptidesList = getAllProteinsWithShifts(entry.Key, entry.Value, onlyRealProteins, order);

                    if (onlyOneLongestSequence) { //tylko białka: od Met do STOP
                        int longestSoFar = 0;
                        string longestID = "";
                        string longestSeq = "";
                        ProteinFromDNA longestProt = null;
                        foreach (ProteinFromDNA prot in peptidesList) {
                            counter++;
                            if (onlyWithSTOPcodon && prot.codonStop == false) //czy jest kodon STOP
                                continue;

                            if (prot.peptideSeqLength < minimumSeqLength) // sprawdź minimalną długość
                                continue;

                            if(prot.peptideSeqLength > longestSoFar) {
                                longestSoFar = prot.peptideSeqLength;
                                longestID = GetProteinTag(prot.DNAseqID, onlyRealProteins, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, 
                                    prot.startingNucleotide, counter, "");
                                longestSeq = prot.peptideSequence;
                                longestProt = prot;
                            }
                        }

                        if(longestSoFar > 0) {  //dodaj najdłuższe do listy zapisu:
                            saveBuffer.Add(longestID);
                            saveBuffer.Add(longestSeq);

                            slownikZapisu.Add(longestID, longestProt);
                        }
                    }
                    else {
                        foreach (ProteinFromDNA prot in peptidesList) {
                            if (onlyWithSTOPcodon && prot.codonStop == false)   //czy jest kodon STOP
                                continue;

                            if (prot.peptideSeqLength < minimumSeqLength) // sprawdź minimalną długość
                                continue;

                            string ID = GetProteinTag(prot.DNAseqID, onlyRealProteins, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, prot.startingNucleotide,
                                    counter, "");

                            //saveBuffer.Add(prot.DNAid + "_PROT_(shift:+" + prot.shiftLevel + ")_(size:" + prot.aminoSize + ")");
                            saveBuffer.Add(ID);
                            saveBuffer.Add(prot.peptideSequence);

                            slownikZapisu.Add(ID, prot);
                        }
                    }

                    if(update)
                        progressBar.Value++;
                }
            } catch (Exception e) {
                MessageBox.Show("Błąd konwersji sekwencji. "+e.Message);
                return;
            }

            int licznik = 0;
            try {
                FileStream fileStream = new FileStream(newSaveName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                foreach(string line in saveBuffer) {
                    writer.WriteLine(line);
                    licznik++;
                }

                writer.Close();
            } catch (Exception e) {
                MessageBox.Show("Błąd zapisu do pliku:" + Environment.NewLine + newSaveName
                    + Environment.NewLine + e.Message);
                return;
            }

            if (DNAfileAlso) {
                try {
                    FileStream fileStream = new FileStream(newSaveDNAname, FileMode.Create);
                    StreamWriter writer = new StreamWriter(fileStream);

                    foreach (KeyValuePair<string, ProteinFromDNA> entry in slownikZapisu) {
                        writer.WriteLine(entry.Key);
                        string realSequence = getCodingSequence(entry.Value);
                        writer.WriteLine(realSequence);
                    }
                    writer.Close();
                } catch (Exception) {

                }
            }

            if (update)
                MessageBox.Show("Zapis zakończony powodzeniem. Zapisano "+(licznik / 2)+" sekwencji");
        }

        public string GetStandardID(ProteinFromDNA prot) {
            string ID = "";
            ID = GetProteinTag(prot.DNAseqID, true, prot._5to3, prot.shiftLevel, prot.peptideSeqLength, prot.startingNucleotide, 0, "");
            return ID;
        }

        /// <summary>
        /// Zwraca identyfikator sekwencji białkowej
        /// </summary>
        /// <param name="DNAid">ID sekwencji DNA</param>
        /// <param name="protAminType">true: białko Met->STOP</param>
        /// <param name="order">true: 5->3; false: 3->5</param>
        /// <param name="lastShift">przesunięcie ramki</param>
        /// <param name="protSize">długość białka</param>
        /// <param name="startingNucleo">początkowy nukleotyd w sekwencji</param>
        /// <param name="protNumber">numer porządkowy</param>
        /// <param name="other">inne</param>
        /// <returns></returns>
        private string GetProteinTag(string DNAid, bool protAminType, bool order, int lastShift, int protSize,
            int startingNucleo, int protNumber, string other) {
            string protAminTypeString = "PROT";
            if (protAminType == false)
                protAminTypeString = "AMINO";

            string orderTag = "53";
            if (order == false)
                orderTag = "35";

            string ID = DNAid + "_" + protAminTypeString + "_" + orderTag + "_orf" + lastShift + "_size" + protSize +
                        "_start" + startingNucleo + "_#" + protNumber + other;

            return ID;
        }

        internal int[] GetAminoNumbers(ProteinFromDNA proteinFromDNA) {
            int[] aminoArray = new int[23];
            Array.Clear(aminoArray, 0, aminoArray.Length);
            char[] seqTmp = proteinFromDNA.peptideSequence.ToCharArray();

            for(int i=0; i< seqTmp.Length; i++) {
                switch (seqTmp[i]) {
                    case 'A':
                        aminoArray[0]++;
                        break;
                    case 'C':
                        aminoArray[1]++;
                        break;
                    case 'D':
                        aminoArray[2]++;
                        break;
                    case 'E':
                        aminoArray[3]++;
                        break;
                    case 'F':
                        aminoArray[4]++;
                        break;
                    case 'G':
                        aminoArray[5]++;
                        break;
                    case 'H':
                        aminoArray[6]++;
                        break;
                    case 'I':
                        aminoArray[7]++;
                        break;
                    case 'K':
                        aminoArray[8]++;
                        break;
                    case 'L':
                        aminoArray[9]++;
                        break;
                    case 'M':
                        aminoArray[10]++;
                        break;
                    case 'N':
                        aminoArray[11]++;
                        break;
                    case 'P':
                        aminoArray[12]++;
                        break;
                    case 'Q':
                        aminoArray[13]++;
                        break;
                    case 'R':
                        aminoArray[14]++;
                        break;
                    case 'S':
                        aminoArray[15]++;
                        break;
                    case 'T':
                        aminoArray[16]++;
                        break;
                    case 'W':
                        aminoArray[17]++;
                        break;
                    case 'Y':
                        aminoArray[18]++;
                        break;
                    case 'V':
                        aminoArray[19]++;
                        break;
                    case '*':
                        aminoArray[21]++;
                        break;
                    default:
                        aminoArray[22]++;
                        break;
                }    
            }
            return aminoArray;
        }

        private string getCodingSequence(ProteinFromDNA prot) {
            string codingDNA = "XXXXXXXXXXXXXXX";

            try {
                int start = prot.startingNucleotide - 1;
                int aminoSize = prot.peptideSeqLength;
                string DNA = prot.DNAsequence;
                if (prot._5to3 == false) {
                    DNA = Ribosome.GetComplementaryDNA(DNA, true);
                }
                codingDNA = DNA.Substring(start, aminoSize * 3);
            } catch (Exception) {
                
            }
            return codingDNA;
        }

        /// <summary>
        /// Zapis do pliku sekwencji białkowych oraz opcjonalnie ich kodujących podsekwencji DNA
        /// </summary>
        /// <param name="fileName">nazwa pliku dla sekwencji białkowych</param>
        /// <param name="bialka">obiekt białka</param>
        /// <param name="DNAalso">true - zapisze także plik z sekwencją kodującą białko</param>
        public void SaveProteinsToFile(string fileName, Dictionary<string, ProteinFromDNA> bialka, bool DNAalso) {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            try {
                foreach (KeyValuePair<string, ProteinFromDNA> entry in bialka) {
                    string nameID = GetShortID(entry.Key);
                    writer.WriteLine(nameID);
                    writer.WriteLine(entry.Value.peptideSequence);
                }
            } catch (Exception) {

            }
            writer.Close();

            if (DNAalso) {
                try {
                    int sep = fileName.LastIndexOf("\\") + 1;
                    string newSaveName = fileName.Substring(sep);
                    string path = fileName.Substring(0, sep);

                    sep = fileName.IndexOf(".");
                    fileName = fileName.Substring(0, sep);
                    fileName = fileName + "_DNA.fasta";

                    newSaveName = path + fileName;

                    fileStream = new FileStream(fileName, FileMode.Create);
                    writer = new StreamWriter(fileStream);

                    foreach (KeyValuePair<string, ProteinFromDNA> entry in bialka) {
                        string nameID = GetShortID(entry.Key);
                        writer.WriteLine(nameID);
                        string realSequence = getCodingSequence(entry.Value);
                        writer.WriteLine(realSequence);
                    }
                    writer.Close();
                } catch (Exception) {
                    
                }
            }
        }

        


        /// <summary>
        /// Zwraca rozdzielone: ścieżkę do pliku [2], nazwę pliku bez rozszerzenia [0] i samo rozszerzenie [1].
        /// </summary>
        /// <param name="path">String - ścieżka do pliku.</param>
        /// <returns>Tablica string z 3 elementami.</returns>
        public static string[] getFileNameInfo(string path) {
            string[] file = new string[3];

            int index = path.LastIndexOf("\\") + 1;
            file[2] = path.Substring(0, index); //ścieżka do pliku
            file[0] = path.Substring(index); //nazwa pliku
            int dotSeparator = file[0].LastIndexOf(".");
            if (dotSeparator < 0) {
                file[1] = "";
            } else {
                file[1] = file[0].Substring(dotSeparator); // rozszerzenie
                file[0] = file[0].Substring(0, dotSeparator);
            }
            return file;
        }

        public static string GetShortID(string oldName) {
            string nameID = oldName;
            nameID = nameID.Substring(0, nameID.IndexOf("_start"));
            string tmp = nameID.Substring(nameID.IndexOf("_size") + 5);
            if (tmp.Length < 4) {
                int size = tmp.Length;
                for (int ii = 0; ii < 4 - size; ii++)
                    tmp = "0" + tmp;

                nameID = nameID.Substring(0, nameID.IndexOf("_size") + 5);
                nameID = nameID + tmp;
            }

            return nameID;
        }
    }
}
