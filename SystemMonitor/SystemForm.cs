using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SystemMonitor
{
    public partial class SystemForm : Form
    {
        public SystemForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadSystemInfo();
        }

        public void ApplyTheme()
        {
            Color emeraldBg = Color.FromArgb(20, 35, 25);       
            Color emeraldPanel = Color.FromArgb(30, 55, 40);   
            Color emeraldText = Color.FromArgb(180, 255, 220);  
            Color emeraldAccent = Color.FromArgb(80, 200, 120); 

            if (SettingsForm.ThemeMode == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;

                lblCPUInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblCPUInfo.ForeColor = Color.LightGreen;

                lblRAMInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblRAMInfo.ForeColor = Color.LightGreen;

                lblDiskInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblDiskInfo.ForeColor = Color.LightGreen;

                lblGPUInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblGPUInfo.ForeColor = Color.LightGreen;

                lblOSInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblOSInfo.ForeColor = Color.LightGreen;

                lblUserInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblUserInfo.ForeColor = Color.LightGreen;

                lblUptimeInfo.BackColor = Color.FromArgb(45, 45, 45);
                lblUptimeInfo.ForeColor = Color.LightGreen;

                btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                lblCPUInfo.BackColor = Color.White;
                lblCPUInfo.ForeColor = Color.DarkGreen;

                lblRAMInfo.BackColor = Color.White;
                lblRAMInfo.ForeColor = Color.DarkGreen;

                lblDiskInfo.BackColor = Color.White;
                lblDiskInfo.ForeColor = Color.DarkGreen;

                lblGPUInfo.BackColor = Color.White;
                lblGPUInfo.ForeColor = Color.DarkGreen;

                lblOSInfo.BackColor = Color.White;
                lblOSInfo.ForeColor = Color.DarkGreen;

                lblUserInfo.BackColor = Color.White;
                lblUserInfo.ForeColor = Color.DarkGreen;

                lblUptimeInfo.BackColor = Color.White;
                lblUptimeInfo.ForeColor = Color.DarkGreen;

                btnRefresh.BackColor = Color.LightGray;
                btnRefresh.ForeColor = Color.Black;
                btnRefresh.FlatStyle = FlatStyle.Standard;
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                lblCPUInfo.BackColor = emeraldPanel;
                lblCPUInfo.ForeColor = emeraldAccent;

                lblRAMInfo.BackColor = emeraldPanel;
                lblRAMInfo.ForeColor = emeraldAccent;

                lblDiskInfo.BackColor = emeraldPanel;
                lblDiskInfo.ForeColor = emeraldAccent;

                lblGPUInfo.BackColor = emeraldPanel;
                lblGPUInfo.ForeColor = emeraldAccent;

                lblOSInfo.BackColor = emeraldPanel;
                lblOSInfo.ForeColor = emeraldAccent;

                lblUserInfo.BackColor = emeraldPanel;
                lblUserInfo.ForeColor = emeraldAccent;

                lblUptimeInfo.BackColor = emeraldPanel;
                lblUptimeInfo.ForeColor = emeraldAccent;

                btnRefresh.BackColor = emeraldAccent;
                btnRefresh.ForeColor = Color.FromArgb(20, 35, 25);
                btnRefresh.FlatStyle = FlatStyle.Flat;
            }
        }

        private void LoadSystemInfo()
        {
            LoadCPUInfo();
            LoadRAMInfo();
            LoadDiskInfo();
            LoadGPUInfo();
            LoadOSInfo();
            LoadUserInfo();
            LoadUptimeInfo();
        }

        private void LoadCPUInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "Невідомо";

                        object coresObj = obj["NumberOfCores"];
                        uint cores = (coresObj != null) ? (uint)coresObj : 0;

                        object logicalObj = obj["NumberOfLogicalProcessors"];
                        uint logical = (logicalObj != null) ? (uint)logicalObj : 0;

                        object maxClockObj = obj["MaxClockSpeed"];
                        uint maxClock = (maxClockObj != null) ? (uint)maxClockObj : 0;

                        lblCPUInfo.Text =
                            $"╔══════════════════════════════════════════════════════════════╗\n" +
                            $"║ 💻 ПРОЦЕСОР (CPU)                                             ║\n" +
                            $"╠══════════════════════════════════════════════════════════════╣\n" +
                            $"║ Модель: {TruncateString(name, 50),-60} ║\n" +
                            $"║ Фізичні ядра: {cores}                                        ║\n" +
                            $"║ Логічні ядра: {logical}                                      ║\n" +
                            $"║ Макс. частота: {maxClock} MHz                               ║\n" +
                            $"╚══════════════════════════════════════════════════════════════╝";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                lblCPUInfo.Text = $"Помилка отримання CPU: {ex.Message}";
            }
        }

        private void LoadRAMInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object totalMemoryObj = obj["TotalPhysicalMemory"];
                        ulong totalMemory = (totalMemoryObj != null) ? (ulong)totalMemoryObj : 0;
                        decimal totalRAM = Math.Round((decimal)totalMemory / 1024 / 1024 / 1024, 2);

                        // Отримуємо вільну RAM
                        using (ManagementObjectSearcher memSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                        {
                            foreach (ManagementObject os in memSearcher.Get())
                            {
                                object freeMemoryObj = os["FreePhysicalMemory"];
                                ulong freeRAM = (freeMemoryObj != null) ? (ulong)freeMemoryObj : 0;
                                decimal freeRAMGB = Math.Round((decimal)freeRAM / 1024 / 1024, 2);

                                lblRAMInfo.Text =
                                    $"╔══════════════════════════════════════════════════════════════╗\n" +
                                    $"║ 🧠 ОПЕРАТИВНА ПАМ'ЯТЬ (RAM)                                  ║\n" +
                                    $"╠══════════════════════════════════════════════════════════════╣\n" +
                                    $"║ Всього: {totalRAM} GB                                       ║\n" +
                                    $"║ Вільно: {freeRAMGB} GB                                       ║\n" +
                                    $"║ Використано: {Math.Round(totalRAM - freeRAMGB, 2)} GB       ║\n" +
                                    $"╚══════════════════════════════════════════════════════════════╝";
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                lblRAMInfo.Text = $"Помилка отримання RAM: {ex.Message}";
            }
        }

        private void LoadDiskInfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("╔══════════════════════════════════════════════════════════════╗");
                sb.AppendLine("║ 💽 ДИСКИ (HARD DRIVE)                                        ║");
                sb.AppendLine("╠══════════════════════════════════════════════════════════════╣");

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        decimal totalGB = Math.Round((decimal)drive.TotalSize / 1024 / 1024 / 1024, 2);
                        decimal freeGB = Math.Round((decimal)drive.AvailableFreeSpace / 1024 / 1024 / 1024, 2);
                        decimal usedGB = totalGB - freeGB;
                        int percentUsed = (totalGB > 0) ? (int)((usedGB / totalGB) * 100) : 0;

                        string driveType = GetDriveTypeName(drive.DriveType);

                        sb.AppendLine($"║ {drive.Name} [{driveType}]                                   ║");
                        sb.AppendLine($"║   Всього: {totalGB} GB                                      ║");
                        sb.AppendLine($"║   Вільно: {freeGB} GB                                      ║");
                        sb.AppendLine($"║   Використано: {percentUsed}%                               ║");
                        sb.AppendLine($"║                                                              ║");
                    }
                }
                sb.AppendLine("╚══════════════════════════════════════════════════════════════╝");
                lblDiskInfo.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                lblDiskInfo.Text = $"Помилка отримання дисків: {ex.Message}";
            }
        }

        private string GetDriveTypeName(DriveType type)
        {
            switch (type)
            {
                case DriveType.Fixed: return "HDD/SSD";
                case DriveType.Removable: return "USB";
                case DriveType.CDRom: return "CD/DVD";
                case DriveType.Network: return "Мережевий";
                default: return "Інший";
            }
        }

        private void LoadGPUInfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("╔══════════════════════════════════════════════════════════════╗");
                sb.AppendLine("║ 🎮 ВІДЕОКАРТА (GPU)                                          ║");
                sb.AppendLine("╠══════════════════════════════════════════════════════════════╣");

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
                {
                    int count = 0;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Name"]?.ToString() ?? "Невідомо";
                        if (name.Contains("NVIDIA") || name.Contains("AMD") || name.Contains("Intel") || count == 0)
                        {
                            string memory = "";
                            object adapterRAMObj = obj["AdapterRAM"];
                            if (adapterRAMObj != null)
                            {
                                ulong ram = (ulong)adapterRAMObj;
                                if (ram > 0)
                                {
                                    decimal ramGB = Math.Round((decimal)ram / 1024 / 1024 / 1024, 2);
                                    memory = $" ({ramGB} GB)";
                                }
                            }
                            sb.AppendLine($"║ {TruncateString(name + memory, 59),-60} ║");
                            count++;
                        }
                    }

                    if (count == 0)
                        sb.AppendLine("║ Не знайдено відеокарт                                       ║");
                }
                sb.AppendLine("╚══════════════════════════════════════════════════════════════╝");
                lblGPUInfo.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                lblGPUInfo.Text = $"Помилка отримання GPU: {ex.Message}";
            }
        }

        private void LoadOSInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string name = obj["Caption"]?.ToString() ?? "Невідомо";
                        string version = obj["Version"]?.ToString() ?? "Невідомо";
                        string build = obj["BuildNumber"]?.ToString() ?? "Невідомо";

                        lblOSInfo.Text =
                            $"╔══════════════════════════════════════════════════════════════╗\n" +
                            $"║ 🪟 ОПЕРАЦІЙНА СИСТЕМА                                        ║\n" +
                            $"╠══════════════════════════════════════════════════════════════╣\n" +
                            $"║ Назва: {TruncateString(name, 52),-56} ║\n" +
                            $"║ Версія: {version} (Build {build})                             ║\n" +
                            $"╚══════════════════════════════════════════════════════════════╝";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                lblOSInfo.Text = $"Помилка отримання ОС: {ex.Message}";
            }
        }

        private void LoadUserInfo()
        {
            try
            {
                string userName = Environment.UserName;
                string computerName = Environment.MachineName;
                string userDomain = Environment.UserDomainName;

                lblUserInfo.Text =
                    $"╔══════════════════════════════════════════════════════════════╗\n" +
                    $"║ 👤 КОРИСТУВАЧ                                               ║\n" +
                    $"╠══════════════════════════════════════════════════════════════╣\n" +
                    $"║ Ім'я: {userName,-57} ║\n" +
                    $"║ Комп'ютер: {computerName,-53} ║\n" +
                    $"║ Домен: {userDomain,-57} ║\n" +
                    $"╚══════════════════════════════════════════════════════════════╝";
            }
            catch (Exception ex)
            {
                lblUserInfo.Text = $"Помилка отримання користувача: {ex.Message}";
            }
        }

        private void LoadUptimeInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object lastBootObj = obj["LastBootUpTime"];
                        if (lastBootObj != null)
                        {
                            DateTime lastBoot = ManagementDateTimeConverter.ToDateTime(lastBootObj.ToString());
                            TimeSpan uptime = DateTime.Now - lastBoot;

                            lblUptimeInfo.Text =
                                $"╔══════════════════════════════════════════════════════════════╗\n" +
                                $"║ 📅 ДАТА ЗАПУСКУ СИСТЕМИ                                      ║\n" +
                                $"╠══════════════════════════════════════════════════════════════╣\n" +
                                $"║ Запуск: {lastBoot.ToString("dd.MM.yyyy HH:mm:ss")}            ║\n" +
                                $"║ Працює: {uptime.Days} днів, {uptime.Hours} год, {uptime.Minutes} хв   ║\n" +
                                $"╚══════════════════════════════════════════════════════════════╝";
                        }
                        else
                        {
                            lblUptimeInfo.Text = "Не вдалося отримати час запуску";
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                lblUptimeInfo.Text = $"Помилка отримання uptime: {ex.Message}";
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadSystemInfo();
        }

        private string TruncateString(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "Невідомо";
            if (text.Length <= maxLength) return text;
            return text.Substring(0, maxLength - 3) + "...";
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}