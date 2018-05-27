namespace StockControl
{
    partial class Orders
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
            this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.cmdClose = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.ColSupplierName = new System.Windows.Forms.ColumnHeader();
            this.ColDate = new System.Windows.Forms.ColumnHeader();
            this.ColSupplierCode = new System.Windows.Forms.ColumnHeader();
            this.lstOrders = new System.Windows.Forms.ListView();
            this.ColOrder = new System.Windows.Forms.ColumnHeader();
            this.ColValue = new System.Windows.Forms.ColumnHeader();
            this.colReceived = new System.Windows.Forms.ColumnHeader();
            this.ColQtyordered = new System.Windows.Forms.ColumnHeader();
            this.ColUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.ColDescription = new System.Windows.Forms.ColumnHeader();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ColCode = new System.Windows.Forms.ColumnHeader();
            this.ColQtyReceived = new System.Windows.Forms.ColumnHeader();
            this.chkfilter = new System.Windows.Forms.CheckBox();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.lbto = new System.Windows.Forms.Label();
            this.dteTo = new System.Windows.Forms.DateTimePicker();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbReceived = new System.Windows.Forms.ComboBox();
            this.cmbfltSupplier = new System.Windows.Forms.ComboBox();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkReceived = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.txtfltCode = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Amount";
            this.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(451, 528);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 25);
            this.cmdClose.TabIndex = 26;
            this.cmdClose.Text = "Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 315);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(115, 13);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "Items included in Order";
            // 
            // ColSupplierName
            // 
            this.ColSupplierName.Text = "Supplier Name";
            this.ColSupplierName.Width = 138;
            // 
            // ColDate
            // 
            this.ColDate.Text = "Date";
            this.ColDate.Width = 84;
            // 
            // ColSupplierCode
            // 
            this.ColSupplierCode.Text = "Supplier Code";
            this.ColSupplierCode.Width = 87;
            // 
            // lstOrders
            // 
            this.lstOrders.AllowColumnReorder = true;
            this.lstOrders.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColOrder,
            this.ColSupplierCode,
            this.ColSupplierName,
            this.ColDate,
            this.ColValue,
            this.colReceived});
            this.lstOrders.FullRowSelect = true;
            this.lstOrders.GridLines = true;
            this.lstOrders.Location = new System.Drawing.Point(12, 37);
            this.lstOrders.MultiSelect = false;
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(563, 269);
            this.lstOrders.TabIndex = 23;
            this.lstOrders.UseCompatibleStateImageBehavior = false;
            this.lstOrders.View = System.Windows.Forms.View.Details;
            this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
            // 
            // ColOrder
            // 
            this.ColOrder.Text = "Order No";
            this.ColOrder.Width = 64;
            // 
            // ColValue
            // 
            this.ColValue.Text = "Estimate value";
            this.ColValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColValue.Width = 84;
            // 
            // colReceived
            // 
            this.colReceived.Text = "Is Received";
            this.colReceived.Width = 76;
            // 
            // ColQtyordered
            // 
            this.ColQtyordered.Text = "Qty ordered";
            this.ColQtyordered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQtyordered.Width = 78;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 68;
            // 
            // ColDescription
            // 
            this.ColDescription.Text = "Description";
            this.ColDescription.Width = 141;
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCode,
            this.ColDescription,
            this.ColQtyordered,
            this.ColQtyReceived,
            this.ColUnitPrice,
            this.ColumnHeader11});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(12, 343);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(516, 169);
            this.lstItems.TabIndex = 24;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // ColCode
            // 
            this.ColCode.Text = "Item Code";
            // 
            // ColQtyReceived
            // 
            this.ColQtyReceived.Text = "Qty Received";
            this.ColQtyReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQtyReceived.Width = 78;
            // 
            // chkfilter
            // 
            this.chkfilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkfilter.Image = global::StockControl.Properties.Resources.search_add_icon16;
            this.chkfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkfilter.Location = new System.Drawing.Point(484, 5);
            this.chkfilter.Name = "chkfilter";
            this.chkfilter.Size = new System.Drawing.Size(91, 23);
            this.chkfilter.TabIndex = 32;
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
            this.pnlfilter.Controls.Add(this.cmbReceived);
            this.pnlfilter.Controls.Add(this.cmbfltSupplier);
            this.pnlfilter.Controls.Add(this.chkCode);
            this.pnlfilter.Controls.Add(this.chkReceived);
            this.pnlfilter.Controls.Add(this.chkDate);
            this.pnlfilter.Controls.Add(this.chkSupplier);
            this.pnlfilter.Controls.Add(this.txtfltCode);
            this.pnlfilter.Controls.Add(this.cmdSearch);
            this.pnlfilter.Location = new System.Drawing.Point(175, 28);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(400, 198);
            this.pnlfilter.TabIndex = 31;
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
            // cmbReceived
            // 
            this.cmbReceived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceived.Enabled = false;
            this.cmbReceived.FormattingEnabled = true;
            this.cmbReceived.Items.AddRange(new object[] {
            "No only",
            "Yes only"});
            this.cmbReceived.Location = new System.Drawing.Point(100, 131);
            this.cmbReceived.Name = "cmbReceived";
            this.cmbReceived.Size = new System.Drawing.Size(119, 21);
            this.cmbReceived.TabIndex = 20;
            // 
            // cmbfltSupplier
            // 
            this.cmbfltSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltSupplier.Enabled = false;
            this.cmbfltSupplier.FormattingEnabled = true;
            this.cmbfltSupplier.Location = new System.Drawing.Point(100, 69);
            this.cmbfltSupplier.Name = "cmbfltSupplier";
            this.cmbfltSupplier.Size = new System.Drawing.Size(210, 21);
            this.cmbfltSupplier.TabIndex = 20;
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(18, 41);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(69, 17);
            this.chkCode.TabIndex = 19;
            this.chkCode.Text = "Order No";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.CheckedChanged += new System.EventHandler(this.chkCode_CheckedChanged);
            // 
            // chkReceived
            // 
            this.chkReceived.AutoSize = true;
            this.chkReceived.Location = new System.Drawing.Point(18, 133);
            this.chkReceived.Name = "chkReceived";
            this.chkReceived.Size = new System.Drawing.Size(72, 17);
            this.chkReceived.TabIndex = 19;
            this.chkReceived.Text = "Received";
            this.chkReceived.UseVisualStyleBackColor = true;
            this.chkReceived.CheckedChanged += new System.EventHandler(this.chkReceived_CheckedChanged);
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
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Location = new System.Drawing.Point(18, 69);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(64, 17);
            this.chkSupplier.TabIndex = 19;
            this.chkSupplier.Text = "Supplier";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
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
            this.cmdShowAll.Location = new System.Drawing.Point(397, 5);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(81, 23);
            this.cmdShowAll.TabIndex = 33;
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
            this.pHeader.Location = new System.Drawing.Point(-2, -1);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(589, 32);
            this.pHeader.TabIndex = 34;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 565);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.chkfilter);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Orders";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ColumnHeader ColSupplierName;
        internal System.Windows.Forms.ColumnHeader ColDate;
        internal System.Windows.Forms.ColumnHeader ColSupplierCode;
        internal System.Windows.Forms.ListView lstOrders;
        internal System.Windows.Forms.ColumnHeader ColOrder;
        internal System.Windows.Forms.ColumnHeader ColValue;
        internal System.Windows.Forms.ColumnHeader ColQtyordered;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColDescription;
        internal System.Windows.Forms.ListView lstItems;
        internal System.Windows.Forms.ColumnHeader ColCode;
        private System.Windows.Forms.ColumnHeader colReceived;
        private System.Windows.Forms.CheckBox chkfilter;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Label lbto;
        private System.Windows.Forms.DateTimePicker dteTo;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.ComboBox cmbReceived;
        private System.Windows.Forms.ComboBox cmbfltSupplier;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkReceived;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.TextBox txtfltCode;
        internal System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ColumnHeader ColQtyReceived;
        private System.Windows.Forms.Button cmdShowAll;
        private System.Windows.Forms.Panel pHeader;
    }
}