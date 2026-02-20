using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCReader {
    static class Ribosome {
        private static readonly string[] CODONS = {
                "TTT", "TTC", "TTA", "TTG", "TCT", "TCC", "TCA", "TCG",
                "TAT", "TAC", "TGT", "TGC", "TGG", "CTT", "CTC", "CTA",
                "CTG", "CCT", "CCC", "CCA", "CCG", "CAT", "CAC", "CAA",
                "CAG", "CGT", "CGC", "CGA", "CGG", "ATT", "ATC", "ATA",
                "ATG", "ACT", "ACC", "ACA", "ACG", "AAT", "AAC", "AAA",
                "AAG", "AGT", "AGC", "AGA", "AGG", "GTT", "GTC", "GTA",
                "GTG", "GCT", "GCC", "GCA", "GCG", "GAT", "GAC", "GAA",
                "GAG", "GGT", "GGC", "GGA", "GGG", "TGA", "TAG", "TAA" };

        private static readonly string[] AMINOS_PER_CODON = {
            "F", "F", "L", "L", "S", "S", "S", "S",
            "Y", "Y", "C", "C", "W", "L", "L", "L",
            "L", "P", "P", "P", "P", "H", "H", "Q",
            "Q", "R", "R", "R", "R", "I", "I", "I",
            "M", "T", "T", "T", "T", "N", "N", "K",
            "K", "S", "S", "R", "R", "V", "V", "V",
            "V", "A", "A", "A", "A", "D", "D", "E",
            "E", "G", "G", "G", "G", "*", "*", "*" };

        private static readonly string[] AMINOS_PER_CODON_FULL = {
            "Phe", "Phe", "Leu", "Leu", "Ser", "Ser", "Ser", "Ser",
            "Tyr", "Tyr", "Cys", "Cys", "Trp", "Leu", "Leu", "Leu",
            "Leu", "Pro", "Pro", "Pro", "Pro", "His", "His", "Gln",
            "Gln", "Arg", "Arg", "Arg", "Arg", "Ile", "Ile", "Ile",
            "Met", "Thr", "Thr", "Thr", "Thr", "Asn", "Asn", "Lys",
            "Lys", "Ser", "Ser", "Arg", "Arg", "Val", "Val", "Val",
            "Val", "Ala", "Ala", "Ala", "Ala", "Asp", "Asp", "Glu",
            "Glu", "Gly", "Gly", "Gly", "Gly", "STP", "STP", "STP" };

        private static readonly string[] FULL_NAMES = {
            "phenylalanine", "phenylalanine", "leucine", "leucine", "serine", "serine", "serine", "serine",
            "tyrosine", "tyrosine", "cysteine", "cysteine", "tryptophan", "leucine", "leucine", "leucine",
            "leucine", "proline", "proline", "proline", "proline", "histidine", "histidine", "glutamine",
            "glutamine", "arginine", "arginine", "arginine", "arginine", "isoleucine", "isoleucine", "isoleucine",
            "methionine", "threonine", "threonine", "threonine", "threonine", "asparagine", "asparagine", "lysine",
            "lysine", "serine", "serine", "arginine", "arginine", "valine", "valine", "valine",
            "valine", "alanine", "alanine", "alanine", "alanine", "aspartic acid", "aspartic acid", "glutamic acid",
            "glutamic acid", "glycine", "glycine", "glycine", "glycine", "STOP", "STOP", "STOP" };

        public static readonly string[] COD_SORTED = {
            "AAA", "AAC", "AAG", "AAT", "ACA", "ACC", "ACG", "ACT",
            "AGA", "AGC", "AGG", "AGT", "ATA", "ATC", "ATG", "ATT",
            "CAA", "CAC", "CAG", "CAT", "CCA", "CCC", "CCG", "CCT",
            "CGA", "CGC", "CGG", "CGT", "CTA", "CTC", "CTG", "CTT",
            "GAA", "GAC", "GAG", "GAT", "GCA", "GCC", "GCG", "GCT",
            "GGA", "GGC", "GGG", "GGT", "GTA", "GTC", "GTG", "GTT",
            "TAA", "TAC", "TAG", "TAT", "TCA", "TCC", "TCG", "TCT",
            "TGA", "TGC", "TGG", "TGT", "TTA", "TTC", "TTG", "TTT" };

        /// <summary>
        /// Zwraca komplementarny ciąg DNA.
        /// </summary>
        /// <param name="dna">sekwencja DNA</param>
        /// <param name="reverse">jeśli true, zwróci odwrotnie komplementarny łańcuch</param>
        /// <returns>sekwencja komplementarna DNA</returns>
        public static string GetComplementaryDNA(string dna, bool reverse) {
            char[] array = dna.ToCharArray();
            for (int i = 0; i < array.Length; i++) {
                char let = array[i];
                if (let == 'A') array[i] = 'T';
                else if (let == 'T') array[i] = 'A';
                else if (let == 'C') array[i] = 'G';
                else if (let == 'G') array[i] = 'C';
            }

            if(reverse)
                Array.Reverse(array);
            return new string(array);
        }


        /// <summary>
        /// Zwraca sekwencję aminokwasową na bazie sekwencji DNA.
        /// </summary>
        /// <param name="dna">sekwencja DNA</param>
        /// <returns>sekwencja aminokwasowa</returns>
        public static string DNAToAminoAcid(string dna) {
            string result = "";
            int i = 0;
            int size = dna.Length;
            try {
                for (i = 0; i < size; i += 3) {
                    if (i+2 >= size)
                        break;
                    result += CodonToAminoAcid(dna.Substring(i, 3), 0);
                }
            }
            catch (Exception) {
                //MessageBox.Show(""+e.Message);
            }
            
            return result;
        }


        /// <summary>
        /// Zwraca aminokwas określony przez dany kodon
        /// </summary>
        /// <param name="codon">string - kodon</param> 
        /// <param name="type">int 0: zwraca literę (default), 1: skrót nazwy, 2: pełną nazwę)</param>
        /// <returns>zależnie od type - aminokwas (jeden!)</returns>
        public static string CodonToAminoAcid(string codon, int type) {
            for (int k = 0; k < CODONS.Length; k++) {
                if (CODONS[k].Equals(codon)) {
                    if(type == 1)
                        return AMINOS_PER_CODON_FULL[k];
                    else if(type == 2)
                        return FULL_NAMES[k];
                    else
                        return AMINOS_PER_CODON[k];
                }
            }

            // never reach here with valid codon
            return "X";
        }

        public static string CodonToAminoAcidSpecial(string codon) {
            if (codon.Equals("---"))
                return "-";

            for (int k = 0; k < CODONS.Length; k++) {
                if (CODONS[k].Equals(codon)) {
                    return AMINOS_PER_CODON[k];
                }
            }
            return "X";
        }

        public static string DNAToAminoAcidSpecial(string dna) {
            string result = "";
            int size = dna.Length;
            try {
                for (int i = 0; i < size; i += 3) {
                    if (i + 2 >= size)
                        break;
                    result += CodonToAminoAcidSpecial(dna.Substring(i, 3));
                }
            } catch (Exception) {
            }
            return result;
        }

        /// <summary>
        /// Sprawdza, czy sekwencja ma tylko znaki acgtACGT
        /// </summary>
        /// <param name="seq">Sekwencja DNA</param>
        /// <returns>true jeśli znaki to tylko ACGT</returns>
        public static bool IsCleanDNA(string seq, bool allowN) {
            if (allowN) {
                Regex regex = new Regex(@"^[acgtnACGTN]+$");
                bool result = regex.IsMatch(seq);
                return result;
            } else {
                Regex regex = new Regex(@"^[acgtACGT]+$");
                bool result = regex.IsMatch(seq);
                return result;
            }
            
        }

        /// <summary>
        /// Sprawdza, czy sekwencja ma tylko znaki acguACGU
        /// </summary>
        /// <param name="seq">Sekwencja RNA</param>
        /// <returns>true jeśli znaki to tylko ACGU</returns>
        public static bool IsCleanRNA(string seq) {
            Regex regex = new Regex(@"^[acguACGU]+$");
            bool result = regex.IsMatch(seq);
            return result;
        }

        public static string CleanDNA(string seq) {
            seq = Regex.Replace(seq, @"[^acgtACGT]+", "");
            return seq;
        }

        public static string cleanRNA(string seq) {
            seq = Regex.Replace(seq, @"[^acguACGU]+", "");
            return seq;
        }

        public static string DNAtoRNA(string seq) {
            seq = Regex.Replace(seq, @"[tT]", "U");
            return seq;
        }

        public static string RNAtoDNA(string seq) {
            seq = Regex.Replace(seq, @"[uU]", "T");
            return seq;
        }
    }
}
