using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Zapoctak
{
    class ButtonEllipse : Button 
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(+5, +5, ClientSize.Width - 10, ClientSize.Height - 10);
            this.Region = new System.Drawing.Region(g);
            base.OnPaint(pevent);
        }
    }
}
