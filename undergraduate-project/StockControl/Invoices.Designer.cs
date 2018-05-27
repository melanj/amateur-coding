namespace StockControl
{
    partial class Invoices
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
            this.ColAmount = new System.Windows.Forms.ColumnHeader();
            this.ColUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.ColQuantity = new System.Windows.Forms.ColumnHeader();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lbItems = new System.Windows.Forms.Label();
            this.ColCustomerName = new System.Windows.Forms.ColumnHeader();
            this.ColDate = new System.Windows.Forms.ColumnHeader();
            this.ColIsCredit = new System.Windows.Forms.ColumnHeader();
            this.lstInvoices = new System.Windows.Forms.ListView();
            this.ColInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.ColCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.ColPaid = new System.Windows.Forms.ColumnHeader();
            this.ColValue = new System.Windows.Forms.ColumnHeader();
            this.ColItemNo = new System.Windows.Forms.ColumnHeader();
            this.ColDescription = new System.Windows.Forms.ColumnHeader();
            this.lstItems = new System.Windows.Forms.ListView();
            this.chkfilter = new System.Windows.Forms.CheckBox();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.lbto = new System.Windows.Forms.Label();
            this.dteTo = new System.Windows.Forms.DateTimePicker();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbPaid = new System.Windows.Forms.ComboBox();
            this.cmbCredit = new System.Windows.Forms.ComboBox();
            this.cmbfltCustomer = new System.Windows.Forms.ComboBox();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkPaid = new System.Windows.Forms.CheckBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.txtfltCode = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColAmount
            // 
            this.ColAmount.Text = "Amount";
            this.ColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColAmount.Width = 73;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 78;
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            this.ColQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQuantity.Width = 57;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(593, 468);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 26);
            this.cmdClose.TabIndex = 26;
            this.cmdClose.Text = "Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lbItems
            // 
            this.lbItems.AutoSize = true;
            this.lbItems.Location = new System.Drawing.Point(12, 311);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(160, 13);
            this.lbItems.TabIndex = 25;
            this.lbItems.Text = "Items included in Current invoice";
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.Text = "Customer Name";
            this.ColCustomerName.Width = 155;
            // 
            // ColDate
            // 
            this.ColDate.Text = "Date";
            this.ColDate.Width = 101;
            // 
            // ColIsCredit
            // 
            this.ColIsCredit.Text = "Is Credit";
            this.ColIsCredit.Width = 77;
            // 
            // lstInvoices
            // 
            this.lstInvoices.AllowColumnReorder = true;
            this.lstInvoices.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColInvoiceNo,
            this.ColCustomerCode,
            this.ColCustomerName,
            this.ColDate,
            this.ColIsCredit,
            this.ColPaid,
            this.ColValue});
            this.lstInvoices.FullRowSelect = true;
            this.lstInvoices.GridLines = true;
            this.lstInvoices.Location = new System.Drawing.Point(12, 33);
            this.lstInvoices.MultiSelect = false;
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(646, 269);
            this.lstInvoices.TabIndex = 23;
            this.lstInvoices.UseCompatibleStateImageBehavior = false;
            this.lstInvoices.View = System.Windows.Forms.View.Details;
            this.lstInvoices.SelectedIndexChanged += new System.EventHandler(this.lstInvoices_SelectedIndexChanged);
            // 
            // ColInvoiceNo
            // 
            this.ColInvoiceNo.Text = "Invoice No";
            this.ColInvoiceNo.Width = 73;
            // 
            // ColCustomerCode
            // 
            this.ColCustomerCode.Text = "Customer Code";
            this.ColCustomerCode.Width = 93;
            // 
            // ColPaid
            // 
            this.ColPaid.Text = "Paid";
            this.ColPaid.Width = 53;
            // 
            // ColValue
            // 
            this.ColValue.Text = "Value";
            this.ColValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColValue.Width = 82;
            // 
            // ColItemNo
            // 
            this.ColItemNo.Text = "Item No";
            // 
            // ColDescription
            // 
            this.ColDescription.Text = "Description";
            this.ColDescription.Width = 223;
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColItemNo,
            this.ColDescription,
            this.ColQuantity,
            this.ColUnitPrice,
            this.ColAmount});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(12, 339);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(571, 169);
            this.lstItems.TabIndex = 24;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // chkfilter
            // 
            this.chkfilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkfilter.Image = global::StockControl.Properties.Resources.search_add_icon16;
            this.chkfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkfilter.Location = new System.Drawing.Point(565, 4);
            this.chkfilter.Name = "chkfilter";
            this.chkfilter.Size = new System.Drawing.Size(91, 23);
            this.chkfilter.TabIndex = 30;
            this.chkfilter.Text = "Show Filters ";
            this.chkfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkfilter.UseVisualStyleBackColor = true;
            this.chkfilter.CheckedChanged += new System.EventHandler(this.chkfilter_CheckedChanged);
            // 
            // pnlfilter
            // 
            this.pnlfilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlfilter.Controls.Add(this.lbto);
            this.pnlfilter.Controls.Add(this.dteTo);
            this.pnlfilter.Controls.Add(this.dteFrom);
            this.pnlfilter.Controls.Add(this.cmbPaid);
            this.pnlfilter.Controls.Add(this.cmbCredit);
            this.pnlfilter.Controls.Add(this.cmbfltCustomer);
            this.pnlfilter.Controls.Add(this.chkCode);
            this.pnlfilter.Controls.Add(this.chkPaid);
            this.pnlfilter.Controls.Add(this.chkCredit);
            this.pnlfilter.Controls.Add(this.chkDate);
            this.pnlfilter.Controls.Add(this.chkCustomer);
            this.pnlfilter.Controls.Add(this.txtfltCode);
            this.pnlfilter.Controls.Add(this.cmdSearch);
            this.pnlfilter.Location = new System.Drawing.Point(256, 27);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(400, 198);
            this.pnlfilter.TabIndex = 29;
            this.pnlfilter.Visible = false;
            this.pnlfilter.Leave += new System.EventHandler(this.pnlfilter_Leave);
            // 
            // lbto
            // 
            this.lbto.AutoSize = true;
            this.lbto.Location = new System.Drawing.Point(191, 104);
            this.lbto.Name = "lbto";
            this.lbto.Size = new System.Drawing.Size(28, 13);
            this.lbto.TabIndex = 22;
            this.lbto.Text = "- to -";
            // 
            // dteTo
            // 
            this.dteTo.CustomFormat = "yyyy/MM/dd";
            this.dteTo.Enabled = false;
            this.dteTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteTo.Location = new System.Drawing.Point(221, 100);
            this.dteTo.Name = "dteTo";
            this.dteTo.Size = new System.Drawing.Size(89, 20);
            this.dteTo.TabIndex = 21;
            // 
            // dteFrom
            // 
            this.dteFrom.CustomFormat = "yyyy/MM/dd";
            this.dteFrom.Enabled = false;
            this.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteFrom.Location = new System.Drawing.Point(100, 100);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Size = new System.Drawing.Size(89, 20);
            this.dteFrom.TabIndex = 21;
            // 
            // cmbPaid
            // 
            this.cmbPaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaid.Enabled = false;
            this.cmbPaid.FormattingEnabled = true;
            this.cmbPaid.Items.AddRange(new object[] {
            "Unpaid only",
            "Paid only"});
            this.cmbPaid.Location = new System.Drawing.Point(100, 162);
            this.cmbPaid.Name = "cmbPaid";
            this.cmbPaid.Size = new System.Drawing.Size(119, 21);
            this.cmbPaid.TabIndex = 20;
            // 
            // cmbCredit
            // 
            this.cmbCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCredit.Enabled = false;
            this.cmbCredit.FormattingEnabled = true;
            this.cmbCredit.Items.AddRange(new object[] {
            "Cash invoices only",
            "Credit invoices only"});
            this.cmbCredit.Location = new System.Drawing.Point(100, 131);
            this.cmbCredit.Name = "cmbCredit";
            this.cmbCredit.Size = new System.Drawing.Size(119, 21);
            this.cmbCredit.TabIndex = 20;
            // 
            // cmbfltCustomer
            // 
            this.cmbfltCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltCustomer.Enabled = false;
            this.cmbfltCustomer.FormattingEnabled = true;
            this.cmbfltCustomer.Location = new System.Drawing.Point(100, 69);
            this.cmbfltCustomer.Name = "cmbfltCustomer";
            this.cmbfltCustomer.Size = new System.Drawing.Size(210, 21);
            this.cmbfltCustomer.TabIndex = 20;
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(18, 41);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(78, 17);
            this.chkCode.TabIndex = 19;
            this.chkCode.Text = "Invoice No";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.CheckedChanged += new System.EventHandler(this.chkCode_CheckedChanged);
            // 
            // chkPaid
            // 
            this.chkPaid.AutoSize = true;
            this.chkPaid.Location = new System.Drawing.Point(18, 164);
            this.chkPaid.Name = "chkPaid";
            this.chkPaid.Size = new System.Drawing.Size(80, 17);
            this.chkPaid.TabIndex = 19;
            this.chkPaid.Text = "Paid Status";
            this.chkPaid.UseVisualStyleBackColor = true;
            this.chkPaid.CheckedChanged += new System.EventHandler(this.chkPaid_CheckedChanged);
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Location = new System.Drawing.Point(18, 133);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(86, 17);
            this.chkCredit.TabIndex = 19;
            this.chkCredit.Text = "Credit Status";
            this.chkCredit.UseVisualStyleBackColor = true;
            this.chkCredit.CheckedChanged += new System.EventHandler(this.chkCredit_CheckedChanged);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(18, 100);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(49, 17);
            this.chkDate.TabIndex = 19;
            this.chkDate.Text = "Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.Location = new System.Drawing.Point(18, 69);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(70, 17);
            this.chkCustomer.TabIndex = 19;
            this.chkCustomer.Text = "Customer";
            this.chkCustomer.UseVisualStyleBackColor = true;
            this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
            // 
            // txtfltCode
            // 
            this.txtfltCode.Enabled = false;
            this.txtfltCode.Location = new System.Drawing.Point(100, 38);
            this.txtfltCode.Name = "txtfltCode";
            this.txtfltCode.Size = new System.Drawing.Size(210, 20);
            this.txtfltCode.TabIndex = 12;
            this.txtfltCode.Tag = "text";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::StockControl.Properties.Resources.search_icon16;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(322, 162);
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
            this.cmdShowAll.Location = new System.Drawing.Point(487, 4);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(72, 23);
            this.cmdShowAll.TabIndex = 31;
            this.cmdShowAll.Text = "Show All";
            this.cmdShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdShowAll.UseVisualStyleBackColor = true;
            this.cmdShowAll.Click += new System.EventHandler(this.cmdShowAll_Click);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.White;
            this.pHeader.BackgroundImage = global::StockControl.Properties.Resources.headerBar;
            this.pHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pHeader.Location = new System.Drawing.Point(0, -3);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(671, 32);
            this.pHeader.TabIndex = 32;
            // 
            // Invoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 524);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.chkfilter);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lstInvoices);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Invoices";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoices";
            this.Load += new System.EventHandler(this.Invoices_Load);
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ColumnHeader ColAmount;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColQuantity;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lbItems;
        internal System.Windows.Forms.ColumnHeader ColCustomerName;
        internal System.Windows.Forms.ColumnHeader ColDate;
        internal System.Windows.Forms.ColumnHeader ColIsCredit;
        internal System.Windows.Forms.ListView lstInvoices;
        internal System.Windows.Forms.ColumnHeader ColInvoiceNo;
        internal System.Windows.Forms.ColumnHeader ColCustomerCode;
        internal System.Windows.Forms.ColumnHeader ColPaid;
        internal System.Windows.Forms.ColumnHeader ColValue;
        internal System.Windows.Forms.ColumnHeader ColItemNo;
        internal System.Windows.Forms.ColumnHeader ColDescription;
        internal System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.CheckBox chkfilter;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.ComboBox cmbfltCustomer;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkPaid;
        private System.Windows.Forms.CheckBox chkCredit;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.TextBox txtfltCode;
        internal System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.DateTimePicker dteTo;
        private System.Windows.Forms.Label lbto;
        private System.Windows.Forms.ComboBox cmbPaid;
        private System.Windows.Forms.ComboBox cmbCredit;
        private System.Windows.Forms.Button cmdShowAll;
        private System.Windows.Forms.Panel pHeader;
    }
}