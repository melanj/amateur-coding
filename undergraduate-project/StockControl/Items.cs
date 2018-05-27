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
    public partial class Items : Form
    {
        //Initialized items,categories,suppliers 
        List<Item> items = new List<Item>();
        List<ItemCategory> categories;
        List<Supplier> suppliers;
        Item SelectedItem;
        ListViewItem SelectedListItem;
        public Items()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            if (Authentication.GetUser().Category < 3) // check whether administrator or manager
            {
                //Enable add and remove button
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = true;
            }

            categories = DataAccess.GetItemCategories(); // get category list
            suppliers = DataAccess.GetSuppliers(new Dictionary<String, String>()); // get supplier list

            FillItemList(null,null,new Dictionary<String, String>()); // fill item listview

            foreach (ItemCategory a in categories)
            {
                cmbfltCategory.Items.Add(a.Name); // add categories to combobox
            }
            foreach (Supplier a in suppliers)
            {
                cmbfltSupplier.Items.Add(a.Name);  // add suppliers to combobox
            } 
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count > 0) // check whether item is selected
            {
                SelectedListItem = lstItems.SelectedItems[0];
                SelectedItem = items[SelectedListItem.Index];
                txtItemCode.Text = String.Format("ITM{0:0000}", SelectedItem.ItemCode);
                txtDescription.Text = SelectedItem.Description;
                txtCategory.Text = SelectedItem.Category.Name;
                txtSupplier.Text = SelectedItem.Supplier.Name;
                txtPrice.Text = String.Format("{0:0.00}", SelectedItem.UnitPrice);
                txtQuantity.Text = SelectedItem.Quantity.ToString();
                txtMinOrderQty.Text = SelectedItem.MinOrderQty.ToString();
                txtReorderQty.Text = SelectedItem.ReorderQty.ToString();
                // enable edit item group if user = administrator or manager 
                grpitem.Enabled = (Authentication.GetUser().Category < 3) ? true : false;
            }
            else grpitem.Enabled = false;
        }

        private void ItemToListViewItem(ListView listview, Item item) {
            // add item to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("ITM{0:0000}", item.ItemCode));
            listItem.SubItems.Add(item.Description);
            listItem.SubItems.Add(item.Category.Name);
            listItem.SubItems.Add(String.Format("{0:0.00}", item.UnitPrice));
            listItem.SubItems.Add(item.Quantity.ToString());
            listItem.SubItems.Add(item.MinOrderQty.ToString());
            listItem.SubItems.Add(item.ReorderQty.ToString());
            listItem.SubItems.Add(item.Supplier.Name);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddItem fAddItem = new AddItem(); //Initialized AddItem form
            if (fAddItem.ShowDialog() == DialogResult.OK)  // show AddItem form and if success
            {
                //get newly add Item form AddItem form and add to list
                items.Add(fAddItem.GetNewItem());
                ItemToListViewItem(lstItems, fAddItem.GetNewItem());
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtDescription, txtQuantity, txtMinOrderQty, txtPrice, txtReorderQty};
            if (validation.validate(Fld)) //validate inputs
            {
                SelectedItem.Description = txtDescription.Text;
                SelectedItem.Quantity = Convert.ToInt32(txtQuantity.Text);
                SelectedItem.MinOrderQty = Convert.ToInt32(txtMinOrderQty.Text);
                SelectedItem.ReorderQty = Convert.ToInt32(txtReorderQty.Text);
                SelectedItem.UnitPrice = Convert.ToDouble(txtPrice.Text);
                if (DataAccess.UpdateItem(SelectedItem) == 1) // update item in database
                {
                    //Show message and update details if success 
                    MessageBox.Show("Updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectedListItem.SubItems[1].Text = SelectedItem.Description;
                    SelectedListItem.SubItems[3].Text = String.Format("{0:0.00}", SelectedItem.UnitPrice);
                    SelectedListItem.SubItems[4].Text = SelectedItem.Quantity.ToString();
                    SelectedListItem.SubItems[5].Text = SelectedItem.MinOrderQty.ToString();
                    SelectedListItem.SubItems[6].Text = SelectedItem.ReorderQty.ToString();
                }
                else
                {
                    if (!DataAccess.IsError()) //if not an error
                        MessageBox.Show("No change detected!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question); //if not an error
                    else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); //Show message if no change detected
                }
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private void chkfilter_CheckedChanged(object sender, EventArgs e)
        {
            // hide/show filter panel according to "filers" click 
            pnlfilter.Visible = chkfilter.Checked;
            if (pnlfilter.Visible) cmdSearch.Focus();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //create filters for searching
            IDictionary<String, String> filter = new Dictionary<String, String>();
            Supplier supplier = null;
            ItemCategory category = null;
            if (chkCode.Checked)
                filter.Add("Code", Convert.ToInt32(txtfltCode.Text).ToString());
            if (chkDescription.Checked)
                filter.Add("Description", txtfltDescription.Text);
            if (chkCategory.Checked)
            {
                if(cmbfltCategory.SelectedIndex>=0)
                category = categories[cmbfltCategory.SelectedIndex];
            }
            if (chkSupplier.Checked)
            {
                if (cmbfltSupplier.SelectedIndex >= 0)
                supplier = suppliers[cmbfltSupplier.SelectedIndex];
            }
            if (chkiflowqty.Checked)
                filter.Add("reorderonly", "true");

            FillItemList(supplier, category, filter); // fill listview with search results
            chkfilter.Checked = false;
        }

        private void FillItemList(Supplier supplier, ItemCategory category, IDictionary<String, String> filter)
        {
            // fill item listview
            items.Clear();
            lstItems.Items.Clear();
            items = DataAccess.GetItems(supplier, category, filter);
            foreach (Item a in items)
            {
                ItemToListViewItem(lstItems, a);
            }
        }

        private void chkCode_CheckedChanged(object sender, EventArgs e)
        {
            txtfltCode.Enabled = chkCode.Checked;
        }

        private void chkDescription_CheckedChanged(object sender, EventArgs e)
        {
            txtfltDescription.Enabled = chkDescription.Checked;
        }

        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            cmbfltCategory.Enabled = chkCategory.Checked;
        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            cmbfltSupplier.Enabled = chkSupplier.Checked;
        }

        private void pnlfilter_Leave(object sender, EventArgs e)
        {
            chkfilter.Checked = false;
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            //show all items
            FillItemList(null, null, new Dictionary<String, String>());
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove item: \"" + SelectedItem.Description + "\"", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                if (DataAccess.DeleteItem(SelectedItem) == 1) // delete item from database
                {
                    //Show message and remove item from listview if success 
                    lstItems.Items.Remove(SelectedListItem);
                    items.Remove(SelectedItem);
                    MessageBox.Show("Deleted Successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
        }
    }
}