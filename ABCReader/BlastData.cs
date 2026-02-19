namespace ABCReader {
    public class BlastData {
        /// <summary>
        /// Query Seq-id
        /// </summary>
        public string qseqid = "";
        /// <summary>
        /// Subject Seq-id
        /// </summary>
        public string sseqid = "";
        /// <summary>
        /// Start of alignment in query
        /// </summary>
        public int qstart = -1;
        /// <summary>
        /// End of alignment in query
        /// </summary>
        public int qend = -1;
        /// <summary>
        /// Start of alignment in subject
        /// </summary>
        public int sstart = -1;
        /// <summary>
        /// End of alignment in subject
        /// </summary>
        public int send = -1;
        /// <summary>
        /// Aligned part of query sequence
        /// </summary>
        public string qseq = "";
        /// <summary>
        /// Aligned part of subject sequence
        /// </summary>
        public string sseq = "";
        /// <summary>
        /// Expect value
        /// </summary>
        public double evalue = 999999.0;
        /// <summary>
        /// Bit score
        /// </summary>
        public double bitscore = 999999.0;
        /// <summary>
        /// Raw score
        /// </summary>
        public double score = 999999.0;
        /// <summary>
        /// Alignment length
        /// </summary>
        public int length = -1;
        /// <summary>
        /// Percentage of identical matches
        /// </summary>
        public double pident = 999999.0;
        /// <summary>
        /// Number of identical matches
        /// </summary>
        public double nident = 999999.0;
        /// <summary>
        /// Number of mismatches
        /// </summary>
        public int mismatch = -1;
        /// <summary>
        /// Number of positive-scoring matches
        /// </summary>
        public int positive = -1;
        /// <summary>
        /// Number of gap openings
        /// </summary>
        public int gapopen = -1;
        /// <summary>
        /// Total number of gap
        /// </summary>
        public int gaps = -1;
        /// <summary>
        /// Percentage of positive-scoring matches
        /// </summary>
        public double ppos = 999999.0;
        /// <summary>
        /// Query Coverage Per Subject(for all HSPs)
        /// </summary>
        public double qcovs = 999999.0;
        /// <summary>
        /// Query Coverage Per HSP
        /// </summary>
        public double qcovhsp = 999999.0;


        public int nonBlast_SeqSize = -1;
    }
}

