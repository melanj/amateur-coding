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
    public partial class Customers : Form
    {
        //Initialized customers,SelectedCustomer, SelectedListItem
        List<Customer> customers = new List<Customer>();
        Customer SelectedCustomer;
        ListViewItem SelectedListItem;

        public Customers()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            if (Authentication.GetUser().Category < 3) // check whether administrator or manager
            {
                //enable add and remove button
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = true;
            }
            FillCustomerList(new Dictionary<String, String>()); // fill customer list
        }
        private void CustomerToListViewItem(ListView listview, Customer customer)
        {
            //add customer to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("CUS{0:0000}", customer.CusCode));
            listItem.SubItems.Add(customer.Name);
            listItem.SubItems.Add(customer.Address);
            listItem.SubItems.Add(customer.Phone);
            listItem.SubItems.Add(customer.Email);
            listItem.SubItems.Add(customer.Notes.Replace("\r\n", ", "));
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddCustomer fAddCustomer = new AddCustomer(); //Initialized AddCustomer form
            if (fAddCustomer.ShowDialog() == DialogResult.OK) // show AddCustomer form and if success
            {
                //get newly add Customer form Customer form and add to list
                customers.Add(fAddCustomer.GetNewCustomer());
                CustomerToListViewItem(lstCustomers,fAddCustomer.GetNewCustomer());
            }
        }

        // update customer
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Control[] Fld = {  txtAddress, txtPhone, txtEmail };
            if (validation.validate(Fld)) //validate inputs
            {
                SelectedCustomer.Address = txtAddress.Text;
                SelectedCustomer.Phone = txtPhone.Text;
                SelectedCustomer.Email = txtEmail.Text;
                SelectedCustomer.Notes = txtNotes.Text;
                if (DataAccess.UpdateCustomer(SelectedCustomer) == 1) // update customer from database
                {
                    //Show message and update details if success 
                    MessageBox.Show("Updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectedListItem.SubItems[2].Text = SelectedCustomer.Address;
                    SelectedListItem.SubItems[3].Text = SelectedCustomer.Phone;
                    SelectedListItem.SubItems[4].Text = SelectedCustomer.Email;
                    SelectedListItem.SubItems[5].Text = SelectedCustomer.Notes;
                }
                else{
                    if (!DataAccess.IsError()) //if not an error
                        MessageBox.Show("No change detected!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question); //Show message if no change detected
                    else
                        MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); // show error message if error occurs

                }
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItems.Count > 0) // check whether Customer is selected
            {
                SelectedListItem = lstCustomers.SelectedItems[0];
                SelectedCustomer = customers[SelectedListItem.Index];
              
                    txtID.Text = String.Format("CUS{0:0000}", SelectedCustomer.CusCode);
                    txtName.Text = SelectedCustomer.Name;
                    txtAddress.Text = SelectedCustomer.Address;
                    txtPhone.Text = SelectedCustomer.Phone;
                    txtEmail.Text = SelectedCustomer.Email;
                    txtNotes.Text = SelectedCustomer.Notes;
                    // enable edit customer group if administrator or manager , disable if selected customer is standard customer
                    GrpCustomer.Enabled = ((Authentication.GetUser().Category < 3) && (SelectedCustomer.Type == 1)) ? true : false;
            }
            else GrpCustomer.Enabled = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            IDictionary<String, String> filter = new Dictionary<String, String>();
            //create filters
            if (chkCode.Checked)
                filter.Add("Code", txtfltCode.Text);
            if (chkName.Checked)
                filter.Add("Name", txtfltName.Text);
            if (chkAddress.Checked)
                filter.Add("Address", txtfltAddress.Text);
            if (chkPhone.Checked)
                filter.Add("Phone", txtfltPhone.Text);
            if (chkEmail.Checked)
                filter.Add("Email", txtfltEmail.Text);
            
            FillCustomerList(filter); // fill listview with search results
            chkfilter.Checked = false;
        }

        private void FillCustomerList(IDictionary<String, String> filter){
            customers.Clear();
            lstCustomers.Items.Clear();
            customers = DataAccess.GetCustomers(filter); // get customers
            foreach (Customer a in customers)
            {
                CustomerToListViewItem(lstCustomers, a); // add customer to listview
            }
        }

        private void pnlfilter_Leave(object sender, EventArgs e)
        {
            //hide filter panel when lostfocus
            chkfilter.Checked = false;
        }

        private void chkfilter_CheckedChanged(object sender, EventArgs e)
        {
            // hide/show filter panel according to "filers" click 
            pnlfilter.Visible = chkfilter.Checked;
            if (pnlfilter.Visible) cmdSearch.Focus();
        }

        private void chkCode_CheckedChanged(object sender, EventArgs e)
        {
            txtfltCode.Enabled = chkCode.Checked;
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            txtfltName.Enabled = chkName.Checked;
        }

        private void chkAddress_CheckedChanged(object sender, EventArgs e)
        {
            txtfltAddress.Enabled = chkAddress.Checked;
        }

        private void chkPhone_CheckedChanged(object sender, EventArgs e)
        {
            txtfltPhone.Enabled = chkPhone.Checked;
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtfltEmail.Enabled = chkEmail.Checked;
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            FillCustomerList(new Dictionary<String, String>()); // show all customers
        }

        //remove customer
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItems.Count > 0)  // check whether customer is selected
            {
                if (MessageBox.Show("Are you sure you want to remove customer: \"" + SelectedCustomer.Name + "\"", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                if (DataAccess.DeleteCustomer(SelectedCustomer) == 1) //delete customer from database
                {
                    //Show message and remove customer from listview if success   
                    lstCustomers.Items.Remove(SelectedListItem);
                    customers.Remove(SelectedCustomer);
                    MessageBox.Show("Deleted Successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
        }
    }
}