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
    public partial class NewVertex : Form
    {
        public int Weight;
        public string VertexName;
        public NewVertex()
        {
            InitializeComponent();
            VertexName = textBox1.Text;
        }

        private void NewVertex_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VertexName = textBox1.Text;
            if (VertexName.Contains(':'))
            {
                button1.Enabled = false;
                label2.Text = "Name cannot contain colon!";
            }
            else
            {
                button1.Enabled = true;
                label2.Text = "";
            }
        }

    }
}
