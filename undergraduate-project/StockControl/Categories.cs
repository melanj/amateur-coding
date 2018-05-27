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
    public partial class Categories : Form
    {
        //Initialized new categories, Listviewitem
        List<ItemCategory> categories;
        ListViewItem newLstItem;
        public Categories()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            if (Authentication.GetUser().Category < 3) // check whether administrator or manager
            {
                //enable add and remove button
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = true;
            }
            
            categories = DataAccess.GetItemCategories(); // get category list
            foreach (ItemCategory a in categories) //add each item to listview
            {
                newLstItem = lstCategories.Items.Add(String.Format("CAT{0:000}", a.Id));
                newLstItem.SubItems.Add(a.Name);
                  }
        }

        // adding category
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddCategory fAddCategory = new AddCategory(); //Initialized AddCategory form
            if (fAddCategory.ShowDialog() == DialogResult.OK) // show AddCategory form and if success
            {
                //get newly add category form AddCategory form and add to list
                newLstItem = lstCategories.Items.Add(String.Format("CAT{0:000}", fAddCategory.GetNewCategory().Id));
                newLstItem.SubItems.Add(fAddCategory.GetNewCategory().Name);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItems.Count > 0) // check whether category is selected
            {
                if (DataAccess.DeleteCategory(categories[lstCategories.SelectedItems[0].Index]) == 1) // delete category from database
                {
                    //remove category and Show message if success  
                    categories.Remove(categories[lstCategories.SelectedItems[0].Index]);
                    lstCategories.Items.Remove(lstCategories.SelectedItems[0]);
                    MessageBox.Show("Deleted Successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
        }
    }
}