namespace StockControl
{
    partial class Backup
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
            this.DlgSave = new System.Windows.Forms.SaveFileDialog();
            this.cmdBackup = new System.Windows.Forms.Button();
            this.BackupProgress = new System.Windows.Forms.ProgressBar();
            this.RestoreProgress = new System.Windows.Forms.ProgressBar();
            this.cmdRestore = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.lbRestore = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.lbBackup = new System.Windows.Forms.Label();
            this.DlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DlgSave
            // 
            this.DlgSave.DefaultExt = "*.gz";
            this.DlgSave.Filter = "GZip files|*.gz";
            // 
            // cmdBackup
            // 
            this.cmdBackup.BackgroundImage = global::StockControl.Properties.Resources.database_next_icon;
            this.cmdBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBackup.Location = new System.Drawing.Point(262, 32);
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.Size = new System.Drawing.Size(75, 23);
            this.cmdBackup.TabIndex = 0;
            this.cmdBackup.Text = "Backup";
            this.cmdBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBackup.UseVisualStyleBackColor = true;
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // BackupProgress
            // 
            this.BackupProgress.Location = new System.Drawing.Point(12, 32);
            this.BackupProgress.Name = "BackupProgress";
            this.BackupProgress.Size = new System.Drawing.Size(234, 18);
            this.BackupProgress.Step = 1;
            this.BackupProgress.TabIndex = 1;
            // 
            // RestoreProgress
            // 
            this.RestoreProgress.Location = new System.Drawing.Point(12, 132);
            this.RestoreProgress.Name = "RestoreProgress";
            this.RestoreProgress.Size = new System.Drawing.Size(234, 18);
            this.RestoreProgress.Step = 1;
            this.RestoreProgress.TabIndex = 1;
            // 
            // cmdRestore
            // 
            this.cmdRestore.Image = global::StockControl.Properties.Resources.database_previous_icon;
            this.cmdRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRestore.Location = new System.Drawing.Point(261, 95);
            this.cmdRestore.Name = "cmdRestore";
            this.cmdRestore.Size = new System.Drawing.Size(75, 23);
            this.cmdRestore.TabIndex = 0;
            this.cmdRestore.Text = "Restore";
            this.cmdRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRestore.UseVisualStyleBackColor = true;
            this.cmdRestore.Click += new System.EventHandler(this.cmdRestore_Click);
            // 
            // lbPath
            // 
            this.lbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPath.Location = new System.Drawing.Point(12, 94);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(215, 23);
            this.lbPath.TabIndex = 2;
            // 
            // lbRestore
            // 
            this.lbRestore.AutoSize = true;
            this.lbRestore.Location = new System.Drawing.Point(11, 72);
            this.lbRestore.Name = "lbRestore";
            this.lbRestore.Size = new System.Drawing.Size(67, 13);
            this.lbRestore.TabIndex = 3;
            this.lbRestore.Text = "Restore from";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(230, 94);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowse.TabIndex = 4;
            this.cmdBrowse.Text = "..";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // lbBackup
            // 
            this.lbBackup.AutoSize = true;
            this.lbBackup.Location = new System.Drawing.Point(9, 9);
            this.lbBackup.Name = "lbBackup";
            this.lbBackup.Size = new System.Drawing.Size(56, 13);
            this.lbBackup.TabIndex = 3;
            this.lbBackup.Text = "Backup to";
            // 
            // DlgOpen
            // 
            this.DlgOpen.DefaultExt = "*.gz";
            this.DlgOpen.Filter = "GZip files|*.gz";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(262, 154);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 191);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.lbBackup);
            this.Controls.Add(this.lbRestore);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.RestoreProgress);
            this.Controls.Add(this.BackupProgress);
            this.Controls.Add(this.cmdRestore);
            this.Controls.Add(this.cmdBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Backup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup and Restore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Backup_FormClosing);
            this.Load += new System.EventHandler(this.Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog DlgSave;
        private System.Windows.Forms.Button cmdBackup;
        private System.Windows.Forms.ProgressBar BackupProgress;
        private System.Windows.Forms.ProgressBar RestoreProgress;
        private System.Windows.Forms.Button cmdRestore;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Label lbRestore;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Label lbBackup;
        private System.Windows.Forms.OpenFileDialog DlgOpen;
        private System.Windows.Forms.Button cmdClose;
    }
}