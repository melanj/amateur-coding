namespace StockControl
{
    partial class Suppliers
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
            this.cmdAdd = new System.Windows.Forms.Button();
            this.grpSupplier = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbemail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lstSuppliers = new System.Windows.Forms.ListView();
            this.ColID = new System.Windows.Forms.ColumnHeader();
            this.ColName = new System.Windows.Forms.ColumnHeader();
            this.ColAddress = new System.Windows.Forms.ColumnHeader();
            this.ColPhone = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.ColDescription = new System.Windows.Forms.ColumnHeader();
            this.chkfilter = new System.Windows.Forms.CheckBox();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkAddress = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.txtfltEmail = new System.Windows.Forms.TextBox();
            this.txtfltPhone = new System.Windows.Forms.TextBox();
            this.txtfltAddress = new System.Windows.Forms.TextBox();
            this.txtfltCode = new System.Windows.Forms.TextBox();
            this.txtfltName = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.grpSupplier.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Image = global::StockControl.Properties.Resources.add_icon16;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(16, 350);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(65, 25);
            this.cmdAdd.TabIndex = 18;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // grpSupplier
            // 
            this.grpSupplier.Controls.Add(this.txtDescription);
            this.grpSupplier.Controls.Add(this.lbDescription);
            this.grpSupplier.Controls.Add(this.txtID);
            this.grpSupplier.Controls.Add(this.lbID);
            this.grpSupplier.Controls.Add(this.txtEmail);
            this.grpSupplier.Controls.Add(this.lbemail);
            this.grpSupplier.Controls.Add(this.txtPhone);
            this.grpSupplier.Controls.Add(this.lbPhone);
            this.grpSupplier.Controls.Add(this.txtAddress);
            this.grpSupplier.Controls.Add(this.lbAddress);
            this.grpSupplier.Controls.Add(this.txtName);
            this.grpSupplier.Controls.Add(this.lbName);
            this.grpSupplier.Controls.Add(this.cmdUpdate);
            this.grpSupplier.Enabled = false;
            this.grpSupplier.Location = new System.Drawing.Point(15, 379);
            this.grpSupplier.Name = "grpSupplier";
            this.grpSupplier.Size = new System.Drawing.Size(748, 190);
            this.grpSupplier.TabIndex = 16;
            this.grpSupplier.TabStop = false;
            this.grpSupplier.Text = "Supplier details";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(417, 22);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(314, 93);
            this.txtDescription.TabIndex = 33;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(353, 26);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 32;
            this.lbDescription.Text = "Description";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(80, 19);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 31;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(16, 25);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 30;
            this.lbID.Text = "ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(80, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(142, 20);
            this.txtEmail.TabIndex = 29;
            this.txtEmail.Tag = "email,Required a valid e-mail address";
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Location = new System.Drawing.Point(16, 151);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(35, 13);
            this.lbemail.TabIndex = 28;
            this.lbemail.Text = "E-mail";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(80, 115);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 27;
            this.txtPhone.Tag = "phone,Required a valid phone number";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(16, 119);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(38, 13);
            this.lbPhone.TabIndex = 26;
            this.lbPhone.Text = "Phone";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(80, 83);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(259, 20);
            this.txtAddress.TabIndex = 25;
            this.txtAddress.Tag = "text,Required a valid postal address";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(16, 87);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(45, 13);
            this.lbAddress.TabIndex = 24;
            this.lbAddress.Text = "Address";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 51);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(255, 20);
            this.txtName.TabIndex = 23;
            this.txtName.Tag = "text";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(16, 55);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 22;
            this.lbName.Text = "Name";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Image = global::StockControl.Properties.Resources.process_accept_icon;
            this.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdate.Location = new System.Drawing.Point(666, 146);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(65, 26);
            this.cmdUpdate.TabIndex = 18;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(771, 532);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 25);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstSuppliers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColID,
            this.ColName,
            this.ColAddress,
            this.ColPhone,
            this.colEmail,
            this.ColDescription});
            this.lstSuppliers.FullRowSelect = true;
            this.lstSuppliers.GridLines = true;
            this.lstSuppliers.Location = new System.Drawing.Point(15, 36);
            this.lstSuppliers.MultiSelect = false;
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(821, 302);
            this.lstSuppliers.TabIndex = 9;
            this.lstSuppliers.UseCompatibleStateImageBehavior = false;
            this.lstSuppliers.View = System.Windows.Forms.View.Details;
            this.lstSuppliers.SelectedIndexChanged += new System.EventHandler(this.lstSuppliers_SelectedIndexChanged);
            // 
            // ColID
            // 
            this.ColID.Text = "ID";
            this.ColID.Width = 56;
            // 
            // ColName
            // 
            this.ColName.Text = "Name";
            this.ColName.Width = 152;
            // 
            // ColAddress
            // 
            this.ColAddress.Text = "Address";
            this.ColAddress.Width = 189;
            // 
            // ColPhone
            // 
            this.ColPhone.Text = "Phone";
            this.ColPhone.Width = 81;
            // 
            // colEmail
            // 
            this.colEmail.Text = "E-mail";
            this.colEmail.Width = 78;
            // 
            // ColDescription
            // 
            this.ColDescription.Text = "Description";
            this.ColDescription.Width = 186;
            // 
            // chkfilter
            // 
            this.chkfilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkfilter.Image = global::StockControl.Properties.Resources.search_add_icon16;
            this.chkfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkfilter.Location = new System.Drawing.Point(741, 7);
            this.chkfilter.Name = "chkfilter";
            this.chkfilter.Size = new System.Drawing.Size(92, 23);
            this.chkfilter.TabIndex = 23;
            this.chkfilter.Text = "Show Filters ";
            this.chkfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkfilter.UseVisualStyleBackColor = true;
            this.chkfilter.CheckedChanged += new System.EventHandler(this.chkfilter_CheckedChanged);
            // 
            // pnlfilter
            // 
            this.pnlfilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlfilter.Controls.Add(this.chkCode);
            this.pnlfilter.Controls.Add(this.chkEmail);
            this.pnlfilter.Controls.Add(this.chkPhone);
            this.pnlfilter.Controls.Add(this.chkAddress);
            this.pnlfilter.Controls.Add(this.chkName);
            this.pnlfilter.Controls.Add(this.txtfltEmail);
            this.pnlfilter.Controls.Add(this.txtfltPhone);
            this.pnlfilter.Controls.Add(this.txtfltAddress);
            this.pnlfilter.Controls.Add(this.txtfltCode);
            this.pnlfilter.Controls.Add(this.txtfltName);
            this.pnlfilter.Controls.Add(this.cmdSearch);
            this.pnlfilter.Location = new System.Drawing.Point(433, 30);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(400, 198);
            this.pnlfilter.TabIndex = 22;
            this.pnlfilter.Visible = false;
            this.pnlfilter.Leave += new System.EventHandler(this.pnlfilter_Leave);
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(18, 41);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(37, 17);
            this.chkCode.TabIndex = 19;
            this.chkCode.Text = "ID";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.CheckedChanged += new System.EventHandler(this.chkCode_CheckedChanged);
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(18, 164);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(54, 17);
            this.chkEmail.TabIndex = 19;
            this.chkEmail.Text = "E-mail";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(18, 133);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 19;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            this.chkPhone.CheckedChanged += new System.EventHandler(this.chkPhone_CheckedChanged);
            // 
            // chkAddress
            // 
            this.chkAddress.AutoSize = true;
            this.chkAddress.Location = new System.Drawing.Point(18, 100);
            this.chkAddress.Name = "chkAddress";
            this.chkAddress.Size = new System.Drawing.Size(64, 17);
            this.chkAddress.TabIndex = 19;
            this.chkAddress.Text = "Address";
            this.chkAddress.UseVisualStyleBackColor = true;
            this.chkAddress.CheckedChanged += new System.EventHandler(this.chkAddress_CheckedChanged);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(18, 69);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(54, 17);
            this.chkName.TabIndex = 19;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // txtfltEmail
            // 
            this.txtfltEmail.Enabled = false;
            this.txtfltEmail.Location = new System.Drawing.Point(84, 162);
            this.txtfltEmail.Name = "txtfltEmail";
            this.txtfltEmail.Size = new System.Drawing.Size(210, 20);
            this.txtfltEmail.TabIndex = 18;
            this.txtfltEmail.Tag = "email";
            // 
            // txtfltPhone
            // 
            this.txtfltPhone.Enabled = false;
            this.txtfltPhone.Location = new System.Drawing.Point(84, 130);
            this.txtfltPhone.Name = "txtfltPhone";
            this.txtfltPhone.Size = new System.Drawing.Size(210, 20);
            this.txtfltPhone.TabIndex = 16;
            this.txtfltPhone.Tag = "phone";
            // 
            // txtfltAddress
            // 
            this.txtfltAddress.Enabled = false;
            this.txtfltAddress.Location = new System.Drawing.Point(84, 98);
            this.txtfltAddress.Name = "txtfltAddress";
            this.txtfltAddress.Size = new System.Drawing.Size(210, 20);
            this.txtfltAddress.TabIndex = 14;
            this.txtfltAddress.Tag = "text";
            // 
            // txtfltCode
            // 
            this.txtfltCode.Enabled = false;
            this.txtfltCode.Location = new System.Drawing.Point(84, 38);
            this.txtfltCode.Name = "txtfltCode";
            this.txtfltCode.Size = new System.Drawing.Size(210, 20);
            this.txtfltCode.TabIndex = 12;
            this.txtfltCode.Tag = "text";
            this.txtfltCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtfltCode_Validating);
            // 
            // txtfltName
            // 
            this.txtfltName.Enabled = false;
            this.txtfltName.Location = new System.Drawing.Point(84, 66);
            this.txtfltName.Name = "txtfltName";
            this.txtfltName.Size = new System.Drawing.Size(210, 20);
            this.txtfltName.TabIndex = 12;
            this.txtfltName.Tag = "text";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::StockControl.Properties.Resources.search_icon16;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(313, 155);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(65, 26);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdShowAll
            // 
            this.cmdShowAll.Image = global::StockControl.Properties.Resources.process_accept_icon;
            this.cmdShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShowAll.Location = new System.Drawing.Point(661, 7);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(74, 23);
            this.cmdShowAll.TabIndex = 27;
            this.cmdShowAll.Text = "Show All";
            this.cmdShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdShowAll.UseVisualStyleBackColor = true;
            this.cmdShowAll.Click += new System.EventHandler(this.cmdShowAll_Click);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.White;
            this.pHeader.BackgroundImage = global::StockControl.Properties.Resources.headerBar;
            this.pHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pHeader.Location = new System.Drawing.Point(0, -2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(845, 32);
            this.pHeader.TabIndex = 35;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(95, 350);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(74, 25);
            this.cmdRemove.TabIndex = 36;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 586);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.chkfilter);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.grpSupplier);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lstSuppliers);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Suppliers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View and Manage  Supplier Profiles";
            this.Load += new System.EventHandler(this.Suppliers_Load);
            this.grpSupplier.ResumeLayout(false);
            this.grpSupplier.PerformLayout();
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.GroupBox grpSupplier;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.ListView lstSuppliers;
        internal System.Windows.Forms.ColumnHeader ColID;
        internal System.Windows.Forms.ColumnHeader ColName;
        internal System.Windows.Forms.ColumnHeader ColAddress;
        internal System.Windows.Forms.ColumnHeader ColPhone;
        internal System.Windows.Forms.ColumnHeader ColDescription;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.CheckBox chkfilter;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkAddress;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.TextBox txtfltEmail;
        private System.Windows.Forms.TextBox txtfltPhone;
        private System.Windows.Forms.TextBox txtfltAddress;
        private System.Windows.Forms.TextBox txtfltCode;
        private System.Windows.Forms.TextBox txtfltName;
        internal System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdShowAll;
        private System.Windows.Forms.Panel pHeader;
        internal System.Windows.Forms.Button cmdRemove;
    }
}