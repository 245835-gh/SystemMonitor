namespace SystemMonitor
{
    partial class DiskForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnOpenDrive = new System.Windows.Forms.Button();
            this.btnLargeFolders = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.lblDriveInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.circularUsage = new CircularProgressBar.CircularProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(211, 342);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnOpenDrive
            // 
            this.btnOpenDrive.Location = new System.Drawing.Point(174, 313);
            this.btnOpenDrive.Name = "btnOpenDrive";
            this.btnOpenDrive.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDrive.TabIndex = 2;
            this.btnOpenDrive.Text = "OpenDrive";
            this.btnOpenDrive.UseVisualStyleBackColor = true;
            this.btnOpenDrive.Click += new System.EventHandler(this.btnOpenDrive_Click);
            // 
            // btnLargeFolders
            // 
            this.btnLargeFolders.Location = new System.Drawing.Point(6, 313);
            this.btnLargeFolders.Name = "btnLargeFolders";
            this.btnLargeFolders.Size = new System.Drawing.Size(81, 23);
            this.btnLargeFolders.TabIndex = 3;
            this.btnLargeFolders.Text = "LargeFolders";
            this.btnLargeFolders.UseVisualStyleBackColor = true;
            this.btnLargeFolders.Click += new System.EventHandler(this.btnLargeFolders_Click);
            // 
            // lblDriveInfo
            // 
            this.lblDriveInfo.AutoSize = true;
            this.lblDriveInfo.Location = new System.Drawing.Point(6, 16);
            this.lblDriveInfo.Name = "lblDriveInfo";
            this.lblDriveInfo.Size = new System.Drawing.Size(35, 13);
            this.lblDriveInfo.TabIndex = 2;
            this.lblDriveInfo.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.circularUsage);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.lblDriveInfo);
            this.groupBox1.Controls.Add(this.btnOpenDrive);
            this.groupBox1.Controls.Add(this.btnLargeFolders);
            this.groupBox1.Location = new System.Drawing.Point(229, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 353);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // circularUsage
            // 
            this.circularUsage.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularUsage.AnimationSpeed = 500;
            this.circularUsage.BackColor = System.Drawing.Color.Transparent;
            this.circularUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold);
            this.circularUsage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularUsage.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.circularUsage.InnerMargin = 2;
            this.circularUsage.InnerWidth = -1;
            this.circularUsage.Location = new System.Drawing.Point(9, 190);
            this.circularUsage.MarqueeAnimationSpeed = 2000;
            this.circularUsage.Name = "circularUsage";
            this.circularUsage.OuterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.circularUsage.OuterMargin = -25;
            this.circularUsage.OuterWidth = 26;
            this.circularUsage.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.circularUsage.ProgressWidth = 25;
            this.circularUsage.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularUsage.Size = new System.Drawing.Size(117, 117);
            this.circularUsage.StartAngle = 270;
            this.circularUsage.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularUsage.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularUsage.SubscriptText = "";
            this.circularUsage.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularUsage.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularUsage.SuperscriptText = "";
            this.circularUsage.TabIndex = 22;
            this.circularUsage.Text = "0%";
            this.circularUsage.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularUsage.Value = 68;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(93, 313);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // DiskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "DiskForm";
            this.Text = "DiskForm";
            this.Load += new System.EventHandler(this.DiskForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnOpenDrive;
        private System.Windows.Forms.Button btnLargeFolders;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label lblDriveInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private CircularProgressBar.CircularProgressBar circularUsage;
    }
}