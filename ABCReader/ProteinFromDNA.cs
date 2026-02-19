using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCReader {
    public class ProteinFromDNA {
        public int startingNucleotide = -1;
        public bool codonStart = false;
        public bool codonStop = false;
        public bool _5to3 = true;
        public int peptideSeqLength = 0;
        public string DNAsequence = "";
        public string DNAseqID = "";
        public string peptideSequence = "";
        public int shiftLevel = 0;

        public string lvl2_DNAcodingSequence = "";
        public string lvl2_proteinID = "";
        public int lvl2_DNAcodingSequenceSize = 0;
        public List<int> lvl2_mainHistogram = null;
        public double lvl2_avgHistValue = 999999.99;

        /// <summary>
        /// Konstruktor obiektu reprezentującego aminowkas.
        /// </summary>
        /// <param name="startingNucleo">Numer pierwszego nukleotydy kodującego Metioninę w DNA.</param>
        /// <param name="isCodonStart">True jeśli zawiera Metioninę na początku.</param>
        /// <param name="isCodonStop">True jeśli kończy się kodonem STOP.</param>
        /// <param name="order53">True jeśli sekwencja była czytana 5' do 3', false jeśli od 3' do 5'.</param>
        /// <param name="aminoSeqSize">Rozmiar - liczba aminokwasów.</param>
        /// <param name="DNAsequence">Sekwencja DNA (kodująca).</param>
        /// <param name="DNA_ID">Identyfikator sekwencji DNA.</param>
        /// <param name="protSequence">Sekwencja aminokwasowa.</param>
        /// <param name="shift">Poziom przesunięcia ramki odczytu: 0, 1 lub 2.</param>
        public ProteinFromDNA(int startingNucleo, bool isCodonStart, bool isCodonStop, bool order53, int aminoSeqSize, string DNAsequence, string DNA_ID, 
            string protSequence, int shift) {
            startingNucleotide = startingNucleo;
            codonStart = isCodonStart;
            codonStop = isCodonStop;
            _5to3 = order53;
            peptideSeqLength = aminoSeqSize;
            this.DNAsequence = DNAsequence;
            this.DNAseqID = DNA_ID;
            peptideSequence = protSequence;
            shiftLevel = shift;

            lvl2_DNAcodingSequenceSize = aminoSeqSize * 3;
        }
    }
}
