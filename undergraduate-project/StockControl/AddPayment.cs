using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using StockControl.Model;

namespace StockControl
{
    public partial class AddPayment : Form
    {
        //Initialized customers, invoices,payments 
        List<Customer> customers;
        List<Invoice> invoices = new List<Invoice>();
        List<Payment> payments= new List<Payment>();
        Payment payment;
        double totalPaid=0;
        double balance = 0;

        public AddPayment()
        {
            InitializeComponent();
        }

        private void AddPayment_Load(object sender, EventArgs e)
        {
            customers = DataAccess.GetCustomers(new Dictionary<String, String>()); // get customer list
            foreach (Customer a in customers)
            {
                if (a.Type == 1) // add customers to combobox except standad customer 
                    cmbCustomer.Items.Add(String.Format("{0} [{1:0000}]",a.Name, a.CusCode));
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear and add new deatils accrding to selected customer
            cmbInvoice.Items.Clear();
            invoices.Clear();
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Paid", "0");
            invoices = DataAccess.GetInvoices(customers[cmbCustomer.SelectedIndex + 1], filter);
            foreach (Invoice a in invoices)
            {
                cmbInvoice.Items.Add(String.Format("{0:0000}", a.InvoiceNo));
            }
        }

        private void cmbInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear and add deatils accrding to selected invoice
            lstPayments.Items.Clear();
            payments.Clear();
            totalPaid = 0;
            payments = DataAccess.GetPayments(invoices[cmbInvoice.SelectedIndex],new Dictionary<String,String>());
            foreach (Payment a in payments)
            {
                totalPaid += a.Amount;
                PaymentToListViewItem(lstPayments, a);
            }
            balance = invoices[cmbInvoice.SelectedIndex].Total - totalPaid;
            lbInvoiceDetails.Text = String.Format("Invoice Value: {0:f} Date: {1:MMM dd, yyyy} Balance: {2:f}", invoices[cmbInvoice.SelectedIndex].Total, invoices[cmbInvoice.SelectedIndex].InvoiceDate, balance);
        }

        private void PaymentToListViewItem(ListView listview, Payment payment)
        {
            //add payment deatils to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("{0:0000}", payment.Ref));
            listItem.SubItems.Add(String.Format("{0:yyyy-MM-dd}", payment.PaidDate));
            listItem.SubItems.Add(String.Format("{0:f}", payment.Amount));
            listItem.SubItems.Add(String.Format("{0:f}", payment.Balance));

        }

        //adding payment
        private void cmdOk_Click(object sender, EventArgs e)
        {
            Control[] Fld = { cmbCustomer, cmbInvoice,txtAmout };

            if (validation.validate(Fld)) //validate inputs
            {
                if (balance.CompareTo(Convert.ToDouble(txtAmout.Text))>=0) //check whether balance >= amount
                {
                    payment = new Payment(); //Initialized new payment
                    payment.Invoice = invoices[cmbInvoice.SelectedIndex];
                    payment.Amount = Convert.ToDouble(txtAmout.Text);
                    payment.Balance = balance - Convert.ToDouble(txtAmout.Text);
                    payment.PaidDate = DateTime.Now;
                    if (DataAccess.InsertPayment(payment) == 1) { // insert payment to databasesa
                        if (payment.Balance == 0)
                        {
                            invoices[cmbInvoice.SelectedIndex].IsPaid = true;
                            DataAccess.UpdateInvoice(invoices[cmbInvoice.SelectedIndex]);
                        }
                        //Show message if success 
                        MessageBox.Show("Payment Added Successfully", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (chkPrint.Checked)
                        {
                            try
                          {
                            docReceipt.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                            docReceipt.Print(); // print receipt
                         }
                         catch (InvalidPrinterException)
                         {
                             // show error message if error occurs while printing
                            MessageBox.Show("An error occurred while printing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         }
                        }
                        // close and dispose this form
                        this.Close();
                        this.Dispose();
                    }
                    else {
                        // show error message if error occurs
                        MessageBox.Show("An error occurred while processing your request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else{
                    MessageBox.Show("Amount cannot exceed balance", "info", MessageBoxButtons.OK, MessageBoxIcon.Information); // show error message if Amount exceed balance
                }
             
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information); // show error message if validation error occurs
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void docReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // prepair receipt for printing  
            Document.Receipt(payment, payments, e);
        }

    }
}