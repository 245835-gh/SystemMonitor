using CircularProgressBar;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public partial class CpuRamForm : Form
    {
        private PerformanceCounter cpu;
        private PerformanceCounter ram;
        private PerformanceCounter cpuFreq;
        private Timer refreshTimer;
        private Computer computer;

        private Queue<float> cpuHistory = new Queue<float>();
        private Queue<float> ramHistory = new Queue<float>();



        public CpuRamForm()
        {
            InitializeComponent();
            InitPerformanceCounters();
            InitChart();
            InitHardwareMonitor();
            ApplyTheme();

            refreshTimer = new Timer();
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += timer1_Tick_1;
            refreshTimer.Start();

            numericInterval.Minimum = 100;
            numericInterval.Maximum = 10000;
            numericInterval.Value = 1000;
            numericInterval.ValueChanged += numericInterval_ValueChanged_1;
        }

        
        private void UpdateCircularProgressBars(float cpuVal, float ramVal)
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
        }

        private void InitPerformanceCounters()
        {
            try
            {
                cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ram = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                cpuFreq = new PerformanceCounter("Processor Information", "Processor Frequency", "_Total");

                cpu.NextValue();
                ram.NextValue();
                cpuFreq.NextValue();
            }
            catch
            {
                cpu = null;
                ram = null;
                cpuFreq = null;
            }
        }

        private void InitHardwareMonitor()
        {
            try
            {
                computer = new Computer() { IsCpuEnabled = true };
                computer.Open();
            }
            catch
            {
                computer = null;
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

                chart1.BackColor = Color.FromArgb(45, 45, 45);
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
                if (chart1.ChartAreas.Count > 0)
                {
                    chart1.ChartAreas[0].BackColor = Color.FromArgb(45, 45, 45);
                    chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                    chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(70, 70, 70);
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(70, 70, 70);
                }
                if (chart1.Legends.Count > 0)
                    chart1.Legends[0].ForeColor = Color.White;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.FromArgb(45, 45, 45);
                    circularCPU.OuterColor = Color.FromArgb(60, 60, 60);
                }
                if (circularRAM != null)
                {
                    circularRAM.InnerColor = Color.FromArgb(45, 45, 45);
                    circularRAM.OuterColor = Color.FromArgb(60, 60, 60);
                }


                labelCPU.ForeColor = Color.LightGreen;
                labelCPUFreq.ForeColor = Color.LightGreen;
                labelTemp.ForeColor = Color.LightGreen;
                labelRAM.ForeColor = Color.LightGreen;
                labelRAMDetails.ForeColor = Color.LightGreen;
                labelInterval.ForeColor = Color.White;

                numericInterval.BackColor = Color.FromArgb(60, 60, 60);
                numericInterval.ForeColor = Color.White;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                chart1.BackColor = Color.White;
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
                if (chart1.ChartAreas.Count > 0)
                {
                    chart1.ChartAreas[0].BackColor = Color.White;
                    chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                    chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                }
                if (chart1.Legends.Count > 0)
                    chart1.Legends[0].ForeColor = Color.Black;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.White;
                    circularCPU.OuterColor = Color.LightGray;
                }
                if (circularRAM != null)
                {
                    circularRAM.InnerColor = Color.White;
                    circularRAM.OuterColor = Color.LightGray;
                }


                labelCPU.ForeColor = Color.DarkGreen;
                labelCPUFreq.ForeColor = Color.DarkGreen;
                labelTemp.ForeColor = Color.DarkGreen;
                labelRAM.ForeColor = Color.DarkGreen;
                labelRAMDetails.ForeColor = Color.DarkGreen;
                labelInterval.ForeColor = Color.Black;

                numericInterval.BackColor = Color.White;
                numericInterval.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                chart1.BackColor = emeraldPanel;
                if (chart1.ChartAreas.Count > 0)
                {
                    chart1.ChartAreas[0].BackColor = emeraldPanel;
                    chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = emeraldText;
                    chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = emeraldText;
                    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(60, 100, 70);
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(60, 100, 70);
                }
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
                if (chart1.Legends.Count > 0)
                    chart1.Legends[0].ForeColor = emeraldText;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = emeraldPanel;
                    circularCPU.OuterColor = emeraldControl;
                }
                if (circularRAM != null)
                {
                    circularRAM.InnerColor = emeraldPanel;
                    circularRAM.OuterColor = emeraldControl;
                }


                labelCPU.ForeColor = emeraldAccent;
                labelCPUFreq.ForeColor = emeraldAccent;
                labelTemp.ForeColor = emeraldAccent;
                labelRAM.ForeColor = emeraldAccent;
                labelRAMDetails.ForeColor = emeraldText;
                labelInterval.ForeColor = emeraldText;

                numericInterval.BackColor = emeraldControl;
                numericInterval.ForeColor = emeraldText;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            float cpuVal = GetCPUUsage();
            float ramVal = GetRAMUsage();
            float freqVal = GetCpuFrequency();

            chart1.Series["CPU"].Points.AddY(cpuVal);
            chart1.Series["RAM"].Points.AddY(ramVal);

            if (chart1.Series[0].Points.Count > 60)
            {
                chart1.Series["CPU"].Points.RemoveAt(0);
                chart1.Series["RAM"].Points.RemoveAt(0);
            }

            cpuHistory.Enqueue(cpuVal);
            ramHistory.Enqueue(ramVal);
            if (cpuHistory.Count > 60) cpuHistory.Dequeue();
            if (ramHistory.Count > 60) ramHistory.Dequeue();

            UpdateCircularProgressBars(cpuVal, ramVal);

            labelCPU.Text = $"CPU: {cpuVal:F1}%";
            labelCPU.ForeColor = GetColor(cpuVal);

            labelCPUFreq.Text = freqVal > 0 ? $"CPU Freq: {freqVal:F0} MHz" : "CPU Freq: N/A";

            float temp = GetCpuTemp();
            if (temp > 0)
                labelTemp.Text = $"Temp: {temp:F1} °C";
            else
                labelTemp.Text = "Temp: N/A";

            labelRAM.Text = $"RAM: {ramVal:F1}%";
            labelRAM.ForeColor = GetColor(ramVal);

            GetRamDetails(out double used, out double free, out double total);
            labelRAMDetails.Text = $"Used: {used:F1} GB | Free: {free:F1} GB | Total: {total:F1} GB";
        }

        private float GetCPUUsage()
        {
            if (cpu != null)
            {
                try { return cpu.NextValue(); }
                catch { }
            }
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT LoadPercentage FROM Win32_Processor"))
                {
                    foreach (var obj in searcher.Get())
                        return Convert.ToSingle(obj["LoadPercentage"]);
                }
            }
            catch { }
            return 0;
        }

        private float GetRAMUsage()
        {
            if (ram != null)
            {
                try { return ram.NextValue(); }
                catch { }
            }
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        ulong total = (ulong)obj["TotalVisibleMemorySize"];
                        ulong free = (ulong)obj["FreePhysicalMemory"];
                        return (float)((total - free) * 100.0 / total);
                    }
                }
            }
            catch { }
            return 0;
        }

        private float GetCpuFrequency()
        {
            if (cpuFreq != null)
            {
                try { return cpuFreq.NextValue(); }
                catch { }
            }
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT CurrentClockSpeed FROM Win32_Processor"))
                {
                    foreach (var obj in searcher.Get())
                        return Convert.ToSingle(obj["CurrentClockSpeed"]);
                }
            }
            catch { }
            return 0;
        }

        private float GetCpuTemp()
        {
            if (computer != null)
            {
                try
                {
                    foreach (var hardware in computer.Hardware)
                    {
                        if (hardware.HardwareType == HardwareType.Cpu)
                        {
                            hardware.Update();
                            foreach (var sensor in hardware.Sensors)
                            {
                                if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                                    return sensor.Value.Value;
                            }
                        }
                    }
                }
                catch { }
            }
            return 0;
        }

        private void GetRamDetails(out double used, out double free, out double total)
        {
            used = 0; free = 0; total = 0;
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        total = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024 / 1024;
                        free = Convert.ToDouble(obj["FreePhysicalMemory"]) / 1024 / 1024;
                        used = total - free;
                    }
                }
            }
            catch { }
        }

        private Color GetColor(float value)
        {
            if (value < 50) return Color.Lime;
            if (value < 80) return Color.Orange;
            return Color.Red;
        }

        private void numericInterval_ValueChanged_1(object sender, EventArgs e)
        {
            int interval = (int)numericInterval.Value;
            if (interval >= 100 && interval <= 10000)
            {
                refreshTimer.Interval = interval;
                labelInterval.Text = $"Interval: {interval} ms";
            }
        }

        private void InitChart()
        {
            chart1.Series.Clear();

            var s1 = chart1.Series.Add("CPU");
            s1.ChartType = SeriesChartType.Line;
            s1.Color = Color.FromArgb(0, 120, 215);
            s1.BorderWidth = 2;

            var s2 = chart1.Series.Add("RAM");
            s2.ChartType = SeriesChartType.Line;
            s2.Color = Color.FromArgb(0, 200, 80);
            s2.BorderWidth = 2;

            if (chart1.ChartAreas.Count > 0)
            {
                chart1.ChartAreas[0].AxisY.Title = "Використання (%)";
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 100;
                chart1.ChartAreas[0].AxisX.Title = "Час (секунди)";
            }

            if (chart1.Legends.Count > 0)
                chart1.Legends[0].Docking = Docking.Bottom;
        }

        private void CpuRamForm_Load(object sender, EventArgs e)
        {
            labelInterval.Text = $"Interval: {refreshTimer.Interval} ms";
        }

        private void chart1_Click(object sender, EventArgs e) { }

    }
}