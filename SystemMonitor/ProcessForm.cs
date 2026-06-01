using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SystemMonitor
{
    public partial class ProcessForm : Form
    {
        private List<ProcessInfo> allProcesses;
        private Timer refreshTimer;
        private bool isRefreshing = false;

        public ProcessForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupTimer();
            SetupSortComboBox();
            LoadProcesses(); 
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

                flowLayoutPanel1.BackColor = Color.FromArgb(45, 45, 45);

                txtSearch.BackColor = Color.FromArgb(60, 60, 60);
                txtSearch.ForeColor = Color.White;

                btnSearch.BackColor = Color.FromArgb(60, 60, 60);
                btnSearch.ForeColor = Color.White;
                btnSearch.FlatStyle = FlatStyle.Flat;

                cmbSort.BackColor = Color.FromArgb(60, 60, 60);
                cmbSort.ForeColor = Color.White;

                btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.FlatStyle = FlatStyle.Flat;

                chkAutoRefresh.ForeColor = Color.White;

                btnKill.BackColor = Color.FromArgb(180, 60, 60);
                btnKill.ForeColor = Color.White;
                btnKill.FlatStyle = FlatStyle.Flat;

                lblProcessDetails.BackColor = Color.FromArgb(45, 45, 45);
                lblProcessDetails.ForeColor = Color.LightGreen;
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                listBox1.BackColor = Color.White;
                listBox1.ForeColor = Color.Black;

                flowLayoutPanel1.BackColor = Color.White;

                txtSearch.BackColor = Color.White;
                txtSearch.ForeColor = Color.Black;

                btnSearch.BackColor = Color.LightGray;
                btnSearch.ForeColor = Color.Black;
                btnSearch.FlatStyle = FlatStyle.Standard;

                cmbSort.BackColor = Color.White;
                cmbSort.ForeColor = Color.Black;

                btnRefresh.BackColor = Color.LightGray;
                btnRefresh.ForeColor = Color.Black;
                btnRefresh.FlatStyle = FlatStyle.Standard;

                chkAutoRefresh.ForeColor = Color.Black;

                btnKill.BackColor = Color.LightCoral;
                btnKill.ForeColor = Color.Black;
                btnKill.FlatStyle = FlatStyle.Standard;

                lblProcessDetails.BackColor = Color.LightGray;
                lblProcessDetails.ForeColor = Color.DarkGreen;
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                listBox1.BackColor = emeraldPanel;
                listBox1.ForeColor = emeraldText;

                flowLayoutPanel1.BackColor = emeraldPanel;

                txtSearch.BackColor = emeraldControl;
                txtSearch.ForeColor = emeraldText;

                btnSearch.BackColor = emeraldAccent;
                btnSearch.ForeColor = Color.FromArgb(20, 35, 25);
                btnSearch.FlatStyle = FlatStyle.Flat;

                cmbSort.BackColor = emeraldControl;
                cmbSort.ForeColor = emeraldText;

                btnRefresh.BackColor = emeraldControl;
                btnRefresh.ForeColor = emeraldText;
                btnRefresh.FlatStyle = FlatStyle.Flat;

                chkAutoRefresh.ForeColor = emeraldText;

                btnKill.BackColor = Color.FromArgb(180, 80, 80);
                btnKill.ForeColor = emeraldText;
                btnKill.FlatStyle = FlatStyle.Flat;

                lblProcessDetails.BackColor = emeraldPanel;
                lblProcessDetails.ForeColor = emeraldAccent;
            }
        }

        private void SetupTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 2000;
            refreshTimer.Tick += RefreshTimer_Tick;
            if (chkAutoRefresh.Checked)
                refreshTimer.Start();
        }

        private void SetupSortComboBox()
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add("📝 За іменем (А→Я)");
            cmbSort.Items.Add("📝 За іменем (Я→А)");
            cmbSort.Items.Add("💾 За RAM (більше→менше)");
            cmbSort.Items.Add("💾 За RAM (менше→більше)");
            cmbSort.Items.Add("⚡ За CPU (більше→менше)");
            cmbSort.Items.Add("⚡ За CPU (менше→більше)");
            cmbSort.Items.Add("🔢 За ID (зростання)");
            cmbSort.Items.Add("🔢 За ID (спадання)");
            cmbSort.SelectedIndex = 0;
        }

        private void LoadProcesses()
        {
            if (isRefreshing) return;
            isRefreshing = true;

            try
            {
                allProcesses = new List<ProcessInfo>();
                var processes = Process.GetProcesses();

                foreach (var proc in processes)
                {
                    try
                    {
                        var info = new ProcessInfo
                        {
                            Id = proc.Id,
                            Name = proc.ProcessName,
                            FullName = proc.ProcessName + ".exe",
                            RAM_MB = 0,
                            CPU_Percent = 0
                        };

                        try
                        {
                            using (var perfCounter = new PerformanceCounter("Process", "Working Set - Private", proc.ProcessName, true))
                            {
                                info.RAM_MB = perfCounter.NextValue() / 1024 / 1024;
                            }
                        }
                        catch { info.RAM_MB = 0; }

                        try
                        {
                            using (var cpuCounter = new PerformanceCounter("Process", "% Processor Time", proc.ProcessName, true))
                            {
                                cpuCounter.NextValue();
                                System.Threading.Thread.Sleep(50);
                                info.CPU_Percent = Math.Round(cpuCounter.NextValue() / Environment.ProcessorCount, 2);
                            }
                        }
                        catch { info.CPU_Percent = 0; }

                        try
                        {
                            info.FilePath = proc.MainModule.FileName;
                            info.Description = proc.MainModule.FileVersionInfo.FileDescription;
                        }
                        catch
                        {
                            info.FilePath = "Доступ заборонено";
                            info.Description = "Немає доступу";
                        }

                        allProcesses.Add(info);
                    }
                    catch
                    {

                    }
                }

                ApplyFilterAndSort();
            }
            catch (Exception ex)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add($"Помилка: {ex.Message}");
            }
            finally
            {
                isRefreshing = false;
            }
        }

        private void ApplyFilterAndSort()
        {
            if (allProcesses == null) return;

            var filtered = allProcesses;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.FullName.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm))
                ).ToList();
            }

            if (cmbSort.SelectedIndex >= 0)
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0: filtered = filtered.OrderBy(p => p.Name).ToList(); break;
                    case 1: filtered = filtered.OrderByDescending(p => p.Name).ToList(); break;
                    case 2: filtered = filtered.OrderByDescending(p => p.RAM_MB).ToList(); break;
                    case 3: filtered = filtered.OrderBy(p => p.RAM_MB).ToList(); break;
                    case 4: filtered = filtered.OrderByDescending(p => p.CPU_Percent).ToList(); break;
                    case 5: filtered = filtered.OrderBy(p => p.CPU_Percent).ToList(); break;
                    case 6: filtered = filtered.OrderBy(p => p.Id).ToList(); break;
                    case 7: filtered = filtered.OrderByDescending(p => p.Id).ToList(); break;
                    default: filtered = filtered.OrderBy(p => p.Name).ToList(); break;
                }
            }

            UpdateListBox(filtered);
        }

        private void UpdateListBox(List<ProcessInfo> processes)
        {
            listBox1.Items.Clear();

            var systemProcesses = processes.Where(p => p.Id < 100 || p.Name.StartsWith("svchost") || p.Name.StartsWith("services")).ToList();
            var userProcesses = processes.Except(systemProcesses).ToList();

            if (systemProcesses.Any())
            {
                listBox1.Items.Add($"─── 🖥️ СИСТЕМНІ ПРОЦЕСИ ({systemProcesses.Count}) ───");
                foreach (var p in systemProcesses.Take(30))
                {
                    listBox1.Items.Add($"  {p.FullName}  |  ID:{p.Id}  |  💾{p.RAM_MB:F0}MB  |  ⚡{p.CPU_Percent:F1}%");
                }
            }

            if (userProcesses.Any())
            {
                listBox1.Items.Add($"─── 📱 ПРОГРАМИ ({userProcesses.Count}) ───");
                foreach (var p in userProcesses.Take(50))
                {
                    listBox1.Items.Add($"  {p.FullName}  |  ID:{p.Id}  |  💾{p.RAM_MB:F0}MB  |  ⚡{p.CPU_Percent:F1}%");
                }
            }

            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add("Немає процесів за вказаним критерієм");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selected = listBox1.SelectedItem.ToString();

                if (selected.Contains("ID:"))
                {
                    int id = ExtractProcessId(selected);
                    var process = allProcesses?.FirstOrDefault(p => p.Id == id);
                    if (process != null)
                    {
                        ShowProcessDetails(process);
                        return;
                    }
                }

                if (selected.StartsWith("───"))
                {
                    lblProcessDetails.Text =
                        "╔════════════════════════════════════════╗\n" +
                        "║ 📄 ДЕТАЛІ ПРОЦЕСУ                      ║\n" +
                        "╠════════════════════════════════════════╣\n" +
                        "║                                        ║\n" +
                        "║   Виберіть процес зі списку вище       ║\n" +
                        "║   щоб побачити детальну інформацію     ║\n" +
                        "║                                        ║\n" +
                        "╚════════════════════════════════════════╝";
                }
            }
        }

        private int ExtractProcessId(string text)
        {
            try
            {
                int start = text.IndexOf("ID:") + 3;
                int end = text.IndexOf(" ", start);
                if (end == -1) end = text.Length;
                return int.Parse(text.Substring(start, end - start));
            }
            catch
            {
                return -1;
            }
        }

        private void ShowProcessDetails(ProcessInfo process)
        {
            string cpuStr = $"║ ⚡ CPU: {process.CPU_Percent:F1}%";
            string ramStr = $"║ 💾 RAM: {process.RAM_MB:F1} MB";

            cpuStr = cpuStr + new string(' ', 38 - cpuStr.Length) + "║";
            ramStr = ramStr + new string(' ', 38 - ramStr.Length) + "║";

            lblProcessDetails.Text =
                $"╔══════════════════════════════════════════╗\n" +
                $"║           📄 ДЕТАЛІ ПРОЦЕСУ              ║\n" +
                $"╠══════════════════════════════════════════╣\n" +
                $"║ 📛 Ім'я: {process.FullName,-32} ║\n" +
                $"║ 🔢 ID: {process.Id,-35} ║\n" +
                $"╠══════════════════════════════════════════╣\n" +
                $"{cpuStr}\n" +
                $"{ramStr}\n" +
                $"╠══════════════════════════════════════════╣\n" +
                $"║ 📂 Шлях:                                  ║\n" +
                $"║ {TruncatePath(process.FilePath, 34),-36} ║\n" +
                $"╠══════════════════════════════════════════╣\n" +
                $"║ 📝 Опис:                                  ║\n" +
                $"║ {TruncateString(process.Description, 34),-36} ║\n" +
                $"╚══════════════════════════════════════════╝";
        }

        private string TruncateString(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "Немає даних";
            if (text.Length <= maxLength) return text;
            return text.Substring(0, maxLength - 3) + "...";
        }

        private string TruncatePath(string path, int maxLength)
        {
            if (string.IsNullOrEmpty(path)) return "Немає доступу";
            if (path.Length <= maxLength) return path;
            return "..." + path.Substring(path.Length - maxLength + 3);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selected = listBox1.SelectedItem.ToString();
                if (selected.Contains("ID:"))
                {
                    int id = ExtractProcessId(selected);
                    var process = allProcesses?.FirstOrDefault(p => p.Id == id);

                    if (process != null)
                    {
                        var result = MessageBox.Show(
                            $"Ви ДІЙСНО хочете завершити процес?\n\n" +
                            $"📛 Процес: {process.FullName}\n" +
                            $"🔢 ID: {process.Id}\n" +
                            $"💾 RAM: {process.RAM_MB:F1} MB\n" +
                            $"⚡ CPU: {process.CPU_Percent:F1}%\n\n" +
                            $"⚠️ Увага! Всі незбережені дані будуть ВТРАЧЕНО!",
                            "🧨 Підтвердження завершення процесу",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                var proc = Process.GetProcessById(id);
                                proc.Kill();
                                MessageBox.Show($"✅ Процес {process.FullName} успішно завершено!",
                                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadProcesses();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"❌ Помилка: {ex.Message}",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть процес зі списку!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void chkAutoRefresh_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                refreshTimer.Start();
            }
            else
            {
                refreshTimer.Stop();
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (refreshTimer != null)
                refreshTimer.Stop();
            base.OnFormClosing(e);
        }
    }

    public class ProcessInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public double RAM_MB { get; set; }
        public double CPU_Percent { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}


      