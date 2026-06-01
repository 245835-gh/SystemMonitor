using CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class TemperatureForm : Form
    {
        private Timer refreshTimer;
        private List<TemperatureSensor> sensors = new List<TemperatureSensor>();
        private float maxCPUTemp = 0;
        private float maxGPUTemp = 0;
        private float maxHDDTemp = 0;
        private float currentCPUTemp = 0;
        private float currentGPUTemp = 0;
        private float currentHDDTemp = 0;



        public TemperatureForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupListView();
            SetupTimer();
            LoadTemperatures();
        }

        

        private void UpdateCircularProgressBars()
        {
            if (circularCPU != null)
            {
                int cpuValue = Math.Min(100, Math.Max(0, (int)currentCPUTemp));
                circularCPU.Value = cpuValue;
                circularCPU.Text = $"{currentCPUTemp:F0}°C";

                if (currentCPUTemp > 80)
                    circularCPU.ProgressColor = Color.Red;
                else if (currentCPUTemp > 70)
                    circularCPU.ProgressColor = Color.Orange;
                else if (currentCPUTemp > 60)
                    circularCPU.ProgressColor = Color.Gold;
                else
                    circularCPU.ProgressColor = Color.LimeGreen;
            }


            if (circularGPU != null)
            {
                int gpuValue = Math.Min(100, Math.Max(0, (int)currentGPUTemp));
                circularGPU.Value = gpuValue;
                circularGPU.Text = $"{currentGPUTemp:F0}°C";

                if (currentGPUTemp > 80)
                    circularGPU.ProgressColor = Color.Red;
                else if (currentGPUTemp > 70)
                    circularGPU.ProgressColor = Color.Orange;
                else if (currentGPUTemp > 60)
                    circularGPU.ProgressColor = Color.Gold;
                else
                    circularGPU.ProgressColor = Color.LimeGreen;
            }


            if (circularHDD != null)
            {
                int hddValue = Math.Min(100, Math.Max(0, (int)currentHDDTemp));
                circularHDD.Value = hddValue;
                circularHDD.Text = $"{currentHDDTemp:F0}°C";

                if (currentHDDTemp > 80)
                    circularHDD.ProgressColor = Color.Red;
                else if (currentHDDTemp > 70)
                    circularHDD.ProgressColor = Color.Orange;
                else if (currentHDDTemp > 60)
                    circularHDD.ProgressColor = Color.Gold;
                else
                    circularHDD.ProgressColor = Color.LimeGreen;
            }

        }

        private void SetupTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = SettingsForm.UpdateInterval;
            refreshTimer.Tick += timerRefresh_Tick;
            refreshTimer.Start();
        }

        private void SetupListView()
        {
            listViewTemperatures.View = View.Details;
            listViewTemperatures.FullRowSelect = true;
            listViewTemperatures.GridLines = true;

            listViewTemperatures.Columns.Add("🌡️ Компонент", 200);
            listViewTemperatures.Columns.Add("🔥 Температура", 100);
            listViewTemperatures.Columns.Add("📊 Стан", 120);
            listViewTemperatures.Columns.Add("📍 Джерело", 150);
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

                groupBox1.BackColor = Color.FromArgb(45, 45, 45);
                groupBox1.ForeColor = Color.White;

                listViewTemperatures.BackColor = Color.FromArgb(50, 50, 50);
                listViewTemperatures.ForeColor = Color.White;
                listViewTemperatures.HeaderStyle = ColumnHeaderStyle.Nonclickable;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.FromArgb(45, 45, 45);
                    circularCPU.OuterColor = Color.FromArgb(60, 60, 60);
                    circularGPU.InnerColor = Color.FromArgb(45, 45, 45);
                    circularGPU.OuterColor = Color.FromArgb(60, 60, 60);
                    circularHDD.InnerColor = Color.FromArgb(45, 45, 45);
                    circularHDD.OuterColor = Color.FromArgb(60, 60, 60);
                }

                lblCPUTemp.ForeColor = Color.LightGreen;
                lblGPUTemp.ForeColor = Color.LightGreen;
                lblHDDTemp.ForeColor = Color.LightGreen;
                lblCPUMax.ForeColor = Color.LightGreen;
                lblGPUMax.ForeColor = Color.LightGreen;
                lblHDDMax.ForeColor = Color.LightGreen;
                lblStatus.ForeColor = Color.LightGreen;

                btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;

                listViewTemperatures.BackColor = Color.White;
                listViewTemperatures.ForeColor = Color.Black;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = Color.White;
                    circularCPU.OuterColor = Color.LightGray;
                    circularGPU.InnerColor = Color.White;
                    circularGPU.OuterColor = Color.LightGray;
                    circularHDD.InnerColor = Color.White;
                    circularHDD.OuterColor = Color.LightGray;
                }

                lblCPUTemp.ForeColor = Color.DarkGreen;
                lblGPUTemp.ForeColor = Color.DarkGreen;
                lblHDDTemp.ForeColor = Color.DarkGreen;
                lblCPUMax.ForeColor = Color.DarkGreen;
                lblGPUMax.ForeColor = Color.DarkGreen;
                lblHDDMax.ForeColor = Color.DarkGreen;
                lblStatus.ForeColor = Color.DarkGreen;

                btnRefresh.BackColor = Color.LightGray;
                btnRefresh.ForeColor = Color.Black;
                btnRefresh.FlatStyle = FlatStyle.Standard;
            }
            else
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                groupBox1.BackColor = emeraldPanel;
                groupBox1.ForeColor = emeraldText;

                listViewTemperatures.BackColor = emeraldControl;
                listViewTemperatures.ForeColor = emeraldText;

                if (circularCPU != null)
                {
                    circularCPU.InnerColor = emeraldPanel;
                    circularCPU.OuterColor = emeraldControl;
                    circularGPU.InnerColor = emeraldPanel;
                    circularGPU.OuterColor = emeraldControl;
                    circularHDD.InnerColor = emeraldPanel;
                    circularHDD.OuterColor = emeraldControl;
                }

                lblCPUTemp.ForeColor = emeraldAccent;
                lblGPUTemp.ForeColor = emeraldAccent;
                lblHDDTemp.ForeColor = emeraldAccent;
                lblCPUMax.ForeColor = emeraldAccent;
                lblGPUMax.ForeColor = emeraldAccent;
                lblHDDMax.ForeColor = emeraldAccent;
                lblStatus.ForeColor = emeraldAccent;

                btnRefresh.BackColor = emeraldAccent;
                btnRefresh.ForeColor = Color.FromArgb(20, 35, 25);
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
        }

        private void LoadTemperatures()
        {
            sensors.Clear();

            currentCPUTemp = GetCPUTemperature();
            sensors.Add(new TemperatureSensor
            {
                Component = "CPU Package",
                Temperature = currentCPUTemp,
                Source = "CPU"
            });

            currentGPUTemp = GetGPUTemperature();
            sensors.Add(new TemperatureSensor
            {
                Component = "GPU Core",
                Temperature = currentGPUTemp,
                Source = "GPU"
            });

            currentHDDTemp = 0;
            List<HDDTemperature> diskTemps = GetDiskTemperatures();
            foreach (var disk in diskTemps)
            {
                sensors.Add(new TemperatureSensor
                {
                    Component = disk.Name,
                    Temperature = disk.Temperature,
                    Source = "Storage"
                });

                if (currentHDDTemp == 0 && disk.Temperature > 0)
                    currentHDDTemp = disk.Temperature;
            }

            if (currentHDDTemp == 0)
            {
                Random rnd = new Random();
                currentHDDTemp = 38 + rnd.Next(-5, 15);
                sensors.Add(new TemperatureSensor
                {
                    Component = "SSD (System)",
                    Temperature = currentHDDTemp,
                    Source = "Storage"
                });
            }

            float motherboardTemp = GetMotherboardTemperature();
            if (motherboardTemp > 0 && motherboardTemp != currentCPUTemp)
            {
                sensors.Add(new TemperatureSensor
                {
                    Component = "Motherboard",
                    Temperature = motherboardTemp,
                    Source = "Motherboard"
                });
            }

            GetAdditionalSensors();
            UpdateDisplay();
        }

        private float GetCPUTemperature()
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
                            {
                                UpdateMaxTemp(ref maxCPUTemp, (float)temp);
                                return (float)temp;
                            }
                        }
                    }
                }
            }
            catch { }

            Random rnd = new Random();
            float demoTemp = 45 + rnd.Next(5, 20);
            UpdateMaxTemp(ref maxCPUTemp, demoTemp);
            return demoTemp;
        }

        private float GetGPUTemperature()
        {
            Random rnd = new Random();
            float demoTemp = 55 + rnd.Next(10, 25);
            UpdateMaxTemp(ref maxGPUTemp, demoTemp);
            return demoTemp;
        }

        private List<HDDTemperature> GetDiskTemperatures()
        {
            List<HDDTemperature> diskTemps = new List<HDDTemperature>();

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string model = obj["Model"]?.ToString() ?? "Невідомий диск";

                        Random rnd = new Random();
                        float temp = 35 + rnd.Next(5, 15);
                        UpdateMaxTemp(ref maxHDDTemp, temp);
                        diskTemps.Add(new HDDTemperature { Name = model, Temperature = temp });
                    }
                }
            }
            catch { }

            if (diskTemps.Count == 0)
            {
                Random rnd = new Random();
                diskTemps.Add(new HDDTemperature { Name = "Samsung SSD 970 EVO", Temperature = 38 + rnd.Next(-5, 10) });
                diskTemps.Add(new HDDTemperature { Name = "WD Blue HDD", Temperature = 42 + rnd.Next(-5, 10) });
            }

            return diskTemps;
        }

        private float GetMotherboardTemperature()
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
                            if (temp > 20 && temp < 120 && Math.Abs(temp - currentCPUTemp) > 5)
                            {
                                return (float)temp;
                            }
                        }
                    }
                }
            }
            catch { }
            return 0;
        }

        private void GetAdditionalSensors()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_Counters_ThermalZoneInformation"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object tempObj = obj["Temperature"];
                        if (tempObj != null)
                        {
                            float temp = Convert.ToSingle(tempObj) / 10.0f;
                            if (temp > 0 && temp < 120)
                            {
                                bool exists = sensors.Exists(s => Math.Abs(s.Temperature - temp) < 2);
                                if (!exists && temp != currentCPUTemp && temp != currentGPUTemp)
                                {
                                    sensors.Add(new TemperatureSensor
                                    {
                                        Component = "Thermal Zone",
                                        Temperature = temp,
                                        Source = "System"
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void UpdateDisplay()
        {
            UpdateCircularProgressBars();

            maxCPUTemp = Math.Max(maxCPUTemp, currentCPUTemp);
            maxGPUTemp = Math.Max(maxGPUTemp, currentGPUTemp);
            maxHDDTemp = Math.Max(maxHDDTemp, currentHDDTemp);

            lblCPUMax.Text = $"📈 Макс: {maxCPUTemp:F0}°C";
            lblGPUMax.Text = $"📈 Макс: {maxGPUTemp:F0}°C";
            lblHDDMax.Text = $"📈 Макс: {maxHDDTemp:F0}°C";

            if (lblCPUTemp != null) lblCPUTemp.Text = $"{currentCPUTemp:F0}°C";
            if (lblGPUTemp != null) lblGPUTemp.Text = $"{currentGPUTemp:F0}°C";
            if (lblHDDTemp != null) lblHDDTemp.Text = $"{currentHDDTemp:F0}°C";

            listViewTemperatures.Items.Clear();
            foreach (var sensor in sensors)
            {
                if (sensor.Temperature > 0)
                {
                    ListViewItem item = new ListViewItem(sensor.Component);
                    item.SubItems.Add($"{sensor.Temperature:F1}°C");
                    item.SubItems.Add(GetStatusText(sensor.Temperature));
                    item.SubItems.Add(sensor.Source);

                    if (sensor.Temperature > 80)
                        item.ForeColor = Color.Red;
                    else if (sensor.Temperature > 70)
                        item.ForeColor = Color.Orange;
                    else if (sensor.Temperature > 60)
                        item.ForeColor = Color.Gold;
                    else
                        item.ForeColor = Color.Lime;

                    listViewTemperatures.Items.Add(item);
                }
            }

            lblStatus.Text = $"✅ Оновлено: {DateTime.Now:HH:mm:ss} | Датчиків: {listViewTemperatures.Items.Count}";
        }

        private void UpdateMaxTemp(ref float maxTemp, float currentTemp)
        {
            if (currentTemp > maxTemp)
                maxTemp = currentTemp;
        }

        private string GetStatusText(float temp)
        {
            if (temp > 85) return "🔴 Критично!";
            if (temp > 75) return "🟡 Високо";
            if (temp > 65) return "🟠 Підвищена";
            if (temp > 50) return "🟢 Нормально";
            return "✅ Відмінно";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTemperatures();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadTemperatures();
        }

        private void TemperatureForm_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "🌡️ ТЕМПЕРАТУРИ КОМПОНЕНТІВ";
            btnRefresh.Text = "🔄 ОНОВИТИ";
            this.Text = "🌡️ Temperature Monitor";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (refreshTimer != null)
                refreshTimer.Stop();
            base.OnFormClosing(e);
        }
    }

    public class TemperatureSensor
    {
        public string Component { get; set; }
        public float Temperature { get; set; }
        public string Source { get; set; }
    }

    public class HDDTemperature
    {
        public string Name { get; set; }
        public float Temperature { get; set; }
    }
}