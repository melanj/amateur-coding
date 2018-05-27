namespace StockControl
{
    partial class AddPayment
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
            this.cmbInvoice = new System.Windows.Forms.ComboBox();
            this.lbInvoice = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.txtAmout = new System.Windows.Forms.TextBox();
            this.lbAmout = new System.Windows.Forms.Label();
            this.lstPayments = new System.Windows.Forms.ListView();
            this.colRef = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colBalance = new System.Windows.Forms.ColumnHeader();
            this.lbDetails = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.docReceipt = new System.Drawing.Printing.PrintDocument();
            this.lbInvoiceDetails = new System.Windows.Forms.Label();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbInvoice
            // 
            this.cmbInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoice.FormattingEnabled = true;
            this.cmbInvoice.Location = new System.Drawing.Point(76, 53);
            this.cmbInvoice.Name = "cmbInvoice";
            this.cmbInvoice.Size = new System.Drawing.Size(100, 21);
            this.cmbInvoice.TabIndex = 34;
            this.cmbInvoice.Tag = "text,Please Select Invoice";
            this.cmbInvoice.SelectedIndexChanged += new System.EventHandler(this.cmbInvoice_SelectedIndexChanged);
            // 
            // lbInvoice
            // 
            this.lbInvoice.AutoSize = true;
            this.lbInvoice.Location = new System.Drawing.Point(13, 57);
            this.lbInvoice.Name = "lbInvoice";
            this.lbInvoice.Size = new System.Drawing.Size(42, 13);
            this.lbInvoice.TabIndex = 33;
            this.lbInvoice.Text = "Invoice";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(76, 21);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(259, 21);
            this.cmbCustomer.TabIndex = 32;
            this.cmbCustomer.Tag = "text,Please Select Customer";
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(13, 25);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(51, 13);
            this.lbCustomer.TabIndex = 31;
            this.lbCustomer.Text = "Customer";
            // 
            // txtAmout
            // 
            this.txtAmout.Location = new System.Drawing.Point(76, 262);
            this.txtAmout.Name = "txtAmout";
            this.txtAmout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmout.Size = new System.Drawing.Size(100, 20);
            this.txtAmout.TabIndex = 36;
            this.txtAmout.Tag = "money,Required a valid";
            // 
            // lbAmout
            // 
            this.lbAmout.AutoSize = true;
            this.lbAmout.Location = new System.Drawing.Point(13, 266);
            this.lbAmout.Name = "lbAmout";
            this.lbAmout.Size = new System.Drawing.Size(43, 13);
            this.lbAmout.TabIndex = 35;
            this.lbAmout.Text = "Amount";
            // 
            // lstPayments
            // 
            this.lstPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRef,
            this.colDate,
            this.colAmount,
            this.colBalance});
            this.lstPayments.FullRowSelect = true;
            this.lstPayments.GridLines = true;
            this.lstPayments.Location = new System.Drawing.Point(16, 149);
            this.lstPayments.MultiSelect = false;
            this.lstPayments.Name = "lstPayments";
            this.lstPayments.Size = new System.Drawing.Size(344, 97);
            this.lstPayments.TabIndex = 37;
            this.lstPayments.UseCompatibleStateImageBehavior = false;
            this.lstPayments.View = System.Windows.Forms.View.Details;
            // 
            // colRef
            // 
            this.colRef.Text = "Ref ID";
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
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Location = new System.Drawing.Point(13, 89);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(39, 13);
            this.lbDetails.TabIndex = 33;
            this.lbDetails.Text = "Details";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(286, 298);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 39;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Image = global::StockControl.Properties.Resources.accept_icon16x16;
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(194, 298);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 38;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // docReceipt
            // 
            this.docReceipt.OriginAtMargins = true;
            this.docReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docReceipt_PrintPage);
            // 
            // lbInvoiceDetails
            // 
            this.lbInvoiceDetails.AutoSize = true;
            this.lbInvoiceDetails.Location = new System.Drawing.Point(13, 121);
            this.lbInvoiceDetails.Name = "lbInvoiceDetails";
            this.lbInvoiceDetails.Size = new System.Drawing.Size(30, 13);
            this.lbInvoiceDetails.TabIndex = 33;
            this.lbInvoiceDetails.Text = "-info-";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(235, 262);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(87, 17);
            this.chkPrint.TabIndex = 40;
            this.chkPrint.Text = "Print Receipt";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // AddPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 332);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lstPayments);
            this.Controls.Add(this.txtAmout);
            this.Controls.Add(this.lbAmout);
            this.Controls.Add(this.cmbInvoice);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.lbInvoiceDetails);
            this.Controls.Add(this.lbInvoice);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lbCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Payment";
            this.Load += new System.EventHandler(this.AddPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInvoice;
        private System.Windows.Forms.Label lbInvoice;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.TextBox txtAmout;
        private System.Windows.Forms.Label lbAmout;
        private System.Windows.Forms.ListView lstPayments;
        private System.Windows.Forms.ColumnHeader colRef;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;
        private System.Drawing.Printing.PrintDocument docReceipt;
        private System.Windows.Forms.Label lbInvoiceDetails;
        private System.Windows.Forms.CheckBox chkPrint;
    }
}