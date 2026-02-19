using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ABCReader {
    public class BlastEngine {
        private static Engine abcEngine = null;

        public BlastEngine(Engine eng) {
            abcEngine = eng;
        }

        public List<BlastData> GetVector(ProteinFromDNA protein, string ID, int max_target_seqs, int max_hsps, string DBname, bool convert) {
            List<BlastData> listaDanych = new List<BlastData>();

            try {
                string path = Environment.CurrentDirectory + "\\blastwork\\";
                if (ID.Equals("")) {
                    ID = abcEngine.GetStandardID(protein);
                }

                bool success = false;
                using (StreamWriter writer = new StreamWriter(new FileStream(path + "queryProt.fasta", FileMode.Create))) {
                    writer.WriteLine(ID);
                    writer.WriteLine(protein.peptideSequence);
                    success = true;
                }
                if (!success) {
                    Form1.guiManager.AddLogLineEnter("Błąd zapisu danych dla Blasta, plik: " + path +
                        "queryProt.fasta nie mógł być zapisany.", Form1.LogType.ERROR);
                    return null;
                }

                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.FileName = path + "blastp.exe";
                proc.StartInfo.Arguments = "-db " + DBname + " -query queryProt.fasta " +
                    "-outfmt \"6 qseqid sseqid evalue score length pident nident mismatch qstart qend sstart send qcovhsp\" " +
                    "-max_target_seqs " + max_target_seqs + " -max_hsps " + max_hsps;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();

                string vector = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();
                proc.Close();
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = vector.Split(stringSeparators, StringSplitOptions.None);

                foreach (string line in lines) {
                    try {
                        string[] row = line.Split('\t');
                        if (row.Length != 13)
                            continue;

                        BlastData entry = new BlastData();
                        entry.qseqid = row[0];
                        entry.sseqid = row[1];

                        try {
                            entry.evalue = Convert.ToDouble(row[2]);
                            entry.score = Convert.ToDouble(row[3]);
                            entry.length = Convert.ToInt32(row[4]);
                            entry.pident = Convert.ToDouble(row[5]);
                            entry.nident = Convert.ToDouble(row[6]);
                            entry.mismatch = Convert.ToInt32(row[7]);
                            entry.qstart = Convert.ToInt32(row[8]);
                            entry.qend = Convert.ToInt32(row[9]);
                            entry.sstart = Convert.ToInt32(row[10]);
                            entry.send = Convert.ToInt32(row[11]);
                            entry.qcovhsp = Convert.ToDouble(row[12]);
                        }
                        catch (Exception ee1) {
                            entry.evalue = Convert.ToDouble(row[2].Replace(".", ","));
                            entry.score = Convert.ToDouble(row[3].Replace(".", ","));
                            entry.length = Convert.ToInt32(row[4]);
                            entry.pident = Convert.ToDouble(row[5].Replace(".", ","));
                            entry.nident = Convert.ToDouble(row[6].Replace(".", ","));
                            entry.mismatch = Convert.ToInt32(row[7]);
                            entry.qstart = Convert.ToInt32(row[8]);
                            entry.qend = Convert.ToInt32(row[9]);
                            entry.sstart = Convert.ToInt32(row[10]);
                            entry.send = Convert.ToInt32(row[11]);
                            entry.qcovhsp = Convert.ToDouble(row[12].Replace(".", ","));
                        }
                        
                        if(convert == true) {
                            //aaa
                        } else {
                            //aaa
                        }
                        
                        listaDanych.Add(entry);
                    } catch (Exception) {
                        Form1.guiManager.AddLogLineEnter("Błąd konwersji danych w programu Blast.", Form1.LogType.ERROR);
                        Form1.guiManager.AddLogLineEnter("Linia danych: " + line, Form1.LogType.ERROR);
                    }
                }
            } catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Nieokreślony błąd w działaniu BlastP.", Form1.LogType.ERROR);
                Form1.guiManager.AddLogLineEnter("Kod błędu: " + e.Message, Form1.LogType.ERROR);
                return null;
            }
            
            return listaDanych;
        }

        public Dictionary<string, BlastData> GetBlastData(Dictionary<string, ProteinFromDNA> proteins, int max_target_seqs, int max_hsps, string DBname) {
            Dictionary<string, BlastData> listaDanych = new Dictionary<string, BlastData>();

            try {
                string path = Environment.CurrentDirectory + "\\blastwork\\";
                List<string> checkListForBlast = new List<string>();

                bool success = false;
                using (StreamWriter writer = new StreamWriter(new FileStream(path + "queryProt.fasta", FileMode.Create))) {
                    foreach (KeyValuePair<string, ProteinFromDNA> entry in proteins) {
                        writer.WriteLine(entry.Key);
                        writer.WriteLine(entry.Value.peptideSequence);
                        checkListForBlast.Add(entry.Key);
                    }
                    success = true;
                }
                if (!success) {
                    Form1.guiManager.AddLogLineEnter("Błąd zapisu danych dla Blasta, plik: " + path +
                        "questionProt.fasta nie mógł być zapisany.", Form1.LogType.ERROR);
                    return null;
                }

                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.FileName = path + "blastp.exe";
                proc.StartInfo.Arguments = "-db " + DBname + " -query queryProt.fasta " +
                    "-outfmt \"6 qseqid sseqid evalue score length pident nident mismatch qstart qend sstart send qcovhsp\" " +
                    "-max_target_seqs " + max_target_seqs + " -max_hsps " + max_hsps;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();

                string vector = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();
                proc.Close();
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = vector.Split(stringSeparators, StringSplitOptions.None);

                foreach (string line in lines) {
                    try {
                        string[] row = line.Split('\t');
                        if (row.Length != 13)
                            continue;

                        string checkString = ">" + row[0];
                        checkListForBlast.Remove(checkString);

                        BlastData entry = new BlastData();
                        try {
                            entry.qseqid = ">" + row[0];
                            entry.sseqid = row[1];
                            entry.evalue = Convert.ToDouble(row[2]);
                            entry.score = Convert.ToDouble(row[3]);
                            entry.length = Convert.ToInt32(row[4]);
                            entry.pident = Convert.ToDouble(row[5]);
                            entry.nident = Convert.ToDouble(row[6]);
                            entry.mismatch = Convert.ToInt32(row[7]);
                            entry.qstart = Convert.ToInt32(row[8]);
                            entry.qend = Convert.ToInt32(row[9]);
                            entry.sstart = Convert.ToInt32(row[10]);
                            entry.send = Convert.ToInt32(row[11]);
                            entry.qcovhsp = Convert.ToDouble(row[12]);
                        } catch (Exception ee1) {
                            entry.qseqid = ">" + row[0];
                            entry.sseqid = row[1];
                            entry.evalue = Convert.ToDouble(row[2].Replace(".", ","));
                            entry.score = Convert.ToDouble(row[3].Replace(".", ","));
                            entry.length = Convert.ToInt32(row[4]);
                            entry.pident = Convert.ToDouble(row[5].Replace(".", ","));
                            entry.nident = Convert.ToDouble(row[6].Replace(".", ","));
                            entry.mismatch = Convert.ToInt32(row[7]);
                            entry.qstart = Convert.ToInt32(row[8]);
                            entry.qend = Convert.ToInt32(row[9]);
                            entry.sstart = Convert.ToInt32(row[10]);
                            entry.send = Convert.ToInt32(row[11]);
                            entry.qcovhsp = Convert.ToDouble(row[12].Replace(".", ","));
                        }

                        
                        listaDanych.Add(entry.qseqid, entry);
                    } catch (Exception) {
                        Form1.guiManager.AddLogLineEnter("Błąd konwersji danych w programu Blast.", Form1.LogType.ERROR);
                        Form1.guiManager.AddLogLineEnter("Linia danych: " + line, Form1.LogType.ERROR);
                    }
                }
                if (checkListForBlast.Count != 0) {
                    foreach (string s in checkListForBlast) {
                        Form1.guiManager.AddLogLineEnter("Brak wyniku z BlastP dla: " + s, Form1.LogType.MONIT);
                        BlastData entry = new BlastData();
                        entry.qseqid = s;
                        entry.sseqid = " --- NO MATCHING SEQUENCE ---";
                        listaDanych.Add(entry.qseqid, entry);
                    }
                }
            } catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Nieokreślony błąd w działaniu BlastP.", Form1.LogType.ERROR);
                Form1.guiManager.AddLogLineEnter("Kod błędu: " + e.Message, Form1.LogType.ERROR);
                return null;
            }
            
            return listaDanych;
        }


        public double EvaluateBlastNident(string seq1, string seq2) {
            double result = 0.0;

            bool clear1 = Ribosome.IsCleanDNA(seq1, true);
            bool clear2 = Ribosome.IsCleanDNA(seq2, true);

            if (seq1.Length < 3 || seq2.Length < 3)
                return -1.0;

            if (clear1 == false || clear2 == false) {
                Form1.guiManager.AddLogLineEnter("BlastN: Nieprawidłowe znaki w kodzie DNA. BlastN nie może zostać uruchomiony.", Form1.LogType.ERROR);
                return -1.0;
            }

            string path = Environment.CurrentDirectory + "\\blastwork\\";
            using (StreamWriter writer = new StreamWriter(new FileStream(path + "f1.fa", FileMode.Create))) {
                writer.WriteLine(">Seq1");
                writer.WriteLine(seq1);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(path + "f2.fa", FileMode.Create))) {
                writer.WriteLine(">Seq2");
                writer.WriteLine(seq2);
            }

            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = path;
            proc.StartInfo.FileName = path + "blastn.exe";
            proc.StartInfo.Arguments = "-query f1.fa -subject f2.fa -outfmt \"6 pident\"";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();

            string vector = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Close();

            //vector = vector.Replace("\n", "");
            //vector = vector.Replace("\r", "");
            string[] stringSeparators = new string[] { "\r\n" };
            string[] results = vector.Split(stringSeparators, StringSplitOptions.None);

            try {
                if (results[0].Length == 0)
                    return 0.0;
                result = Convert.ToDouble(results[0].Replace(".",","));
            } catch (Exception exc) {
                Form1.guiManager.AddLogLineEnter("" + exc.Message, Form1.LogType.ERROR);
                return -1.0;
            }

            return result;
        }
    }
}
