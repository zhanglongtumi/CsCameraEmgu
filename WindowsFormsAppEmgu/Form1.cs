using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEmgu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCapture _capture = null;
        private Stopwatch _stopWatch = new Stopwatch();
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture(0);

            if (_capture.IsOpened)
            {
                Application.Idle += Application_Idle;
                _stopWatch.Start();
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            _stopWatch.Stop();
            Console.WriteLine("用时{0}毫秒", _stopWatch.ElapsedMilliseconds);
            pictureBox1.Image = _capture.QueryFrame().Clone().Bitmap;
            _stopWatch.Restart();
        }
    }
}
