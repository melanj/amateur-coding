using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace StockControl
{
    public partial class Reports : Form
    {
        public int reportType;

        public Reports()
        {
            InitializeComponent();
        }

        public void SetReportSource(ReportClass rpt){
            // set report
            ReportViewer.ReportSource = rpt;
        }

        public void DisplayToolBar(bool visible)
        {
            //set visible status of toolbar
            ReportViewer.Dock = (visible) ?  DockStyle.None: DockStyle.Fill;
            pToolBar.Visible = visible;
        }

        private void Reports_ClientSizeChanged(object sender, EventArgs e)
        {
            if (ReportViewer.Dock == DockStyle.None) {
                ReportViewer.Width = this.Width - 5;
                ReportViewer.Height = this.Height - (pToolBar.Height+5);
                ReportViewer.Top = pToolBar.Height;
            }
        }

        private void optSelectedPeriod_CheckedChanged(object sender, EventArgs e)
        {
            // enable date selector if optSelectedPeriod checked
            dteFrom.Enabled = optSelectedPeriod.Checked;
            dteTo.Enabled = optSelectedPeriod.Checked;
            lbTo.Enabled = optSelectedPeriod.Checked;
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            //update report dataset of selected report accring to select  range 
            switch (reportType)
            {
                case 1:
                    if (optSelectedPeriod.Checked)
                        SetReportSource(DataAccess.Sales(dteFrom.Value, dteTo.Value.AddDays(1)));
                    else
                        SetReportSource(DataAccess.Sales(null, null));
                    break;
                case 2:
                    break;
                case 3:
                    if(optSelectedPeriod.Checked)
                    SetReportSource(DataAccess.StockDemand(dteFrom.Value, dteTo.Value.AddDays(1)));
                    else
                    SetReportSource(DataAccess.StockDemand(null,null));
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // set maxdate to today
            dteFrom.MaxDate = DateTime.Today;
            dteTo.MaxDate = DateTime.Today;
        }

    }
}