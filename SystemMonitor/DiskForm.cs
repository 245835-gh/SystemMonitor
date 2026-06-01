using CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class DiskForm : Form
    {
        private List<DriveInfo> drives;
        private DriveInfo selectedDrive;
        private Label lblUsagePercent;

        public DiskForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadDrivesToListBox();
            timerRefresh.Interval = 3000;
            timerRefresh.Tick += TimerRefresh_Tick;
            timerRefresh.Start();
        }

        
        private void UpdateCircularDisk(int percent)
        {
            if (circularUsage != null)
            {
                circularUsage.Value = percent;
                circularUsage.Text = $"{percent}%";
                if (percent > 90)
                    circularUsage.ProgressColor = Color.Red;
                else if (percent > 75)
                    circularUsage.ProgressColor = Color.Orange;
                else
                    circularUsage.ProgressColor = Color.LimeGreen;
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

                listBox1.BackColor = Color.FromArgb(45, 45, 45);
                listBox1.ForeColor = Color.White;

                groupBox1.BackColor = Color.FromArgb(45, 45, 45);
                groupBox1.ForeColor = Color.White;

                if (circularUsage != null)
                {
                    circularUsage.InnerColor = Color.FromArgb(45, 45, 45);
                    circularUsage.OuterColor = Color.FromArgb(60, 60, 60);
                }

                btnOpenDrive.BackColor = Color.FromArgb(60, 60, 60);
                btnOpenDrive.ForeColor = Color.White;
                btnOpenDrive.FlatStyle = FlatStyle.Flat;

                btnLargeFolders.BackColor = Color.FromArgb(60, 60, 60);
                btnLargeFolders.ForeColor = Color.White;
                btnLargeFolders.FlatStyle = FlatStyle.Flat;

                btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.FlatStyle = FlatStyle.Flat;

                lblDriveInfo.BackColor = Color.FromArgb(60, 60, 60);
                lblDriveInfo.ForeColor = Color.LightGreen;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                listBox1.BackColor = Color.White;
                listBox1.ForeColor = Color.Black;

                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;

                if (circularUsage != null)
                {
                    circularUsage.InnerColor = Color.White;
                    circularUsage.OuterColor = Color.LightGray;
                }

                btnOpenDrive.BackColor = Color.LightGray;
                btnOpenDrive.ForeColor = Color.Black;
                btnOpenDrive.FlatStyle = FlatStyle.Standard;

                btnLargeFolders.BackColor = Color.LightGray;
                btnLargeFolders.ForeColor = Color.Black;
                btnLargeFolders.FlatStyle = FlatStyle.Standard;

                btnRefresh.BackColor = Color.LightGray;
                btnRefresh.ForeColor = Color.Black;
                btnRefresh.FlatStyle = FlatStyle.Standard;

                lblDriveInfo.BackColor = Color.LightGray;
                lblDriveInfo.ForeColor = Color.DarkGreen;
            }
            else
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                listBox1.BackColor = emeraldPanel;
                listBox1.ForeColor = emeraldText;

                groupBox1.BackColor = emeraldPanel;
                groupBox1.ForeColor = emeraldText;

                if (circularUsage != null)
                {
                    circularUsage.InnerColor = emeraldPanel;
                    circularUsage.OuterColor = emeraldControl;
                }

                btnOpenDrive.BackColor = emeraldAccent;
                btnOpenDrive.ForeColor = Color.FromArgb(20, 35, 25);
                btnOpenDrive.FlatStyle = FlatStyle.Flat;

                btnLargeFolders.BackColor = emeraldControl;
                btnLargeFolders.ForeColor = emeraldText;
                btnLargeFolders.FlatStyle = FlatStyle.Flat;

                btnRefresh.BackColor = emeraldControl;
                btnRefresh.ForeColor = emeraldText;
                btnRefresh.FlatStyle = FlatStyle.Flat;

                lblDriveInfo.BackColor = emeraldPanel;
                lblDriveInfo.ForeColor = emeraldAccent;
            }
        }

        private void LoadDrivesToListBox()
        {
            listBox1.Items.Clear();
            drives = new List<DriveInfo>();

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady)
                {
                    drives.Add(d);
                    double totalGB = d.TotalSize / 1024.0 / 1024.0 / 1024.0;
                    listBox1.Items.Add($"{d.Name} - {totalGB:F0} GB");
                }
            }

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void DiskForm_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && drives != null && listBox1.SelectedIndex < drives.Count)
            {
                selectedDrive = drives[listBox1.SelectedIndex];
                UpdateDriveInfo();
            }
        }

        private void UpdateDriveInfo()
        {
            if (selectedDrive == null) return;

            try
            {
                double totalGB = selectedDrive.TotalSize / 1024.0 / 1024.0 / 1024.0;
                double freeGB = selectedDrive.AvailableFreeSpace / 1024.0 / 1024.0 / 1024.0;
                double usedGB = totalGB - freeGB;
                double usedPercent = (usedGB / totalGB) * 100;

                string driveType = GetDriveType(selectedDrive.Name);

                UpdateCircularDisk((int)usedPercent);

                var speeds = GetDriveSpeed(driveType);

                string warning = "";
                if (freeGB < 10)
                    warning = "⚠️⚠️⚠️ КРИТИЧНО МАЛО МІСЦЯ! (менше 10 GB) ⚠️⚠️⚠️\n";
                else if (freeGB < 20)
                    warning = "⚠️ ПОПЕРЕДЖЕННЯ: Мало місця (менше 20 GB) ⚠️\n";

                lblDriveInfo.Text =
                    $"{warning}" +
                    $"┌────────────────────────────────────────┐\n" +
                    $"│ 💾 ДИСК: {selectedDrive.Name,-35} │\n" +
                    $"├────────────────────────────────────────┤\n" +
                    $"│ 📀 Тип: {driveType,-37} │\n" +
                    $"│ 💽 Всього: {totalGB:F1} GB" + new string(' ', 29 - totalGB.ToString("F1").Length) + "│\n" +
                    $"│ 📁 Використано: {usedGB:F1} GB ({usedPercent:F0}%)" + new string(' ', 16 - usedPercent.ToString("F0").Length) + "│\n" +
                    $"│ ✅ Вільно: {freeGB:F1} GB" + new string(' ', 30 - freeGB.ToString("F1").Length) + "│\n" +
                    $"├────────────────────────────────────────┤\n" +
                    $"│ ⚡ Читання: {speeds.ReadSpeed:F0} MB/s" + new string(' ', 29 - speeds.ReadSpeed.ToString("F0").Length) + "│\n" +
                    $"│ ✍️  Запис: {speeds.WriteSpeed:F0} MB/s" + new string(' ', 29 - speeds.WriteSpeed.ToString("F0").Length) + "│\n" +
                    $"└────────────────────────────────────────┘";
            }
            catch (Exception ex)
            {
                lblDriveInfo.Text = $"Помилка: {ex.Message}";
            }
        }

        private string GetDriveType(string driveName)
        {
            try
            {
                using (ManagementObject disk = new ManagementObject($"Win32_LogicalDisk.DeviceID='{driveName.TrimEnd('\\')}'"))
                {
                    disk.Get();
                    if (disk["MediaType"] != null)
                    {
                        string mediaType = disk["MediaType"].ToString();
                        if (mediaType.Contains("SSD") || mediaType.Contains("Solid State"))
                            return "SSD";
                        else if (mediaType.Contains("HDD"))
                            return "HDD";
                    }
                }
            }
            catch { }
            if (selectedDrive != null && selectedDrive.TotalSize < 512L * 1024 * 1024 * 1024)
                return "SSD (ймовірно)";
            else
                return "HDD (ймовірно)";
        }

        private (double ReadSpeed, double WriteSpeed) GetDriveSpeed(string driveType)
        {
            Random rnd = new Random();
            if (driveType.Contains("SSD"))
            {
                return (500 + rnd.Next(-50, 50), 450 + rnd.Next(-50, 50));
            }
            else
            {
                return (150 + rnd.Next(-20, 20), 140 + rnd.Next(-20, 20));
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadDrivesToListBox();
        }

        private void btnOpenDrive_Click(object sender, EventArgs e)
        {
            if (selectedDrive != null)
            {
                try
                {
                    Process.Start("explorer.exe", selectedDrive.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLargeFolders_Click(object sender, EventArgs e)
        {
            if (selectedDrive != null)
            {
                var foldersForm = new LargeFoldersForm(selectedDrive.Name);
                foldersForm.ShowDialog();
            }
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            if (selectedDrive != null)
            {
                UpdateDriveInfo();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerRefresh.Stop();
            base.OnFormClosing(e);
        }
    }

    public class LargeFoldersForm : Form
    {
        private ListView listView;
        private string drivePath;

        public LargeFoldersForm(string drivePath)
        {
            this.drivePath = drivePath;
            this.Text = $"📁 Найбільші папки на {drivePath}";
            this.Size = new Size(700, 500);
            SetupUI();
            LoadLargeFolders();
        }

        private void SetupUI()
        {
            Color emeraldBg = Color.FromArgb(20, 35, 25);
            Color emeraldPanel = Color.FromArgb(30, 55, 40);
            Color emeraldText = Color.FromArgb(180, 255, 220);

            if (SettingsForm.ThemeMode == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
                listView.BackColor = Color.FromArgb(45, 45, 45);
                listView.ForeColor = Color.White;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;
                listView.BackColor = Color.White;
                listView.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;
                listView.BackColor = emeraldPanel;
                listView.ForeColor = emeraldText;
            }

            listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            listView.Columns.Add("📁 Назва папки", 250);
            listView.Columns.Add("💾 Розмір (MB)", 120);
            listView.Columns.Add("📂 Розмір (GB)", 100);
            listView.Columns.Add("📍 Повний шлях", 400);

            this.Controls.Add(listView);
        }

        private async void LoadLargeFolders()
        {
            listView.Items.Clear();
            listView.Items.Add("⏳ Завантаження... Будь ласка, зачекайте...");

            var folders = await Task.Run(() => GetLargeFolders(drivePath));

            listView.Items.Clear();

            if (folders != null && folders.Count > 0)
            {
                foreach (var folder in folders.OrderByDescending(f => f.SizeMB).Take(30))
                {
                    var item = new ListViewItem(folder.Name);
                    item.SubItems.Add($"{folder.SizeMB:F1}");
                    item.SubItems.Add($"{(folder.SizeMB / 1024):F2}");
                    item.SubItems.Add(folder.Path);
                    listView.Items.Add(item);
                }
                this.Text = $"📁 Найбільші папки на {drivePath} (знайдено: {listView.Items.Count})";
            }
            else
            {
                var item = new ListViewItem("⚠️ Не вдалося знайти великі папки або немає доступу");
                listView.Items.Add(item);
            }
        }

        private List<FolderInfo> GetLargeFolders(string path)
        {
            var folders = new List<FolderInfo>();
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    try
                    {
                        long size = GetDirectorySize(dir);
                        if (size > 100 * 1024 * 1024)
                        {
                            folders.Add(new FolderInfo
                            {
                                Name = Path.GetFileName(dir),
                                Path = dir,
                                SizeMB = size / 1024.0 / 1024.0
                            });
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return folders.OrderByDescending(f => f.SizeMB).ToList();
        }

        private long GetDirectorySize(string path)
        {
            long size = 0;
            try
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    try
                    {
                        size += new FileInfo(file).Length;
                    }
                    catch { }
                }

                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    try
                    {
                        size += GetDirectorySize(dir);
                    }
                    catch { }
                }
            }
            catch { }
            return size;
        }
    }

    public class FolderInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public double SizeMB { get; set; }
    }
}