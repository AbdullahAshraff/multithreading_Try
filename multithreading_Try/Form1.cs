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

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Start threads to draw circle and rectangle
            circleThread = new Thread(DrawCircle);
            rectangleThread = new Thread(DrawRectangle);

            circleThread.Start();
            rectangleThread.Start();
        }

        private void DrawCircle()
        {
            using (Graphics g = CreateGraphics())
            {
                // Draw a circle
                Pen pen = new Pen(Color.Blue);
                g.DrawEllipse(pen, 50, 50, 100, 100);
            }
        }

        private void DrawRectangle()
        {
            using (Graphics g = CreateGraphics())
            {
                // Draw a rectangle
                Pen pen = new Pen(Color.Red);
                g.DrawRectangle(pen, 200, 50, 100, 100);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure to stop the threads when closing the form
            circleThread.Join();
            rectangleThread.Join();
        }
    }
}
