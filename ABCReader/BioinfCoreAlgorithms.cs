using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ABCReader {
    class BioinfCoreAlgorithms {
        public static readonly int[] BLOSUM62 = {
              4,                                                                  // A
             -1, 5,                                                               // R
             -2, 0, 6,                                                            // N
             -2,-2, 1, 6,                                                         // D
              0,-3,-3,-3, 9,                                                      // C
             -1, 1, 0, 0,-3, 5,                                                   // Q
             -1, 0, 0, 2,-4, 2, 5,                                                // E
              0,-2, 0,-1,-3,-2,-2, 6,                                             // G
             -2, 0, 1,-1,-3, 0, 0,-2, 8,                                          // H
             -1,-3,-3,-3,-1,-3,-3,-4,-3, 4,                                       // I
             -1,-2,-3,-4,-1,-2,-3,-4,-3, 2, 4,                                    // L
             -1, 2, 0,-1,-3, 1, 1,-2,-1,-3,-2, 5,                                 // K
             -1,-1,-2,-3,-1, 0,-2,-3,-2, 1, 2,-1, 5,                              // M
             -2,-3,-3,-3,-2,-3,-3,-3,-1, 0, 0,-3, 0, 6,                           // F
             -1,-2,-2,-1,-3,-1,-1,-2,-2,-3,-3,-1,-2,-4, 7,                        // P
              1,-1, 1, 0,-1, 0, 0, 0,-1,-2,-2, 0,-1,-2,-1, 4,                     // S
              0,-1, 0,-1,-1,-1,-1,-2,-2,-1,-1,-1,-1,-2,-1, 1, 5,                  // T
             -3,-3,-4,-4,-2,-2,-3,-2,-2,-3,-2,-3,-1, 1,-4,-3,-2,11,               // W
             -2,-2,-2,-3,-2,-1,-2,-3, 2,-1,-1,-2,-1, 3,-3,-2,-2, 2, 7,            // Y
              0,-3,-3,-3,-1,-2,-2,-3,-3, 3, 1,-2, 1,-1,-2,-2, 0,-3,-1, 4,         // V
             -2,-1, 3, 4,-3, 0, 1,-1, 0,-3,-4, 0,-3,-3,-2, 0,-1,-4,-3,-3, 4,      // B
             -1, 0, 0, 1,-3, 3, 4,-2, 0,-3,-3, 1,-1,-3,-1, 0,-1,-3,-2,-2, 1, 4,   // Z
              0,-1,-1,-1,-2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-2, 0, 0,-2,-1,-1,-1,-1,-1 // X
            //A  R  N  D  C  Q  E  G  H  I  L  K  M  F  P  S  T  W  Y  V  B  Z  X
            //0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19  2  6 20
            };
        public readonly char[] aa =  { 'A','R','N','D','C','Q','E','G','H','I','L','K','M','F','P','S','T','W','Y','V','B','Z','X' };
                                   //{  0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 2,  6, 20};
        public readonly int[] aa2idx = {0, 2, 4, 3, 6, 13,7, 8, 9,20,11,10,12, 2,20,14, 5, 1,15,16,20,19,17,20,18, 6};
        // idx for  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P
        //          Q  R  S  T  U  V  W  X  Y  Z
        // so  aa2idx[ X - 'A'] => idx_of_X, eg aa2idx['A' - 'A'] => 0,
        // and aa2idx['M'-'A'] => 12
        
        public static string[] NeedlemanWunsch(string refSeq, string alignSeq) {
            //string refSeq = "GAATTCAGTTA";
            //string alignSeq = "GGATCGA";

            //refSeq = "ATGGCCATGGAGATAGAGGGGCCTGCGCAGCATGGAGCAACAGGATGGG";
            //alignSeq = "ATGCAAACACTAAGACAATTGGCAAGAGATGGACACACGGTGATCTGTTCTA";
            //STAGE1
            string[] result = new string[5];
            int refSeqCnt = refSeq.Length + 1;
            int alineSeqCnt = alignSeq.Length + 1;

            int[,] scoringMatrix = new int[alineSeqCnt, refSeqCnt];

            //Initialization Step - filled with 0 for the first row and the first column of matrix
            for (int i = 0; i < alineSeqCnt; i++) {
                scoringMatrix[i, 0] = 0;
            }

            for (int j = 0; j < refSeqCnt; j++) {
                scoringMatrix[0, j] = 0;
            }
            //STAGE2

            //Matrix Fill Step
            for (int i = 1; i < alineSeqCnt; i++) {
                for (int j = 1; j < refSeqCnt; j++) {
                    int scroeDiag = 0;
                    if (refSeq.Substring(j - 1, 1) == alignSeq.Substring(i - 1, 1))
                        scroeDiag = scoringMatrix[i - 1, j - 1] + 2;
                    else
                        scroeDiag = scoringMatrix[i - 1, j - 1] + -1;

                    int scroeLeft = scoringMatrix[i, j - 1] - 2;
                    int scroeUp = scoringMatrix[i - 1, j] - 2;

                    int maxScore = Math.Max(Math.Max(scroeDiag, scroeLeft), scroeUp);

                    scoringMatrix[i, j] = maxScore;
                }
            }
            //STAGE3
            //Traceback Step
            char[] alineSeqArray = alignSeq.ToCharArray();
            char[] refSeqArray = refSeq.ToCharArray();

            string AlignmentA = string.Empty;
            string AlignmentB = string.Empty;
            int m = alineSeqCnt - 1;
            int n = refSeqCnt - 1;

            int lvl1_points = 0;

            while (m > 0 && n > 0) {
                int scroeDiag = 0;

                //Remembering that the scoring scheme is +2 for a match, -1 for a mismatch and -2 for a gap
                if (alineSeqArray[m - 1] == refSeqArray[n - 1])
                    scroeDiag = 2;
                else
                    scroeDiag = -1;

                if (m > 0 && n > 0 && scoringMatrix[m, n] == scoringMatrix[m - 1, n - 1] + scroeDiag) {
                    AlignmentA = refSeqArray[n - 1] + AlignmentA;
                    AlignmentB = alineSeqArray[m - 1] + AlignmentB;
                    //
                    if (refSeqArray[n - 1] == alineSeqArray[m - 1]) lvl1_points++;
                    //
                    m = m - 1;
                    n = n - 1;
                } else if (n > 0 && scoringMatrix[m, n] == scoringMatrix[m, n - 1] - 2) {
                    AlignmentA = refSeqArray[n - 1] + AlignmentA;
                    AlignmentB = "-" + AlignmentB;
                    n = n - 1;
                } else //if (m > 0 && scoringMatrix[m, n] == scoringMatrix[m - 1, n] + -2)
                  {
                    AlignmentA = "-" + AlignmentA;
                    AlignmentB = alineSeqArray[m - 1] + AlignmentB;
                    m = m - 1;
                }
            }
            result[2] = AlignmentA;
            result[3] = AlignmentB;


            if (m > 0) { //pierwsza dłuższa
                for (int i = 0; i < m; i++)
                    AlignmentA = "-" + AlignmentA;

                AlignmentB = alignSeq.Substring(0, m) + AlignmentB;

            } else { //druga dłuższa
                for (int i = 0; i < n; i++)
                    AlignmentB = "-" + AlignmentB;

                AlignmentA = refSeq.Substring(0, n) + AlignmentA;

            }

            result[0] = AlignmentA;
            result[1] = AlignmentB;

            result[4] = lvl1_points.ToString();
            return result;
        }

        private static int ScoreFunction(char a, char b, int matchScore, int mismatchScore) {
            //Wenn die Buchstaben gleich sind ist der Match-Score der Rückgabewert.
            //Wenn nicht gib den Mismatch-Score zurück.
            return a == b ? matchScore : mismatchScore;
        }

        //Die Align-Methode bekommt die beiden Sequenzen A und B, den Gap-Penalty, Match- und Mismatch-Score als Parameter.
        //match +5 , mismatch as -3 and gap penalty as -4
        public static string[] SmithWatermanAlign(string sequenceA, string sequenceB, int gapPenalty, int matchScore, int mismatchScore) {
            //Hier werden beide Matrizen initialisiert. Die Scoring- und Traceback-Matrix.
            #region Initialize
            int[,] matrix = new int[sequenceA.Length + 1, sequenceB.Length + 1];
            char[,] tracebackMatrix = new char[sequenceA.Length + 1, sequenceB.Length + 1];
            matrix[0, 0] = 0;

            //Befülle die erste Reihe der Matrizen.
            for (int i = 1; i < sequenceA.Length + 1; i++) {
                matrix[i, 0] = 0;
                tracebackMatrix[i, 0] = '0';
            }

            //Befülle die erste Spalte der Matrizen.
            for (int i = 1; i < sequenceB.Length + 1; i++) {
                matrix[0, i] = 0;
                tracebackMatrix[0, i] = '0';
            }
            #endregion

            //Hier werden die Werte für die Scoring-Matrix berechnet. Zeitgleich befüllen
            //wir die Traceback-Matrix.
            #region Scoring

            //Diese Variable benutzen wir um uns die Zelle mit dem Höchsten Wert zu merken.
            //Diese wird uns beim Traceback als Startpunkt dienen.
            int[] score = new int[2];

            for (int i = 1; i < sequenceA.Length + 1; i++) {
                for (int j = 1; j < sequenceB.Length + 1; j++) {
                    //Lese und berechne die Werte der Vorgängerzellen.                     
                    int diagonal = matrix[i - 1, j - 1] + ScoreFunction(sequenceA[i - 1], sequenceB[j - 1], matchScore, mismatchScore);                    
                    int links = matrix[i - 1, j] + gapPenalty;                    
                    int oben = matrix[i, j - 1] + gapPenalty;                     
                    //Der höchste Wert wird eingetragen.                    
                    matrix[i, j] = Math.Max(Math.Max(oben, Math.Max(links, diagonal)),0);                     
                    //Hier wird geprüft ob die aktuelle Zelle als Score für die matrix taugt.                     
                    if (matrix[i,j] > matrix[score[0],score[1]])
                    {
                        score[0] = i;
                        score[1] = j;
                    }

                    //Finde raus welche der Zellen den Wert geliefert hat und trage
                    //dies in die Traceback-Matrix ein.
                    if (matrix[i, j] == diagonal && i > 0 && j > 0) {
                        tracebackMatrix[i, j] = 'D';
                    } else if (matrix[i, j] == links) {
                        tracebackMatrix[i, j] = 'L';
                    } else if (matrix[i, j] == oben) {
                        tracebackMatrix[i, j] = 'U';
                    } else if (matrix[i, j] == 0) {
                        tracebackMatrix[i, j] = '0';
                    }
                }
            }
            #endregion

            //Hier wird einfach die Traceback-Methode aufgerufen und liefert uns das Alignment.
            #region Traceback
            return TraceBack(tracebackMatrix, score, sequenceA, sequenceB);
            #endregion

        }

        //Eine TraceBack-Matrix und die beiden Sequenzen sind die Paramter für das Traceback.
        //Außerdem wird hier die Position der Score-zelle an die Methode übergeben.
        private static string[] TraceBack(char[,] tracebackMatrix, int[] score, string sequenzA, string sequenzB) {
            //Lege die Startposition anhand des Scores fest
            int i = score[0];
            int j = score[1];

            StringBuilder alignedSeqA = new StringBuilder();
            StringBuilder alignedSeqB = new StringBuilder();

            //Das Traceback wird asugeführt solange wir uns nicht in der Zelle (0,0) befinden.
            while (tracebackMatrix[i, j] != '0') {
                switch (tracebackMatrix[i, j]) {
                    case 'D':
                        alignedSeqA.Append(sequenzA[i - 1]);
                        alignedSeqB.Append(sequenzB[j - 1]);
                        i--;
                        j--;
                        break;
                    case 'U':
                        alignedSeqA.Append("-");
                        alignedSeqB.Append(sequenzB[j - 1]);
                        j--;
                        break;
                    case 'L':
                        alignedSeqA.Append(sequenzA[i - 1]);
                        alignedSeqB.Append("-");
                        i--;
                        break;

                }
            }

            string[] alignments = new string[2];

            //Da wir die Zeichen jeweils rechts an die Alignments angefügt haben,
            //rufen wir hier die Reverse-Methode um die Strings umzudrehen.
            alignments[0] = new string(alignedSeqA.ToString().Reverse().ToArray());
            alignments[1] = new string(alignedSeqB.ToString().Reverse().ToArray());

            /*
            int size1 = sequenzA.Length;
            int size2 = sequenzB.Length;
            if(size1 > size2) {
                string tmp = alignments[0].Replace("-", "");
                int x = sequenzA.IndexOf(tmp);
                alignments[0] = sequenzA.Substring(0, x) + alignments[0];

                for(int ii=0; ii<x; ii++) {
                    alignments[1] = "-" + alignments[1];
                }
            } else {
                string tmp = alignments[1].Replace("-", "");
                int x = sequenzB.IndexOf(tmp);
                alignments[1] = sequenzB.Substring(0, x) + alignments[1];

                for (int ii = 0; ii < x; ii++) {
                    alignments[0] = "-" + alignments[0];
                }
            }
            */

            //  tmp = alignments[1].Replace("-", "");
            // x = sequenzB.IndexOf(tmp);
            //alignments[1] = sequenzB.Substring(0, x) + alignments[1];

            //Der Rückgabewert ist ein array welches beide alignments enthält.
            return alignments;
        }


    }
}
