using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCReader {
    public partial class ChooseAlignForm : Form {
        Form1 parentForm = null;
        public ChooseAlignForm(Form1 parent) {
            InitializeComponent();
            parentForm = parent;
        }

        private void button1_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = 0;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = 1;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = 2;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = 3;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = 4;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e) {
            parentForm.AlignWindowDecision = -1;
            this.Close();
        }
    }
}
