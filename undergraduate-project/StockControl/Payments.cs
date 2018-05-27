using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StockControl.Model;

namespace StockControl
{
    public partial class Payments : Form
    {
        //Initialized variables
        List<Payment> payments = new List<Payment>();
        List<Customer> customers;
        List<Invoice> invoices = new List<Invoice>();
        String invoicesList;

        public Payments()
        {
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            dteFrom.MaxDate = DateTime.Today;
            dteTo.MaxDate = DateTime.Today;
            customers = DataAccess.GetCustomers(new Dictionary<String, String>()); // get customer list

            foreach (Customer a in customers)
            {
                cmbfltCustomer.Items.Add(String.Format("{0} [{1:0000}]", a.Name, a.CusCode)); // add customers to combobox
            }
            FillPaymentList(null, new Dictionary<String, String>()); // fill payments listview
            showInvoices();
        }

        private void PaymentToListViewItem(ListView listview, Payment payment)
        {
            // add paymnet to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("{0:0000}", payment.Ref));
            listItem.SubItems.Add(String.Format("{0:0000}", payment.Invoice.InvoiceNo));
            listItem.SubItems.Add(String.Format("{0:yyyy-MM-dd}", payment.PaidDate));
            listItem.SubItems.Add(String.Format("{0:f}", payment.Amount));
            listItem.SubItems.Add(String.Format("{0:f}", payment.Balance));
        }

        private void cmbfltCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInvoices(); 
        }

        // get invoice of selected customer
        private void showInvoices(){
            cmbfltInvoice.Items.Clear();
            invoices.Clear();
            invoicesList = "";
            invoices = DataAccess.GetInvoices(((cmbfltCustomer.SelectedIndex > -1) && chkCustomer.Checked) ? customers[cmbfltCustomer.SelectedIndex] : null, new Dictionary<String, String>());
            foreach (Invoice a in invoices)
            {
                cmbfltInvoice.Items.Add(String.Format("{0:0000}", a.InvoiceNo));
                invoicesList += (a.InvoiceNo.ToString() + ",");

            }
            invoicesList = invoicesList.Trim(',');
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //prepair filters for searching
            IDictionary<String, String> filter = new Dictionary<String, String>();
            Invoice invoice = null;
            if (chkCustomer.Checked && !chkInvoice.Checked)
                if (invoicesList.Length > 0)
                    filter.Add("invoices", invoicesList);
                else {
                    MessageBox.Show("No invoices avalable for selected customer!", "payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            if (chkInvoice.Checked)
            {
                if (cmbfltInvoice.Items.Count >0){
                if (cmbfltInvoice.SelectedIndex >= 0)
                    invoice = invoices[cmbfltInvoice.SelectedIndex];
                else
                    filter.Add("invoices", invoicesList);
                } else {
                    MessageBox.Show("No invoices avalable for selected customer!", "payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (chkDate.Checked)
            {
                filter.Add("from", String.Format("{0:yyyy-MM-dd}", dteFrom.Value));
                filter.Add("to", String.Format("{0:yyyy-MM-dd}", dteTo.Value.AddDays(1)));
            }

            FillPaymentList(invoice, filter); // fill listview with search results
            chkfilter.Checked = false;
        }
        private void FillPaymentList(Invoice invoice, IDictionary<String, String> filter)
        {
            payments.Clear();
            lstPayments.Items.Clear();
            payments = DataAccess.GetPayments(invoice, filter); // get paymnet list
            foreach (Payment a in payments)
            {
                PaymentToListViewItem(lstPayments, a); // add paymnets to listview
            }
        }

        private void chkfilter_CheckedChanged(object sender, EventArgs e)
        {
            // hide/show filter panel according to "filers" click 
            pnlfilter.Visible = chkfilter.Checked;
            if (pnlfilter.Visible) cmdSearch.Focus();
        }

        private void pnlfilter_Leave(object sender, EventArgs e)
        {
            //Show message and remove customer from listview if success 
            pnlfilter.Visible = false;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            // enable search by customer
            cmbfltCustomer.Enabled = chkCustomer.Checked;
            showInvoices();
        }

        private void chkInvoice_CheckedChanged(object sender, EventArgs e)
        {
            cmbfltInvoice.Enabled = chkInvoice.Checked;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dteFrom.Enabled = chkDate.Checked;
            dteTo.Enabled = chkDate.Checked;
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            // show all paymnets
            FillPaymentList(null, new Dictionary<String, String>());
        }
    }
}