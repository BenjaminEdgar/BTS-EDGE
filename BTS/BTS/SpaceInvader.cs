using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDGE;
using System.Drawing;

namespace BTS
{
    public class SpaceInvader : Sprite
    {
        public SpaceInvader()
        {
            this._Size = new System.Drawing.Size(50, 50);
            // this._Image =  BTS.Properties.Resources.space_invader;

            this._Image = new Bitmap(50, 50);

            using (Graphics f = Graphics.FromImage(this._Image))
            {
                f.DrawImage(BTS.Properties.Resources.space_invader, new Rectangle(0,0, 50,50));
            }
                //this.Position = new System.Drawing.Point(0, 0);
                this.Tag = "si";
        }

        public bool MR = true;

        public int NumberiL = 0;

        

        public override void Update()
        {
            if (Kill)
            {
                stats.Points += 1000;
            }
            else
            {
                if (this.Position.X + (NumberiL * 50) + (10 * NumberiL) == 750)
                {
                    MR = false;
                    this.Position.Y += 10;
                }
                else if (this.Position.X + (NumberiL * 50) + (10 * NumberiL) - 100 == 0)
                {
                    MR = true;
                    this.Position.Y += 10;
                }
                if (MR)
                {
                    this.Position.X += 10;
                }
                else
                {
                    this.Position.X -= 10;
                }
            }
        }
    }
}
