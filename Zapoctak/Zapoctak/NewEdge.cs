using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zapoctak
{
    public partial class NewEdge : Form
    {
        public int Weight;
        public NewEdge()
        {
            InitializeComponent();
            Weight = (int)numericUpDown1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Weight = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
