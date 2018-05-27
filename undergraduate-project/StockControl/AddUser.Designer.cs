namespace StockControl
{
    partial class AddUser
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.cmdCategory = new System.Windows.Forms.ComboBox();
            this.txtRePasswd = new System.Windows.Forms.TextBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbRePasswd = new System.Windows.Forms.Label();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(219, 45);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(65, 25);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(219, 9);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(65, 25);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(84, 44);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(122, 20);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Tag = "text,You must enter  user\'s full name";
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Location = new System.Drawing.Point(10, 50);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(54, 13);
            this.lbFullName.TabIndex = 29;
            this.lbFullName.Text = "Full Name";
            // 
            // cmdCategory
            // 
            this.cmdCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdCategory.FormattingEnabled = true;
            this.cmdCategory.Items.AddRange(new object[] {
            "Administrator",
            "Manager",
            "General"});
            this.cmdCategory.Location = new System.Drawing.Point(84, 140);
            this.cmdCategory.Name = "cmdCategory";
            this.cmdCategory.Size = new System.Drawing.Size(122, 21);
            this.cmdCategory.TabIndex = 4;
            this.cmdCategory.Tag = "text,You must select a Category";
            // 
            // txtRePasswd
            // 
            this.txtRePasswd.Location = new System.Drawing.Point(84, 108);
            this.txtRePasswd.Name = "txtRePasswd";
            this.txtRePasswd.PasswordChar = '*';
            this.txtRePasswd.Size = new System.Drawing.Size(122, 20);
            this.txtRePasswd.TabIndex = 3;
            this.txtRePasswd.Tag = "text,You must enter confirm password";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(84, 76);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(122, 20);
            this.txtPasswd.TabIndex = 2;
            this.txtPasswd.Tag = "text,Cannot have a blank password";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(10, 144);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 25;
            this.lbCategory.Text = "Category";
            // 
            // lbRePasswd
            // 
            this.lbRePasswd.AutoSize = true;
            this.lbRePasswd.Location = new System.Drawing.Point(10, 112);
            this.lbRePasswd.Name = "lbRePasswd";
            this.lbRePasswd.Size = new System.Drawing.Size(42, 13);
            this.lbRePasswd.TabIndex = 24;
            this.lbRePasswd.Text = "Confirm";
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Location = new System.Drawing.Point(10, 80);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(53, 13);
            this.lbPasswd.TabIndex = 23;
            this.lbPasswd.Text = "Password";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(10, 16);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(60, 13);
            this.lbUserID.TabIndex = 22;
            this.lbUserID.Text = "User Name";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(84, 12);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(122, 20);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.Tag = "text,You must specify a user name";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 180);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.cmdCategory);
            this.Controls.Add(this.txtRePasswd);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.lbRePasswd);
            this.Controls.Add(this.lbPasswd);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.txtUserID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.TextBox txtFullName;
        internal System.Windows.Forms.Label lbFullName;
        internal System.Windows.Forms.ComboBox cmdCategory;
        internal System.Windows.Forms.TextBox txtRePasswd;
        internal System.Windows.Forms.TextBox txtPasswd;
        internal System.Windows.Forms.Label lbCategory;
        internal System.Windows.Forms.Label lbRePasswd;
        internal System.Windows.Forms.Label lbPasswd;
        internal System.Windows.Forms.Label lbUserID;
        internal System.Windows.Forms.MaskedTextBox txtUserID;
    }
}