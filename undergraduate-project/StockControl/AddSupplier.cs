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
    public partial class AddSupplier : Form
    {
        //Initialized supplier
        Supplier supplier;

        public AddSupplier()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        //adding supplier
        private void cmdOk_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtName, txtAddress, txtPhone, txtEmail };
            if (validation.validate(Fld)) //validate inputs
            {
                supplier = new Supplier(); //Initialized new supplier
                supplier.Name = txtName.Text;
                supplier.Address = txtAddress.Text;
                supplier.Phone = txtPhone.Text;
                supplier.Email = txtEmail.Text;
                supplier.Description = txtDescription.Text;
                if (DataAccess.InsertSupplier(supplier) == 1) //add supplier to database
                {
                    //Show message if success 
                    MessageBox.Show("New supplier is added successfully, supplier code=" + String.Format("SUP{0:0000}", supplier.SupCode), "New supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(DataAccess.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); // show error message if error occurs
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        public Supplier GetNewSupplier()
        {
            // return newly added Supplier
            return supplier;
        }
    }
}