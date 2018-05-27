namespace StockControl
{
    partial class TransactionLog
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
            this.lstTransaction = new System.Windows.Forms.ListView();
            this.colUser = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.grpdetails = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.grpdetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTransaction
            // 
            this.lstTransaction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser,
            this.colTime,
            this.colDescription});
            this.lstTransaction.FullRowSelect = true;
            this.lstTransaction.GridLines = true;
            this.lstTransaction.Location = new System.Drawing.Point(5, 7);
            this.lstTransaction.MultiSelect = false;
            this.lstTransaction.Name = "lstTransaction";
            this.lstTransaction.Size = new System.Drawing.Size(748, 295);
            this.lstTransaction.TabIndex = 39;
            this.lstTransaction.UseCompatibleStateImageBehavior = false;
            this.lstTransaction.View = System.Windows.Forms.View.Details;
            this.lstTransaction.SelectedIndexChanged += new System.EventHandler(this.lstTransaction_SelectedIndexChanged);
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 140;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 530;
            // 
            // grpdetails
            // 
            this.grpdetails.Controls.Add(this.txtDescription);
            this.grpdetails.Controls.Add(this.txtTime);
            this.grpdetails.Controls.Add(this.txtUser);
            this.grpdetails.Controls.Add(this.lbDescription);
            this.grpdetails.Controls.Add(this.lbTime);
            this.grpdetails.Controls.Add(this.lbUser);
            this.grpdetails.Location = new System.Drawing.Point(5, 319);
            this.grpdetails.Name = "grpdetails";
            this.grpdetails.Size = new System.Drawing.Size(372, 144);
            this.grpdetails.TabIndex = 40;
            this.grpdetails.TabStop = false;
            this.grpdetails.Text = "Details";
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Location = new System.Drawing.Point(111, 72);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(248, 66);
            this.txtDescription.TabIndex = 5;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(111, 42);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(167, 20);
            this.txtTime.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(111, 16);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(167, 20);
            this.txtUser.TabIndex = 3;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(8, 72);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 2;
            this.lbDescription.Text = "Description";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(8, 45);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(33, 13);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "Time:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(8, 20);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(32, 13);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "User:";
            // 
            // TransactionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 475);
            this.Controls.Add(this.grpdetails);
            this.Controls.Add(this.lstTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionLog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Log";
            this.Load += new System.EventHandler(this.TransactionLog_Load);
            this.grpdetails.ResumeLayout(false);
            this.grpdetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstTransaction;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.GroupBox grpdetails;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtUser;
    }
}