using EDGE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS
{
    public class Player : Sprite
    {

        public Player()
        {
            this._Size = new System.Drawing.Size(200, 200);
            this.Position = new System.Drawing.Point(0, 600);
            this._Image = new Bitmap(200, 200);
            this.Tag = "Player";

            using (Graphics f = Graphics.FromImage(this._Image))
            {
                f.DrawImage(BTS.Properties.Resources.PlayerShip, new Rectangle(0, 0, 200, 200));
            }
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
