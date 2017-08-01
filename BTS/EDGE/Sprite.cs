using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDGE
{
    public abstract class Sprite
    {
        public Point Position;
        public Image _Image;
        public string Tag = "";
        public Size _Size;

        public bool Kill;

        public abstract void Update();
    }
}
