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
    public partial class Settings : Form
    {
        public Color bgcolor;
        public Color vcolor;
        public Color ecolor;
        public Color textcolor;
        public Settings(Color bgcolor, Color vcolor, Color ecolor, Color textcolor)
        {
            InitializeComponent();
            this.bgcolor = bgcolor;
            this.vcolor = vcolor;
            this.ecolor = ecolor;
            this.textcolor = textcolor;
            button1.BackColor = bgcolor;
            button2.BackColor = vcolor;
            button3.BackColor = ecolor;
            button4.BackColor = textcolor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bgcolor = colorDialog1.Color;
                button1.BackColor = bgcolor;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ecolor = colorDialog1.Color;
                button3.BackColor = ecolor;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                vcolor = colorDialog1.Color;
                button2.BackColor = vcolor;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textcolor = colorDialog1.Color;
                button6.BackColor = textcolor;
            }
        }
    }
}
