using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            Color emeraldBg = Color.FromArgb(20, 35, 25);      
            Color emeraldPanel = Color.FromArgb(30, 55, 40);   
            Color emeraldMenu = Color.FromArgb(25, 45, 35);     
            Color emeraldText = Color.FromArgb(180, 255, 220);

            if (SettingsForm.ThemeMode == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;

                menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
                menuStrip1.ForeColor = Color.White;

                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.BackColor = Color.FromArgb(45, 45, 45);
                    item.ForeColor = Color.White;
                }

                mainPanel.BackColor = Color.FromArgb(30, 30, 30);
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                menuStrip1.BackColor = Color.White;
                menuStrip1.ForeColor = Color.Black;

                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }

                mainPanel.BackColor = Color.FromArgb(240, 240, 240);
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                menuStrip1.BackColor = emeraldMenu;
                menuStrip1.ForeColor = emeraldText;

                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.BackColor = emeraldMenu;
                    item.ForeColor = emeraldText;
                }

                mainPanel.BackColor = emeraldBg;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LoadForm(Form form)
        {
            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void cPURAMToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadForm(new CpuRamForm());
        }
        
        private void дискиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadForm(new DiskForm());
        }

        private void процесиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadForm(new ProcessForm());
        }

        private void програмиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadForm(new ProgramsForm());
        }

        private void мережаPingScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new NetworkForm());
        }

        private void системаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadForm(new SystemForm());
        }

        private void головнеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new DashboardForm());
        }

        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new GpuForm());
        }

        private void температураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new TemperatureForm());
        }
    }
}