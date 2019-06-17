using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace vet_clinicka
{
    public class CustomSeparator : ToolStripSeparator
    {
        public CustomSeparator()
        {
            this.Paint += CustomSeparatorColor;
        }
        private void CustomSeparatorColor(object Sender, PaintEventArgs e)
        {
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)Sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;
            Color forecolor = Color.Black;
            Color backcolor = Color.LightSeaGreen;
            e.Graphics.FillRectangle(new SolidBrush(backcolor), 0, 0, width, height);
            e.Graphics.DrawLine(new Pen(forecolor), 4, height / 2, width - 4, height / 2);
        }
    }
}
