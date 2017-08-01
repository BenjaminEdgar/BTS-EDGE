using EDGE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS
{
    public class Bullet : Sprite
    {
        public Bullet()
        {
            this._Image = new Bitmap(5, 100);
            using (Graphics g = Graphics.FromImage(this._Image))
            {
                g.FillRectangle(Brushes.LimeGreen, new Rectangle(0, 0, 5, 100));
            }
            this.Tag = "bullet";
            this._Size = new Size(5, 100);
        }

        public override void Update()
        {
            if(this.Position.Y < 0)
            {
                Kill = true;
            }
            this.Position.Y -= 30;
        }
    }
}
