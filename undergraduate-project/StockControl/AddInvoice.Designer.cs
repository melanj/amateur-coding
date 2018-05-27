namespace StockControl
{
    partial class AddInvoice
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
            this.ColQuantity = new System.Windows.Forms.ColumnHeader();
            this.ColUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.ColAmount = new System.Windows.Forms.ColumnHeader();
            this.ColDescription = new System.Windows.Forms.ColumnHeader();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ColNo = new System.Windows.Forms.ColumnHeader();
            this.ColItemCode = new System.Windows.Forms.ColumnHeader();
            this.cmdProceed = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.GrpItems = new System.Windows.Forms.GroupBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.lbforTotal = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.grpAddItem = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.NumericUpDown();
            this.lbDiscount = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.LbItemCode = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.ChkCredit = new System.Windows.Forms.CheckBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.optStandard = new System.Windows.Forms.RadioButton();
            this.optRegular = new System.Windows.Forms.RadioButton();
            this.docInvoice = new System.Drawing.Printing.PrintDocument();
            this.lPaymentTerm = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.GrpItems.SuspendLayout();
            this.grpAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            this.ColQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQuantity.Width = 56;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price (Rs)";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 81;
            // 
            // ColAmount
            // 
            this.ColAmount.Text = "Amount (Rs)";
            this.ColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColAmount.Width = 76;
            // 
            // ColDescription
            // 
            this.ColDescription.Text = "Description";
            this.ColDescription.Width = 205;
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColNo,
            this.ColItemCode,
            this.ColDescription,
            this.ColQuantity,
            this.ColUnitPrice,
            this.ColAmount});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(10, 19);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(524, 190);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // ColNo
            // 
            this.ColNo.Text = "No";
            this.ColNo.Width = 31;
            // 
            // ColItemCode
            // 
            this.ColItemCode.Text = "Item Code";
            this.ColItemCode.Width = 69;
            // 
            // cmdProceed
            // 
            this.cmdProceed.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdProceed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProceed.Location = new System.Drawing.Point(375, 459);
            this.cmdProceed.Name = "cmdProceed";
            this.cmdProceed.Size = new System.Drawing.Size(75, 25);
            this.cmdProceed.TabIndex = 16;
            this.cmdProceed.Text = "Proceed";
            this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProceed.UseVisualStyleBackColor = true;
            this.cmdProceed.Click += new System.EventHandler(this.cmdProceed_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(459, 459);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // GrpItems
            // 
            this.GrpItems.Controls.Add(this.chkPrint);
            this.GrpItems.Controls.Add(this.lbforTotal);
            this.GrpItems.Controls.Add(this.lbTotal);
            this.GrpItems.Controls.Add(this.grpAddItem);
            this.GrpItems.Controls.Add(this.cmdRemove);
            this.GrpItems.Controls.Add(this.cmdRemoveAll);
            this.GrpItems.Controls.Add(this.lstItems);
            this.GrpItems.Location = new System.Drawing.Point(10, 39);
            this.GrpItems.Name = "GrpItems";
            this.GrpItems.Size = new System.Drawing.Size(540, 409);
            this.GrpItems.TabIndex = 14;
            this.GrpItems.TabStop = false;
            this.GrpItems.Text = "Items";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(391, 366);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(85, 17);
            this.chkPrint.TabIndex = 6;
            this.chkPrint.Text = "Print Invoice";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // lbforTotal
            // 
            this.lbforTotal.AutoSize = true;
            this.lbforTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbforTotal.Location = new System.Drawing.Point(354, 266);
            this.lbforTotal.Name = "lbforTotal";
            this.lbforTotal.Size = new System.Drawing.Size(71, 14);
            this.lbforTotal.TabIndex = 4;
            this.lbforTotal.Text = "Total (Rs.)";
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(420, 266);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(120, 14);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "0.00";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAddItem
            // 
            this.grpAddItem.Controls.Add(this.cmbCategory);
            this.grpAddItem.Controls.Add(this.lbCategory);
            this.grpAddItem.Controls.Add(this.txtDiscount);
            this.grpAddItem.Controls.Add(this.lbDiscount);
            this.grpAddItem.Controls.Add(this.cmdAdd);
            this.grpAddItem.Controls.Add(this.lbQuantity);
            this.grpAddItem.Controls.Add(this.txtQuantity);
            this.grpAddItem.Controls.Add(this.cmbItems);
            this.grpAddItem.Controls.Add(this.LbItemCode);
            this.grpAddItem.Location = new System.Drawing.Point(17, 217);
            this.grpAddItem.Name = "grpAddItem";
            this.grpAddItem.Size = new System.Drawing.Size(331, 166);
            this.grpAddItem.TabIndex = 3;
            this.grpAddItem.TabStop = false;
            this.grpAddItem.Text = "Add Item";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(90, 33);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(221, 21);
            this.cmbCategory.TabIndex = 8;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(13, 33);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 7;
            this.lbCategory.Text = "Category";
            // 
            // txtDiscount
            // 
            this.txtDiscount.DecimalPlaces = 1;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txtDiscount.Location = new System.Drawing.Point(90, 121);
            this.txtDiscount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(41, 20);
            this.txtDiscount.TabIndex = 6;
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Enabled = false;
            this.lbDiscount.Location = new System.Drawing.Point(13, 124);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(60, 13);
            this.lbDiscount.TabIndex = 5;
            this.lbDiscount.Text = "Discount %";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = global::StockControl.Properties.Resources.add_icon16;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(236, 116);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 25);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(13, 92);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(46, 13);
            this.lbQuantity.TabIndex = 3;
            this.lbQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(90, 92);
            this.txtQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(41, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbItems
            // 
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(90, 65);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(221, 21);
            this.cmbItems.TabIndex = 1;
            this.cmbItems.Tag = "text,Please Select a item";
            this.cmbItems.SelectedIndexChanged += new System.EventHandler(this.cmbItems_SelectedIndexChanged);
            // 
            // LbItemCode
            // 
            this.LbItemCode.AutoSize = true;
            this.LbItemCode.Location = new System.Drawing.Point(13, 65);
            this.LbItemCode.Name = "LbItemCode";
            this.LbItemCode.Size = new System.Drawing.Size(55, 13);
            this.LbItemCode.TabIndex = 0;
            this.LbItemCode.Text = "Item Code";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Image = global::StockControl.Properties.Resources.shopping_cart_remove_icon;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(365, 218);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 25);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Image = global::StockControl.Properties.Resources.database_remove_icon;
            this.cmdRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoveAll.Location = new System.Drawing.Point(449, 218);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(85, 25);
            this.cmdRemoveAll.TabIndex = 1;
            this.cmdRemoveAll.Text = "Remove All";
            this.cmdRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // ChkCredit
            // 
            this.ChkCredit.AutoSize = true;
            this.ChkCredit.Enabled = false;
            this.ChkCredit.Location = new System.Drawing.Point(479, 5);
            this.ChkCredit.Name = "ChkCredit";
            this.ChkCredit.Size = new System.Drawing.Size(53, 17);
            this.ChkCredit.TabIndex = 13;
            this.ChkCredit.Text = "Credit";
            this.ChkCredit.UseVisualStyleBackColor = true;
            this.ChkCredit.CheckedChanged += new System.EventHandler(this.ChkCredit_CheckedChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(209, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(170, 21);
            this.cmbCustomer.TabIndex = 12;
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(10, 14);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(51, 13);
            this.lbCustomer.TabIndex = 11;
            this.lbCustomer.Text = "Customer";
            // 
            // optStandard
            // 
            this.optStandard.AutoSize = true;
            this.optStandard.Checked = true;
            this.optStandard.Location = new System.Drawing.Point(67, 14);
            this.optStandard.Name = "optStandard";
            this.optStandard.Size = new System.Drawing.Size(68, 17);
            this.optStandard.TabIndex = 17;
            this.optStandard.TabStop = true;
            this.optStandard.Text = "Standard";
            this.optStandard.UseVisualStyleBackColor = true;
            this.optStandard.CheckedChanged += new System.EventHandler(this.optStandard_CheckedChanged);
            // 
            // optRegular
            // 
            this.optRegular.AutoSize = true;
            this.optRegular.Location = new System.Drawing.Point(141, 14);
            this.optRegular.Name = "optRegular";
            this.optRegular.Size = new System.Drawing.Size(62, 17);
            this.optRegular.TabIndex = 18;
            this.optRegular.Text = "Regular";
            this.optRegular.UseVisualStyleBackColor = true;
            this.optRegular.CheckedChanged += new System.EventHandler(this.optRegular_CheckedChanged);
            // 
            // docInvoice
            // 
            this.docInvoice.OriginAtMargins = true;
            this.docInvoice.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docInvoice_PrintPage);
            // 
            // lPaymentTerm
            // 
            this.lPaymentTerm.AutoSize = true;
            this.lPaymentTerm.Location = new System.Drawing.Point(398, 8);
            this.lPaymentTerm.Name = "lPaymentTerm";
            this.lPaymentTerm.Size = new System.Drawing.Size(75, 13);
            this.lPaymentTerm.TabIndex = 19;
            this.lPaymentTerm.Text = "Payment Term";
            // 
            // chkCash
            // 
            this.chkCash.AutoCheck = false;
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Location = new System.Drawing.Point(479, 24);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(50, 17);
            this.chkCash.TabIndex = 20;
            this.chkCash.Text = "Cash";
            this.chkCash.UseVisualStyleBackColor = true;
            this.chkCash.CheckedChanged += new System.EventHandler(this.chkCash_CheckedChanged);
            // 
            // AddInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 494);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.lPaymentTerm);
            this.Controls.Add(this.optRegular);
            this.Controls.Add(this.optStandard);
            this.Controls.Add(this.cmdProceed);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.GrpItems);
            this.Controls.Add(this.ChkCredit);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lbCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Invoice ( New Sale)";
            this.Load += new System.EventHandler(this.AddInvoice_Load);
            this.GrpItems.ResumeLayout(false);
            this.GrpItems.PerformLayout();
            this.grpAddItem.ResumeLayout(false);
            this.grpAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ColumnHeader ColQuantity;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColAmount;
        internal System.Windows.Forms.ColumnHeader ColDescription;
        internal System.Windows.Forms.ListView lstItems;
        internal System.Windows.Forms.ColumnHeader ColNo;
        internal System.Windows.Forms.ColumnHeader ColItemCode;
        internal System.Windows.Forms.Button cmdProceed;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.GroupBox GrpItems;
        internal System.Windows.Forms.Label lbTotal;
        internal System.Windows.Forms.Label lbforTotal;
        internal System.Windows.Forms.GroupBox grpAddItem;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.Label lbQuantity;
        internal System.Windows.Forms.NumericUpDown txtQuantity;
        internal System.Windows.Forms.ComboBox cmbItems;
        internal System.Windows.Forms.Label LbItemCode;
        internal System.Windows.Forms.Button cmdRemove;
        internal System.Windows.Forms.Button cmdRemoveAll;
        internal System.Windows.Forms.CheckBox ChkCredit;
        internal System.Windows.Forms.ComboBox cmbCustomer;
        internal System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.Label lbDiscount;
        private System.Windows.Forms.NumericUpDown txtDiscount;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.RadioButton optStandard;
        private System.Windows.Forms.RadioButton optRegular;
        private System.Drawing.Printing.PrintDocument docInvoice;
        private System.Windows.Forms.Label lPaymentTerm;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.CheckBox chkPrint;
    }
}