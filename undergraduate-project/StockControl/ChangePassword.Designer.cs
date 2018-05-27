namespace StockControl
{
    partial class ChangePassword
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
            this.txtRePasswd = new System.Windows.Forms.TextBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lbRePasswd = new System.Windows.Forms.Label();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRePasswd
            // 
            this.txtRePasswd.Location = new System.Drawing.Point(106, 49);
            this.txtRePasswd.Name = "txtRePasswd";
            this.txtRePasswd.PasswordChar = '*';
            this.txtRePasswd.Size = new System.Drawing.Size(136, 20);
            this.txtRePasswd.TabIndex = 1;
            this.txtRePasswd.Tag = "text,You must enter confirm password";
            this.txtRePasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRePasswd_KeyPress);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(106, 17);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(136, 20);
            this.txtPasswd.TabIndex = 0;
            this.txtPasswd.Tag = "text,Cannot have a blank password";
            this.txtPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPasswd_KeyPress);
            // 
            // lbRePasswd
            // 
            this.lbRePasswd.AutoSize = true;
            this.lbRePasswd.Location = new System.Drawing.Point(12, 52);
            this.lbRePasswd.Name = "lbRePasswd";
            this.lbRePasswd.Size = new System.Drawing.Size(91, 13);
            this.lbRePasswd.TabIndex = 29;
            this.lbRePasswd.Text = "Confirm Password";
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Location = new System.Drawing.Point(12, 20);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(78, 13);
            this.lbPasswd.TabIndex = 28;
            this.lbPasswd.Text = "New Password";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(175, 92);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(67, 23);
            this.cmdCancel.TabIndex = 33;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(102, 92);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(67, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 127);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtRePasswd);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.lbRePasswd);
            this.Controls.Add(this.lbPasswd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtRePasswd;
        internal System.Windows.Forms.TextBox txtPasswd;
        internal System.Windows.Forms.Label lbRePasswd;
        internal System.Windows.Forms.Label lbPasswd;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
    }
}