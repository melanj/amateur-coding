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
    public partial class Suppliers : Form
    {
        //Initialized variables
        List<Supplier> suppliers = new List<Supplier>();
        Supplier SelectedSupplier;
        ListViewItem SelectedListItem;

        public Suppliers()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            if (Authentication.GetUser().Category < 3)
            {
                // enable add and remove button
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = true;
            }
            FillSupplierList(new Dictionary<String, String>()); // fill supplier listview
        }

        private void SupplierToListViewItem(ListView listview, Supplier supplier)
        {
            // add supplier to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("SUP{0:0000}", supplier.SupCode));
            listItem.SubItems.Add(supplier.Name);
            listItem.SubItems.Add(supplier.Address);
            listItem.SubItems.Add(supplier.Phone);
            listItem.SubItems.Add(supplier.Email);
            listItem.SubItems.Add(supplier.Description.Replace("\r\n",", "));
        } 

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddSupplier fAddSupplier = new AddSupplier(); //Initialized AddSupplier form
            if (fAddSupplier.ShowDialog() == DialogResult.OK) // show AddSupplier form and if success
            {
                //get newly add supplier form AddSupplier form and add to list
                suppliers.Add(fAddSupplier.GetNewSupplier());
                SupplierToListViewItem(lstSuppliers, fAddSupplier.GetNewSupplier());
            }
        }

        private void lstSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSuppliers.SelectedItems.Count > 0) // check whether Supplier is selected
            {
                SelectedListItem = lstSuppliers.SelectedItems[0];
                SelectedSupplier = suppliers[SelectedListItem.Index];
                txtID.Text = String.Format("SUP{0:0000}", SelectedSupplier.SupCode);
                txtName.Text = SelectedSupplier.Name;
                txtAddress.Text = SelectedSupplier.Address;
                txtPhone.Text = SelectedSupplier.Phone;
                txtEmail.Text = SelectedSupplier.Email;
                txtDescription.Text = SelectedSupplier.Description;
                // enable edit Supplier group if administrator or manager 
                grpSupplier.Enabled = (Authentication.GetUser().Category < 3) ? true : false;
            }
            else grpSupplier.Enabled = false;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtAddress, txtPhone, txtEmail };
            if (validation.validate(Fld)) //validate inputs
            {
                SelectedSupplier.Address = txtAddress.Text;
                SelectedSupplier.Phone = txtPhone.Text;
                SelectedSupplier.Email = txtEmail.Text;
                SelectedSupplier.Description = txtDescription.Text;
                if (DataAccess.UpdateSupplier(SelectedSupplier) == 1) // update Supplier from database
                {
                    //Show message and update details if success 
                    MessageBox.Show("Updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectedListItem.SubItems[2].Text = SelectedSupplier.Address;
                    SelectedListItem.SubItems[3].Text = SelectedSupplier.Phone;
                    SelectedListItem.SubItems[4].Text = SelectedSupplier.Email;
                    SelectedListItem.SubItems[5].Text = SelectedSupplier.Description;
                }
                else
                {
                    if (!DataAccess.IsError()) //if not an error
                        MessageBox.Show("No change detected!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question); //Show message if no change detected
                    else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);// show error message if error occurs
                } 
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);// show error message if validation error occurs
        }

        private void chkfilter_CheckedChanged(object sender, EventArgs e)
        {
            // hide/show filter panel according to "filers" click 
            pnlfilter.Visible = chkfilter.Checked;
            if (pnlfilter.Visible) cmdSearch.Focus();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //prepair filters for searching
            IDictionary<String, String> filter = new Dictionary<String, String>();
            if (chkCode.Checked)
                filter.Add("Code", Convert.ToInt32(txtfltCode.Text).ToString());
            if (chkName.Checked)
                filter.Add("Name", txtfltName.Text);
            if (chkAddress.Checked)
                filter.Add("Address", txtfltAddress.Text);
            if (chkPhone.Checked)
                filter.Add("Phone", txtfltPhone.Text);
            if (chkEmail.Checked)
                filter.Add("Email", txtfltEmail.Text);
            FillSupplierList(filter); // fill listview with search results
            chkfilter.Checked = false;
        }

        private void FillSupplierList(IDictionary<String, String> filter)
        {
            suppliers.Clear();
            lstSuppliers.Items.Clear();
            suppliers = DataAccess.GetSuppliers(filter); // get supplier list
            foreach (Supplier a in suppliers)
            {
                SupplierToListViewItem(lstSuppliers, a); // add supplier to listview
            }
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

        private void pnlfilter_Leave(object sender, EventArgs e)
        {
            chkfilter.Checked = false;
        }

        private void txtfltCode_Validating(object sender, CancelEventArgs e)
        {
            txtfltCode.Text = String.Format("{0:0000}", Convert.ToInt32(txtfltCode.Text));
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            // show all suppliers
            FillSupplierList(new Dictionary<String, String>());
        }

        //remove supplier
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstSuppliers.SelectedItems.Count > 0) // check whether Supplier is selected
            {
                if (MessageBox.Show("Are you sure you want to remove supplier: \"" + SelectedSupplier.Name +"\"", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                if (DataAccess.DeleteSupplier(SelectedSupplier) == 1) // remove supplier from database
                {
                  //  Show message and remove supplier from listview if success 
                    lstSuppliers.Items.Remove(SelectedListItem);
                    suppliers.Remove(SelectedSupplier);
                    MessageBox.Show("Deleted Successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
        }
    }
}