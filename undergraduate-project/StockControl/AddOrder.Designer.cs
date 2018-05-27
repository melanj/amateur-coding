namespace StockControl
{
    partial class AddOrder
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
            this.cmdProceed = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbforTotal = new System.Windows.Forms.Label();
            this.grpAddItem = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.lbItem = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ColNo = new System.Windows.Forms.ColumnHeader();
            this.ColItem = new System.Windows.Forms.ColumnHeader();
            this.ColQuantity = new System.Windows.Forms.ColumnHeader();
            this.ColUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.ColAmount = new System.Windows.Forms.ColumnHeader();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.docOrder = new System.Drawing.Printing.PrintDocument();
            this.grpItems.SuspendLayout();
            this.grpAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdProceed
            // 
            this.cmdProceed.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdProceed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProceed.Location = new System.Drawing.Point(346, 393);
            this.cmdProceed.Name = "cmdProceed";
            this.cmdProceed.Size = new System.Drawing.Size(98, 25);
            this.cmdProceed.TabIndex = 13;
            this.cmdProceed.Text = "Make Order";
            this.cmdProceed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProceed.UseVisualStyleBackColor = true;
            this.cmdProceed.Click += new System.EventHandler(this.cmdProceed_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(459, 393);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.chkPrint);
            this.grpItems.Controls.Add(this.lbTotal);
            this.grpItems.Controls.Add(this.lbforTotal);
            this.grpItems.Controls.Add(this.grpAddItem);
            this.grpItems.Controls.Add(this.cmdRemove);
            this.grpItems.Controls.Add(this.cmdRemoveAll);
            this.grpItems.Controls.Add(this.lstItems);
            this.grpItems.Location = new System.Drawing.Point(10, 48);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(540, 339);
            this.grpItems.TabIndex = 11;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Order Items";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(358, 316);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(76, 17);
            this.chkPrint.TabIndex = 7;
            this.chkPrint.Text = "Print Order";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(422, 271);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(100, 14);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "0.00";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbforTotal
            // 
            this.lbforTotal.AutoSize = true;
            this.lbforTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbforTotal.Location = new System.Drawing.Point(321, 271);
            this.lbforTotal.Name = "lbforTotal";
            this.lbforTotal.Size = new System.Drawing.Size(95, 14);
            this.lbforTotal.TabIndex = 4;
            this.lbforTotal.Text = "Estimate Total";
            // 
            // grpAddItem
            // 
            this.grpAddItem.Controls.Add(this.txtPrice);
            this.grpAddItem.Controls.Add(this.lbPrice);
            this.grpAddItem.Controls.Add(this.cmdAdd);
            this.grpAddItem.Controls.Add(this.lbQuantity);
            this.grpAddItem.Controls.Add(this.txtQuantity);
            this.grpAddItem.Controls.Add(this.cmbItems);
            this.grpAddItem.Controls.Add(this.lbItem);
            this.grpAddItem.Location = new System.Drawing.Point(17, 190);
            this.grpAddItem.Name = "grpAddItem";
            this.grpAddItem.Size = new System.Drawing.Size(298, 143);
            this.grpAddItem.TabIndex = 3;
            this.grpAddItem.TabStop = false;
            this.grpAddItem.Text = "Add Item";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(90, 58);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 20;
            this.txtPrice.Tag = "money,Required a valid unit price";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(13, 58);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(53, 13);
            this.lbPrice.TabIndex = 5;
            this.lbPrice.Text = "Unit Price";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = global::StockControl.Properties.Resources.add_icon16;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(202, 101);
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
            this.lbQuantity.Location = new System.Drawing.Point(13, 91);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(46, 13);
            this.lbQuantity.TabIndex = 3;
            this.lbQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(90, 91);
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
            this.cmbItems.Location = new System.Drawing.Point(90, 23);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(187, 21);
            this.cmbItems.TabIndex = 1;
            this.cmbItems.SelectedIndexChanged += new System.EventHandler(this.cmbItems_SelectedIndexChanged);
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Location = new System.Drawing.Point(13, 23);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(58, 13);
            this.lbItem.TabIndex = 0;
            this.lbItem.Text = "Item Name";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Image = global::StockControl.Properties.Resources.shopping_cart_remove_icon;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(368, 190);
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
            this.cmdRemoveAll.Location = new System.Drawing.Point(449, 190);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(86, 25);
            this.cmdRemoveAll.TabIndex = 1;
            this.cmdRemoveAll.Text = "Remove All";
            this.cmdRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColNo,
            this.ColItem,
            this.ColQuantity,
            this.ColUnitPrice,
            this.ColAmount});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.Location = new System.Drawing.Point(10, 21);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(524, 163);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // ColNo
            // 
            this.ColNo.Text = "No";
            this.ColNo.Width = 31;
            // 
            // ColItem
            // 
            this.ColItem.Text = "Item";
            this.ColItem.Width = 174;
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            this.ColQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQuantity.Width = 61;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 90;
            // 
            // ColAmount
            // 
            this.ColAmount.Text = "Estimate Amount";
            this.ColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColAmount.Width = 108;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(88, 9);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(170, 21);
            this.cmbSupplier.TabIndex = 10;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(12, 12);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(45, 13);
            this.lbSupplier.TabIndex = 9;
            this.lbSupplier.Text = "Supplier";
            // 
            // docOrder
            // 
            this.docOrder.OriginAtMargins = true;
            this.docOrder.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docOrder_PrintPage);
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 424);
            this.Controls.Add(this.cmdProceed);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lbSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Order";
            this.Load += new System.EventHandler(this.AddOrder_Load);
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            this.grpAddItem.ResumeLayout(false);
            this.grpAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdProceed;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.GroupBox grpItems;
        internal System.Windows.Forms.Label lbTotal;
        internal System.Windows.Forms.Label lbforTotal;
        internal System.Windows.Forms.GroupBox grpAddItem;
        internal System.Windows.Forms.Label lbPrice;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.Label lbQuantity;
        internal System.Windows.Forms.NumericUpDown txtQuantity;
        internal System.Windows.Forms.ComboBox cmbItems;
        internal System.Windows.Forms.Label lbItem;
        internal System.Windows.Forms.Button cmdRemove;
        internal System.Windows.Forms.Button cmdRemoveAll;
        internal System.Windows.Forms.ListView lstItems;
        internal System.Windows.Forms.ColumnHeader ColNo;
        internal System.Windows.Forms.ColumnHeader ColItem;
        internal System.Windows.Forms.ColumnHeader ColQuantity;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColAmount;
        internal System.Windows.Forms.ComboBox cmbSupplier;
        internal System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Drawing.Printing.PrintDocument docOrder;
        private System.Windows.Forms.CheckBox chkPrint;
    }
}