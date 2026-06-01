namespace SystemMonitor
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCPU = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.labelDisk = new System.Windows.Forms.Label();
            this.labelProc = new System.Windows.Forms.Label();
            this.labelNet = new System.Windows.Forms.Label();
            this.labelUptime = new System.Windows.Forms.Label();
            this.labelOS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.circularCPU = new CircularProgressBar.CircularProgressBar();
            this.labelAvg = new System.Windows.Forms.Label();
            this.labelAlert = new System.Windows.Forms.Label();
            this.chartUsage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listTopProcesses = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.circularDisk = new CircularProgressBar.CircularProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.circularRAM = new CircularProgressBar.CircularProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Location = new System.Drawing.Point(6, 186);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(51, 13);
            this.labelCPU.TabIndex = 0;
            this.labelCPU.Text = "labelCPU";
            // 
            // labelRAM
            // 
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(6, 186);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(53, 13);
            this.labelRAM.TabIndex = 1;
            this.labelRAM.Text = "labelRAM";
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Location = new System.Drawing.Point(6, 186);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(50, 13);
            this.labelDisk.TabIndex = 2;
            this.labelDisk.Text = "labelDisk";
            // 
            // labelProc
            // 
            this.labelProc.AutoSize = true;
            this.labelProc.Location = new System.Drawing.Point(6, 39);
            this.labelProc.Name = "labelProc";
            this.labelProc.Size = new System.Drawing.Size(51, 13);
            this.labelProc.TabIndex = 3;
            this.labelProc.Text = "labelProc";
            // 
            // labelNet
            // 
            this.labelNet.AutoSize = true;
            this.labelNet.Location = new System.Drawing.Point(6, 65);
            this.labelNet.Name = "labelNet";
            this.labelNet.Size = new System.Drawing.Size(46, 13);
            this.labelNet.TabIndex = 4;
            this.labelNet.Text = "labelNet";
            // 
            // labelUptime
            // 
            this.labelUptime.AutoSize = true;
            this.labelUptime.Location = new System.Drawing.Point(6, 16);
            this.labelUptime.Name = "labelUptime";
            this.labelUptime.Size = new System.Drawing.Size(62, 13);
            this.labelUptime.TabIndex = 5;
            this.labelUptime.Text = "labelUptime";
            // 
            // labelOS
            // 
            this.labelOS.AutoSize = true;
            this.labelOS.Location = new System.Drawing.Point(200, 16);
            this.labelOS.Name = "labelOS";
            this.labelOS.Size = new System.Drawing.Size(44, 13);
            this.labelOS.TabIndex = 6;
            this.labelOS.Text = "labelOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.circularCPU);
            this.groupBox1.Controls.Add(this.labelCPU);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 233);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU";
            // 
            // circularCPU
            // 
            this.circularCPU.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularCPU.AnimationSpeed = 500;
            this.circularCPU.BackColor = System.Drawing.Color.Transparent;
            this.circularCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularCPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularCPU.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularCPU.InnerMargin = 2;
            this.circularCPU.InnerWidth = -1;
            this.circularCPU.Location = new System.Drawing.Point(40, 19);
            this.circularCPU.MarqueeAnimationSpeed = 2000;
            this.circularCPU.Name = "circularCPU";
            this.circularCPU.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularCPU.OuterMargin = -25;
            this.circularCPU.OuterWidth = 26;
            this.circularCPU.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularCPU.ProgressWidth = 25;
            this.circularCPU.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularCPU.Size = new System.Drawing.Size(117, 117);
            this.circularCPU.StartAngle = 270;
            this.circularCPU.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularCPU.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularCPU.SubscriptText = "";
            this.circularCPU.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularCPU.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularCPU.SuperscriptText = "";
            this.circularCPU.TabIndex = 1;
            this.circularCPU.Text = "0%";
            this.circularCPU.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularCPU.Value = 68;
            // 
            // labelAvg
            // 
            this.labelAvg.AutoSize = true;
            this.labelAvg.Location = new System.Drawing.Point(200, 39);
            this.labelAvg.Name = "labelAvg";
            this.labelAvg.Size = new System.Drawing.Size(48, 13);
            this.labelAvg.TabIndex = 11;
            this.labelAvg.Text = "labelAvg";
            // 
            // labelAlert
            // 
            this.labelAlert.AutoSize = true;
            this.labelAlert.Location = new System.Drawing.Point(200, 65);
            this.labelAlert.Name = "labelAlert";
            this.labelAlert.Size = new System.Drawing.Size(50, 13);
            this.labelAlert.TabIndex = 10;
            this.labelAlert.Text = "labelAlert";
            // 
            // chartUsage
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUsage.ChartAreas.Add(chartArea1);
            this.chartUsage.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartUsage.Legends.Add(legend1);
            this.chartUsage.Location = new System.Drawing.Point(0, 0);
            this.chartUsage.Name = "chartUsage";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartUsage.Series.Add(series1);
            this.chartUsage.Size = new System.Drawing.Size(930, 186);
            this.chartUsage.TabIndex = 11;
            this.chartUsage.Text = "chart1";
            this.chartUsage.Click += new System.EventHandler(this.chartUsage_Click);
            // 
            // listTopProcesses
            // 
            this.listTopProcesses.FormattingEnabled = true;
            this.listTopProcesses.Location = new System.Drawing.Point(6, 19);
            this.listTopProcesses.Name = "listTopProcesses";
            this.listTopProcesses.Size = new System.Drawing.Size(299, 199);
            this.listTopProcesses.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listTopProcesses);
            this.groupBox2.Location = new System.Drawing.Point(621, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 233);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "listTopProcesses";
            // 
            // circularDisk
            // 
            this.circularDisk.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularDisk.AnimationSpeed = 500;
            this.circularDisk.BackColor = System.Drawing.Color.Transparent;
            this.circularDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularDisk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularDisk.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularDisk.InnerMargin = 2;
            this.circularDisk.InnerWidth = -1;
            this.circularDisk.Location = new System.Drawing.Point(42, 19);
            this.circularDisk.MarqueeAnimationSpeed = 2000;
            this.circularDisk.Name = "circularDisk";
            this.circularDisk.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularDisk.OuterMargin = -25;
            this.circularDisk.OuterWidth = 26;
            this.circularDisk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularDisk.ProgressWidth = 25;
            this.circularDisk.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.circularDisk.Size = new System.Drawing.Size(117, 117);
            this.circularDisk.StartAngle = 270;
            this.circularDisk.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularDisk.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularDisk.SubscriptText = "";
            this.circularDisk.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularDisk.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularDisk.SuperscriptText = "";
            this.circularDisk.TabIndex = 13;
            this.circularDisk.Text = "0%";
            this.circularDisk.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularDisk.Value = 68;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.circularDisk);
            this.groupBox3.Controls.Add(this.labelDisk);
            this.groupBox3.Location = new System.Drawing.Point(215, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 233);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Disk";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelRAM);
            this.groupBox4.Controls.Add(this.circularRAM);
            this.groupBox4.Location = new System.Drawing.Point(418, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 233);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RAM";
            // 
            // circularRAM
            // 
            this.circularRAM.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularRAM.AnimationSpeed = 500;
            this.circularRAM.BackColor = System.Drawing.Color.Transparent;
            this.circularRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularRAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularRAM.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularRAM.InnerMargin = 2;
            this.circularRAM.InnerWidth = -1;
            this.circularRAM.Location = new System.Drawing.Point(39, 19);
            this.circularRAM.MarqueeAnimationSpeed = 2000;
            this.circularRAM.Name = "circularRAM";
            this.circularRAM.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularRAM.OuterMargin = -25;
            this.circularRAM.OuterWidth = 26;
            this.circularRAM.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularRAM.ProgressWidth = 25;
            this.circularRAM.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularRAM.Size = new System.Drawing.Size(117, 117);
            this.circularRAM.StartAngle = 270;
            this.circularRAM.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularRAM.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularRAM.SubscriptText = "";
            this.circularRAM.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularRAM.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularRAM.SuperscriptText = "";
            this.circularRAM.TabIndex = 0;
            this.circularRAM.Text = "0%";
            this.circularRAM.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularRAM.Value = 68;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelUptime);
            this.groupBox5.Controls.Add(this.labelAvg);
            this.groupBox5.Controls.Add(this.labelAlert);
            this.groupBox5.Controls.Add(this.labelProc);
            this.groupBox5.Controls.Add(this.labelNet);
            this.groupBox5.Controls.Add(this.labelOS);
            this.groupBox5.Location = new System.Drawing.Point(12, 437);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(400, 100);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chartUsage);
            this.Controls.Add(this.groupBox1);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.Label labelProc;
        private System.Windows.Forms.Label labelNet;
        private System.Windows.Forms.Label labelUptime;
        private System.Windows.Forms.Label labelOS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsage;
        private System.Windows.Forms.Label labelAvg;
        private System.Windows.Forms.Label labelAlert;
        private System.Windows.Forms.ListBox listTopProcesses;
        private System.Windows.Forms.GroupBox groupBox2;
        private CircularProgressBar.CircularProgressBar circularDisk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private CircularProgressBar.CircularProgressBar circularRAM;
        private CircularProgressBar.CircularProgressBar circularCPU;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}