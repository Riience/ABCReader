using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCReader {
    class ConfigData {
        public bool tab1_DNA_metStart = true;
        public bool tab1_sortSequences = true;

        public bool tab2_DNA_metStart = true;
        public bool tab2_DNA_codonStop = false;
        public int tab2_minProtSize = 1000;

        public double tab3_maxEvalue = 0.0f;
        public int tab3_minCover = 70;

        public int tab4_fontSize = 7;
        public int tab4_frameSize = 45;
    }
}
