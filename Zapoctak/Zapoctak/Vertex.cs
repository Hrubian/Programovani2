using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Zapoctak
{
    public class VertexButton : Button
    {
        public Vertex v;
        public VertexButton(System.Drawing.Point pt, Vertex v) : base()
        {
            this.BackColor = System.Drawing.Color.Aqua;
            this.Location = pt;
            this.v = v;
            this.Text = "";
            this.Size = new System.Drawing.Size(90, 30);
        }
 protected override void OnPaint(PaintEventArgs e) {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(5, 5, 20, 20);
            this.Region = new System.Drawing.Region(g);
            base.OnPaint(e);
        }
    }
}
