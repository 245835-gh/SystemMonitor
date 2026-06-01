using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace SystemMonitor
{
    public partial class SettingsForm : Form
    {
        public static int UpdateInterval = 2000;
        public static string ThemeMode = "Emerald"; 
        public static string DefaultSubnet = "192.168.1.0/24";
        public static bool AutoSaveLogs = false;
        public static bool EnableAlerts = true;

        private string settingsFile = "settings.json";

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
            SetupThemeComboBox();
            ApplyTheme();
        }

        private void SetupThemeComboBox()
        {
            if (cmbTheme != null)
            {
                cmbTheme.Items.Clear();
                cmbTheme.Items.Add("🌙 Dark (Темна)");
                cmbTheme.Items.Add("☀️ Light (Світла)");
                cmbTheme.Items.Add("💚 Emerald (Ізумрудна)");

                switch (ThemeMode)
                {
                    case "Dark": cmbTheme.SelectedIndex = 0; break;
                    case "Light": cmbTheme.SelectedIndex = 1; break;
                    case "Emerald": cmbTheme.SelectedIndex = 2; break;
                    default: cmbTheme.SelectedIndex = 2; break;
                }
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsFile))
                {
                    string json = File.ReadAllText(settingsFile);
                    var settings = JsonSerializer.Deserialize<SettingsData>(json);

                    if (settings != null)
                    {
                        UpdateInterval = settings.UpdateInterval;
                        ThemeMode = settings.ThemeMode ?? "Emerald";
                        DefaultSubnet = settings.DefaultSubnet ?? "192.168.1.0/24";
                        AutoSaveLogs = settings.AutoSaveLogs;
                        EnableAlerts = settings.EnableAlerts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження налаштувань: {ex.Message}");
            }

            numericInterval.Minimum = 100;
            numericInterval.Maximum = 10000;
            numericInterval.Value = UpdateInterval;
            txtDefaultSubnet.Text = DefaultSubnet;
            chkAutoSaveLogs.Checked = AutoSaveLogs;
            chkEnableAlerts.Checked = EnableAlerts;
        }

        public void ApplyTheme()
        {
            Color emeraldBg = Color.FromArgb(20, 35, 25);       
            Color emeraldPanel = Color.FromArgb(30, 55, 40);    
            Color emeraldControl = Color.FromArgb(40, 75, 55);  
            Color emeraldAccent = Color.FromArgb(80, 200, 120); 
            Color emeraldText = Color.FromArgb(180, 255, 220);  

            if (ThemeMode == "Dark")
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;

                numericInterval.BackColor = Color.FromArgb(60, 60, 60);
                numericInterval.ForeColor = Color.White;
                txtDefaultSubnet.BackColor = Color.FromArgb(60, 60, 60);
                txtDefaultSubnet.ForeColor = Color.White;
                btnSave.BackColor = Color.FromArgb(60, 60, 60);
                btnSave.ForeColor = Color.White;
                lblStatus.BackColor = Color.FromArgb(45, 45, 45);
                lblStatus.ForeColor = Color.LightGreen;

                if (cmbTheme != null)
                {
                    cmbTheme.BackColor = Color.FromArgb(60, 60, 60);
                    cmbTheme.ForeColor = Color.White;
                }


                lblSubnet.ForeColor = Color.White;
                lblAutoSave.ForeColor = Color.White;
                lblAlerts.ForeColor = Color.White;
                lblTheme.ForeColor = Color.White;
                chkAutoSaveLogs.ForeColor = Color.White;
                chkEnableAlerts.ForeColor = Color.White;
            }
            else if (ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                numericInterval.BackColor = Color.White;
                numericInterval.ForeColor = Color.Black;
                txtDefaultSubnet.BackColor = Color.White;
                txtDefaultSubnet.ForeColor = Color.Black;
                btnSave.BackColor = Color.LightGray;
                btnSave.ForeColor = Color.Black;
                lblStatus.BackColor = Color.LightGray;
                lblStatus.ForeColor = Color.DarkGreen;

                if (cmbTheme != null)
                {
                    cmbTheme.BackColor = Color.White;
                    cmbTheme.ForeColor = Color.Black;
                }

                               lblSubnet.ForeColor = Color.Black;
                lblAutoSave.ForeColor = Color.Black;
                lblAlerts.ForeColor = Color.Black;
                lblTheme.ForeColor = Color.Black;
                chkAutoSaveLogs.ForeColor = Color.Black;
                chkEnableAlerts.ForeColor = Color.Black;
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                numericInterval.BackColor = emeraldControl;
                numericInterval.ForeColor = emeraldText;
                txtDefaultSubnet.BackColor = emeraldControl;
                txtDefaultSubnet.ForeColor = emeraldText;
                btnSave.BackColor = emeraldAccent;
                btnSave.ForeColor = Color.FromArgb(20, 35, 25);
                btnSave.FlatStyle = FlatStyle.Flat;
                lblStatus.BackColor = emeraldPanel;
                lblStatus.ForeColor = emeraldAccent;

                if (cmbTheme != null)
                {
                    cmbTheme.BackColor = emeraldControl;
                    cmbTheme.ForeColor = emeraldText;
                    cmbTheme.FlatStyle = FlatStyle.Flat;
                }

               
                lblSubnet.ForeColor = emeraldText;
                lblAutoSave.ForeColor = emeraldText;
                lblAlerts.ForeColor = emeraldText;
                lblTheme.ForeColor = emeraldText;
                chkAutoSaveLogs.ForeColor = emeraldText;
                chkEnableAlerts.ForeColor = emeraldText;
            }
        }

        private void SaveSettings()
        {
            try
            {
                UpdateInterval = (int)numericInterval.Value;


                if (cmbTheme != null && cmbTheme.SelectedIndex >= 0)
                {
                    switch (cmbTheme.SelectedIndex)
                    {
                        case 0: ThemeMode = "Dark"; break;
                        case 1: ThemeMode = "Light"; break;
                        case 2: ThemeMode = "Emerald"; break;
                        default: ThemeMode = "Emerald"; break;
                    }
                }

                DefaultSubnet = txtDefaultSubnet.Text.Trim();
                AutoSaveLogs = chkAutoSaveLogs.Checked;
                EnableAlerts = chkEnableAlerts.Checked;

                var settings = new SettingsData
                {
                    UpdateInterval = UpdateInterval,
                    ThemeMode = ThemeMode,
                    DefaultSubnet = DefaultSubnet,
                    AutoSaveLogs = AutoSaveLogs,
                    EnableAlerts = EnableAlerts,
                    LastSaved = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsFile, json);

                lblStatus.Text = $"✅ Налаштування збережено! ({DateTime.Now:HH:mm:ss})";
                lblStatus.ForeColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"❌ Помилка збереження: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
        }

        public static void ApplyThemeToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is DiskForm diskForm)
                    diskForm.ApplyTheme();
                else if (form is ProcessForm processForm)
                    processForm.ApplyTheme();
                else if (form is ProgramsForm programsForm)
                    programsForm.ApplyTheme();
                else if (form is NetworkForm networkForm)
                    networkForm.ApplyTheme();
                else if (form is SystemForm systemForm)
                    systemForm.ApplyTheme();
                else if (form is SettingsForm settingsForm)
                    settingsForm.ApplyTheme();
                else if (form is Form1 mainForm)
                    mainForm.ApplyTheme();
                else if (form is CpuRamForm cpuRamForm)
                    cpuRamForm.ApplyTheme();
                else if (form is DashboardForm dashboardForm)
                    dashboardForm.ApplyTheme();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldTheme = ThemeMode;

            SaveSettings();
            ApplyTheme();

            if (oldTheme != ThemeMode)
            {
                ApplyThemeToAllForms();
            }

            string themeIcon = ThemeMode == "Dark" ? "🌙" : (ThemeMode == "Light" ? "☀️" : "💚");
            string themeName = ThemeMode == "Dark" ? "Dark (Темна)" : (ThemeMode == "Light" ? "Light (Світла)" : "Emerald (Ізумрудна)");

            MessageBox.Show($"✅ Налаштування збережено!\n\n" +
                $"⏱ Інтервал: {UpdateInterval} ms\n" +
                $"🎨 Тема: {themeIcon} {themeName}\n" +
                $"🌐 Мережа: {DefaultSubnet}\n" +
                $"📁 Автолог: {(AutoSaveLogs ? "Увімкнено" : "Вимкнено")}\n" +
                $"🔔 Алерти: {(EnableAlerts ? "Увімкнено" : "Вимкнено")}",
                "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "⚙️ Готово до налаштувань";
            btnSave.Text = "💾 Зберегти налаштування";
            lblSubnet.Text = "🌐 Мережа за замовчуванням:";
            lblAutoSave.Text = "📁 Автозбереження логів:";
            lblAlerts.Text = "🔔 Алерти:";
            lblTheme.Text = "🎨 Тема оформлення:";
            chkAutoSaveLogs.Text = "Зберігати автоматично";
            chkEnableAlerts.Text = "Показувати сповіщення";
            this.Text = "⚙️ НАЛАШТУВАННЯ";
        }

        private void chkAutoSaveLogs_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAutoSaveLogs.Checked)
            {
                string logDir = "logs";
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
            }
        }

        public static string GetSettingsString()
        {
            string themeIcon = ThemeMode == "Dark" ? "🌙" : (ThemeMode == "Light" ? "☀️" : "💚");
            return $"⏱ Інтервал: {UpdateInterval}ms | 🎨 Тема: {themeIcon} {ThemeMode} | 🌐 Мережа: {DefaultSubnet} | 📁 Автолог: {(AutoSaveLogs ? "Так" : "Ні")} | 🔔 Алерти: {(EnableAlerts ? "Так" : "Ні")}";
        }

        public static void LogEvent(string eventName, string details)
        {
            if (!AutoSaveLogs) return;

            try
            {
                string logDir = "logs";
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                string logFile = Path.Combine(logDir, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
                string logEntry = $"[{DateTime.Now:HH:mm:ss}] {eventName}: {details}";

                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch { }
        }
    }

    public class SettingsData
    {
        public int UpdateInterval { get; set; }
        public string ThemeMode { get; set; }
        public string DefaultSubnet { get; set; }
        public bool AutoSaveLogs { get; set; }
        public bool EnableAlerts { get; set; }
        public string LastSaved { get; set; }
    }
}