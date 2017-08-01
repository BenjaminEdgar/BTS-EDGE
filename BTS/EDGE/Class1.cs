using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDGE
{
    public class View
    {
        public Size ViewSize;

        

        public Level _level;

        public Point OffsetFromTL = new Point(0, 0);

        public Image Generate(int Zoom)
        {
            Bitmap _view = new Bitmap(ViewSize.Width, ViewSize.Height);
            using (Graphics i = Graphics.FromImage(_view))
            {
                i.FillRectangle(Brushes.Black, new Rectangle(0, 0, ViewSize.Width, ViewSize.Height));
                
            }
            Image toDraw = _level.Generate(Zoom);

            int x = /*(100 - toDraw.Width / 2) +*/ OffsetFromTL.X ;
            int y = /*(100 - toDraw.Height / 2) +*/ OffsetFromTL.Y;
            using (Graphics i = Graphics.FromImage(_view))
            {
               i.DrawImage(toDraw, new Point(x, y));
            }
            

            return _view;
        }

    }

    public class Level
    {

        public bool tryGetSprite(string tag)
        {
            if (GetSprite(tag) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Sprite GetSprite(string tag)
        {
            for (int i = 0; i < Sprites.Count;)
            {
                if (Sprites[i].Tag == tag)
                {
                    return Sprites[i];

                }
                i++;
            }
            return null;
        }

        public Image background;

        public Image Generate(int zoom)
        {
            Image Back = new Bitmap(2000, 800);

            using (Graphics n = Graphics.FromImage(Back))
            {
                /*  n.DrawRectangle(Pens.Lime, 0, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 100, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 200, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 300, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 400, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 500, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 600, 10, 100, 10);
                  n.DrawRectangle(Pens.Lime, 700, 10, 100, 10); */
                n.DrawString(stats.Points.ToString(), SystemFonts.DefaultFont, Brushes.White, new PointF(10, 50));
                n.DrawString(stats.CalcFPS.ToString(), SystemFonts.DefaultFont, Brushes.White, new PointF(1000, 50));





                if (stats.Points == 6000)
                {
                    n.DrawString("YOU WIN", SystemFonts.DefaultFont, Brushes.White, new PointF(350, 400));

                }
            }


            using (Graphics i = Graphics.FromImage(Back))
            {
                cycle(Back);
                
                List<Sprite> toRemove = new List<Sprite>();
                for (int n = 0; n < Sprites.Count;)
                {

                    if (Sprites[n].Kill)
                    {
                        toRemove.Add(Sprites[n]);
                    }

                    n++;
                }

                for(int p = 0; p < toRemove.Count;)
                {
                    Sprites.Remove(toRemove[p]);
                    p++;
                }
                

               
            }
            //GC.Collect();
            return Back;

              
        }

        public void cycle(Image toSample)
        {
            Current = toSample;
            n = Graphics.FromImage(Current);
            List<Thread> Basket = new List<Thread>();
            for (int j = 0; j < Sprites.Count;)
            {
                if (tryGetSprite("bullet"))
                {
                    Sprite bull = GetSprite("bullet");
                    Rectangle r = new Rectangle(Sprites[j].Position, Sprites[j]._Size);
                    Rectangle b = new Rectangle(bull.Position, bull._Size);
                    if (r.IntersectsWith(b) && Sprites[j].Tag != "bullet")
                    {
                        Sprites[j].Kill = true;
                        bull.Kill = true;
                    }

                }
                Sprites[j].Update();

                DrawImage(Sprites[j]);
                j++;
                /*
                int cn = j;
                var thread = new Thread(new ParameterizedThreadStart(DrawImage));
                thread.Start(Sprites[j]);
                Basket.Add(thread);
                j++;
            }
            int completed = 0; 
            for(bool run = true; run;)
            {
                foreach(Thread tt in Basket)
                {
                    if(tt.ThreadState == ThreadState.Stopped)
                    {
                        completed++;
                    }
                }
                if(completed == Basket.Count)
                {
                    run = false;
                }
                else
                {
                    completed = 0;
                }*/
            }

                

             
            
        }

        public Image Current;
        Graphics n;
        public void DrawImage(Sprite ToDraw)
        {
            
            {
                n.DrawImage(((Sprite)ToDraw)._Image,  new Rectangle(((Sprite)ToDraw).Position, ((Sprite)ToDraw)._Size));
            }
        }

        public List<Sprite> Sprites = new List<Sprite>();

      /*  public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }*/
    }
}
