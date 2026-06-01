namespace SystemMonitor
{
    partial class SettingsForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.numericInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.txtDefaultSubnet = new System.Windows.Forms.TextBox();
            this.lblSubnet = new System.Windows.Forms.Label();
            this.chkAutoSaveLogs = new System.Windows.Forms.CheckBox();
            this.chkEnableAlerts = new System.Windows.Forms.CheckBox();
            this.lblAutoSave = new System.Windows.Forms.Label();
            this.lblAlerts = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numericInterval
            // 
            this.numericInterval.Location = new System.Drawing.Point(144, 47);
            this.numericInterval.Name = "numericInterval";
            this.numericInterval.Size = new System.Drawing.Size(120, 20);
            this.numericInterval.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "⏱ Інтервал оновлення:";
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(12, 88);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(52, 13);
            this.lblTheme.TabIndex = 4;
            this.lblTheme.Text = "🎨 Тема:";
            // 
            // txtDefaultSubnet
            // 
            this.txtDefaultSubnet.Location = new System.Drawing.Point(185, 139);
            this.txtDefaultSubnet.Name = "txtDefaultSubnet";
            this.txtDefaultSubnet.Size = new System.Drawing.Size(148, 20);
            this.txtDefaultSubnet.TabIndex = 5;
            // 
            // lblSubnet
            // 
            this.lblSubnet.AutoSize = true;
            this.lblSubnet.Location = new System.Drawing.Point(12, 142);
            this.lblSubnet.Name = "lblSubnet";
            this.lblSubnet.Size = new System.Drawing.Size(167, 13);
            this.lblSubnet.TabIndex = 6;
            this.lblSubnet.Text = "🌐 Мережа за замовчюванням:";
            // 
            // chkAutoSaveLogs
            // 
            this.chkAutoSaveLogs.AutoSize = true;
            this.chkAutoSaveLogs.Location = new System.Drawing.Point(157, 192);
            this.chkAutoSaveLogs.Name = "chkAutoSaveLogs";
            this.chkAutoSaveLogs.Size = new System.Drawing.Size(96, 17);
            this.chkAutoSaveLogs.TabIndex = 7;
            this.chkAutoSaveLogs.Text = "AutoSaveLogs";
            this.chkAutoSaveLogs.UseVisualStyleBackColor = true;
            this.chkAutoSaveLogs.CheckedChanged += new System.EventHandler(this.chkAutoSaveLogs_CheckedChanged_1);
            // 
            // chkEnableAlerts
            // 
            this.chkEnableAlerts.AutoSize = true;
            this.chkEnableAlerts.Location = new System.Drawing.Point(157, 218);
            this.chkEnableAlerts.Name = "chkEnableAlerts";
            this.chkEnableAlerts.Size = new System.Drawing.Size(85, 17);
            this.chkEnableAlerts.TabIndex = 8;
            this.chkEnableAlerts.Text = "EnableAlerts";
            this.chkEnableAlerts.UseVisualStyleBackColor = true;
            // 
            // lblAutoSave
            // 
            this.lblAutoSave.AutoSize = true;
            this.lblAutoSave.Location = new System.Drawing.Point(12, 192);
            this.lblAutoSave.Name = "lblAutoSave";
            this.lblAutoSave.Size = new System.Drawing.Size(139, 13);
            this.lblAutoSave.TabIndex = 9;
            this.lblAutoSave.Text = "📁 Автозбереження логів:";
            // 
            // lblAlerts
            // 
            this.lblAlerts.AutoSize = true;
            this.lblAlerts.Location = new System.Drawing.Point(12, 218);
            this.lblAlerts.Name = "lblAlerts";
            this.lblAlerts.Size = new System.Drawing.Size(61, 13);
            this.lblAlerts.TabIndex = 10;
            this.lblAlerts.Text = "🔔 Алерти:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(296, 47);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "lblStatus";
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(144, 88);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(121, 21);
            this.cmbTheme.TabIndex = 12;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.cmbTheme);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblAlerts);
            this.Controls.Add(this.lblAutoSave);
            this.Controls.Add(this.chkEnableAlerts);
            this.Controls.Add(this.chkAutoSaveLogs);
            this.Controls.Add(this.lblSubnet);
            this.Controls.Add(this.txtDefaultSubnet);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericInterval);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numericInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.TextBox txtDefaultSubnet;
        private System.Windows.Forms.Label lblSubnet;
        private System.Windows.Forms.CheckBox chkAutoSaveLogs;
        private System.Windows.Forms.CheckBox chkEnableAlerts;
        private System.Windows.Forms.Label lblAutoSave;
        private System.Windows.Forms.Label lblAlerts;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbTheme;
    }
}