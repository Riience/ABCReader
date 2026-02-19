using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCReader {
    class DNAtools {
        private static int nValue(char nucleotide) {
            switch (nucleotide) {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                default:
                    return 100;
            }
        }
        public static List<int> GetSeqHistogram(string DNA) {
            List<int> result = new List<int>();
            for (int i = 0; i < 64; i++)
                result.Add(0);

            DNA = DNA.ToUpper();

            try {
                int length = DNA.Length;
                for(int i=0; i< length; ) {
                    if(i+3 >= length) {
                        break;
                    }
                        
                    string codon = DNA.Substring(i, 3);
                    i += 3;
                    char[] tab = codon.ToArray();

                    int value = nValue(tab[0]) * 16 + nValue(tab[1]) * 4 + nValue(tab[2]);
                    if (value > 63) { //nieznany nukleotyd
                        continue;
                    }
                    result[value]++;
                }
                
            } catch (Exception e) {
                Form1.guiManager.AddLogLineEnter("Błąd tworzenia historgramu.", Form1.LogType.ERROR);
                Form1.guiManager.AddLogLineEnter(e.Message, Form1.LogType.ERROR);
            }

            return result;
        }

        public static double GetHistAvg(List<int> hist) {
            int points = 0;
            int pos = 1;
            foreach(int i in hist) {

                points += i;
                pos++;
            }
            return (double)(points/61.0); //61, bo bez kodonów stop, bo po co je wliczać...
        }

        public static double GetCzekanowskiValue(List<int> hist, List<int> hist2) {
            double result = 0;
            //debug:
            
            string s1 = "";
            string s2 = "";
            for(int i=0; i<64; i++) {
                s1 += " " + hist[i];
                s2 += " " + hist2[i];
            }
            
            for(int i=0; i<64; i++) {
                if (i == 48 || i == 50 || i == 56) //TAA TAG TGA
                    continue; //CODON STOP NOT INCLUDED
                

                int a = hist[i];
                int b = hist2[i];
                //if (a == 0 && b == 0) {
                if (a == b) {
                    result += 0.5;
                    continue;
                } else {
                    int min = a < b ? a : b;
                    result += ((double)min / (double)(a + b));
                }
            }
            return result; 
        }
    }
}
