namespace SystemMonitor
{
    partial class GpuForm
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
            this.lblGPUName = new System.Windows.Forms.Label();
            this.lblGPUVendor = new System.Windows.Forms.Label();
            this.lblGPUDriver = new System.Windows.Forms.Label();
            this.lblGPUMemory = new System.Windows.Forms.Label();
            this.lblGPUTemp = new System.Windows.Forms.Label();
            this.lblGPUClock = new System.Windows.Forms.Label();
            this.lblGPUMemoryClock = new System.Windows.Forms.Label();
            this.lblGPUVoltage = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.circularGPUMemory = new CircularProgressBar.CircularProgressBar();
            this.circularGPUTemp = new CircularProgressBar.CircularProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.circularGPUUsage = new CircularProgressBar.CircularProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGPUName
            // 
            this.lblGPUName.AutoSize = true;
            this.lblGPUName.Location = new System.Drawing.Point(6, 31);
            this.lblGPUName.Name = "lblGPUName";
            this.lblGPUName.Size = new System.Drawing.Size(68, 13);
            this.lblGPUName.TabIndex = 0;
            this.lblGPUName.Text = "lblGPUName";
            // 
            // lblGPUVendor
            // 
            this.lblGPUVendor.AutoSize = true;
            this.lblGPUVendor.Location = new System.Drawing.Point(6, 77);
            this.lblGPUVendor.Name = "lblGPUVendor";
            this.lblGPUVendor.Size = new System.Drawing.Size(74, 13);
            this.lblGPUVendor.TabIndex = 1;
            this.lblGPUVendor.Text = "lblGPUVendor";
            // 
            // lblGPUDriver
            // 
            this.lblGPUDriver.AutoSize = true;
            this.lblGPUDriver.Location = new System.Drawing.Point(6, 126);
            this.lblGPUDriver.Name = "lblGPUDriver";
            this.lblGPUDriver.Size = new System.Drawing.Size(68, 13);
            this.lblGPUDriver.TabIndex = 2;
            this.lblGPUDriver.Text = "lblGPUDriver";
            // 
            // lblGPUMemory
            // 
            this.lblGPUMemory.AutoSize = true;
            this.lblGPUMemory.Location = new System.Drawing.Point(6, 198);
            this.lblGPUMemory.Name = "lblGPUMemory";
            this.lblGPUMemory.Size = new System.Drawing.Size(77, 13);
            this.lblGPUMemory.TabIndex = 3;
            this.lblGPUMemory.Text = "lblGPUMemory";
            // 
            // lblGPUTemp
            // 
            this.lblGPUTemp.AutoSize = true;
            this.lblGPUTemp.Location = new System.Drawing.Point(6, 23);
            this.lblGPUTemp.Name = "lblGPUTemp";
            this.lblGPUTemp.Size = new System.Drawing.Size(67, 13);
            this.lblGPUTemp.TabIndex = 9;
            this.lblGPUTemp.Text = "lblGPUTemp";
            // 
            // lblGPUClock
            // 
            this.lblGPUClock.AutoSize = true;
            this.lblGPUClock.Location = new System.Drawing.Point(6, 66);
            this.lblGPUClock.Name = "lblGPUClock";
            this.lblGPUClock.Size = new System.Drawing.Size(67, 13);
            this.lblGPUClock.TabIndex = 10;
            this.lblGPUClock.Text = "lblGPUClock";
            // 
            // lblGPUMemoryClock
            // 
            this.lblGPUMemoryClock.AutoSize = true;
            this.lblGPUMemoryClock.Location = new System.Drawing.Point(6, 112);
            this.lblGPUMemoryClock.Name = "lblGPUMemoryClock";
            this.lblGPUMemoryClock.Size = new System.Drawing.Size(104, 13);
            this.lblGPUMemoryClock.TabIndex = 11;
            this.lblGPUMemoryClock.Text = "lblGPUMemoryClock";
            // 
            // lblGPUVoltage
            // 
            this.lblGPUVoltage.AutoSize = true;
            this.lblGPUVoltage.Location = new System.Drawing.Point(6, 162);
            this.lblGPUVoltage.Name = "lblGPUVoltage";
            this.lblGPUVoltage.Size = new System.Drawing.Size(76, 13);
            this.lblGPUVoltage.TabIndex = 12;
            this.lblGPUVoltage.Text = "lblGPUVoltage";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 447);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGPUName);
            this.groupBox1.Controls.Add(this.lblGPUVendor);
            this.groupBox1.Controls.Add(this.lblGPUDriver);
            this.groupBox1.Location = new System.Drawing.Point(424, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 171);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblGPUMemory);
            this.groupBox2.Controls.Add(this.lblGPUTemp);
            this.groupBox2.Controls.Add(this.lblGPUClock);
            this.groupBox2.Controls.Add(this.lblGPUMemoryClock);
            this.groupBox2.Controls.Add(this.lblGPUVoltage);
            this.groupBox2.Location = new System.Drawing.Point(218, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 230);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // circularGPUMemory
            // 
            this.circularGPUMemory.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularGPUMemory.AnimationSpeed = 500;
            this.circularGPUMemory.BackColor = System.Drawing.Color.Transparent;
            this.circularGPUMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularGPUMemory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularGPUMemory.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularGPUMemory.InnerMargin = 2;
            this.circularGPUMemory.InnerWidth = -1;
            this.circularGPUMemory.Location = new System.Drawing.Point(31, 23);
            this.circularGPUMemory.MarqueeAnimationSpeed = 2000;
            this.circularGPUMemory.Name = "circularGPUMemory";
            this.circularGPUMemory.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularGPUMemory.OuterMargin = -25;
            this.circularGPUMemory.OuterWidth = 26;
            this.circularGPUMemory.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularGPUMemory.ProgressWidth = 25;
            this.circularGPUMemory.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularGPUMemory.Size = new System.Drawing.Size(117, 117);
            this.circularGPUMemory.StartAngle = 270;
            this.circularGPUMemory.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUMemory.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularGPUMemory.SubscriptText = "";
            this.circularGPUMemory.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUMemory.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularGPUMemory.SuperscriptText = "";
            this.circularGPUMemory.TabIndex = 18;
            this.circularGPUMemory.Text = "0%";
            this.circularGPUMemory.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularGPUMemory.Value = 68;
            // 
            // circularGPUTemp
            // 
            this.circularGPUTemp.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularGPUTemp.AnimationSpeed = 500;
            this.circularGPUTemp.BackColor = System.Drawing.Color.Transparent;
            this.circularGPUTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularGPUTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularGPUTemp.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularGPUTemp.InnerMargin = 2;
            this.circularGPUTemp.InnerWidth = -1;
            this.circularGPUTemp.Location = new System.Drawing.Point(40, 23);
            this.circularGPUTemp.MarqueeAnimationSpeed = 2000;
            this.circularGPUTemp.Name = "circularGPUTemp";
            this.circularGPUTemp.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularGPUTemp.OuterMargin = -25;
            this.circularGPUTemp.OuterWidth = 26;
            this.circularGPUTemp.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularGPUTemp.ProgressWidth = 25;
            this.circularGPUTemp.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularGPUTemp.Size = new System.Drawing.Size(117, 117);
            this.circularGPUTemp.StartAngle = 270;
            this.circularGPUTemp.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUTemp.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularGPUTemp.SubscriptText = "";
            this.circularGPUTemp.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUTemp.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularGPUTemp.SuperscriptText = "";
            this.circularGPUTemp.TabIndex = 19;
            this.circularGPUTemp.Text = "0%";
            this.circularGPUTemp.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularGPUTemp.Value = 68;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.circularGPUMemory);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 160);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GPUMemory";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.circularGPUUsage);
            this.groupBox5.Location = new System.Drawing.Point(12, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 212);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPUUsage";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.circularGPUTemp);
            this.groupBox3.Location = new System.Drawing.Point(218, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 160);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GPUMemoryUsage";
            // 
            // circularGPUUsage
            // 
            this.circularGPUUsage.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularGPUUsage.AnimationSpeed = 500;
            this.circularGPUUsage.BackColor = System.Drawing.Color.Transparent;
            this.circularGPUUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularGPUUsage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularGPUUsage.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularGPUUsage.InnerMargin = 2;
            this.circularGPUUsage.InnerWidth = -1;
            this.circularGPUUsage.Location = new System.Drawing.Point(31, 34);
            this.circularGPUUsage.MarqueeAnimationSpeed = 2000;
            this.circularGPUUsage.Name = "circularGPUUsage";
            this.circularGPUUsage.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularGPUUsage.OuterMargin = -25;
            this.circularGPUUsage.OuterWidth = 26;
            this.circularGPUUsage.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularGPUUsage.ProgressWidth = 25;
            this.circularGPUUsage.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularGPUUsage.Size = new System.Drawing.Size(117, 117);
            this.circularGPUUsage.StartAngle = 270;
            this.circularGPUUsage.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUUsage.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularGPUUsage.SubscriptText = "";
            this.circularGPUUsage.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPUUsage.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularGPUUsage.SuperscriptText = "";
            this.circularGPUUsage.TabIndex = 17;
            this.circularGPUUsage.Text = "0%";
            this.circularGPUUsage.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularGPUUsage.Value = 68;
            // 
            // GpuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Name = "GpuForm";
            this.Text = "GpuForm";
            this.Load += new System.EventHandler(this.GpuForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGPUName;
        private System.Windows.Forms.Label lblGPUVendor;
        private System.Windows.Forms.Label lblGPUDriver;
        private System.Windows.Forms.Label lblGPUMemory;
        private System.Windows.Forms.Label lblGPUTemp;
        private System.Windows.Forms.Label lblGPUClock;
        private System.Windows.Forms.Label lblGPUMemoryClock;
        private System.Windows.Forms.Label lblGPUVoltage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CircularProgressBar.CircularProgressBar circularGPUMemory;
        private CircularProgressBar.CircularProgressBar circularGPUTemp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private CircularProgressBar.CircularProgressBar circularGPUUsage;
    }
}