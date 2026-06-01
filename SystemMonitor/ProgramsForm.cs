using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;

namespace SystemMonitor
{
    public partial class ProgramsForm : Form
    {
        private List<ProgramInfo> allPrograms;
        private List<ProgramInfo> filteredPrograms;

        public ProgramsForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupSortComboBox();
            LoadPrograms();
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

                groupBox1.BackColor = Color.FromArgb(45, 45, 45);
                groupBox1.ForeColor = Color.White;

                lblProgramDetails.BackColor = Color.FromArgb(60, 60, 60);
                lblProgramDetails.ForeColor = Color.LightGreen;

                lblProgramCount.ForeColor = Color.White;

                btnUninstall.BackColor = Color.FromArgb(180, 60, 60);
                btnUninstall.ForeColor = Color.White;
                btnUninstall.FlatStyle = FlatStyle.Flat;
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

                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;

                lblProgramDetails.BackColor = Color.LightGray;
                lblProgramDetails.ForeColor = Color.DarkGreen;

                lblProgramCount.ForeColor = Color.Black;

                btnUninstall.BackColor = Color.LightCoral;
                btnUninstall.ForeColor = Color.Black;
                btnUninstall.FlatStyle = FlatStyle.Standard;
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

                groupBox1.BackColor = emeraldPanel;
                groupBox1.ForeColor = emeraldText;

                lblProgramDetails.BackColor = emeraldControl;
                lblProgramDetails.ForeColor = emeraldAccent;

                lblProgramCount.ForeColor = emeraldText;

