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
    public partial class AddCategory : Form
    {
        ItemCategory category;
        public AddCategory()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtCategory };
            if (validation.validate(Fld)) //validate inputs
            {
                category = new ItemCategory(); //Initialized new category 
                category.Name = txtCategory.Text;

                if (DataAccess.InsertItemCategory(category) == 1) //add new catagory
                {
                    //Show message if success 
                    MessageBox.Show("New Category is added successfully, Category code=" + String.Format("CAT{0:000}", category.Id), "New Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(DataAccess.GetError(), "New Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        public ItemCategory GetNewCategory()
        {
            // return newly added catagory
            return category;
        }
    }
}