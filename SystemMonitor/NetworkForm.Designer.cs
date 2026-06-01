namespace SystemMonitor
{
    partial class NetworkForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopScan = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.labelPorts = new System.Windows.Forms.Label();
            this.txtPorts = new System.Windows.Forms.TextBox();
            this.btnSaveJSON = new System.Windows.Forms.Button();
            this.btnSaveTXT = new System.Windows.Forms.Button();
            this.chkOnlineOnly = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarScan = new System.Windows.Forms.ProgressBar();
            this.labelRange = new System.Windows.Forms.Label();
            this.txtIPRangeEnd = new System.Windows.Forms.TextBox();
            this.txtIPRangeStart = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(912, 374);
            this.dataGridView1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopScan);
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.labelPorts);
            this.groupBox1.Controls.Add(this.txtPorts);
            this.groupBox1.Controls.Add(this.btnSaveJSON);
            this.groupBox1.Controls.Add(this.btnSaveTXT);
            this.groupBox1.Controls.Add(this.chkOnlineOnly);
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.progressBarScan);
            this.groupBox1.Controls.Add(this.labelRange);
            this.groupBox1.Controls.Add(this.txtIPRangeEnd);
            this.groupBox1.Controls.Add(this.txtIPRangeStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 148);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnStopScan
            // 
            this.btnStopScan.Location = new System.Drawing.Point(93, 83);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(75, 23);
            this.btnStopScan.TabIndex = 11;
            this.btnStopScan.Text = "StopScan";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click_1);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 83);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 10;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click_1);
            // 
            // labelPorts
            // 
            this.labelPorts.AutoSize = true;
            this.labelPorts.Location = new System.Drawing.Point(6, 48);
            this.labelPorts.Name = "labelPorts";
            this.labelPorts.Size = new System.Drawing.Size(124, 13);
            this.labelPorts.TabIndex = 9;
            this.labelPorts.Text = "Порти для сканування:";
            // 
            // txtPorts
            // 
            this.txtPorts.Location = new System.Drawing.Point(136, 45);
            this.txtPorts.Name = "txtPorts";
            this.txtPorts.Size = new System.Drawing.Size(100, 20);
            this.txtPorts.TabIndex = 8;
            // 
            // btnSaveJSON
            // 
            this.btnSaveJSON.Location = new System.Drawing.Point(341, 83);
            this.btnSaveJSON.Name = "btnSaveJSON";
            this.btnSaveJSON.Size = new System.Drawing.Size(75, 23);
            this.btnSaveJSON.TabIndex = 7;
            this.btnSaveJSON.Text = "SaveJSON";
            this.btnSaveJSON.UseVisualStyleBackColor = true;
            this.btnSaveJSON.Click += new System.EventHandler(this.btnSaveJSON_Click_1);
            // 
            // btnSaveTXT
            // 
            this.btnSaveTXT.Location = new System.Drawing.Point(260, 83);
            this.btnSaveTXT.Name = "btnSaveTXT";
            this.btnSaveTXT.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTXT.TabIndex = 6;
            this.btnSaveTXT.Text = "SaveTXT";
            this.btnSaveTXT.UseVisualStyleBackColor = true;
            this.btnSaveTXT.Click += new System.EventHandler(this.btnSaveTXT_Click_1);
            // 
            // chkOnlineOnly
            // 
            this.chkOnlineOnly.AutoSize = true;
            this.chkOnlineOnly.Location = new System.Drawing.Point(177, 87);
            this.chkOnlineOnly.Name = "chkOnlineOnly";
            this.chkOnlineOnly.Size = new System.Drawing.Size(77, 17);
            this.chkOnlineOnly.TabIndex = 5;
            this.chkOnlineOnly.Text = "OnlyOnline";
            this.chkOnlineOnly.UseVisualStyleBackColor = true;
            this.chkOnlineOnly.CheckedChanged += new System.EventHandler(this.chkOnlineOnly_CheckedChanged_1);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(196, 110);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(58, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "lblProgress";
            // 
            // progressBarScan
            // 
            this.progressBarScan.Location = new System.Drawing.Point(6, 110);
            this.progressBarScan.Name = "progressBarScan";
            this.progressBarScan.Size = new System.Drawing.Size(173, 23);
            this.progressBarScan.TabIndex = 3;
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Location = new System.Drawing.Point(6, 22);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(67, 13);
            this.labelRange.TabIndex = 2;
            this.labelRange.Text = "IP діапазон:";
            // 
            // txtIPRangeEnd
            // 
            this.txtIPRangeEnd.Location = new System.Drawing.Point(199, 19);
            this.txtIPRangeEnd.Name = "txtIPRangeEnd";
            this.txtIPRangeEnd.Size = new System.Drawing.Size(100, 20);
            this.txtIPRangeEnd.TabIndex = 1;
            // 
            // txtIPRangeStart
            // 
            this.txtIPRangeStart.Location = new System.Drawing.Point(79, 19);
            this.txtIPRangeStart.Name = "txtIPRangeStart";
            this.txtIPRangeStart.Size = new System.Drawing.Size(100, 20);
            this.txtIPRangeStart.TabIndex = 0;
            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NetworkForm";
            this.Text = "NetworkForm";
            this.Load += new System.EventHandler(this.NetworkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveJSON;
        private System.Windows.Forms.Button btnSaveTXT;
        private System.Windows.Forms.CheckBox chkOnlineOnly;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBarScan;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.TextBox txtIPRangeEnd;
        private System.Windows.Forms.TextBox txtIPRangeStart;
        private System.Windows.Forms.Label labelPorts;
        private System.Windows.Forms.TextBox txtPorts;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStopScan;
    }
}