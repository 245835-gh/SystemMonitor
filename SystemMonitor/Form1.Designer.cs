namespace SystemMonitor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.головнеМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моніторингCPURAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cPURAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.температураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дискиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.процесиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.програмиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мережаPingScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.головнеМенюToolStripMenuItem,
            this.моніторингCPURAMToolStripMenuItem,
            this.дискиToolStripMenuItem,
            this.процесиToolStripMenuItem,
            this.програмиToolStripMenuItem,
            this.мережаPingScannerToolStripMenuItem,
            this.системаToolStripMenuItem,
            this.налаштуванняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // головнеМенюToolStripMenuItem
            // 
            this.головнеМенюToolStripMenuItem.Name = "головнеМенюToolStripMenuItem";
            this.головнеМенюToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.головнеМенюToolStripMenuItem.Text = "Головне меню";
            this.головнеМенюToolStripMenuItem.Click += new System.EventHandler(this.головнеМенюToolStripMenuItem_Click);
            // 
            // моніторингCPURAMToolStripMenuItem
            // 
            this.моніторингCPURAMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cPURAMToolStripMenuItem,
            this.gPUToolStripMenuItem,
            this.температураToolStripMenuItem});
            this.моніторингCPURAMToolStripMenuItem.Name = "моніторингCPURAMToolStripMenuItem";
            this.моніторингCPURAMToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.моніторингCPURAMToolStripMenuItem.Text = "Моніторинг";
            // 
            // cPURAMToolStripMenuItem
            // 
            this.cPURAMToolStripMenuItem.Name = "cPURAMToolStripMenuItem";
            this.cPURAMToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cPURAMToolStripMenuItem.Text = "CPU / RAM";
            this.cPURAMToolStripMenuItem.Click += new System.EventHandler(this.cPURAMToolStripMenuItem_Click_1);
            // 
            // gPUToolStripMenuItem
            // 
            this.gPUToolStripMenuItem.Name = "gPUToolStripMenuItem";
            this.gPUToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gPUToolStripMenuItem.Text = "GPU";
            this.gPUToolStripMenuItem.Click += new System.EventHandler(this.gPUToolStripMenuItem_Click);
            // 
            // температураToolStripMenuItem
            // 
            this.температураToolStripMenuItem.Name = "температураToolStripMenuItem";
            this.температураToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.температураToolStripMenuItem.Text = "Температура";
            this.температураToolStripMenuItem.Click += new System.EventHandler(this.температураToolStripMenuItem_Click);
            // 
            // дискиToolStripMenuItem
            // 
            this.дискиToolStripMenuItem.Name = "дискиToolStripMenuItem";
            this.дискиToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.дискиToolStripMenuItem.Text = "Диски";
            this.дискиToolStripMenuItem.Click += new System.EventHandler(this.дискиToolStripMenuItem_Click_1);
            // 
            // процесиToolStripMenuItem
            // 
            this.процесиToolStripMenuItem.Name = "процесиToolStripMenuItem";
            this.процесиToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.процесиToolStripMenuItem.Text = "Процеси";
            this.процесиToolStripMenuItem.Click += new System.EventHandler(this.процесиToolStripMenuItem_Click_1);
            // 
            // програмиToolStripMenuItem
            // 
            this.програмиToolStripMenuItem.Name = "програмиToolStripMenuItem";
            this.програмиToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.програмиToolStripMenuItem.Text = "Програми";
            this.програмиToolStripMenuItem.Click += new System.EventHandler(this.програмиToolStripMenuItem_Click_1);
            // 
            // мережаPingScannerToolStripMenuItem
            // 
            this.мережаPingScannerToolStripMenuItem.Name = "мережаPingScannerToolStripMenuItem";
            this.мережаPingScannerToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.мережаPingScannerToolStripMenuItem.Text = "Мережа (Ping / Scanner)";
            this.мережаPingScannerToolStripMenuItem.Click += new System.EventHandler(this.мережаPingScannerToolStripMenuItem_Click);
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.системаToolStripMenuItem.Text = "Система";
            this.системаToolStripMenuItem.Click += new System.EventHandler(this.системаToolStripMenuItem_Click_1);
            // 
            // налаштуванняToolStripMenuItem
            // 
            this.налаштуванняToolStripMenuItem.Name = "налаштуванняToolStripMenuItem";
            this.налаштуванняToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.налаштуванняToolStripMenuItem.Text = "Налаштування";
            this.налаштуванняToolStripMenuItem.Click += new System.EventHandler(this.налаштуванняToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(930, 516);
            this.mainPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SystemMonitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem моніторингCPURAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cPURAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дискиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem процесиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem програмиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мережаPingScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem головнеМенюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem температураToolStripMenuItem;
    }
}

