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
    public partial class AddItem : Form
    {
        //Initialized categories,suppliers, item 
        List<ItemCategory> categories; 
        List<Supplier> suppliers;
        Item item; 

        public AddItem()
        {
            InitializeComponent();
        }

        //insert Item to database
        private void cmdOk_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtDescription,txtQuantity,txtMinOrderQty,txtPrice,txtReorderQty,cmbCategory,cmbSupplier };
            if (validation.validate(Fld)) //validate inputs
            {
                item = new Item(); //Initialized new item
                item.Description = txtDescription.Text;
                item.Category = categories[cmbCategory.SelectedIndex];
                item.Quantity = Convert.ToInt32(txtQuantity.Text);
                item.MinOrderQty = Convert.ToInt32(txtMinOrderQty.Text);
                item.ReorderQty = Convert.ToInt32(txtReorderQty.Text);
                item.UnitPrice = Convert.ToDouble(txtPrice.Text);
                item.Supplier = suppliers[cmbSupplier.SelectedIndex];
                if (DataAccess.InsertItem(item) == 1) //insert Item to database
                {
                    //Show message if success 
                    MessageBox.Show("New item is added successfully, item code=" + String.Format("ITM{0:0000}", item.ItemCode), "New item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // show error message if error occurs
                        MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 }
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            categories = DataAccess.GetItemCategories(); // get Categories
            suppliers = DataAccess.GetSuppliers(new Dictionary<String,String>()); //get suppliers
            foreach (ItemCategory a in categories) {
                cmbCategory.Items.Add(a.Name); // add categories to combo box
            }
            foreach (Supplier a in suppliers)
            {
                cmbSupplier.Items.Add(a.Name); // add suppliers to combo box
            } 
        }

        public Item GetNewItem() {
            // return newly added item
            return item; 
        }
    }
}