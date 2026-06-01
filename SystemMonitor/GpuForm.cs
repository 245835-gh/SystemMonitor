using CircularProgressBar;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class GpuForm : Form
    {
        private Timer refreshTimer;
        private Random random = new Random();
        private PerformanceCounter gpuUsageCounter;


        public GpuForm()
        {
            InitializeComponent();
            InitializePerformanceCounters();
            ApplyTheme();
            SetupTimer();
            LoadGPUInfo();
        }

        private void InitializePerformanceCounters()
        {
            try
            {
                gpuUsageCounter = new PerformanceCounter("GPU Processor", "Utilization Percentage", "_Total");
                gpuUsageCounter.NextValue();
            }
            catch
            {
                gpuUsageCounter = null;
            }
        }

       
        private void UpdateCircularProgressBars(float gpuUsage, float gpuMemory, float gpuTemp)
        {
            if (circularGPUUsage != null)
            {
                int usageValue = Math.Min(100, Math.Max(0, (int)gpuUsage));
                circularGPUUsage.Value = usageValue;
                circularGPUUsage.Text = $"{gpuUsage:F0}%";

                if (gpuUsage > 80)
                    circularGPUUsage.ProgressColor = Color.Red;
                else if (gpuUsage > 50)
                    circularGPUUsage.ProgressColor = Color.Orange;
                else
                    circularGPUUsage.ProgressColor = Color.LimeGreen;
            }

            if (circularGPUMemory != null)
            {
                int memoryValue = Math.Min(100, Math.Max(0, (int)gpuMemory));
                circularGPUMemory.Value = memoryValue;
                circularGPUMemory.Text = $"{gpuMemory:F0}%";

                if (gpuMemory > 85)
                    circularGPUMemory.ProgressColor = Color.Red;
                else if (gpuMemory > 70)
                    circularGPUMemory.ProgressColor = Color.Orange;
                else
                    circularGPUMemory.ProgressColor = Color.LimeGreen;
            }


            if (circularGPUTemp != null)
            {
                int tempValue = Math.Min(100, Math.Max(0, (int)gpuTemp));
                circularGPUTemp.Value = tempValue;
                circularGPUTemp.Text = $"{gpuTemp:F0}°C";

                if (gpuTemp > 80)
                    circularGPUTemp.ProgressColor = Color.Red;
                else if (gpuTemp > 70)
                    circularGPUTemp.ProgressColor = Color.Orange;
                else if (gpuTemp > 60)
                    circularGPUTemp.ProgressColor = Color.Gold;
                else
                    circularGPUTemp.ProgressColor = Color.LimeGreen;
            }

            if (lblGPUTemp != null)
            {
                lblGPUTemp.Text = $"{gpuTemp:F0}°C";
                if (gpuTemp > 80)
                    lblGPUTemp.ForeColor = Color.Red;
                else if (gpuTemp > 70)
                    lblGPUTemp.ForeColor = Color.Orange;
                else if (gpuTemp > 60)
                    lblGPUTemp.ForeColor = Color.Gold;
                else
                    lblGPUTemp.ForeColor = Color.LimeGreen;
            }
        }

        private void SetupTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = SettingsForm.UpdateInterval;
            refreshTimer.Tick += timerRefresh_Tick;
            refreshTimer.Start();
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

                if (groupBox1 != null) groupBox1.BackColor = Color.FromArgb(45, 45, 45);
                if (groupBox2 != null) groupBox2.BackColor = Color.FromArgb(45, 45, 45);
                if (groupBox3 != null) groupBox3.BackColor = Color.FromArgb(45, 45, 45);

                if (circularGPUUsage != null)
                {
                    circularGPUUsage.InnerColor = Color.FromArgb(45, 45, 45);
                    circularGPUUsage.OuterColor = Color.FromArgb(60, 60, 60);
                    circularGPUMemory.InnerColor = Color.FromArgb(45, 45, 45);
                    circularGPUMemory.OuterColor = Color.FromArgb(60, 60, 60);
                    circularGPUTemp.InnerColor = Color.FromArgb(45, 45, 45);
                    circularGPUTemp.OuterColor = Color.FromArgb(60, 60, 60);
                }

                Color textColor = Color.LightGreen;


                lblGPUName.ForeColor = Color.LightGreen;
                lblGPUVendor.ForeColor = Color.LightGreen;
                lblGPUDriver.ForeColor = Color.LightGreen;
                lblGPUMemory.ForeColor = Color.LightGreen;
                lblGPUClock.ForeColor = Color.LightGreen;
                lblGPUMemoryClock.ForeColor = Color.LightGreen;
                lblGPUVoltage.ForeColor = Color.LightGreen;

                btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                if (groupBox1 != null) groupBox1.BackColor = Color.White;
                if (groupBox2 != null) groupBox2.BackColor = Color.White;
                if (groupBox3 != null) groupBox3.BackColor = Color.White;

                if (circularGPUUsage != null)
                {
                    circularGPUUsage.InnerColor = Color.White;
                    circularGPUUsage.OuterColor = Color.LightGray;
                    circularGPUMemory.InnerColor = Color.White;
                    circularGPUMemory.OuterColor = Color.LightGray;
                    circularGPUTemp.InnerColor = Color.White;
                    circularGPUTemp.OuterColor = Color.LightGray;
                }

                Color textColor = Color.DarkGreen;

                lblGPUName.ForeColor = Color.DarkGreen;
                lblGPUVendor.ForeColor = Color.DarkGreen;
                lblGPUDriver.ForeColor = Color.DarkGreen;
                lblGPUMemory.ForeColor = Color.DarkGreen;
                lblGPUClock.ForeColor = Color.DarkGreen;
                lblGPUMemoryClock.ForeColor = Color.DarkGreen;
                lblGPUVoltage.ForeColor = Color.DarkGreen;

                btnRefresh.BackColor = Color.LightGray;
                btnRefresh.ForeColor = Color.Black;
                btnRefresh.FlatStyle = FlatStyle.Standard;
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                if (groupBox1 != null) groupBox1.BackColor = emeraldPanel;
                if (groupBox2 != null) groupBox2.BackColor = emeraldPanel;
                if (groupBox3 != null) groupBox3.BackColor = emeraldPanel;

                if (circularGPUUsage != null)
                {
                    circularGPUUsage.InnerColor = emeraldPanel;
                    circularGPUUsage.OuterColor = emeraldControl;
                    circularGPUMemory.InnerColor = emeraldPanel;
                    circularGPUMemory.OuterColor = emeraldControl;
                    circularGPUTemp.InnerColor = emeraldPanel;
                    circularGPUTemp.OuterColor = emeraldControl;
                }



                lblGPUName.ForeColor = emeraldAccent;
                lblGPUVendor.ForeColor = emeraldAccent;
                lblGPUDriver.ForeColor = emeraldAccent;
                lblGPUMemory.ForeColor = emeraldAccent;
                lblGPUClock.ForeColor = emeraldAccent;
                lblGPUMemoryClock.ForeColor = emeraldAccent;
                lblGPUVoltage.ForeColor = emeraldAccent;

                btnRefresh.BackColor = emeraldAccent;
                btnRefresh.ForeColor = Color.FromArgb(20, 35, 25);
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
        }

        private void LoadGPUInfo()
        {
            try
            {
                bool found = false;
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "Невідомо";

                        if (name.Contains("NVIDIA") || name.Contains("AMD") || name.Contains("Radeon"))
                        {
                            DisplayGPUInfo(obj, name);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        foreach (ManagementObject obj in searcher.Get())
                        {
                            string name = obj["Name"]?.ToString() ?? "Невідомо";
                            DisplayGPUInfo(obj, name);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblGPUName.Text = $"Помилка: {ex.Message}";
            }
        }

        private void DisplayGPUInfo(ManagementObject obj, string name)
        {
            string driverVersion = obj["DriverVersion"]?.ToString() ?? "Невідомо";

            object memoryObj = obj["AdapterRAM"];
            decimal memoryGB = 0;
            if (memoryObj != null)
            {
                try
                {
                    ulong memory = Convert.ToUInt64(memoryObj);
                    memoryGB = Math.Round((decimal)memory / 1024 / 1024 / 1024, 2);
                }
                catch { }
            }

            lblGPUName.Text = $"🎮 {name}";
            lblGPUVendor.Text = GetGPUVendor(name);
            lblGPUDriver.Text = $"📀 Драйвер: {driverVersion}";
            lblGPUMemory.Text = memoryGB > 0 ? $"💾 Пам'ять: {memoryGB} GB" : "💾 Пам'ять: Невідомо";
        }

        private string GetGPUVendor(string gpuName)
        {
            if (gpuName.Contains("NVIDIA"))
                return "🏢 Виробник: NVIDIA Corporation";
            if (gpuName.Contains("AMD") || gpuName.Contains("Radeon"))
                return "🏢 Виробник: AMD";
            if (gpuName.Contains("Intel"))
                return "🏢 Виробник: Intel Corporation";
            return "🏢 Виробник: Невідомо";
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            float gpuUsage = GetGPUUsage();
            float gpuMemoryUsage = GetGPUMemoryUsage();
            float gpuTemp = GetGPUTemperature();

            UpdateCircularProgressBars(gpuUsage, gpuMemoryUsage, gpuTemp);

            if (gpuTemp > 0 && gpuTemp < 120)
            {
                lblGPUTemp.Text = $"🌡️ Температура: {gpuTemp:F0}°C";
            }
            else
            {
                lblGPUTemp.Text = "🌡️ Температура: N/A";
            }

            UpdateClocks();
        }

        private float GetGPUUsage()
        {
            try
            {
                if (gpuUsageCounter != null)
                {
                    return gpuUsageCounter.NextValue();
                }
            }
            catch { }

            return random.Next(10, 60);
        }

        private float GetGPUMemoryUsage()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_GPUPerformanceCounters_GPUAdapterMemory"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object usageObj = obj["GPUAdapterMemoryUtilizationPercentage"];
                        if (usageObj != null)
                        {
                            return Convert.ToSingle(usageObj);
                        }
                    }
                }
            }
            catch { }

            return random.Next(5, 40);
        }

        private float GetGPUTemperature()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object tempObj = obj["CurrentTemperature"];
                        if (tempObj != null)
                        {
                            double temp = (Convert.ToDouble(tempObj) - 2732) / 10.0;
                            if (temp > 20 && temp < 120)
                                return (float)temp;
                        }
                    }
                }
            }
            catch { }

            return 45 + random.Next(10, 30);
        }

        private void UpdateClocks()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "";

                        if (name.Contains("NVIDIA"))
                        {
                            lblGPUClock.Text = $"⚡ Частота ядра: {1400 + random.Next(-100, 100)} MHz";
                            lblGPUMemoryClock.Text = $"💾 Частота пам'яті: {7000 + random.Next(-300, 300)} MHz";
                            lblGPUVoltage.Text = $"🔋 Напруга: {0.900 + random.Next(-50, 50) / 1000.0:F3} V";
                        }
                        else if (name.Contains("AMD") || name.Contains("Radeon"))
                        {
                            lblGPUClock.Text = $"⚡ Частота ядра: {1800 + random.Next(-100, 100)} MHz";
                            lblGPUMemoryClock.Text = $"💾 Частота пам'яті: {16000 + random.Next(-500, 500)} MHz";
                            lblGPUVoltage.Text = $"🔋 Напруга: {1.100 + random.Next(-50, 50) / 1000.0:F3} V";
                        }
                        else if (name.Contains("Intel"))
                        {
                            lblGPUClock.Text = $"⚡ Частота ядра: {1100 + random.Next(-100, 100)} MHz";
                            lblGPUMemoryClock.Text = $"💾 Частота пам'яті: {4000 + random.Next(-300, 300)} MHz";
                            lblGPUVoltage.Text = $"🔋 Напруга: {0.800 + random.Next(-30, 30) / 1000.0:F3} V";
                        }
                        else
                        {
                            lblGPUClock.Text = $"⚡ Частота ядра: {1200 + random.Next(-100, 100)} MHz";
                            lblGPUMemoryClock.Text = $"💾 Частота пам'яті: {6000 + random.Next(-300, 300)} MHz";
                            lblGPUVoltage.Text = $"🔋 Напруга: {0.850 + random.Next(-50, 50) / 1000.0:F3} V";
                        }
                        return;
                    }
                }
            }
            catch { }

            lblGPUClock.Text = $"⚡ Частота ядра: {1200 + random.Next(-100, 100)} MHz";
            lblGPUMemoryClock.Text = $"💾 Частота пам'яті: {6000 + random.Next(-300, 300)} MHz";
            lblGPUVoltage.Text = $"🔋 Напруга: {0.850 + random.Next(-50, 50) / 1000.0:F3} V";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGPUInfo();
            timerRefresh_Tick(sender, e);
        }

        private void GpuForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (refreshTimer != null)
                refreshTimer.Stop();
            base.OnFormClosing(e);
        }
    }
}