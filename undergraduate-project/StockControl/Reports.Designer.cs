namespace StockControl
{
    partial class Reports
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
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pToolBar = new System.Windows.Forms.Panel();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.lbTo = new System.Windows.Forms.Label();
            this.optSelectedPeriod = new System.Windows.Forms.RadioButton();
            this.optEntirePeriod = new System.Windows.Forms.RadioButton();
            this.dteTo = new System.Windows.Forms.DateTimePicker();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.pToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.AutoSize = true;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.DisplayGroupTree = false;
            this.ReportViewer.Location = new System.Drawing.Point(0, 47);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.SelectionFormula = "";
            this.ReportViewer.ShowGroupTreeButton = false;
            this.ReportViewer.Size = new System.Drawing.Size(934, 506);
            this.ReportViewer.TabIndex = 0;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // pToolBar
            // 
            this.pToolBar.Controls.Add(this.cmdFilter);
            this.pToolBar.Controls.Add(this.lbTo);
            this.pToolBar.Controls.Add(this.optSelectedPeriod);
            this.pToolBar.Controls.Add(this.optEntirePeriod);
            this.pToolBar.Controls.Add(this.dteTo);
            this.pToolBar.Controls.Add(this.dteFrom);
            this.pToolBar.Location = new System.Drawing.Point(0, 0);
            this.pToolBar.Name = "pToolBar";
            this.pToolBar.Size = new System.Drawing.Size(934, 41);
            this.pToolBar.TabIndex = 1;
            this.pToolBar.Visible = false;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(508, 11);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 5;
            this.cmdFilter.Text = "Filter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Enabled = false;
            this.lbTo.Location = new System.Drawing.Point(351, 16);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(28, 13);
            this.lbTo.TabIndex = 4;
            this.lbTo.Text = "- to -";
            // 
            // optSelectedPeriod
            // 
            this.optSelectedPeriod.AutoSize = true;
            this.optSelectedPeriod.Location = new System.Drawing.Point(132, 12);
            this.optSelectedPeriod.Name = "optSelectedPeriod";
            this.optSelectedPeriod.Size = new System.Drawing.Size(99, 17);
            this.optSelectedPeriod.TabIndex = 3;
            this.optSelectedPeriod.TabStop = true;
            this.optSelectedPeriod.Text = "Selected period";
            this.optSelectedPeriod.UseVisualStyleBackColor = true;
            this.optSelectedPeriod.CheckedChanged += new System.EventHandler(this.optSelectedPeriod_CheckedChanged);
            // 
            // optEntirePeriod
            // 
            this.optEntirePeriod.AutoSize = true;
            this.optEntirePeriod.Checked = true;
            this.optEntirePeriod.Location = new System.Drawing.Point(24, 12);
            this.optEntirePeriod.Name = "optEntirePeriod";
            this.optEntirePeriod.Size = new System.Drawing.Size(84, 17);
            this.optEntirePeriod.TabIndex = 2;
            this.optEntirePeriod.TabStop = true;
            this.optEntirePeriod.Text = "Entire period";
            this.optEntirePeriod.UseVisualStyleBackColor = true;
            // 
            // dteTo
            // 
            this.dteTo.CustomFormat = "yyyy/MM/dd";
            this.dteTo.Enabled = false;
            this.dteTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteTo.Location = new System.Drawing.Point(385, 12);
            this.dteTo.Name = "dteTo";
            this.dteTo.Size = new System.Drawing.Size(107, 20);
            this.dteTo.TabIndex = 1;
            // 
            // dteFrom
            // 
            this.dteFrom.CustomFormat = "yyyy/MM/dd";
            this.dteFrom.Enabled = false;
            this.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteFrom.Location = new System.Drawing.Point(238, 12);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Size = new System.Drawing.Size(107, 20);
            this.dteFrom.TabIndex = 0;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 545);
            this.Controls.Add(this.pToolBar);
            this.Controls.Add(this.ReportViewer);
            this.Name = "Reports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ClientSizeChanged += new System.EventHandler(this.Reports_ClientSizeChanged);
            this.Load += new System.EventHandler(this.Reports_Load);
            this.pToolBar.ResumeLayout(false);
            this.pToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.Panel pToolBar;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.RadioButton optSelectedPeriod;
        private System.Windows.Forms.RadioButton optEntirePeriod;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.DateTimePicker dteTo;
        private System.Windows.Forms.Label lbTo;
    }
}