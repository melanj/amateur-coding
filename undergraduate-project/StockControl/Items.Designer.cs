namespace StockControl
{
    partial class Items
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.grpitem = new System.Windows.Forms.GroupBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.txtReorderQty = new System.Windows.Forms.TextBox();
            this.lbReorderQty = new System.Windows.Forms.Label();
            this.txtMinOrderQty = new System.Windows.Forms.TextBox();
            this.lbMinOrderQty = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.lbItemCode = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.MaskedTextBox();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ColCode = new System.Windows.Forms.ColumnHeader();
            this.ColDescription = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.ColUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.ColQuantity = new System.Windows.Forms.ColumnHeader();
            this.colMinOrderQty = new System.Windows.Forms.ColumnHeader();
            this.colReorderQty = new System.Windows.Forms.ColumnHeader();
            this.colSupplier = new System.Windows.Forms.ColumnHeader();
            this.chkfilter = new System.Windows.Forms.CheckBox();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.cmbfltSupplier = new System.Windows.Forms.ComboBox();
            this.cmbfltCategory = new System.Windows.Forms.ComboBox();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkiflowqty = new System.Windows.Forms.CheckBox();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.chkCategory = new System.Windows.Forms.CheckBox();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.txtfltCode = new System.Windows.Forms.TextBox();
            this.txtfltDescription = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdShowAll = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.grpitem.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(764, 571);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 26);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Image = global::StockControl.Properties.Resources.add_icon16;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 423);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 14;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // grpitem
            // 
            this.grpitem.Controls.Add(this.txtSupplier);
            this.grpitem.Controls.Add(this.txtCategory);
            this.grpitem.Controls.Add(this.lbSupplier);
            this.grpitem.Controls.Add(this.txtReorderQty);
            this.grpitem.Controls.Add(this.lbReorderQty);
            this.grpitem.Controls.Add(this.txtMinOrderQty);
            this.grpitem.Controls.Add(this.lbMinOrderQty);
            this.grpitem.Controls.Add(this.txtQuantity);
            this.grpitem.Controls.Add(this.lbQuantity);
            this.grpitem.Controls.Add(this.txtPrice);
            this.grpitem.Controls.Add(this.lbPrice);
            this.grpitem.Controls.Add(this.lbCategory);
            this.grpitem.Controls.Add(this.txtDescription);
            this.grpitem.Controls.Add(this.lbDescription);
            this.grpitem.Controls.Add(this.cmdUpdate);
            this.grpitem.Controls.Add(this.lbItemCode);
            this.grpitem.Controls.Add(this.txtItemCode);
            this.grpitem.Enabled = false;
            this.grpitem.Location = new System.Drawing.Point(12, 452);
            this.grpitem.Name = "grpitem";
            this.grpitem.Size = new System.Drawing.Size(740, 158);
            this.grpitem.TabIndex = 12;
            this.grpitem.TabStop = false;
            this.grpitem.Text = "Item details";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.White;
            this.txtSupplier.Location = new System.Drawing.Point(73, 119);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(259, 20);
            this.txtSupplier.TabIndex = 40;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.White;
            this.txtCategory.Location = new System.Drawing.Point(73, 87);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(259, 20);
            this.txtCategory.TabIndex = 39;
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(10, 123);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(45, 13);
            this.lbSupplier.TabIndex = 37;
            this.lbSupplier.Text = "Supplier";
            // 
            // txtReorderQty
            // 
            this.txtReorderQty.Location = new System.Drawing.Point(657, 83);
            this.txtReorderQty.Name = "txtReorderQty";
            this.txtReorderQty.Size = new System.Drawing.Size(66, 20);
            this.txtReorderQty.TabIndex = 36;
            this.txtReorderQty.Tag = "number,required a valid Re-order quantity";
            this.txtReorderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbReorderQty
            // 
            this.lbReorderQty.AutoSize = true;
            this.lbReorderQty.Location = new System.Drawing.Point(560, 87);
            this.lbReorderQty.Name = "lbReorderQty";
            this.lbReorderQty.Size = new System.Drawing.Size(88, 13);
            this.lbReorderQty.TabIndex = 35;
            this.lbReorderQty.Text = "Re-order quantity";
            // 
            // txtMinOrderQty
            // 
            this.txtMinOrderQty.Location = new System.Drawing.Point(657, 51);
            this.txtMinOrderQty.Name = "txtMinOrderQty";
            this.txtMinOrderQty.Size = new System.Drawing.Size(66, 20);
            this.txtMinOrderQty.TabIndex = 34;
            this.txtMinOrderQty.Tag = "number,required a valid minimum order quantity";
            this.txtMinOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbMinOrderQty
            // 
            this.lbMinOrderQty.AutoSize = true;
            this.lbMinOrderQty.Location = new System.Drawing.Point(560, 55);
            this.lbMinOrderQty.Name = "lbMinOrderQty";
            this.lbMinOrderQty.Size = new System.Drawing.Size(91, 13);
            this.lbMinOrderQty.TabIndex = 33;
            this.lbMinOrderQty.Text = "Min-order quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(440, 83);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 31;
            this.txtQuantity.Tag = "number,required a valid quantity";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(377, 87);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(46, 13);
            this.lbQuantity.TabIndex = 30;
            this.lbQuantity.Text = "Quantity";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(440, 51);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 29;
            this.txtPrice.Tag = "money,required a valid unit price";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(377, 55);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(52, 13);
            this.lbPrice.TabIndex = 28;
            this.lbPrice.Text = "Unit price";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(10, 91);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 27;
            this.lbCategory.Text = "Category";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(73, 55);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 20);
            this.txtDescription.TabIndex = 26;
            this.txtDescription.Tag = "text,You must specify a item description";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(10, 59);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 25;
            this.lbDescription.Text = "Description";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Image = global::StockControl.Properties.Resources.process_accept_icon;
            this.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdate.Location = new System.Drawing.Point(657, 119);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(65, 26);
            this.cmdUpdate.TabIndex = 22;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // lbItemCode
            // 
            this.lbItemCode.AutoSize = true;
            this.lbItemCode.Location = new System.Drawing.Point(10, 27);
            this.lbItemCode.Name = "lbItemCode";
            this.lbItemCode.Size = new System.Drawing.Size(55, 13);
            this.lbItemCode.TabIndex = 15;
            this.lbItemCode.Text = "Item Code";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.Location = new System.Drawing.Point(73, 23);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.PromptChar = ' ';
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(100, 20);
            this.txtItemCode.TabIndex = 12;
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCode,
            this.ColDescription,
            this.colCategory,
            this.ColUnitPrice,
            this.ColQuantity,
            this.colMinOrderQty,
            this.colReorderQty,
            this.colSupplier});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(12, 38);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.ShowItemToolTips = true;
            this.lstItems.Size = new System.Drawing.Size(817, 369);
            this.lstItems.TabIndex = 11;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // ColCode
            // 
            this.ColCode.Text = "Item Code";
            this.ColCode.Width = 65;
            // 
            // ColDescription
            // 
            this.ColDescription.Text = "Description";
            this.ColDescription.Width = 217;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 77;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price (Rs)";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 74;
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            this.ColQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQuantity.Width = 70;
            // 
            // colMinOrderQty
            // 
            this.colMinOrderQty.Text = "Min. Ord. Qty";
            this.colMinOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMinOrderQty.Width = 81;
            // 
            // colReorderQty
            // 
            this.colReorderQty.Text = "Re-ord. Qty";
            this.colReorderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReorderQty.Width = 73;
            // 
            // colSupplier
            // 
            this.colSupplier.Text = "Supplier";
            this.colSupplier.Width = 176;
            // 
            // chkfilter
            // 
            this.chkfilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkfilter.Image = global::StockControl.Properties.Resources.search_add_icon16;
            this.chkfilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkfilter.Location = new System.Drawing.Point(738, 9);
            this.chkfilter.Name = "chkfilter";
            this.chkfilter.Size = new System.Drawing.Size(91, 23);
            this.chkfilter.TabIndex = 25;
            this.chkfilter.Text = "Show Filters ";
            this.chkfilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkfilter.UseVisualStyleBackColor = true;
            this.chkfilter.CheckedChanged += new System.EventHandler(this.chkfilter_CheckedChanged);
            // 
            // pnlfilter
            // 
            this.pnlfilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlfilter.Controls.Add(this.cmbfltSupplier);
            this.pnlfilter.Controls.Add(this.cmbfltCategory);
            this.pnlfilter.Controls.Add(this.chkCode);
            this.pnlfilter.Controls.Add(this.chkiflowqty);
            this.pnlfilter.Controls.Add(this.chkSupplier);
            this.pnlfilter.Controls.Add(this.chkCategory);
            this.pnlfilter.Controls.Add(this.chkDescription);
            this.pnlfilter.Controls.Add(this.txtfltCode);
            this.pnlfilter.Controls.Add(this.txtfltDescription);
            this.pnlfilter.Controls.Add(this.cmdSearch);
            this.pnlfilter.Location = new System.Drawing.Point(429, 32);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(400, 198);
            this.pnlfilter.TabIndex = 24;
            this.pnlfilter.Visible = false;
            this.pnlfilter.Leave += new System.EventHandler(this.pnlfilter_Leave);
            // 
            // cmbfltSupplier
            // 
            this.cmbfltSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltSupplier.Enabled = false;
            this.cmbfltSupplier.FormattingEnabled = true;
            this.cmbfltSupplier.Location = new System.Drawing.Point(100, 129);
            this.cmbfltSupplier.Name = "cmbfltSupplier";
            this.cmbfltSupplier.Size = new System.Drawing.Size(210, 21);
            this.cmbfltSupplier.TabIndex = 21;
            // 
            // cmbfltCategory
            // 
            this.cmbfltCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfltCategory.Enabled = false;
            this.cmbfltCategory.FormattingEnabled = true;
            this.cmbfltCategory.Location = new System.Drawing.Point(100, 98);
            this.cmbfltCategory.Name = "cmbfltCategory";
            this.cmbfltCategory.Size = new System.Drawing.Size(210, 21);
            this.cmbfltCategory.TabIndex = 20;
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(18, 41);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(74, 17);
            this.chkCode.TabIndex = 19;
            this.chkCode.Text = "Item Code";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.CheckedChanged += new System.EventHandler(this.chkCode_CheckedChanged);
            // 
            // chkiflowqty
            // 
            this.chkiflowqty.AutoSize = true;
            this.chkiflowqty.Location = new System.Drawing.Point(18, 164);
            this.chkiflowqty.Name = "chkiflowqty";
            this.chkiflowqty.Size = new System.Drawing.Size(288, 17);
            this.chkiflowqty.TabIndex = 19;
            this.chkiflowqty.Text = "Items Required Re-ordering  (if Quantity <= Re. Odr Qty)";
            this.chkiflowqty.UseVisualStyleBackColor = true;
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Location = new System.Drawing.Point(18, 133);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(64, 17);
            this.chkSupplier.TabIndex = 19;
            this.chkSupplier.Text = "Supplier";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
            // 
            // chkCategory
            // 
            this.chkCategory.AutoSize = true;
            this.chkCategory.Location = new System.Drawing.Point(18, 100);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(68, 17);
            this.chkCategory.TabIndex = 19;
            this.chkCategory.Text = "Category";
            this.chkCategory.UseVisualStyleBackColor = true;
            this.chkCategory.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Location = new System.Drawing.Point(18, 69);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(79, 17);
            this.chkDescription.TabIndex = 19;
            this.chkDescription.Text = "Description";
            this.chkDescription.UseVisualStyleBackColor = true;
            this.chkDescription.CheckedChanged += new System.EventHandler(this.chkDescription_CheckedChanged);
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
            // txtfltDescription
            // 
            this.txtfltDescription.Enabled = false;
            this.txtfltDescription.Location = new System.Drawing.Point(100, 66);
            this.txtfltDescription.Name = "txtfltDescription";
            this.txtfltDescription.Size = new System.Drawing.Size(210, 20);
            this.txtfltDescription.TabIndex = 12;
            this.txtfltDescription.Tag = "text";
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
            this.cmdShowAll.Location = new System.Drawing.Point(659, 9);
            this.cmdShowAll.Name = "cmdShowAll";
            this.cmdShowAll.Size = new System.Drawing.Size(73, 23);
            this.cmdShowAll.TabIndex = 26;
            this.cmdShowAll.Text = "Show All";
            this.cmdShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdShowAll.UseVisualStyleBackColor = true;
            this.cmdShowAll.Click += new System.EventHandler(this.cmdShowAll_Click);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.White;
            this.pHeader.BackgroundImage = global::StockControl.Properties.Resources.headerBar;
            this.pHeader.Location = new System.Drawing.Point(-2, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(845, 32);
            this.pHeader.TabIndex = 27;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(93, 423);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(74, 25);
            this.cmdRemove.TabIndex = 28;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 627);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdShowAll);
            this.Controls.Add(this.chkfilter);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.grpitem);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Items";
            this.Load += new System.EventHandler(this.Items_Load);
            this.grpitem.ResumeLayout(false);
            this.grpitem.PerformLayout();
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.GroupBox grpitem;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Label lbItemCode;
        internal System.Windows.Forms.MaskedTextBox txtItemCode;
        internal System.Windows.Forms.ListView lstItems;
        internal System.Windows.Forms.ColumnHeader ColCode;
        internal System.Windows.Forms.ColumnHeader ColDescription;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColQuantity;
        private System.Windows.Forms.ColumnHeader colMinOrderQty;
        private System.Windows.Forms.ColumnHeader colReorderQty;
        private System.Windows.Forms.ColumnHeader colSupplier;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox txtReorderQty;
        private System.Windows.Forms.Label lbReorderQty;
        private System.Windows.Forms.TextBox txtMinOrderQty;
        private System.Windows.Forms.Label lbMinOrderQty;
        private System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.CheckBox chkfilter;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkiflowqty;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.CheckBox chkCategory;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.TextBox txtfltCode;
        private System.Windows.Forms.TextBox txtfltDescription;
        internal System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ComboBox cmbfltCategory;
        private System.Windows.Forms.ComboBox cmbfltSupplier;
        private System.Windows.Forms.Button cmdShowAll;
        private System.Windows.Forms.Panel pHeader;
        internal System.Windows.Forms.Button cmdRemove;
    }
}