                btnUninstall.BackColor = Color.FromArgb(180, 80, 80);
                btnUninstall.ForeColor = emeraldText;
                btnUninstall.FlatStyle = FlatStyle.Flat;
            }
        }

        private void SetupSortComboBox()
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add("📝 За назвою (А→Я)");
            cmbSort.Items.Add("📝 За назвою (Я→А)");
            cmbSort.Items.Add("📅 За датою (нові→старі)");
            cmbSort.Items.Add("📅 За датою (старі→нові)");
            cmbSort.Items.Add("🔢 За версією");
            cmbSort.Items.Add("🏢 За видавцем");
            cmbSort.SelectedIndex = 0;
        }

        private void LoadPrograms()
        {
            try
            {
                allPrograms = new List<ProgramInfo>();

                string[] registryKeys = new string[]
                {
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                    @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
                };

                foreach (string registryKey in registryKeys)
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
                    {
                        if (key != null)
                        {
                            foreach (string subkeyName in key.GetSubKeyNames())
                            {
                                using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                                {
                                    try
                                    {
                                        string displayName = subkey.GetValue("DisplayName") as string;
                                        if (!string.IsNullOrEmpty(displayName))
                                        {
                                            var program = new ProgramInfo
                                            {
                                                Name = displayName,
                                                DisplayName = displayName,
                                                Version = subkey.GetValue("DisplayVersion") as string ?? "Немає даних",
                                                Publisher = subkey.GetValue("Publisher") as string ?? "Невідомий видавець",
                                                InstallDate = subkey.GetValue("InstallDate") as string ?? "Немає даних",
                                                UninstallString = subkey.GetValue("UninstallString") as string ?? ""
                                            };

                                            if (program.InstallDate.Length == 8 && program.InstallDate != "Немає даних")
                                            {
                                                program.InstallDate = $"{program.InstallDate.Substring(0, 4)}-{program.InstallDate.Substring(4, 2)}-{program.InstallDate.Substring(6, 2)}";
                                            }

                                            allPrograms.Add(program);
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }

                ApplyFilterAndSort();
                UpdateProgramCount();
            }
            catch (Exception ex)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add($"Помилка: {ex.Message}");
            }
        }

        private void ApplyFilterAndSort()
        {
            if (allPrograms == null) return;

            var filtered = allPrograms.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Publisher != null && p.Publisher.ToLower().Contains(searchTerm)) ||
                    (p.Version != null && p.Version.ToLower().Contains(searchTerm))
                );
            }

            if (cmbSort.SelectedIndex >= 0)
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0: 
                        filtered = filtered.OrderBy(p => p.Name);
                        break;
                    case 1: 
                        filtered = filtered.OrderByDescending(p => p.Name);
                        break;
                    case 2: 
                        filtered = filtered.OrderByDescending(p => p.GetInstallDateAsDateTime());
                        break;
                    case 3: 
                        filtered = filtered.OrderBy(p => p.GetInstallDateAsDateTime());
                        break;
                    case 4: 
                        filtered = filtered.OrderBy(p => p.Version);
                        break;
                    case 5: 
                        filtered = filtered.OrderBy(p => p.Publisher);
                        break;
                }
            }

            filteredPrograms = filtered.ToList();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();

            if (filteredPrograms == null || filteredPrograms.Count == 0)
            {
                listBox1.Items.Add("Немає програм за вказаним критерієм");
                return;
            }

            foreach (var program in filteredPrograms)
            {
                string dateStr = program.InstallDate != "Немає даних" ? $"📅 {program.InstallDate}" : "📅 Немає дати";
                listBox1.Items.Add($"📦 {program.Name}");
                listBox1.Items.Add($"   {dateStr}  |  Версія: {program.Version}");
                listBox1.Items.Add($"   🏢 {program.Publisher}");
                listBox1.Items.Add(""); 
            }
        }

        private void UpdateProgramCount()
        {
            int total = allPrograms?.Count ?? 0;
            int filtered = filteredPrograms?.Count ?? 0;

            if (total == filtered)
                lblProgramCount.Text = $"📊 Всього програм: {total}";
            else
                lblProgramCount.Text = $"📊 Показано: {filtered} з {total} програм";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selected = listBox1.SelectedItem.ToString();

                if (selected.StartsWith("📦"))
                {
                    string programName = selected.Substring(2); 
                    var program = filteredPrograms?.FirstOrDefault(p => p.Name == programName);
                    if (program != null)
                    {
                        ShowProgramDetails(program);
                        return;
                    }
                }

                int index = listBox1.SelectedIndex;
                if (index > 0 && listBox1.Items[index - 1].ToString().StartsWith("📦"))
                {
                    string programName = listBox1.Items[index - 1].ToString().Substring(2);
                    var program = filteredPrograms?.FirstOrDefault(p => p.Name == programName);
                    if (program != null)
                    {
                        ShowProgramDetails(program);
                    }
                }
            }
        }

        private void ShowProgramDetails(ProgramInfo program)
        {
            string dateStr = program.InstallDate != "Немає даних" ? program.InstallDate : "Немає даних";

            string nameDisplay = program.Name.Length > 33 ? program.Name.Substring(0, 30) + "..." : program.Name;
            string publisherDisplay = program.Publisher.Length > 27 ? program.Publisher.Substring(0, 24) + "..." : program.Publisher;

            lblProgramDetails.Text =
                $"╔════════════════════════════════════════╗\n" +
                $"║           📦 ДЕТАЛІ ПРОГРАМИ           ║\n" +
                $"╠════════════════════════════════════════╣\n" +
                $"║ 📛 Назва:                               ║\n" +
                $"║ {nameDisplay,-36} ║\n" +
                $"╠════════════════════════════════════════╣\n" +
                $"║ 🔢 Версія: {program.Version,-30} ║\n" +
                $"║ 📅 Дата встановлення: {dateStr,-22} ║\n" +
                $"║ 🏢 Видавець: {publisherDisplay,-29} ║\n" +
                $"╚════════════════════════════════════════╝";
        }


        private void ProgramsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
            UpdateProgramCount();
        }

        private void cmbSort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
            UpdateProgramCount();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
            UpdateProgramCount();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadPrograms();
        }

        private void btnUninstall_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ProgramInfo selectedProgram = null;

                int index = listBox1.SelectedIndex;
                for (int i = index; i >= 0; i--)
                {
                    string item = listBox1.Items[i].ToString();
                    if (item.StartsWith("📦"))
                    {
                        string programName = item.Substring(2);
                        selectedProgram = filteredPrograms?.FirstOrDefault(p => p.Name == programName);
                        break;
                    }
                }

                if (selectedProgram != null)
                {
                    var result = MessageBox.Show(
                        $"Ви ДІЙСНО хочете видалити програму?\n\n" +
                        $"📦 Програма: {selectedProgram.Name}\n" +
                        $"🔢 Версія: {selectedProgram.Version}\n" +
                        $"🏢 Видавець: {selectedProgram.Publisher}\n\n" +
                        $"⚠️ Увага! Цю дію НЕ МОЖНА буде скасувати!",
                        "🧨 Підтвердження видалення програми",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(selectedProgram.UninstallString))
                            {
                                Process.Start("cmd.exe", $"/c {selectedProgram.UninstallString}");
                                MessageBox.Show($"✅ Запущено деінсталятор для {selectedProgram.Name}\n\nПісля видалення натисніть 'Оновити'.",
                                    "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("❌ Не вдалося знайти деінсталятор для цієї програми.",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Помилка: {ex.Message}",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть програму зі списку!",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }


    public class ProgramInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }
        public string InstallDate { get; set; }
        public string UninstallString { get; set; }

        public DateTime GetInstallDateAsDateTime()
        {
            if (DateTime.TryParse(InstallDate, out DateTime date))
                return date;
            return DateTime.MinValue;
        }
    }
}