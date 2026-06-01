namespace SystemMonitor
{
    partial class TemperatureForm
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
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewTemperatures = new System.Windows.Forms.ListView();
            this.circularCPU = new CircularProgressBar.CircularProgressBar();
            this.lblCPUMax = new System.Windows.Forms.Label();
            this.lblCPUTemp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGPUMax = new System.Windows.Forms.Label();
            this.lblGPUTemp = new System.Windows.Forms.Label();
            this.circularGPU = new CircularProgressBar.CircularProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblHDDMax = new System.Windows.Forms.Label();
            this.lblHDDTemp = new System.Windows.Forms.Label();
            this.circularHDD = new CircularProgressBar.CircularProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(103, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "lblStatus";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.listViewTemperatures);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 487);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // listViewTemperatures
            // 
            this.listViewTemperatures.HideSelection = false;
            this.listViewTemperatures.Location = new System.Drawing.Point(6, 256);
            this.listViewTemperatures.Name = "listViewTemperatures";
            this.listViewTemperatures.Size = new System.Drawing.Size(750, 225);
            this.listViewTemperatures.TabIndex = 9;
            this.listViewTemperatures.UseCompatibleStateImageBehavior = false;
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
            this.circularCPU.Location = new System.Drawing.Point(46, 19);
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
            this.circularCPU.TabIndex = 19;
            this.circularCPU.Text = "0%";
            this.circularCPU.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularCPU.Value = 68;
            // 
            // lblCPUMax
            // 
            this.lblCPUMax.AutoSize = true;
            this.lblCPUMax.Location = new System.Drawing.Point(6, 171);
            this.lblCPUMax.Name = "lblCPUMax";
            this.lblCPUMax.Size = new System.Drawing.Size(59, 13);
            this.lblCPUMax.TabIndex = 6;
            this.lblCPUMax.Text = "lblCPUMax";
            // 
            // lblCPUTemp
            // 
            this.lblCPUTemp.AutoSize = true;
            this.lblCPUTemp.Location = new System.Drawing.Point(6, 139);
            this.lblCPUTemp.Name = "lblCPUTemp";
            this.lblCPUTemp.Size = new System.Drawing.Size(66, 13);
            this.lblCPUTemp.TabIndex = 3;
            this.lblCPUTemp.Text = "lblCPUTemp";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCPUTemp);
            this.groupBox2.Controls.Add(this.lblCPUMax);
            this.groupBox2.Controls.Add(this.circularCPU);
            this.groupBox2.Location = new System.Drawing.Point(13, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 197);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CPU";
            // 
            // lblGPUMax
            // 
            this.lblGPUMax.AutoSize = true;
            this.lblGPUMax.Location = new System.Drawing.Point(6, 171);
            this.lblGPUMax.Name = "lblGPUMax";
            this.lblGPUMax.Size = new System.Drawing.Size(60, 13);
            this.lblGPUMax.TabIndex = 7;
            this.lblGPUMax.Text = "lblGPUMax";
            // 
            // lblGPUTemp
            // 
            this.lblGPUTemp.AutoSize = true;
            this.lblGPUTemp.Location = new System.Drawing.Point(6, 139);
            this.lblGPUTemp.Name = "lblGPUTemp";
            this.lblGPUTemp.Size = new System.Drawing.Size(67, 13);
            this.lblGPUTemp.TabIndex = 5;
            this.lblGPUTemp.Text = "lblGPUTemp";
            // 
            // circularGPU
            // 
            this.circularGPU.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularGPU.AnimationSpeed = 500;
            this.circularGPU.BackColor = System.Drawing.Color.Transparent;
            this.circularGPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularGPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularGPU.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularGPU.InnerMargin = 2;
            this.circularGPU.InnerWidth = -1;
            this.circularGPU.Location = new System.Drawing.Point(50, 19);
            this.circularGPU.MarqueeAnimationSpeed = 2000;
            this.circularGPU.Name = "circularGPU";
            this.circularGPU.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularGPU.OuterMargin = -25;
            this.circularGPU.OuterWidth = 26;
            this.circularGPU.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularGPU.ProgressWidth = 25;
            this.circularGPU.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularGPU.Size = new System.Drawing.Size(117, 117);
            this.circularGPU.StartAngle = 270;
            this.circularGPU.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPU.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularGPU.SubscriptText = "";
            this.circularGPU.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularGPU.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularGPU.SuperscriptText = "";
            this.circularGPU.TabIndex = 20;
            this.circularGPU.Text = "0%";
            this.circularGPU.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularGPU.Value = 68;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.circularGPU);
            this.groupBox3.Controls.Add(this.lblGPUTemp);
            this.groupBox3.Controls.Add(this.lblGPUMax);
            this.groupBox3.Location = new System.Drawing.Point(425, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 197);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GPU";
            // 
            // lblHDDMax
            // 
            this.lblHDDMax.AutoSize = true;
            this.lblHDDMax.Location = new System.Drawing.Point(6, 168);
            this.lblHDDMax.Name = "lblHDDMax";
            this.lblHDDMax.Size = new System.Drawing.Size(61, 13);
            this.lblHDDMax.TabIndex = 8;
            this.lblHDDMax.Text = "lblHDDMax";
            // 
            // lblHDDTemp
            // 
            this.lblHDDTemp.AutoSize = true;
            this.lblHDDTemp.Location = new System.Drawing.Point(6, 139);
            this.lblHDDTemp.Name = "lblHDDTemp";
            this.lblHDDTemp.Size = new System.Drawing.Size(68, 13);
            this.lblHDDTemp.TabIndex = 4;
            this.lblHDDTemp.Text = "lblHDDTemp";
            // 
            // circularHDD
            // 
            this.circularHDD.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularHDD.AnimationSpeed = 500;
            this.circularHDD.BackColor = System.Drawing.Color.Transparent;
            this.circularHDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularHDD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularHDD.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularHDD.InnerMargin = 2;
            this.circularHDD.InnerWidth = -1;
            this.circularHDD.Location = new System.Drawing.Point(43, 19);
            this.circularHDD.MarqueeAnimationSpeed = 2000;
            this.circularHDD.Name = "circularHDD";
            this.circularHDD.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularHDD.OuterMargin = -25;
            this.circularHDD.OuterWidth = 26;
            this.circularHDD.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularHDD.ProgressWidth = 25;
            this.circularHDD.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularHDD.Size = new System.Drawing.Size(117, 117);
            this.circularHDD.StartAngle = 270;
            this.circularHDD.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularHDD.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularHDD.SubscriptText = "";
            this.circularHDD.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularHDD.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularHDD.SuperscriptText = "";
            this.circularHDD.TabIndex = 21;
            this.circularHDD.Text = "0%";
            this.circularHDD.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularHDD.Value = 68;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.circularHDD);
            this.groupBox4.Controls.Add(this.lblHDDTemp);
            this.groupBox4.Controls.Add(this.lblHDDMax);
            this.groupBox4.Location = new System.Drawing.Point(219, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 197);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HDD/SDD";
            // 
            // TemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Name = "TemperatureForm";
            this.Text = "TemperatureForm";
            this.Load += new System.EventHandler(this.TemperatureForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewTemperatures;
        private CircularProgressBar.CircularProgressBar circularCPU;
        private System.Windows.Forms.GroupBox groupBox4;
        private CircularProgressBar.CircularProgressBar circularHDD;
        private System.Windows.Forms.Label lblHDDTemp;
        private System.Windows.Forms.Label lblHDDMax;
        private System.Windows.Forms.GroupBox groupBox3;
        private CircularProgressBar.CircularProgressBar circularGPU;
        private System.Windows.Forms.Label lblGPUTemp;
        private System.Windows.Forms.Label lblGPUMax;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCPUTemp;
        private System.Windows.Forms.Label lblCPUMax;
    }
}