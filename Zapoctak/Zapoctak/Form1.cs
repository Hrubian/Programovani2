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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEllipse3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("programming_documentation.pdf");
        }

        private void buttonEllipse4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("user_documentation.pdf");
        }

        private void buttonEllipse2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                main_window Window = new main_window(openFileDialog1.FileName);
                Window.Show();
            }
        }

        private void buttonEllipse1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int Type = 0;
                if (checkBox1.Checked) Type += 2;
                if (checkBox2.Checked) Type += 1;
                main_window Window = new main_window((GraphRepresentation.GraphType)Type, saveFileDialog1.FileName);
                Window.Show();
            }
        }
    }
}
