namespace StockControl
{
    partial class Payments
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
            this.lstPayments = new System.Windows.Forms.ListView();
            this.colRef = new System.Windows.Forms.ColumnHeader();
            this.colInvoice = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colBalance = new System.Windows.Forms.ColumnHeader();
            this.chkfilter = new System.Windows.Forms.CheckBox();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.lbto = new System.Windows.Forms.Label();
            this.dteTo = new System.Windows.Forms.DateTimePicker();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbfltInvoice = new System.Windows.Forms.ComboBox();
            this.cmbfltCustomer = new System.Windows.Forms.ComboBox();
            this.chkInvoice = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPayments
            // 
            this.lstPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRef,
            this.colInvoice,
            this.colDate,
            this.colAmount,
            this.colBalance});
            this.lstPayments.FullRowSelect = true;
            this.lstPayments.GridLines = true;
            this.lstPayments.Location = new System.Drawing.Point(12, 43);
            this.lstPayments.MultiSelect = false;
            this.lstPayments.Name = "lstPayments";
            this.lstPayments.Size = new System.Drawing.Size(421, 236);
            this.lstPayments.TabIndex = 38;
            this.lstPayments.UseCompatibleStateImageBehavior = false;
            this.lstPayments.View = System.Windows.Forms.View.Details;
            // 
            // colRef
            // 
            this.colRef.Text = "Ref ID";
            // 
            // colInvoice
            // 
            this.colInvoice.Text = "Invoice No";
            this.colInvoice.Width = 87;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 94;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 89;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            this.colBalance.Width = 80;
            // 
            // chkfilter
            // 
            this.chkfilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkfilter.Image = global::StockControl.Properties.Resources.search_add_icon16;
            this.chkfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkfilter.Location = new System.Drawing.Point(331, 15);
            this.chkfilter.Name = "chkfilter";
            this.chkfilter.Size = new System.Drawing.Size(91, 23);
            this.chkfilter.TabIndex = 40;
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
            this.pnlfilter.Controls.Add(this.cmbfltInvoice);
            this.pnlfilter.Controls.Add(this.cmbfltCustomer);
            this.pnlfilter.Controls.Add(this.chkInvoice);
            this.pnlfilter.Controls.Add(this.chkDate);
            this.pnlfilter.Controls.Add(this.chkCustomer);
            this.pnlfilter.Controls.Add(this.cmdSearch);
            this.pnlfilter.Location = new System.Drawing.Point(22, 38);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(400, 164);
            this.pnlfilter.TabIndex = 39;
            this.pnlfilter.Visible = false;
            this.pnlfilter.Leave += new System.EventHandler(this.pnlfilter_Leave);
            // 
            // lbto
            // 
            this.lbto.AutoSize = true;
            this.lbto.Location = new System.Drawing.Point(186, 80);
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
            this.dteTo.Location = new System.Drawing.Point(216, 76);
            this.dteTo.Name = "dteTo";
            this.dteTo.Size = new System.Drawing.Size(89, 20);
            this.dteTo.TabIndex = 21;
            // 
            // dteFrom
            // 
            this.dteFrom.CustomFormat = "yyyy/MM/dd";
            this.dteFrom.Enabled = false;
            this.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteFrom.Location = new System.Drawing.Point(95, 76);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Size = new System.Drawing.Size(89, 20);
            this.dteFrom.TabIndex = 21;
            // 
            // cmbfltInvoice
            // 
            this.cmbfltInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltInvoice.Enabled = false;
            this.cmbfltInvoice.FormattingEnabled = true;
            this.cmbfltInvoice.Location = new System.Drawing.Point(95, 46);
            this.cmbfltInvoice.Name = "cmbfltInvoice";
            this.cmbfltInvoice.Size = new System.Drawing.Size(119, 21);
            this.cmbfltInvoice.TabIndex = 20;
            // 
            // cmbfltCustomer
            // 
            this.cmbfltCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltCustomer.Enabled = false;
            this.cmbfltCustomer.FormattingEnabled = true;
            this.cmbfltCustomer.Location = new System.Drawing.Point(95, 16);
            this.cmbfltCustomer.Name = "cmbfltCustomer";
            this.cmbfltCustomer.Size = new System.Drawing.Size(210, 21);
            this.cmbfltCustomer.TabIndex = 20;
            this.cmbfltCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbfltCustomer_SelectedIndexChanged);
            // 
            // chkInvoice
            // 
            this.chkInvoice.AutoSize = true;
            this.chkInvoice.Location = new System.Drawing.Point(13, 48);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(61, 17);
            this.chkInvoice.TabIndex = 19;
            this.chkInvoice.Text = "Invoice";
            this.chkInvoice.UseVisualStyleBackColor = true;
            this.chkInvoice.CheckedChanged += new System.EventHandler(this.chkInvoice_CheckedChanged);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(13, 76);
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
            this.chkCustomer.Location = new System.Drawing.Point(13, 16);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(70, 17);
            this.chkCustomer.TabIndex = 19;
            this.chkCustomer.Text = "Customer";
            this.chkCustomer.UseVisualStyleBackColor = true;
            this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::StockControl.Properties.Resources.search_icon16;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(319, 121);
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
            this.cmdShowAll.Location = new System.Drawing.Point(250, 15);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(75, 23);
            this.cmdShowAll.TabIndex = 41;
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
            this.pHeader.Location = new System.Drawing.Point(-1, -1);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(447, 37);
            this.pHeader.TabIndex = 42;
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 291);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.chkfilter);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.lstPayments);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payments";
            this.Load += new System.EventHandler(this.Payments_Load);
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstPayments;
        private System.Windows.Forms.ColumnHeader colRef;
        private System.Windows.Forms.ColumnHeader colInvoice;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.CheckBox chkfilter;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Label lbto;
        private System.Windows.Forms.DateTimePicker dteTo;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.ComboBox cmbfltInvoice;
        private System.Windows.Forms.ComboBox cmbfltCustomer;
        private System.Windows.Forms.CheckBox chkInvoice;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkCustomer;
        internal System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdShowAll;
        private System.Windows.Forms.Panel pHeader;

    }
}