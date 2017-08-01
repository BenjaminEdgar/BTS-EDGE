using EDGE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading;

namespace BTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 800);
        }
        EDGE.View v = new EDGE.View();
        DateTime dt = DateTime.Now;
        private void Form1_Load(object sender, EventArgs e)
        {



            v.ViewSize = new Size(800, 800);
            v._level = new EDGE.Level();
           v._level.background = BTS.Properties.Resources.imagetest;

            pictureBox1.Image = v.Generate(100);
            SpaceInvader si3 = new SpaceInvader();
            si3.Tag = "si";
            si3.NumberiL = 2;
            si3.Position = new Point(10, 0);
            SpaceInvader si1 = new SpaceInvader();
            si1.Tag = "si";
            si1.NumberiL = 1;
            si1.Position = new Point(70, 0);
            SpaceInvader si2 = new SpaceInvader();
            si2.NumberiL = 0;
            si2.Tag = "si";
            si2.Position = new Point(130, 0);


            SpaceInvader si31 = new SpaceInvader();
            si31.Tag = "si";
            si31.NumberiL = 2;
            si31.Position = new Point(10, 70);
            SpaceInvader si11 = new SpaceInvader();
            si11.Tag = "si";
            si11.NumberiL = 1;
            si11.Position = new Point(70, 70);
            SpaceInvader si21 = new SpaceInvader();
            si21.NumberiL = 0;
            si21.Tag = "si";
            si21.Position = new Point(130, 70);


            SpaceInvader si311 = new SpaceInvader();
            si311.Tag = "si";
            si311.NumberiL = 2;
            si311.Position = new Point(10, 130);
            SpaceInvader si111 = new SpaceInvader();
            si111.Tag = "si";
            si111.NumberiL = 1;
            si111.Position = new Point(70, 130);
            SpaceInvader si211 = new SpaceInvader();
            si211.NumberiL = 0;
            si211.Tag = "si";
            si211.Position = new Point(130, 130);

            v._level.Sprites.Add(si1);
            v._level.Sprites.Add(si2);
            v._level.Sprites.Add(si3);

            v._level.Sprites.Add(si11);
            v._level.Sprites.Add(si21);
            v._level.Sprites.Add(si31);

            v._level.Sprites.Add(si111);
            v._level.Sprites.Add(si211);
            v._level.Sprites.Add(si311);

            v._level.Sprites.Add(new Player());

            this.Show();
            
            while (run)
            {
                Application.DoEvents();

                if (this.Visible == false)
                {
                    run = false;
                }
                stats.FPS += 1;

                // Thread.Sleep(10);

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    if (v._level.tryGetSprite("bullet") == false)
                    {
                        Bullet b = new Bullet();
                        b.Position = new Point(v._level.GetSprite("Player").Position.X + (v._level.GetSprite("Player")._Size.Width / 2), v._level.GetSprite("Player").Position.Y - 110);

                        v._level.Sprites.Add(b);
                    }
                }
                
                if (Keyboard.IsKeyDown(Key.Left))
                {

                    v._level.GetSprite("Player").Position.X -= 5;

                    //v._level.Sprites.Add(b);
                }

                if (Keyboard.IsKeyDown(Key.A))
                {

                    v.OffsetFromTL.X -= 10;

                    //v._level.Sprites.Add(b);
                }
                if (Keyboard.IsKeyDown(Key.D))
                {

                    v.OffsetFromTL.X += 10;

                    //v._level.Sprites.Add(b);
                }
                if (Keyboard.IsKeyDown(Key.W))
                {

                    v.OffsetFromTL.Y += 10;

                    //v._level.Sprites.Add(b);
                }
                if (Keyboard.IsKeyDown(Key.S))
                {

                    v.OffsetFromTL.Y -= 10;

                    //v._level.Sprites.Add(b);
                }
                if (Keyboard.IsKeyDown(Key.Right))
                {

                    v._level.GetSprite("Player").Position.X += 5;

                    //v._level.Sprites.Add(b);
                }

                Image temp = v.Generate(100);


                if (stats.Points >= 6000)
                {
                    if ((i % 2) == 1)
                    {
                        pictureBox1.Image = (Image)RotateImage((Bitmap)temp, i);
                    }
                }
                else
                {
                    pictureBox1.Image = temp;
                }
                i += 1;
            }

        }
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }

        float i = 1;

        bool run = true;

        private void timer1_Tick(object sender, EventArgs e)
        {

            stats.CalcFPS = stats.FPS;
            stats.FPS = 0;
            
        }

        public bool LKP = false;
        public bool RKP = false;

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
