namespace SystemMonitor
{
    partial class SystemForm
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
            this.lblCPUInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblRAMInfo = new System.Windows.Forms.Label();
            this.lblDiskInfo = new System.Windows.Forms.Label();
            this.lblGPUInfo = new System.Windows.Forms.Label();
            this.lblOSInfo = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblUptimeInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCPUInfo
            // 
            this.lblCPUInfo.AutoSize = true;
            this.lblCPUInfo.Location = new System.Drawing.Point(12, 56);
            this.lblCPUInfo.Name = "lblCPUInfo";
            this.lblCPUInfo.Size = new System.Drawing.Size(57, 13);
            this.lblCPUInfo.TabIndex = 0;
            this.lblCPUInfo.Text = "lblCPUInfo";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(15, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // lblRAMInfo
            // 
            this.lblRAMInfo.AutoSize = true;
            this.lblRAMInfo.Location = new System.Drawing.Point(413, 56);
            this.lblRAMInfo.Name = "lblRAMInfo";
            this.lblRAMInfo.Size = new System.Drawing.Size(59, 13);
            this.lblRAMInfo.TabIndex = 2;
            this.lblRAMInfo.Text = "lblRAMInfo";
            // 
            // lblDiskInfo
            // 
            this.lblDiskInfo.AutoSize = true;
            this.lblDiskInfo.Location = new System.Drawing.Point(413, 150);
            this.lblDiskInfo.Name = "lblDiskInfo";
            this.lblDiskInfo.Size = new System.Drawing.Size(56, 13);
            this.lblDiskInfo.TabIndex = 3;
            this.lblDiskInfo.Text = "lblDiskInfo";
            // 
            // lblGPUInfo
            // 
            this.lblGPUInfo.AutoSize = true;
            this.lblGPUInfo.Location = new System.Drawing.Point(411, 391);
            this.lblGPUInfo.Name = "lblGPUInfo";
            this.lblGPUInfo.Size = new System.Drawing.Size(58, 13);
            this.lblGPUInfo.TabIndex = 4;
            this.lblGPUInfo.Text = "lblGPUInfo";
            // 
            // lblOSInfo
            // 
            this.lblOSInfo.AutoSize = true;
            this.lblOSInfo.Location = new System.Drawing.Point(12, 150);
            this.lblOSInfo.Name = "lblOSInfo";
            this.lblOSInfo.Size = new System.Drawing.Size(50, 13);
            this.lblOSInfo.TabIndex = 6;
            this.lblOSInfo.Text = "lblOSInfo";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 229);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(57, 13);
            this.lblUserInfo.TabIndex = 7;
            this.lblUserInfo.Text = "lblUserInfo";
            // 
            // lblUptimeInfo
            // 
            this.lblUptimeInfo.AutoSize = true;
            this.lblUptimeInfo.Location = new System.Drawing.Point(12, 332);
            this.lblUptimeInfo.Name = "lblUptimeInfo";
            this.lblUptimeInfo.Size = new System.Drawing.Size(68, 13);
            this.lblUptimeInfo.TabIndex = 8;
            this.lblUptimeInfo.Text = "lblUptimeInfo";
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.lblUptimeInfo);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.lblOSInfo);
            this.Controls.Add(this.lblGPUInfo);
            this.Controls.Add(this.lblDiskInfo);
            this.Controls.Add(this.lblRAMInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCPUInfo);
            this.Name = "SystemForm";
            this.Text = "SystemForm";
            this.Load += new System.EventHandler(this.SystemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCPUInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblRAMInfo;
        private System.Windows.Forms.Label lblDiskInfo;
        private System.Windows.Forms.Label lblGPUInfo;
        private System.Windows.Forms.Label lblOSInfo;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblUptimeInfo;
    }
}