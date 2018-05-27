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
    public partial class Invoices : Form
    {
        //Initialized invoices, solditems, customers
        List<Invoice> invoices = new List<Invoice>();
        List<SoldItem> solditems = new List<SoldItem>();
        List<Customer> customers = new List<Customer>();
      
        public Invoices()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void Invoices_Load(object sender, EventArgs e)
        {
            dteFrom.MaxDate = DateTime.Today;
            dteTo.MaxDate = DateTime.Today;
            FillInvoiceList(null,new Dictionary<String, String>()); // fill invoices
            customers = DataAccess.GetCustomers(new Dictionary<String, String>()); //get customer list
            
            foreach (Customer a in customers)
            {
                    cmbfltCustomer.Items.Add(String.Format("{0} [CUS{1:0000}]", a.Name, a.CusCode)); // add customers to combobox
            }
           
        }

        private void InvoiceToListViewItem(ListView listview, Invoice invoice)
        {
            //add invoice to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("INV{0:0000}", invoice.InvoiceNo));
            listItem.SubItems.Add(String.Format("CUS{0:0000}",invoice.Customer.CusCode));
            listItem.SubItems.Add(invoice.Customer.Name);
            listItem.SubItems.Add(String.Format("{0:yyyy-MM-dd}",invoice.InvoiceDate));
            listItem.SubItems.Add(invoice.IsCredit.ToString());
            listItem.SubItems.Add(invoice.IsPaid.ToString());
            listItem.SubItems.Add(String.Format("{0:f}",invoice.Total));
        }

        private void SoldItemToListViewItem(ListView listview, SoldItem item)
        {
            // add solditem to list view
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("ITM{0:0000}", item.Item.ItemCode));
            listItem.SubItems.Add(item.Item.Description);
            listItem.SubItems.Add(item.Quantity.ToString());
            listItem.SubItems.Add(String.Format("{0:f}",item.UnitPrice));
            listItem.SubItems.Add(String.Format("{0:f}",(Convert.ToDouble(item.Quantity) * item.UnitPrice)));

        }

        private void lstInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInvoices.SelectedItems.Count > 0) // check whether invoice is selected
            {  
                //clear current solditems and add new solditems 
                lstItems.Items.Clear();
                solditems.Clear();
                solditems = DataAccess.GetSoldItems(invoices[lstInvoices.SelectedItems[0].Index]);
                foreach (SoldItem a in solditems)
                {
                    SoldItemToListViewItem(lstItems, a);
                }
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
            //hide filter panel when lostfocus
            chkfilter.Checked = false;
        }

        private void chkCode_CheckedChanged(object sender, EventArgs e)
        {
            txtfltCode.Enabled = chkCode.Checked;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            cmbfltCustomer.Enabled = chkCustomer.Checked;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dteFrom.Enabled = chkDate.Checked;
            dteTo.Enabled = chkDate.Checked;
        }

        private void chkCredit_CheckedChanged(object sender, EventArgs e)
        {
            cmbCredit.Enabled = chkCredit.Checked;
        }

        private void chkPaid_CheckedChanged(object sender, EventArgs e)
        {
            cmbPaid.Enabled = chkPaid.Checked;
        }

        private void FillInvoiceList(Customer customer,  IDictionary<String, String> filter)
        {
            //get invoice and fill listview
            invoices.Clear();
            lstInvoices.Items.Clear();
            lstItems.Items.Clear();
            solditems.Clear();
            invoices = DataAccess.GetInvoices(customer, filter);
            foreach (Invoice a in invoices)
            {
                InvoiceToListViewItem(lstInvoices, a);
            }
        }

        //search 
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //create filters for searching
            IDictionary<String, String> filter = new Dictionary<String, String>();
            Customer customer = null;
            if (chkCode.Checked && txtfltCode.Text.Length>0)
                filter.Add("Code", Convert.ToInt32(txtfltCode.Text).ToString());
            if (chkCustomer.Checked)
            {
                if (cmbfltCustomer.SelectedIndex >= 0)
                    customer = customers[cmbfltCustomer.SelectedIndex];
            }
            if (chkDate.Checked)
            {
               filter.Add("from", String.Format("{0:yyyy-MM-dd}",dteFrom.Value));
               filter.Add("to", String.Format("{0:yyyy-MM-dd}", dteTo.Value.AddDays(1)));
                
            }
            if (chkPaid.Checked){
                if (cmbPaid.SelectedIndex >= 0)
                filter.Add("Paid", cmbPaid.SelectedIndex.ToString());
                }
            if (chkCredit.Checked){
                if (cmbCredit.SelectedIndex >= 0)
                    filter.Add("Credit", cmbCredit.SelectedIndex.ToString());
             }
             FillInvoiceList(customer, filter);  // fill listview with search results
            chkfilter.Checked = false;
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            // show all items
            FillInvoiceList(null, new Dictionary<String, String>());
        }
    }
}