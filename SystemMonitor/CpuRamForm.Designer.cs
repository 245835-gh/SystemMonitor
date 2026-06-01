namespace SystemMonitor
{
    partial class CpuRamForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCPUFreq = new System.Windows.Forms.Label();
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.labelRAMDetails = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.circularCPU = new CircularProgressBar.CircularProgressBar();
            this.labelCPU = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.circularRAM = new CircularProgressBar.CircularProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(15, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(903, 224);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // labelCPUFreq
            // 
            this.labelCPUFreq.AutoSize = true;
            this.labelCPUFreq.Location = new System.Drawing.Point(6, 35);
            this.labelCPUFreq.Name = "labelCPUFreq";
            this.labelCPUFreq.Size = new System.Drawing.Size(72, 13);
            this.labelCPUFreq.TabIndex = 6;
            this.labelCPUFreq.Text = "labelCPUFreq";
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Location = new System.Drawing.Point(6, 107);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(56, 13);
            this.labelTemp.TabIndex = 7;
            this.labelTemp.Text = "labelTemp";
            // 
            // labelRAM
            // 
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(6, 164);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(53, 13);
            this.labelRAM.TabIndex = 8;
            this.labelRAM.Text = "labelRAM";
            // 
            // labelRAMDetails
            // 
            this.labelRAMDetails.AutoSize = true;
            this.labelRAMDetails.Location = new System.Drawing.Point(6, 72);
            this.labelRAMDetails.Name = "labelRAMDetails";
            this.labelRAMDetails.Size = new System.Drawing.Size(85, 13);
            this.labelRAMDetails.TabIndex = 9;
            this.labelRAMDetails.Text = "labelRAMDetails";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(100, 145);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(64, 13);
            this.labelInterval.TabIndex = 10;
            this.labelInterval.Text = "labelInterval";
            // 
            // numericInterval
            // 
            this.numericInterval.Location = new System.Drawing.Point(9, 143);
            this.numericInterval.Name = "numericInterval";
            this.numericInterval.Size = new System.Drawing.Size(85, 20);
            this.numericInterval.TabIndex = 11;
            this.numericInterval.ValueChanged += new System.EventHandler(this.numericInterval_ValueChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.circularCPU);
            this.groupBox1.Controls.Add(this.labelCPU);
            this.groupBox1.Location = new System.Drawing.Point(15, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 236);
            this.groupBox1.TabIndex = 12;
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
            this.circularCPU.Location = new System.Drawing.Point(23, 35);
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
            this.circularCPU.TabIndex = 13;
            this.circularCPU.Text = "0%";
            this.circularCPU.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularCPU.Value = 68;
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Location = new System.Drawing.Point(6, 164);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(51, 13);
            this.labelCPU.TabIndex = 5;
            this.labelCPU.Text = "labelCPU";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.circularRAM);
            this.groupBox2.Controls.Add(this.labelRAM);
            this.groupBox2.Location = new System.Drawing.Point(188, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 236);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RAM";
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
            this.circularRAM.Location = new System.Drawing.Point(39, 35);
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
            this.circularRAM.TabIndex = 14;
            this.circularRAM.Text = "0%";
            this.circularRAM.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularRAM.Value = 68;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelCPUFreq);
            this.groupBox3.Controls.Add(this.labelTemp);
            this.groupBox3.Controls.Add(this.labelRAMDetails);
            this.groupBox3.Controls.Add(this.numericInterval);
            this.groupBox3.Controls.Add(this.labelInterval);
            this.groupBox3.Location = new System.Drawing.Point(394, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 236);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // CpuRamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Name = "CpuRamForm";
            this.Text = "CpuRamForm";
            this.Load += new System.EventHandler(this.CpuRamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelCPUFreq;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.Label labelRAMDetails;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericInterval;
        private System.Windows.Forms.GroupBox groupBox1;
        private CircularProgressBar.CircularProgressBar circularCPU;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.GroupBox groupBox2;
        private CircularProgressBar.CircularProgressBar circularRAM;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}