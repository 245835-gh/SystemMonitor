using System;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class SplashForm : Form
    {
        Timer t = new Timer();

        public SplashForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            t.Interval = 2000;
            t.Tick += T_Tick;

        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();

            Form1 main = new Form1();
            main.Show();

            this.Hide();
        }
    }
}