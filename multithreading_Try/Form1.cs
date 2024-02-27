using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace multithreading_Try
{
    public partial class Form1 : Form
    {
        private Thread circleThread;
        private Thread rectangleThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circleThread = new Thread(DrawCircle);
            rectangleThread = new Thread(DrawRectangle);

            circleThread.Start();
            rectangleThread.Start();
        }

        private void DrawCircle()
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen pen = new Pen(Color.Blue);
                for (int i = 1; i <= 100; i++)
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(50, 50, i, i));
                    /*g.Clear(this.BackColor);*/
                    g.DrawEllipse(pen, 50, 50, i, i);
                    Thread.Sleep(50);
                }
            }
        }

        private void DrawRectangle()
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen pen = new Pen(Color.Red);
                for (int i = 1; i <= 100; i++)
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(300, 50, i, i));
                    /*g.Clear(this.BackColor);*/
                    g.DrawRectangle(pen, 300, 50, i, i);
                    Thread.Sleep(50);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            circleThread.Join();
            rectangleThread.Join();
        }
    }
}
