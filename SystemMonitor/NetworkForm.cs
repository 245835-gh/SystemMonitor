using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class NetworkForm : Form
    {
        private List<NetworkDevice> scanResults = new List<NetworkDevice>();
        private int scannedCount = 0;
        private int totalToScan = 0;
        private CancellationTokenSource cancellationTokenSource;

        public NetworkForm()
        {
            InitializeComponent();
            ApplyTheme();
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

                dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 45);
                dataGridView1.GridColor = Color.FromArgb(70, 70, 70);
                dataGridView1.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;

                txtIPRangeStart.BackColor = Color.FromArgb(60, 60, 60);
                txtIPRangeStart.ForeColor = Color.White;
                txtIPRangeEnd.BackColor = Color.FromArgb(60, 60, 60);
                txtIPRangeEnd.ForeColor = Color.White;
                txtPorts.BackColor = Color.FromArgb(60, 60, 60);
                txtPorts.ForeColor = Color.White;

                btnScan.BackColor = Color.FromArgb(60, 60, 60);
                btnScan.ForeColor = Color.White;
                btnScan.FlatStyle = FlatStyle.Flat;

                btnStopScan.BackColor = Color.FromArgb(180, 60, 60);
                btnStopScan.ForeColor = Color.White;
                btnStopScan.FlatStyle = FlatStyle.Flat;

                btnSaveTXT.BackColor = Color.FromArgb(60, 60, 60);
                btnSaveTXT.ForeColor = Color.White;
                btnSaveTXT.FlatStyle = FlatStyle.Flat;

                btnSaveJSON.BackColor = Color.FromArgb(60, 60, 60);
                btnSaveJSON.ForeColor = Color.White;
                btnSaveJSON.FlatStyle = FlatStyle.Flat;

                chkOnlineOnly.ForeColor = Color.White;
                labelRange.ForeColor = Color.White;
                labelPorts.ForeColor = Color.White;
                lblProgress.ForeColor = Color.LightGreen;

                progressBarScan.BackColor = Color.FromArgb(60, 60, 60);
            }
            else if (SettingsForm.ThemeMode == "Light")
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                this.ForeColor = Color.Black;

                groupBox1.BackColor = Color.White;
                groupBox1.ForeColor = Color.Black;

                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.GridColor = Color.LightGray;
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.EnableHeadersVisualStyles = true;

                txtIPRangeStart.BackColor = Color.White;
                txtIPRangeStart.ForeColor = Color.Black;
                txtIPRangeEnd.BackColor = Color.White;
                txtIPRangeEnd.ForeColor = Color.Black;
                txtPorts.BackColor = Color.White;
                txtPorts.ForeColor = Color.Black;

                btnScan.BackColor = Color.LightGray;
                btnScan.ForeColor = Color.Black;
                btnScan.FlatStyle = FlatStyle.Standard;

                btnStopScan.BackColor = Color.LightCoral;
                btnStopScan.ForeColor = Color.Black;
                btnStopScan.FlatStyle = FlatStyle.Standard;

                btnSaveTXT.BackColor = Color.LightGray;
                btnSaveTXT.ForeColor = Color.Black;
                btnSaveTXT.FlatStyle = FlatStyle.Standard;

                btnSaveJSON.BackColor = Color.LightGray;
                btnSaveJSON.ForeColor = Color.Black;
                btnSaveJSON.FlatStyle = FlatStyle.Standard;

                chkOnlineOnly.ForeColor = Color.Black;
                labelRange.ForeColor = Color.Black;
                labelPorts.ForeColor = Color.Black;
                lblProgress.ForeColor = Color.DarkGreen;

                progressBarScan.BackColor = Color.White;
            }
            else 
            {
                this.BackColor = emeraldBg;
                this.ForeColor = emeraldText;

                groupBox1.BackColor = emeraldPanel;
                groupBox1.ForeColor = emeraldText;

                dataGridView1.BackgroundColor = emeraldPanel;
                dataGridView1.GridColor = Color.FromArgb(60, 100, 70);
                dataGridView1.ForeColor = emeraldText;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = emeraldControl;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = emeraldText;
                dataGridView1.DefaultCellStyle.BackColor = emeraldPanel;
                dataGridView1.DefaultCellStyle.ForeColor = emeraldText;
                dataGridView1.EnableHeadersVisualStyles = false;

                txtIPRangeStart.BackColor = emeraldControl;
                txtIPRangeStart.ForeColor = emeraldText;
                txtIPRangeEnd.BackColor = emeraldControl;
                txtIPRangeEnd.ForeColor = emeraldText;
                txtPorts.BackColor = emeraldControl;
                txtPorts.ForeColor = emeraldText;

                btnScan.BackColor = emeraldAccent;
                btnScan.ForeColor = Color.FromArgb(20, 35, 25);
                btnScan.FlatStyle = FlatStyle.Flat;

                btnStopScan.BackColor = Color.FromArgb(180, 80, 80);
                btnStopScan.ForeColor = emeraldText;
                btnStopScan.FlatStyle = FlatStyle.Flat;

                btnSaveTXT.BackColor = emeraldControl;
                btnSaveTXT.ForeColor = emeraldText;
                btnSaveTXT.FlatStyle = FlatStyle.Flat;

                btnSaveJSON.BackColor = emeraldControl;
                btnSaveJSON.ForeColor = emeraldText;
                btnSaveJSON.FlatStyle = FlatStyle.Flat;

                chkOnlineOnly.ForeColor = emeraldText;
                labelRange.ForeColor = emeraldText;
                labelPorts.ForeColor = emeraldText;
                lblProgress.ForeColor = emeraldAccent;

                progressBarScan.BackColor = emeraldControl;
            }
        }

        private void SetupDataGridView()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("IP", "🌐 IP адреса");
                dataGridView1.Columns.Add("Status", "📡 Статус");
                dataGridView1.Columns.Add("Hostname", "🏠 Hostname");
                dataGridView1.Columns.Add("MAC", "🔌 MAC / Vendor");
                dataGridView1.Columns.Add("OS", "💿 OS");
                dataGridView1.Columns.Add("Ports", "🚪 Відкриті порти");
                dataGridView1.Columns.Add("Latency", "⏱️ Ping (ms)");

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void NetworkForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();

            txtPorts.Text = "21,22,80,443,3389";


            txtIPRangeStart.Text = GetLocalIPRange();
            txtIPRangeEnd.Text = GetLocalIPRangeEnd();
        }

        private string GetLocalIPRange()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string[] parts = ip.ToString().Split('.');
                        return $"{parts[0]}.{parts[1]}.{parts[2]}.1";
                    }
                }
            }
            catch { }
            return "192.168.1.1";
        }

        private string GetLocalIPRangeEnd()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string[] parts = ip.ToString().Split('.');
                        return $"{parts[0]}.{parts[1]}.{parts[2]}.254";
                    }
                }
            }
            catch { }
            return "192.168.1.254";
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            await StartScan();
        }

        private async Task StartScan()
        {
            if (!ValidateIPs()) return;

            cancellationTokenSource = new CancellationTokenSource();
            scanResults.Clear();
            scannedCount = 0;

            dataGridView1.Rows.Clear();

            HashSet<string> ipList = GenerateIPList();
            totalToScan = ipList.Count;

            progressBarScan.Maximum = totalToScan;
            progressBarScan.Value = 0;

            var tasks = new List<Task>();

            foreach (string ip in ipList)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                tasks.Add(ScanDevice(ip));
            }

            await Task.WhenAll(tasks);

            ShowFinalResults();
        }

        private HashSet<string> GenerateIPList()
        {
            var ipList = new HashSet<string>();

            string startIP = txtIPRangeStart.Text.Trim();
            string endIP = txtIPRangeEnd.Text.Trim();

            if (IsCIDRNotation(startIP))
            {
                string[] parts = startIP.Split('/');
                string network = parts[0];
                int mask = int.Parse(parts[1]);
                int hosts = (int)Math.Pow(2, 32 - mask);

                string[] ipParts = network.Split('.');
                uint start = (uint.Parse(ipParts[0]) << 24) | (uint.Parse(ipParts[1]) << 16) |
                             (uint.Parse(ipParts[2]) << 8) | uint.Parse(ipParts[3]);
                start = start & (uint.MaxValue << (32 - mask));

                for (int i = 1; i < hosts - 1; i++)
                {
                    uint ip = start + (uint)i;
                    ipList.Add($"{((ip >> 24) & 0xFF)}.{((ip >> 16) & 0xFF)}.{((ip >> 8) & 0xFF)}.{ip & 0xFF}");
                }
            }
            else
            {
                long start = IPToLong(IPAddress.Parse(startIP));
                long end = IPToLong(IPAddress.Parse(endIP));

                for (long i = start; i <= end; i++)
                {
                    ipList.Add(LongToIP(i));
                }
            }

            return ipList;
        }

        private bool IsCIDRNotation(string ip)
        {
            return ip.Contains("/");
        }

        private long IPToLong(IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();
            return ((long)bytes[0] << 24) | ((long)bytes[1] << 16) | ((long)bytes[2] << 8) | bytes[3];
        }

        private string LongToIP(long ip)
        {
            return $"{((ip >> 24) & 0xFF)}.{((ip >> 16) & 0xFF)}.{((ip >> 8) & 0xFF)}.{ip & 0xFF}";
        }

        private bool ValidateIPs()
        {
            try
            {
                if (!IsCIDRNotation(txtIPRangeStart.Text))
                {
                    IPAddress.Parse(txtIPRangeStart.Text);
                    IPAddress.Parse(txtIPRangeEnd.Text);
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Введіть коректну IP адресу або CIDR (наприклад 192.168.1.0/24)");
                return false;
            }
        }

        private async Task ScanDevice(string ip)
        {
            try
            {
                Ping ping = new Ping();
                var reply = await ping.SendPingAsync(ip, 200);

                scannedCount++;

                string status = reply.Status == IPStatus.Success ? "Online" : "Offline";

                string latency = "-";
                if (reply.Status == IPStatus.Success && reply.RoundtripTime > 0)
                {
                    latency = reply.RoundtripTime.ToString();
                }

                string hostname = "-";
                string mac = "-";
                string vendor = "-";
                string os = "-";

                if (reply.Status == IPStatus.Success)
                {
                    hostname = GetHostname(ip);
                    mac = GetMacAddress(ip);
                    vendor = GetVendorFromMAC(mac);
                    List<int> openPorts = await ScanPortsList(ip);
                    os = DetectOSAdvanced(reply, openPorts);

                    var device = new NetworkDevice
                    {
                        IP = ip,
                        Status = status,
                        Hostname = hostname,
                        MAC = mac,
                        Vendor = vendor,
                        OS = os,
                        OpenPorts = string.Join(",", openPorts),
                        Latency = latency
                    };

                    scanResults.Add(device);

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (chkOnlineOnly.Checked && reply.Status != IPStatus.Success)
                        {

                        }
                        else
                        {
                            dataGridView1.Rows.Add(ip, status, hostname,
                                !string.IsNullOrEmpty(vendor) ? $"{mac} ({vendor})" : mac,
                                os, device.OpenPorts, latency);
                        }

                        UpdateProgress();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateProgress();
                    });
                }
            }
            catch
            {
                scannedCount++;
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateProgress();
                });
            }
        }

        private void UpdateProgress()
        {
            progressBarScan.Value = scannedCount;
            lblProgress.Text = $"Сканування: {scannedCount} / {totalToScan}";

            if (scannedCount == totalToScan)
            {
                lblProgress.Text = $"✅ Завершено! Знайдено: {scanResults.Count}";
            }
        }

        private void ShowFinalResults()
        {
            lblProgress.Text = $"✅ Завершено! Знайдено: {scanResults.Count} пристроїв";
        }

        private string GetHostname(string ip)
        {
            try
            {
                var entry = Dns.GetHostEntry(ip);
                return entry.HostName;
            }
            catch
            {
                return "-";
            }
        }

        private string GetMacAddress(string ip)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "arp";
                p.StartInfo.Arguments = "-a " + ip;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit(1000);

                var line = output.Split('\n')
                    .FirstOrDefault(l => l.Contains(ip));

                if (line != null)
                {
                    var parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return parts.Length >= 2 ? parts[1].ToUpper() : "-";
                }
            }
            catch { }
            return "-";
        }

        private string GetVendorFromMAC(string mac)
        {
            if (mac == "-" || mac.Length < 8) return "";

            string prefix = mac.Replace("-", "").Replace(":", "").Substring(0, 6).ToUpper();

            var vendors = new Dictionary<string, string>
            {
                { "00:14:22", "Dell" },
                { "00:1E:C2", "Intel" },
                { "00:1B:63", "Apple" },
                { "00:24:36", "TP-Link" },
                { "CC:46:3A", "TP-Link" },
                { "B8:27:EB", "Raspberry Pi" },
                { "00:0C:29", "VMware" },
                { "00:50:56", "VMware" },
                { "00:05:69", "Cisco" },
                { "00:1A:12", "Huawei" },
                { "F0:DE:F1", "Samsung" },
                { "80:BE:05", "Google" },
                { "10:9A:DD", "Xiaomi" }
            };

            if (vendors.ContainsKey(prefix))
                return vendors[prefix];

            return "";
        }

        private async Task<List<int>> ScanPortsList(string ip)
        {
            List<int> portsToCheck = ParsePorts(txtPorts.Text);
            List<int> openPorts = new List<int>();

            var tasks = portsToCheck.Select(port => IsPortOpen(ip, port, 100));
            var results = await Task.WhenAll(tasks);

            for (int i = 0; i < portsToCheck.Count; i++)
            {
                if (results[i])
                    openPorts.Add(portsToCheck[i]);
            }

            return openPorts;
        }

        private List<int> ParsePorts(string portsText)
        {
            var ports = new List<int>();
            var parts = portsText.Split(',');

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int port))
                {
                    ports.Add(port);
                }
            }

            if (ports.Count == 0)
                ports.AddRange(new[] { 21, 22, 80, 443, 3389 });

            return ports;
        }

        private async Task<bool> IsPortOpen(string ip, int port, int timeout)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var task = client.ConnectAsync(ip, port);
                    var result = await Task.WhenAny(task, Task.Delay(timeout));
                    return result == task && client.Connected;
                }
            }
            catch
            {
                return false;
            }
        }

        private string DetectOSAdvanced(PingReply reply, List<int> openPorts)
        {
            int ttl = reply.Options?.Ttl ?? 0;

            if (ttl >= 120 && ttl <= 130)
            {
                if (openPorts.Contains(3389))
                    return "Windows (RDP)";
                if (openPorts.Contains(445))
                    return "Windows (SMB)";
                return "Windows";
            }

            if (ttl >= 60 && ttl <= 70)
            {
                if (openPorts.Contains(22))
                    return "Linux (SSH)";
                if (openPorts.Contains(80))
                    return "Linux (HTTP)";
                return "Linux / Unix";
            }

            if (ttl >= 240 && ttl <= 255)
            {
                if (openPorts.Contains(80))
                    return "Router (HTTP)";
                return "Router / Network device";
            }

            if (ttl >= 40 && ttl <= 50)
            {
                if (openPorts.Contains(80))
                    return "Android (HTTP)";
                return "Android / Mobile";
            }

            return "Unknown";
        }



        private void btnSaveTXT_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.Title = "Зберегти результати сканування";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("=== NETWORK SCAN RESULTS ===");
                    writer.WriteLine($"Date: {DateTime.Now}");
                    writer.WriteLine($"Range: {txtIPRangeStart.Text} - {txtIPRangeEnd.Text}");
                    writer.WriteLine($"Found: {scanResults.Count} devices");
                    writer.WriteLine(new string('=', 100));

                    foreach (var device in scanResults)
                    {
                        writer.WriteLine($"IP: {device.IP}");
                        writer.WriteLine($"  Status: {device.Status}");
                        writer.WriteLine($"  Hostname: {device.Hostname}");
                        writer.WriteLine($"  MAC: {device.MAC}");
                        writer.WriteLine($"  Vendor: {device.Vendor}");
                        writer.WriteLine($"  OS: {device.OS}");
                        writer.WriteLine($"  Ports: {device.OpenPorts}");
                        writer.WriteLine($"  Latency: {device.Latency} ms");
                        writer.WriteLine(new string('-', 50));
                    }
                }

                MessageBox.Show($"✅ Збережено {scanResults.Count} записів у {saveFileDialog.FileName}");
            }
        }

        private void btnSaveJSON_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Зберегти результати сканування";
            saveFileDialog.DefaultExt = "json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var exportData = new
                {
                    scan_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ip_range = $"{txtIPRangeStart.Text} - {txtIPRangeEnd.Text}",
                    total_devices = scanResults.Count,
                    devices = scanResults
                };

                string json = JsonSerializer.Serialize(exportData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, json);

                MessageBox.Show($"✅ Збережено {scanResults.Count} записів у {saveFileDialog.FileName}");
            }
        }

        private void btnStopScan_Click_1(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                lblProgress.Text = "⚠️ Сканування зупинено!";
            }
        }

        private void chkOnlineOnly_CheckedChanged_1(object sender, EventArgs e)
        {
            if (scanResults.Count > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (var device in scanResults)
                {
                    if (chkOnlineOnly.Checked && device.Status != "Online")
                        continue;

                    dataGridView1.Rows.Add(device.IP, device.Status, device.Hostname,
                        !string.IsNullOrEmpty(device.Vendor) ? $"{device.MAC} ({device.Vendor})" : device.MAC,
                        device.OS, device.OpenPorts, device.Latency);
                }
            }
        }

        private async void btnScan_Click_1(object sender, EventArgs e)
        {
            await StartScan();
        }
    }

    public class NetworkDevice
    {
        public string IP { get; set; }
        public string Status { get; set; }
        public string Hostname { get; set; }
        public string MAC { get; set; }
        public string Vendor { get; set; }
        public string OS { get; set; }
        public string OpenPorts { get; set; }
        public string Latency { get; set; }
    }
}