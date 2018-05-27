namespace StockControl
{
    partial class AddReceivedOrder
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
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.lbOrder = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListView();
            this.ColRef = new System.Windows.Forms.ColumnHeader();
            this.ColItemNo = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.ColQuantity = new System.Windows.Forms.ColumnHeader();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.docGRN = new System.Drawing.Printing.PrintDocument();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmdChange = new System.Windows.Forms.Button();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(75, 14);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(100, 21);
            this.cmbOrder.TabIndex = 36;
            this.cmbOrder.Tag = "text, Please Select Order No";
            this.cmbOrder.SelectedIndexChanged += new System.EventHandler(this.cmbOrder_SelectedIndexChanged);
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Location = new System.Drawing.Point(12, 18);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(33, 13);
            this.lbOrder.TabIndex = 35;
            this.lbOrder.Text = "Order";
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstItems.CheckBoxes = true;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColRef,
            this.ColItemNo,
            this.colDescription,
            this.ColQuantity});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstItems.Location = new System.Drawing.Point(12, 52);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(382, 169);
            this.lstItems.TabIndex = 37;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstItems_ItemChecked);
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // ColRef
            // 
            this.ColRef.Text = "Ref";
            // 
            // ColItemNo
            // 
            this.ColItemNo.Text = "Item No";
            this.ColItemNo.Width = 67;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 158;
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            this.ColQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColQuantity.Width = 61;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(314, 279);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 25);
            this.cmdCancel.TabIndex = 41;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(228, 279);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(80, 25);
            this.cmdOk.TabIndex = 40;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // docGRN
            // 
            this.docGRN.OriginAtMargins = true;
            this.docGRN.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docGRN_PrintPage);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(33, 242);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 42;
            this.txtQuantity.Tag = "number,Required a valid quantity";
            // 
            // cmdChange
            // 
            this.cmdChange.Enabled = false;
            this.cmdChange.Location = new System.Drawing.Point(139, 242);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(75, 23);
            this.cmdChange.TabIndex = 43;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(246, 242);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(74, 17);
            this.chkPrint.TabIndex = 44;
            this.chkPrint.Text = "Print GRN";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // AddReceivedOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 316);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.cmdChange);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.cmbOrder);
            this.Controls.Add(this.lbOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddReceivedOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Received Order";
            this.Load += new System.EventHandler(this.AddReceivedItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Label lbOrder;
        internal System.Windows.Forms.ListView lstItems;
        internal System.Windows.Forms.ColumnHeader ColRef;
        internal System.Windows.Forms.ColumnHeader ColItemNo;
        private System.Windows.Forms.ColumnHeader colDescription;
        internal System.Windows.Forms.ColumnHeader ColQuantity;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;
        private System.Drawing.Printing.PrintDocument docGRN;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.CheckBox chkPrint;
    }
}