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
    public partial class AddInvoice : Form
    {
        //Initialized customers, items, cagegoris, invoice,solditems
        List<Customer> customers; 
        List<Item> items = new List<Item>();
        List<ItemCategory> categories;
        Invoice invoice;
        List<SoldItem> solditems = new List<SoldItem>();
        int itemcount = 0;
        double total = 0;

        public AddInvoice()
        {
            InitializeComponent();
        }

        private void optStandard_CheckedChanged(object sender, EventArgs e)
        {
            // check Cash checkbox when standard customer checked (selected)
            chkCash.Checked = true;  
        }

        private void optRegular_CheckedChanged(object sender, EventArgs e)
        {
            // enable special  when regular customer checked (selected)
            cmbCustomer.Enabled = optRegular.Checked;
            ChkCredit.Enabled = optRegular.Checked;
            lbDiscount.Enabled = optRegular.Checked;
            txtDiscount.Enabled = optRegular.Checked;
            chkCash.AutoCheck = optRegular.Checked;
        }

        private void AddInvoice_Load(object sender, EventArgs e)
        {
            customers = DataAccess.GetCustomers(new Dictionary<String,String>()); // get customer list
            items = DataAccess.GetItems(null,null,null); // get item list
            categories = DataAccess.GetItemCategories(); //get category list

            foreach (ItemCategory a in categories)
            {
                cmbCategory.Items.Add(a.Name); //add category list to category combo box
            }
            foreach (Customer a in customers)
            {
                if(a.Type==1) // add regular customer to customer combo box
                    cmbCustomer.Items.Add(String.Format("{0} [CUS{1:0000}]", a.Name,a.CusCode));
            }
            foreach (Item a in items)
            {
                cmbItems.Items.Add(String.Format("ITM{0:0000} [{1}]", a.ItemCode, a.Description)); //add item list to item combo box
            } 
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ListViewItem SelectedItem;
            double price;
            Item item;
            SoldItem solditem;
            Control[] Fld = { cmbItems };
            if (validation.validate(Fld)) //validate inputs
            {
                item = items[cmbItems.SelectedIndex];
                if (!isAlready(String.Format("ITM{0:0000}", item.ItemCode))) //check item Already added
                {
                    if (item.Quantity >= txtQuantity.Value) // Check required quantity available in stoc
                    {
                        solditem = new SoldItem(); //Initialized new item
                        price = (txtDiscount.Enabled) ? (item.UnitPrice - ((Convert.ToDouble(txtDiscount.Value) / 100) * item.UnitPrice)) : item.UnitPrice;
                        itemcount++;
                        SelectedItem = lstItems.Items.Add(itemcount.ToString());
                        SelectedItem.SubItems.Add(String.Format("ITM{0:0000}", item.ItemCode));
                        SelectedItem.SubItems.Add(item.Description);
                        solditem.Item = item;
                        solditem.UnitPrice = price;
                        solditem.Quantity = Convert.ToInt32(txtQuantity.Value);
                        solditems.Add(solditem);
                        SelectedItem.SubItems.Add(txtQuantity.Value.ToString());
                        SelectedItem.SubItems.Add(String.Format("{0:0.00}", price));
                        SelectedItem.SubItems.Add(String.Format("{0:0.00}", price * Convert.ToDouble(txtQuantity.Value)));
                    }
                    else
                    {
                        // show error message if required quantity not available
                        MessageBox.Show(("Required quantity not in stock!\nRequired=" + txtQuantity.Value.ToString() + "\nAvalable=" + item.Quantity.ToString()), "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // show error message if item already added
                    MessageBox.Show("Item Already in Bucket List!, if you want to adjust quantity, remove it and add again", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdateTotal(); // update total
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private bool isAlready(string itemcode) // function for check item Already added
        {
            int i = 0;
            ListViewItem item;
            for (i = 0; i < lstItems.Items.Count ; i++)
            {
                item = lstItems.Items[i];
                if (item.SubItems[1].Text.Equals(itemcode))
                    {
                    return true;
                }
            }
            return false;
        }

        private void UpdateTotal() // function for update total
        {
            int i = 0;
            total = 0;
            ListViewItem item;
            for (i = 0; i < lstItems.Items.Count; i++)
            {
                item = lstItems.Items[i];
                total += Convert.ToDouble(item.SubItems[5].Text);
            }
            lbTotal.Text = string.Format("{0:0.00}", total);
        }

        private void cmdRemove_Click(object sender, EventArgs e) // function for remove item
        {
            int i = 0;
                ListViewItem item;
                if (lstItems.SelectedItems.Count > 0)
                {
                    itemcount--;
                    solditems.RemoveAt(lstItems.SelectedItems[0].Index);
                    lstItems.Items.Remove(lstItems.SelectedItems[0]);
                    for (i = 0; i < lstItems.Items.Count; i++)
                    {
                        item = lstItems.Items[i];
                        item.SubItems[0].Text = (i + 1).ToString();
                    }
                }
                UpdateTotal();
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e) // function for remove all (claer)
        {
        lstItems.Items.Clear();
        solditems.Clear();
        itemcount = 0;
        UpdateTotal();
        }

        private void cmdProceed_Click(object sender, EventArgs e)
        {
            if (lstItems.Items.Count > 0) {
                invoice = new Invoice(); //Initialized new invoice
                Payment payment = null; 
                if (optRegular.Checked) { // if regular customer
                    if (cmbCustomer.SelectedIndex == -1)
                    {
                        // show error message if customer not selected
                        MessageBox.Show("Please select customer!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else {
                        invoice.Customer = customers[cmbCustomer.SelectedIndex+1];
                        if (ChkCredit.Checked) { // if credit invoice
                        invoice.IsPaid = false;
                        invoice.IsCredit = true;
                        }
                        else { //cash invoice
                            invoice.IsPaid = true;
                            invoice.IsCredit = false;
                            payment = new Payment(); //Initialized new payment
                            payment.PaidDate = DateTime.Now;
                        }
                    }
                }
                else {
                    invoice.Customer = customers[0];
                    invoice.IsPaid = true;
                    invoice.IsCredit = false;
                    payment = new Payment(); //Initialized new payment
                    payment.PaidDate = DateTime.Now;
                }
                invoice.Total = total;
                invoice.InvoiceDate = DateTime.Now;
                if (DataAccess.InsertInvoice(invoice) == 1) { // add current invoice to database
                    if (payment != null)
                    {
                        payment.Invoice = invoice;
                        payment.Amount = invoice.Total;
                        payment.Balance = 0.0;
                        DataAccess.InsertPayment(payment); // insert payment details to current invoice
                    }
                    
                    foreach (SoldItem a in solditems) // add each sold item of current invoice to database
                    {
                        a.Invoice = invoice;
                        DataAccess.InsertSoldItem(a);
                        DataAccess.UpdateItemQuantity(a.Item, -a.Quantity);
                    }
                    //Show message if success 
                    MessageBox.Show("Invoice Added Successfully!", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (chkPrint.Checked) // if print invoice checked
                    {
                        try
                        {
                            // print invoice
                            docInvoice.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                            docInvoice.Print();
                        }
                        catch (InvalidPrinterException)
                        {
                            // show error message if occurs while printing
                            MessageBox.Show("An error occurred while printing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                       
                    }
                    // close and dispose this form
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    // show error message if error occurs
                    MessageBox.Show("An error occurred while processing your request!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else {
                // show error message if validation error occurs
                MessageBox.Show("You cannot add a empty invoice!", "empty invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear items in item combobox and add items in selected category
            cmbItems.Items.Clear();
            items.Clear();
            items = DataAccess.GetItems(null, categories[cmbCategory.SelectedIndex], new Dictionary<String, String>()); // get item list in selected category
            foreach (Item a in items) // add items to combo box
            {
                cmbItems.Items.Add(String.Format("ITM{0:0000} [{1}]", a.ItemCode, a.Description));
            } 
        }

        private void docInvoice_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Prepare printable document according to current invoice   
            Document.Invoice(invoice, solditems, e);
        }

        private void ChkCredit_CheckedChanged(object sender, EventArgs e)
        {
            //uncheck cash checkbox if Credit checkbox checked
            chkCash.Checked = !ChkCredit.Checked ;
        }

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            //uncheck Credit checkbox if cash checkbox checked
            ChkCredit.Checked = !chkCash.Checked;
        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set Quantity textbox to 1 when item selection changed
            txtQuantity.Value = 1;
        }
    }
}