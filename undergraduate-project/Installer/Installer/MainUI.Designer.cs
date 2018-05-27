namespace Installer
{
    partial class MainUI
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
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pfirst = new System.Windows.Forms.Panel();
            this.lbdesserver = new System.Windows.Forms.Label();
            this.lbClient = new System.Windows.Forms.Label();
            this.lbInspath = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lbdes = new System.Windows.Forms.Label();
            this.OptServer = new System.Windows.Forms.RadioButton();
            this.optClinet = new System.Windows.Forms.RadioButton();
            this.pClient = new System.Windows.Forms.Panel();
            this.lbclientunfo = new System.Windows.Forms.Label();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.txtpasswd = new System.Windows.Forms.TextBox();
            this.txtuid = new System.Windows.Forms.TextBox();
            this.lbinfoclient = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lbDB = new System.Windows.Forms.Label();
            this.lbpassword = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.cmdCNext = new System.Windows.Forms.Button();
            this.cmdCCancel = new System.Windows.Forms.Button();
            this.cmdCBack = new System.Windows.Forms.Button();
            this.pfinish = new System.Windows.Forms.Panel();
            this.prgInstall = new System.Windows.Forms.ProgressBar();
            this.cmdFinish = new System.Windows.Forms.Button();
            this.cmdFCancel = new System.Windows.Forms.Button();
            this.lbfinish = new System.Windows.Forms.Label();
            this.cmdFBack = new System.Windows.Forms.Button();
            this.pServer = new System.Windows.Forms.Panel();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkCreateDB = new System.Windows.Forms.CheckBox();
            this.cmbSDB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpw = new System.Windows.Forms.TextBox();
            this.txtSUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSNext = new System.Windows.Forms.Button();
            this.cmdSCancel = new System.Windows.Forms.Button();
            this.cmdSBack = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.WaitforExit = new System.Windows.Forms.Timer(this.components);
            this.pfirst.SuspendLayout();
            this.pClient.SuspendLayout();
            this.pfinish.SuspendLayout();
            this.pServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(244, 178);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 2;
            this.cmdNext.Text = "Next";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(325, 178);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pfirst
            // 
            this.pfirst.Controls.Add(this.lbdesserver);
            this.pfirst.Controls.Add(this.lbClient);
            this.pfirst.Controls.Add(this.lbInspath);
            this.pfirst.Controls.Add(this.lbWelcome);
            this.pfirst.Controls.Add(this.cmdBrowse);
            this.pfirst.Controls.Add(this.txtPath);
            this.pfirst.Controls.Add(this.lbdes);
            this.pfirst.Controls.Add(this.OptServer);
            this.pfirst.Controls.Add(this.optClinet);
            this.pfirst.Controls.Add(this.cmdNext);
            this.pfirst.Controls.Add(this.cmdCancel);
            this.pfirst.Location = new System.Drawing.Point(4, 43);
            this.pfirst.Name = "pfirst";
            this.pfirst.Size = new System.Drawing.Size(415, 214);
            this.pfirst.TabIndex = 4;
            // 
            // lbdesserver
            // 
            this.lbdesserver.AutoSize = true;
            this.lbdesserver.Location = new System.Drawing.Point(28, 152);
            this.lbdesserver.Name = "lbdesserver";
            this.lbdesserver.Size = new System.Drawing.Size(372, 13);
            this.lbdesserver.TabIndex = 9;
            this.lbdesserver.Text = "Install program files and database files, Mysql server running on this computer ";
            // 
            // lbClient
            // 
            this.lbClient.Location = new System.Drawing.Point(26, 103);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(366, 30);
            this.lbClient.TabIndex = 8;
            this.lbClient.Text = "Install program files only, will connect to existing database server running on a" +
                "nother computer ";
            // 
            // lbInspath
            // 
            this.lbInspath.AutoSize = true;
            this.lbInspath.Location = new System.Drawing.Point(7, 23);
            this.lbInspath.Name = "lbInspath";
            this.lbInspath.Size = new System.Drawing.Size(100, 13);
            this.lbInspath.TabIndex = 7;
            this.lbInspath.Text = "Installation location ";
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(8, 0);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(276, 13);
            this.lbWelcome.TabIndex = 6;
            this.lbWelcome.Text = "Welcome to the Stock Control and Billing System Installer";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(325, 42);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(67, 23);
            this.cmdBrowse.TabIndex = 5;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(8, 42);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(311, 20);
            this.txtPath.TabIndex = 4;
            // 
            // lbdes
            // 
            this.lbdes.AutoSize = true;
            this.lbdes.Location = new System.Drawing.Point(7, 72);
            this.lbdes.Name = "lbdes";
            this.lbdes.Size = new System.Drawing.Size(228, 13);
            this.lbdes.TabIndex = 1;
            this.lbdes.Text = "This computer will be (Choose one of following)";
            // 
            // OptServer
            // 
            this.OptServer.AutoSize = true;
            this.OptServer.Location = new System.Drawing.Point(10, 132);
            this.OptServer.Name = "OptServer";
            this.OptServer.Size = new System.Drawing.Size(56, 17);
            this.OptServer.TabIndex = 0;
            this.OptServer.TabStop = true;
            this.OptServer.Text = "Server";
            this.OptServer.UseVisualStyleBackColor = true;
            // 
            // optClinet
            // 
            this.optClinet.AutoSize = true;
            this.optClinet.Location = new System.Drawing.Point(10, 87);
            this.optClinet.Name = "optClinet";
            this.optClinet.Size = new System.Drawing.Size(51, 17);
            this.optClinet.TabIndex = 0;
            this.optClinet.TabStop = true;
            this.optClinet.Text = "Client";
            this.optClinet.UseVisualStyleBackColor = true;
            // 
            // pClient
            // 
            this.pClient.Controls.Add(this.lbclientunfo);
            this.pClient.Controls.Add(this.cmbDB);
            this.pClient.Controls.Add(this.txtpasswd);
            this.pClient.Controls.Add(this.txtuid);
            this.pClient.Controls.Add(this.lbinfoclient);
            this.pClient.Controls.Add(this.txtServer);
            this.pClient.Controls.Add(this.lbDB);
            this.pClient.Controls.Add(this.lbpassword);
            this.pClient.Controls.Add(this.lbuser);
            this.pClient.Controls.Add(this.lbServer);
            this.pClient.Controls.Add(this.cmdCNext);
            this.pClient.Controls.Add(this.cmdCCancel);
            this.pClient.Controls.Add(this.cmdCBack);
            this.pClient.Location = new System.Drawing.Point(4, 275);
            this.pClient.Name = "pClient";
            this.pClient.Size = new System.Drawing.Size(415, 214);
            this.pClient.TabIndex = 4;
            // 
            // lbclientunfo
            // 
            this.lbclientunfo.Location = new System.Drawing.Point(258, 39);
            this.lbclientunfo.Name = "lbclientunfo";
            this.lbclientunfo.Size = new System.Drawing.Size(142, 49);
            this.lbclientunfo.TabIndex = 16;
            this.lbclientunfo.Text = "Please enter all fields. After completing the form, click \'Next\' to Continue.";
            // 
            // cmbDB
            // 
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(115, 134);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(121, 21);
            this.cmbDB.TabIndex = 15;
            this.cmbDB.Enter += new System.EventHandler(this.cmbDB_Enter);
            this.cmbDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDB_KeyDown);
            // 
            // txtpasswd
            // 
            this.txtpasswd.Location = new System.Drawing.Point(115, 101);
            this.txtpasswd.Name = "txtpasswd";
            this.txtpasswd.PasswordChar = '*';
            this.txtpasswd.Size = new System.Drawing.Size(121, 20);
            this.txtpasswd.TabIndex = 14;
            this.txtpasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpasswd_KeyDown);
            // 
            // txtuid
            // 
            this.txtuid.Location = new System.Drawing.Point(115, 69);
            this.txtuid.Name = "txtuid";
            this.txtuid.Size = new System.Drawing.Size(121, 20);
            this.txtuid.TabIndex = 13;
            this.txtuid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtuid_KeyDown);
            // 
            // lbinfoclient
            // 
            this.lbinfoclient.AutoSize = true;
            this.lbinfoclient.Location = new System.Drawing.Point(8, 13);
            this.lbinfoclient.Name = "lbinfoclient";
            this.lbinfoclient.Size = new System.Drawing.Size(217, 13);
            this.lbinfoclient.TabIndex = 6;
            this.lbinfoclient.Text = "Please enter the database server information";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(115, 39);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(121, 20);
            this.txtServer.TabIndex = 12;
            this.txtServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServer_KeyDown);
            // 
            // lbDB
            // 
            this.lbDB.AutoSize = true;
            this.lbDB.Location = new System.Drawing.Point(36, 138);
            this.lbDB.Name = "lbDB";
            this.lbDB.Size = new System.Drawing.Size(56, 13);
            this.lbDB.TabIndex = 11;
            this.lbDB.Text = "Database:";
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.Location = new System.Drawing.Point(36, 104);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(53, 13);
            this.lbpassword.TabIndex = 10;
            this.lbpassword.Text = "Password";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(36, 72);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(32, 13);
            this.lbuser.TabIndex = 9;
            this.lbuser.Text = "User:";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(36, 42);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(58, 13);
            this.lbServer.TabIndex = 8;
            this.lbServer.Text = "My Server:";
            // 
            // cmdCNext
            // 
            this.cmdCNext.Location = new System.Drawing.Point(244, 178);
            this.cmdCNext.Name = "cmdCNext";
            this.cmdCNext.Size = new System.Drawing.Size(75, 23);
            this.cmdCNext.TabIndex = 2;
            this.cmdCNext.Text = "Next";
            this.cmdCNext.UseVisualStyleBackColor = true;
            this.cmdCNext.Click += new System.EventHandler(this.cmdCNext_Click);
            // 
            // cmdCCancel
            // 
            this.cmdCCancel.Location = new System.Drawing.Point(325, 178);
            this.cmdCCancel.Name = "cmdCCancel";
            this.cmdCCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCCancel.TabIndex = 3;
            this.cmdCCancel.Text = "Cancel";
            this.cmdCCancel.UseVisualStyleBackColor = true;
            this.cmdCCancel.Click += new System.EventHandler(this.cmdCCancel_Click);
            // 
            // cmdCBack
            // 
            this.cmdCBack.Location = new System.Drawing.Point(163, 178);
            this.cmdCBack.Name = "cmdCBack";
            this.cmdCBack.Size = new System.Drawing.Size(75, 23);
            this.cmdCBack.TabIndex = 1;
            this.cmdCBack.Text = "Back";
            this.cmdCBack.UseVisualStyleBackColor = true;
            this.cmdCBack.Click += new System.EventHandler(this.cmdCBack_Click);
            // 
            // pfinish
            // 
            this.pfinish.Controls.Add(this.prgInstall);
            this.pfinish.Controls.Add(this.cmdFinish);
            this.pfinish.Controls.Add(this.cmdFCancel);
            this.pfinish.Controls.Add(this.lbfinish);
            this.pfinish.Controls.Add(this.cmdFBack);
            this.pfinish.Location = new System.Drawing.Point(438, 275);
            this.pfinish.Name = "pfinish";
            this.pfinish.Size = new System.Drawing.Size(415, 214);
            this.pfinish.TabIndex = 4;
            // 
            // prgInstall
            // 
            this.prgInstall.Location = new System.Drawing.Point(21, 60);
            this.prgInstall.Name = "prgInstall";
            this.prgInstall.Size = new System.Drawing.Size(379, 23);
            this.prgInstall.TabIndex = 4;
            // 
            // cmdFinish
            // 
            this.cmdFinish.Location = new System.Drawing.Point(244, 178);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(75, 23);
            this.cmdFinish.TabIndex = 2;
            this.cmdFinish.Text = "Install";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // cmdFCancel
            // 
            this.cmdFCancel.Location = new System.Drawing.Point(325, 178);
            this.cmdFCancel.Name = "cmdFCancel";
            this.cmdFCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdFCancel.TabIndex = 3;
            this.cmdFCancel.Text = "Cancel";
            this.cmdFCancel.UseVisualStyleBackColor = true;
            this.cmdFCancel.Click += new System.EventHandler(this.cmdFCancel_Click);
            // 
            // lbfinish
            // 
            this.lbfinish.AutoSize = true;
            this.lbfinish.Location = new System.Drawing.Point(18, 30);
            this.lbfinish.Name = "lbfinish";
            this.lbfinish.Size = new System.Drawing.Size(120, 13);
            this.lbfinish.TabIndex = 6;
            this.lbfinish.Text = "Click \'Install\' to continue";
            // 
            // cmdFBack
            // 
            this.cmdFBack.Enabled = false;
            this.cmdFBack.Location = new System.Drawing.Point(163, 178);
            this.cmdFBack.Name = "cmdFBack";
            this.cmdFBack.Size = new System.Drawing.Size(75, 23);
            this.cmdFBack.TabIndex = 1;
            this.cmdFBack.Text = "Back";
            this.cmdFBack.UseVisualStyleBackColor = true;
            // 
            // pServer
            // 
            this.pServer.Controls.Add(this.chkSample);
            this.pServer.Controls.Add(this.chkCreateDB);
            this.pServer.Controls.Add(this.cmbSDB);
            this.pServer.Controls.Add(this.label5);
            this.pServer.Controls.Add(this.txtSpw);
            this.pServer.Controls.Add(this.txtSUser);
            this.pServer.Controls.Add(this.label1);
            this.pServer.Controls.Add(this.label2);
            this.pServer.Controls.Add(this.label3);
            this.pServer.Controls.Add(this.cmdSNext);
            this.pServer.Controls.Add(this.cmdSCancel);
            this.pServer.Controls.Add(this.cmdSBack);
            this.pServer.Location = new System.Drawing.Point(438, 43);
            this.pServer.Name = "pServer";
            this.pServer.Size = new System.Drawing.Size(415, 214);
            this.pServer.TabIndex = 4;
            // 
            // chkSample
            // 
            this.chkSample.AutoSize = true;
            this.chkSample.Location = new System.Drawing.Point(266, 142);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(97, 17);
            this.chkSample.TabIndex = 23;
            this.chkSample.Text = "Install test data";
            this.chkSample.UseVisualStyleBackColor = true;
            this.chkSample.Visible = false;
            // 
            // chkCreateDB
            // 
            this.chkCreateDB.AutoSize = true;
            this.chkCreateDB.Location = new System.Drawing.Point(154, 142);
            this.chkCreateDB.Name = "chkCreateDB";
            this.chkCreateDB.Size = new System.Drawing.Size(106, 17);
            this.chkCreateDB.TabIndex = 22;
            this.chkCreateDB.Text = "Create Database";
            this.chkCreateDB.UseVisualStyleBackColor = true;
            this.chkCreateDB.CheckedChanged += new System.EventHandler(this.chkCreateDB_CheckedChanged);
            // 
            // cmbSDB
            // 
            this.cmbSDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSDB.FormattingEnabled = true;
            this.cmbSDB.Location = new System.Drawing.Point(154, 105);
            this.cmbSDB.Name = "cmbSDB";
            this.cmbSDB.Size = new System.Drawing.Size(121, 21);
            this.cmbSDB.TabIndex = 21;
            this.cmbSDB.Enter += new System.EventHandler(this.cmbSDB_Enter);
            this.cmbSDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSDB_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Please enter the database server information";
            // 
            // txtSpw
            // 
            this.txtSpw.Location = new System.Drawing.Point(154, 72);
            this.txtSpw.Name = "txtSpw";
            this.txtSpw.PasswordChar = '*';
            this.txtSpw.Size = new System.Drawing.Size(121, 20);
            this.txtSpw.TabIndex = 20;
            this.txtSpw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpw_KeyDown);
            // 
            // txtSUser
            // 
            this.txtSUser.Location = new System.Drawing.Point(154, 39);
            this.txtSUser.Name = "txtSUser";
            this.txtSUser.Size = new System.Drawing.Size(121, 20);
            this.txtSUser.TabIndex = 19;
            this.txtSUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSUser_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "User:";
            // 
            // cmdSNext
            // 
            this.cmdSNext.Location = new System.Drawing.Point(244, 178);
            this.cmdSNext.Name = "cmdSNext";
            this.cmdSNext.Size = new System.Drawing.Size(75, 23);
            this.cmdSNext.TabIndex = 2;
            this.cmdSNext.Text = "Next";
            this.cmdSNext.UseVisualStyleBackColor = true;
            this.cmdSNext.Click += new System.EventHandler(this.cmdSNext_Click);
            // 
            // cmdSCancel
            // 
            this.cmdSCancel.Location = new System.Drawing.Point(325, 178);
            this.cmdSCancel.Name = "cmdSCancel";
            this.cmdSCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdSCancel.TabIndex = 3;
            this.cmdSCancel.Text = "Cancel";
            this.cmdSCancel.UseVisualStyleBackColor = true;
            this.cmdSCancel.Click += new System.EventHandler(this.cmdSCancel_Click);
            // 
            // cmdSBack
            // 
            this.cmdSBack.Location = new System.Drawing.Point(163, 178);
            this.cmdSBack.Name = "cmdSBack";
            this.cmdSBack.Size = new System.Drawing.Size(75, 23);
            this.cmdSBack.TabIndex = 1;
            this.cmdSBack.Text = "Back";
            this.cmdSBack.UseVisualStyleBackColor = true;
            this.cmdSBack.Click += new System.EventHandler(this.cmdSBack_Click);
            // 
            // WaitforExit
            // 
            this.WaitforExit.Interval = 1000;
            this.WaitforExit.Tick += new System.EventHandler(this.WaitforExit_Tick);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Installer.Properties.Resources.headerBar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(425, 266);
            this.Controls.Add(this.pServer);
            this.Controls.Add(this.pfinish);
            this.Controls.Add(this.pClient);
            this.Controls.Add(this.pfirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Control and Billing System Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.pfirst.ResumeLayout(false);
            this.pfirst.PerformLayout();
            this.pClient.ResumeLayout(false);
            this.pClient.PerformLayout();
            this.pfinish.ResumeLayout(false);
            this.pfinish.PerformLayout();
            this.pServer.ResumeLayout(false);
            this.pServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel pfirst;
        private System.Windows.Forms.RadioButton OptServer;
        private System.Windows.Forms.RadioButton optClinet;
        private System.Windows.Forms.Label lbdes;
        private System.Windows.Forms.Panel pClient;
        private System.Windows.Forms.Button cmdCNext;
        private System.Windows.Forms.Button cmdCCancel;
        private System.Windows.Forms.Button cmdCBack;
        private System.Windows.Forms.Panel pfinish;
        private System.Windows.Forms.Button cmdFinish;
        private System.Windows.Forms.Button cmdFCancel;
        private System.Windows.Forms.Button cmdFBack;
        private System.Windows.Forms.Panel pServer;
        private System.Windows.Forms.Button cmdSNext;
        private System.Windows.Forms.Button cmdSCancel;
        private System.Windows.Forms.Button cmdSBack;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.TextBox txtpasswd;
        private System.Windows.Forms.TextBox txtuid;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lbDB;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.ComboBox cmbSDB;
        private System.Windows.Forms.TextBox txtSpw;
        private System.Windows.Forms.TextBox txtSUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCreateDB;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.ProgressBar prgInstall;
        private System.Windows.Forms.Timer WaitforExit;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Label lbInspath;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.Label lbdesserver;
        private System.Windows.Forms.Label lbinfoclient;
        private System.Windows.Forms.Label lbfinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbclientunfo;

    }
}

