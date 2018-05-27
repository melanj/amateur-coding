namespace StockControl
{
    partial class AddItem
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtMinOrderQty = new System.Windows.Forms.TextBox();
            this.lbMinOrderQty = new System.Windows.Forms.Label();
            this.txtReorderQty = new System.Windows.Forms.TextBox();
            this.lbReorderQty = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(265, 296);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(173, 296);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 7;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(75, 153);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Tag = "number,Required a valid quantity";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(12, 157);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(46, 13);
            this.lbQuantity.TabIndex = 20;
            this.lbQuantity.Text = "Quantity";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(75, 121);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.Tag = "money,Required a valid unit price";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(12, 125);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(55, 13);
            this.lbPrice.TabIndex = 18;
            this.lbPrice.Text = "Unit price ";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(12, 93);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 16;
            this.lbCategory.Text = "Category";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 57);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(259, 20);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Tag = "text,You must specify a item description";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(12, 61);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 14;
            this.lbDescription.Text = "Description";
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.White;
            this.pHeader.BackgroundImage = global::StockControl.Properties.Resources.headerBar;
            this.pHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pHeader.Location = new System.Drawing.Point(-1, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(359, 37);
            this.pHeader.TabIndex = 13;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(75, 89);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(259, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.Tag = "text,You must select a Category";
            // 
            // txtMinOrderQty
            // 
            this.txtMinOrderQty.Location = new System.Drawing.Point(109, 185);
            this.txtMinOrderQty.Name = "txtMinOrderQty";
            this.txtMinOrderQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinOrderQty.Size = new System.Drawing.Size(66, 20);
            this.txtMinOrderQty.TabIndex = 4;
            this.txtMinOrderQty.Tag = "number,Required a valid minimum order quantity";
            // 
            // lbMinOrderQty
            // 
            this.lbMinOrderQty.AutoSize = true;
            this.lbMinOrderQty.Location = new System.Drawing.Point(12, 189);
            this.lbMinOrderQty.Name = "lbMinOrderQty";
            this.lbMinOrderQty.Size = new System.Drawing.Size(91, 13);
            this.lbMinOrderQty.TabIndex = 25;
            this.lbMinOrderQty.Text = "Min-order quantity";
            // 
            // txtReorderQty
            // 
            this.txtReorderQty.Location = new System.Drawing.Point(109, 217);
            this.txtReorderQty.Name = "txtReorderQty";
            this.txtReorderQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReorderQty.Size = new System.Drawing.Size(66, 20);
            this.txtReorderQty.TabIndex = 5;
            this.txtReorderQty.Tag = "number,Required a valid Re-order quantity";
            // 
            // lbReorderQty
            // 
            this.lbReorderQty.AutoSize = true;
            this.lbReorderQty.Location = new System.Drawing.Point(12, 221);
            this.lbReorderQty.Name = "lbReorderQty";
            this.lbReorderQty.Size = new System.Drawing.Size(88, 13);
            this.lbReorderQty.TabIndex = 27;
            this.lbReorderQty.Text = "Re-order quantity";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(75, 249);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(259, 21);
            this.cmbSupplier.TabIndex = 6;
            this.cmbSupplier.Tag = "text,You must select a Supplier";
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(12, 253);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(45, 13);
            this.lbSupplier.TabIndex = 29;
            this.lbSupplier.Text = "Supplier";
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 334);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lbSupplier);
            this.Controls.Add(this.txtReorderQty);
            this.Controls.Add(this.lbReorderQty);
            this.Controls.Add(this.txtMinOrderQty);
            this.Controls.Add(this.lbMinOrderQty);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Item";
            this.Load += new System.EventHandler(this.AddItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtMinOrderQty;
        private System.Windows.Forms.Label lbMinOrderQty;
        private System.Windows.Forms.TextBox txtReorderQty;
        private System.Windows.Forms.Label lbReorderQty;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lbSupplier;
    }
}