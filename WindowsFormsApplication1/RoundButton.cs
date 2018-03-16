using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    class Round : Button
    {
        protected override void OnCreateControl()
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(2, 2, this.Width - 5, this.Height - 5));
                this.Region = new Region(path);
            }
            base.OnCreateControl();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            Pen pn = new Pen(Color.Brown);
            gp.DrawEllipse(pn,2,2,this.Width -5 , this.Height -5);
            pn.Dispose();
            
        }
    }
}
