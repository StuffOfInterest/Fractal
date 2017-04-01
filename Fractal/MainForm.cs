using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Fractal : Form
    {
        delegate void SetStopCallback();                       // Used for thread-safe call
        System.Drawing.Pen myPen;                              // Pen to use for drawing
        private System.Drawing.Bitmap ImageBitmap;             // Our Bitmap declaration
        Graphics graphicsObj;                                  // Graphics object used during drawing of image
        private static System.Threading.Semaphore ImageLock;   // Semaphore to avoid two threads talking to the image
        int ClockTicks = 0;                                    // Miliseconds since boot, used to keep from over invalidating

        public Fractal()
        {
            InitializeComponent();
        }

        private void Fractal_Load(object sender, EventArgs e)
        {
            Graphics GraphObj;

            // Setup persistent image for picture box and set background to white
            ImageBitmap = new Bitmap(picImage.ClientRectangle.Width, picImage.ClientRectangle.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GraphObj = Graphics.FromImage(ImageBitmap);
            GraphObj.Clear(System.Drawing.Color.White);
            GraphObj.Dispose();

            ImageLock = new System.Threading.Semaphore(1, 1);   // Create semaphore
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            butStart.Enabled = false;
            butStop.Enabled = true;
            nudDetail.Enabled = false;
            radStandard.Enabled = false;
            radInvert.Enabled = false;
            radDouble.Enabled = false;
            radTriple.Enabled = false;
            radSolid.Enabled = false;

            LaunchThread();
            //DrawFractal();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            EndDrawing();
        }

        private void butStop_EnabledChanged(object sender, EventArgs e)
        {
            // If the stop button is clicked are changed to false then reactive other controls
            if (butStop.Enabled == false)
            {
                butStart.Enabled = true;
                nudDetail.Enabled = true;
                radStandard.Enabled = true;
                radInvert.Enabled = true;
                radDouble.Enabled = true;
                radTriple.Enabled = true;
                radSolid.Enabled = true;
            }
        }

        private void LaunchThread()
        {
            System.Threading.Thread thdDraw;
            thdDraw = new System.Threading.Thread(DrawFractal);
            thdDraw.Start();
        }

        private void DrawFractal()
        {

            //MessageBox.Show("In Thread");

            // Start a new bitmap to handle the fractal
            ImageLock.WaitOne();
            ImageBitmap.Dispose();
            ImageBitmap = new Bitmap(picImage.ClientRectangle.Width, picImage.ClientRectangle.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            graphicsObj = Graphics.FromImage(ImageBitmap);
            graphicsObj.Clear(Color.White);         // Set background to white
            ImageLock.Release();

            // Create drawing tools
            //myPen = new Pen(Color.Red);
            //formGraphics = ImageBitmap.CreateGraphics();

            // Setup area of fractal
            double maxsize = Math.Min(picImage.Width, picImage.Height) / 2 * .8;

            // Get center of image area
            double cx = picImage.Width / 2;
            double cy = picImage.Height / 2;

            double p1x = cx + Math.Cos(Math.PI * 3 / 2) * maxsize;     // Top point
            double p1y = cy + Math.Sin(Math.PI * 3 / 2) * maxsize;

            double p2x = cx + Math.Cos(Math.PI * 1 / 6) * maxsize;     // Bottom right
            double p2y = cy + Math.Sin(Math.PI * 1 / 6) * maxsize;

            double p3x = cx + Math.Cos(Math.PI * 5 / 6) * maxsize;     // Bottom left
            double p3y = cy + Math.Sin(Math.PI * 5 / 6) * maxsize;

            // Top right
            myPen = new Pen(Color.Red);
            FractalLine(p1x, p1y, p2x, p2y, (int)nudDetail.Value);
            myPen.Dispose();

            // Bottom
            myPen = new Pen(Color.Green);
            FractalLine(p2x, p2y, p3x, p3y, (int)nudDetail.Value);
            myPen.Dispose();

            // Top left
            myPen = new Pen(Color.Blue);
            FractalLine(p3x, p3y, p1x, p1y, (int)nudDetail.Value);
            myPen.Dispose();

            picImage.Invalidate();              // Make sure last block of lines is displayed

            // Dispose of the drawing tools
            //myPen.Dispose();
            graphicsObj.Dispose();

            EndDrawing();
        }

        private void EndDrawing()
        {
            // Shut off stop button in a thread safe way
            if (butStop.InvokeRequired)
            {
                SetStopCallback d = new SetStopCallback(EndDrawing);
                this.Invoke(d, new object[] { });
            }
            else
                butStop.Enabled = false;
        }

        private void FractalLine(double p1x, double p1y, double p2x, double p2y, int depth)
        {
            // Drop out immediately if the stop button has been clicked.
            if (butStop.Enabled == false)
                return;

            if (depth < 1)              // If we reach 0, draw a straight line
            {
                ImageLock.WaitOne();
                graphicsObj.DrawLine(myPen, (float)p1x, (float)p1y, (float)p2x, (float)p2y);
                ImageLock.Release();
                
                int newticks = Environment.TickCount;
                if (newticks - ClockTicks > 200)
                {
                    ClockTicks = newticks;
                    picImage.Invalidate();
                }
            }
            else
            {
                // Calculate line information
                double la = Math.Atan2(p2y - p1y, p2x - p1x);  // Original line's angle
                double ll = Math.Sqrt(Math.Pow(p2y - p1y, 2) + Math.Pow(p2x - p1x, 2));  // Original line's length
                double na1 = la - Math.PI / 3;                // Normal angle
                double na2 = la + Math.PI / 3;                // Inverted angle
                double nl = ll / 3;                       // New line's length
                //MessageBox.Show("Old Angle: " + la.ToString() + "  Old Length: " + ll.ToString() + "\n" + 
                //                "New Angle: " + na.ToString() + "  New Length: " + nl.ToString());

                // Calculate next levels points
                double m1x = p1x + (p2x - p1x) / 3;
                double m1y = p1y + (p2y - p1y) / 3;
                double m2x = p1x + (p2x - p1x) * 2 / 3;
                double m2y = p1y + (p2y - p1y) * 2 / 3;
                double c1x = m1x + Math.Cos(na1) * nl;       // Outside (standard) point
                double c1y = m1y + Math.Sin(na1) * nl;
                double c2x = m1x + Math.Cos(na2) * nl;       // Inside (inverted) point
                double c2y = m1y + Math.Sin(na2) * nl;
                double i1x = p1x + Math.Cos(na2) * nl;       // Inside front fill point
                double i1y = p1y + Math.Sin(na2) * nl;
                double i2x = m2x + Math.Cos(na2) * nl;       // Inside back fill point
                double i2y = m2y + Math.Sin(na2) * nl;
                double o1x = p1x + Math.Cos(na1) * nl;       // Outside front fill point
                double o1y = p1y + Math.Sin(na1) * nl;
                double o2x = m2x + Math.Cos(na1) * nl;       // Outside front fill point
                double o2y = m2y + Math.Sin(na1) * nl;

                FractalLine(p1x, p1y, m1x, m1y, depth - 1);
                if (radTriple.Checked || radSolid.Checked)
                    FractalLine(m1x, m1y, m2x, m2y, depth - 1);    // Triple barrel hack
                if (radStandard.Checked || radDouble.Checked || radTriple.Checked || radSolid.Checked)
                    FractalLine(m1x, m1y, c1x, c1y, depth - 1);
                if (radInvert.Checked || radDouble.Checked || radTriple.Checked || radSolid.Checked)
                    FractalLine(m1x, m1y, c2x, c2y, depth - 1);    // Double barrel hack
                if (radStandard.Checked || radDouble.Checked || radTriple.Checked || radSolid.Checked)
                    FractalLine(c1x, c1y, m2x, m2y, depth - 1);
                if (radInvert.Checked || radDouble.Checked || radTriple.Checked || radSolid.Checked)
                    FractalLine(c2x, c2y, m2x, m2y, depth - 1);    // Double barrel hack
                FractalLine(m2x, m2y, p2x, p2y, depth - 1);
                if (radSolid.Checked)
                {
                    FractalLine(m2x, m2y, i2x, i2y, depth - 1);    // Inside fill back
                    FractalLine(p1x, p1y, o1x, o1y, depth - 1);    // Front outside
                    FractalLine(o1x, o1y, c1x, c1y, depth - 1);
                    FractalLine(o1x, o1y, m1x, m1y, depth - 1);
                    FractalLine(m2x, m2y, o2x, o2y, depth - 1);    // Back outside
                    FractalLine(c1x, c1y, o2x, o2y, depth - 1);
                    FractalLine(o2x, o2y, p2x, p2y, depth - 1);
                }
            }
        }

        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphObj = e.Graphics;
            ImageLock.WaitOne();
            graphObj.DrawImage(ImageBitmap, 0, 0, ImageBitmap.Width, ImageBitmap.Height);
            ImageLock.Release();
        }


    }
}
