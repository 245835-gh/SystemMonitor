using CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public partial class DashboardForm : Form
    {
        PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ram = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        Timer timer = new Timer();
        long lastBytes = 0;
        Queue<float> cpuHistory = new Queue<float>();

        public DashboardForm()
        {
            InitializeComponent();
            InitChart();
            ApplyTheme();

            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
        }


        private void UpdateCircularProgressBars(float cpuVal, float ramVal, int diskPercent)
        {
            if (circularCPU != null)
            {
                circularCPU.Value = (int)cpuVal;
                circularCPU.Text = $"{cpuVal:F0}%";
                if (cpuVal > 80) circularCPU.ProgressColor = Color.Red;
                else if (cpuVal > 50) circularCPU.ProgressColor = Color.Orange;
                else circularCPU.ProgressColor = Color.LimeGreen;
            }

            if (circularRAM != null)
            {
                circularRAM.Value = (int)ramVal;
                circularRAM.Text = $"{ramVal:F0}%";
                if (ramVal > 85) circularRAM.ProgressColor = Color.Red;
                else if (ramVal > 70) circularRAM.ProgressColor = Color.Orange;
                else circularRAM.ProgressColor = Color.LimeGreen;
            }

            if (circularDisk != null)
            {
                circularDisk.Value = diskPercent;
                circularDisk.Text = $"{diskPercent}%";
                if (diskPercent > 90) circularDisk.ProgressColor = Color.Red;
                else if (diskPercent > 75) circularDisk.ProgressColor = Color.Orange;
                else circularDisk.ProgressColor = Color.LimeGreen;
            }
        }


        private void DashboardForm_Load(object sender, EventArgs e)
        {
        }

        private void InitChart()
        {
            chartUsage.Series.Clear();

            chartUsage.Series.Add("CPU");
            chartUsage.Series.Add("RAM");

            chartUsage.Series["CPU"].ChartType = SeriesChartType.Line;
            chartUsage.Series["CPU"].Color = Color.FromArgb(0, 120, 215);
            chartUsage.Series["CPU"].BorderWidth = 2;

            chartUsage.Series["RAM"].ChartType = SeriesChartType.Line;
            chartUsage.Series["RAM"].Color = Color.FromArgb(0, 200, 80);
            chartUsage.Series["RAM"].BorderWidth = 2;

            if (chartUsage.ChartAreas.Count > 0)
            {
                chartUsage.ChartAreas[0].AxisY.Title = "Використання (%)";
                chartUsage.ChartAreas[0].AxisY.Minimum = 0;
                chartUsage.ChartAreas[0].AxisY.Maximum = 100;
                chartUsage.ChartAreas[0].AxisX.Title = "Час (секунди)";
            }
        }

        public void ApplyTheme()
        {
            Color emeraldBg = Color.FromArgb(20, 35, 25);
            Color emeraldPanel = Color.FromArgb(30, 55, 40);
            Color emeraldControl = Color.FromArgb(40, 75, 55);
            Color emeraldText = Color.FromArgb(180, 255, 220);
            Color emeraldAccent = Color.FromArgb(80, 200, 120);

            if (SettingsForm.ThemeMode == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;

                if (groupBox1 != null)
                {
                    groupBox1.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox1.ForeColor = Color.White;
                }
                if (groupBox2 != null)
                {
                    groupBox2.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox2.ForeColor = Color.White;
                }
                if (groupBox3 != null)
                {
                    groupBox3.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox3.ForeColor = Color.White;
                }
                if (groupBox4 != null)
                {
                    groupBox4.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox4.ForeColor = Color.White;
                }
                if (groupBox5 != null)
                {
                    groupBox5.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox5.ForeColor = Color.White;
                }

                chartUsage.BackColor = Color.FromArgb(45, 45, 45);
                if (chartUsage.ChartAreas.Count > 0)
                {
                    chartUsage.ChartAreas[0].BackColor = Color.FromArgb(45, 45, 45);
                    chartUsage.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                    chartUsage.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                    chartUsage.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(70, 70, 70);
                    chartUsage.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(70, 70, 70);
                }
                if (chartUsage.Legends.Count > 0)
                    chartUsage.Legends[0].ForeColor = Color.White;

                if (listTopProcesses != null)
                {
                    listTopProcesses.BackColor = Color.FromArgb(60, 60, 60);
                    listTopProcesses.ForeColor = Color.White;
                }

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.FromArgb(45, 45, 45);
                    circularCPU.OuterColor = Color.FromArgb(60, 60, 60);
                }

                labelCPU.ForeColor = Color.LightGreen;
                labelRAM.ForeColor = Color.LightGreen;
                labelDisk.ForeColor = Color.LightGreen;
                labelProc.ForeColor = Color.LightGreen;
                labelNet.ForeColor = Color.LightGreen;
                labelUptime.ForeColor = Color.LightGreen;
                labelOS.ForeColor = Color.LightGreen;
                labelAvg.ForeColor = Color.LightBlue;
                labelAlert.ForeColor = Color.LightCoral;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                if (groupBox1 != null)
                {
                    groupBox1.BackColor = Color.White;
                    groupBox1.ForeColor = Color.Black;
                }
                if (groupBox2 != null)
                {
                    groupBox2.BackColor = Color.White;
                    groupBox2.ForeColor = Color.Black;
                }
                if (groupBox3 != null)
                {
                    groupBox3.BackColor = Color.White;
                    groupBox3.ForeColor = Color.Black;
                }
                if (groupBox4 != null)
                {
                    groupBox4.BackColor = Color.White;
                    groupBox4.ForeColor = Color.Black;
                }
                if (groupBox5 != null)
                {
                    groupBox5.BackColor = Color.White;
                    groupBox5.ForeColor = Color.Black;
                }

                chartUsage.BackColor = Color.White;
                if (chartUsage.ChartAreas.Count > 0)
                {
                    chartUsage.ChartAreas[0].BackColor = Color.White;
                    chartUsage.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                    chartUsage.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                    chartUsage.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chartUsage.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                }
                if (chartUsage.Legends.Count > 0)
                    chartUsage.Legends[0].ForeColor = Color.Black;

                if (listTopProcesses != null)
                {
                    listTopProcesses.BackColor = Color.White;
                    listTopProcesses.ForeColor = Color.Black;
                }

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.White;
                    circularCPU.OuterColor = Color.LightGray;
                }

                labelCPU.ForeColor = Color.DarkGreen;
                labelRAM.ForeColor = Color.DarkGreen;
                labelDisk.ForeColor = Color.DarkGreen;
                labelProc.ForeColor = Color.DarkGreen;
                labelNet.ForeColor = Color.DarkGreen;
                labelUptime.ForeColor = Color.DarkGreen;
                labelOS.ForeColor = Color.DarkGreen;
                labelAvg.ForeColor = Color.Blue;
                labelAlert.ForeColor = Color.Red;
            }
            else
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                if (groupBox1 != null)
                {
                    groupBox1.BackColor = emeraldPanel;
                    groupBox1.ForeColor = emeraldText;
                }
                if (groupBox2 != null)
                {
                    groupBox2.BackColor = emeraldPanel;
                    groupBox2.ForeColor = emeraldText;
                }
                if (groupBox3 != null)
                {
                    groupBox3.BackColor = emeraldPanel;
                    groupBox3.ForeColor = emeraldText;
                }
                if (groupBox4 != null)
                {
                    groupBox4.BackColor = emeraldPanel;
                    groupBox4.ForeColor = emeraldText;
                }
                if (groupBox5 != null)
                {
                    groupBox5.BackColor = Color.FromArgb(45, 45, 45);
                    groupBox5.ForeColor = Color.White;
                }

                chartUsage.BackColor = emeraldPanel;
                if (chartUsage.ChartAreas.Count > 0)
                {
                    chartUsage.ChartAreas[0].BackColor = emeraldPanel;
                    chartUsage.ChartAreas[0].AxisX.LabelStyle.ForeColor = emeraldText;
                    chartUsage.ChartAreas[0].AxisY.LabelStyle.ForeColor = emeraldText;
                    chartUsage.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(60, 100, 70);
                    chartUsage.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(60, 100, 70);
                }
                if (chartUsage.Legends.Count > 0)
                    chartUsage.Legends[0].ForeColor = emeraldText;

                if (listTopProcesses != null)
                {
                    listTopProcesses.BackColor = emeraldControl;
                    listTopProcesses.ForeColor = emeraldText;
                }

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = emeraldPanel;
                    circularCPU.OuterColor = emeraldControl;
                }

                labelCPU.ForeColor = emeraldAccent;
                labelRAM.ForeColor = emeraldAccent;
                labelDisk.ForeColor = emeraldAccent;
                labelProc.ForeColor = emeraldText;
                labelNet.ForeColor = emeraldText;
                labelUptime.ForeColor = emeraldText;
                labelOS.ForeColor = emeraldText;
                labelAvg.ForeColor = emeraldAccent;
                labelAlert.ForeColor = Color.FromArgb(255, 120, 120);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float cpuVal = cpu.NextValue();
            float ramVal = ram.NextValue();

            chartUsage.Series["CPU"].Points.AddY(cpuVal);
            chartUsage.Series["RAM"].Points.AddY(ramVal);

            if (chartUsage.Series[0].Points.Count > 60)
            {
                chartUsage.Series["CPU"].Points.RemoveAt(0);
                chartUsage.Series["RAM"].Points.RemoveAt(0);
            }

            cpuHistory.Enqueue(cpuVal);
            if (cpuHistory.Count > 60)
                cpuHistory.Dequeue();

            labelAvg.Text = $"📊 Сер. CPU: {cpuHistory.Average():F1}%";

            labelCPU.Text = $"💻 CPU: {cpuVal:F1}%";
            labelRAM.Text = $"🧠 RAM: {ramVal:F1}%";

            labelCPU.ForeColor = GetColor(cpuVal);
            labelRAM.ForeColor = GetColor(ramVal);

            labelProc.Text = $"📊 Процесів: {Process.GetProcesses().Length}";
            labelOS.Text = $"🪟 {Environment.OSVersion.VersionString}";

            if (cpuVal > 90 && SettingsForm.EnableAlerts)
                labelAlert.Text = "⚠️ ВИСОКЕ НАВАНТАЖЕННЯ CPU!";
            else if (ramVal > 90 && SettingsForm.EnableAlerts)
                labelAlert.Text = "⚠️ ВИСОКЕ НАВАНТАЖЕННЯ RAM!";
            else
                labelAlert.Text = "✅ Система працює нормально";

            labelUptime.Text = $"⏱ Аптайм: {TimeSpan.FromMilliseconds(Environment.TickCount)}";

            long current = NetworkInterface.GetAllNetworkInterfaces()
                .Sum(n => n.GetIPv4Statistics().BytesReceived);

            long speed = (current - lastBytes) / 1024;
            lastBytes = current;
            labelNet.Text = $"🌐 Мережа: {Math.Max(0, speed)} KB/s";

            var d = DriveInfo.GetDrives().FirstOrDefault(x => x.IsReady && x.Name.Contains("C:"));
            if (d != null)
            {
                long free = d.AvailableFreeSpace / (1024 * 1024 * 1024);
                long total = d.TotalSize / (1024 * 1024 * 1024);
                long used = total - free;
                int percent = (int)((double)(d.TotalSize - d.AvailableFreeSpace) / d.TotalSize * 100);

                labelDisk.Text = $"💽 Диск C: {used}/{total} GB ({percent}%)";
                UpdateCircularProgressBars(cpuVal, ramVal, percent);
            }
            else
            {
                UpdateCircularProgressBars(cpuVal, ramVal, 0);
            }

            LoadTopProcesses();
        }

        private Color GetColor(float value)
        {
            if (value < 50) return Color.Lime;
            if (value < 80) return Color.Orange;
            return Color.Red;
        }

        private void LoadTopProcesses()
        {
            try
            {
                var processes = Process.GetProcesses()
                    .Select(p =>
                    {
                        try
                        {
                            return new
                            {
                                Name = p.ProcessName,
                                CPU = p.TotalProcessorTime.TotalMilliseconds,
                                RAM = p.WorkingSet64 / 1024 / 1024
                            };
                        }
                        catch { return null; }
                    })
                    .Where(p => p != null)
                    .OrderByDescending(p => p.CPU)
                    .Take(10)
                    .ToList();

                if (listTopProcesses != null)
                {
                    listTopProcesses.Items.Clear();
                    listTopProcesses.Items.Add("════════ ТОП-10 ПРОЦЕСІВ ════════");

                    foreach (var p in processes)
                    {
                        string name = p.Name.Length > 20 ? p.Name.Substring(0, 17) + "..." : p.Name;
                        listTopProcesses.Items.Add($"{name,-20} │ CPU: {p.CPU / 100:F1}% │ RAM: {p.RAM,3} MB");
                    }
                }
            }
            catch { }
        }

        private void chartUsage_Click(object sender, EventArgs e)
        {
            CpuRamForm cpuRamForm = new CpuRamForm();
            cpuRamForm.ShowDialog();
        }
    }
}