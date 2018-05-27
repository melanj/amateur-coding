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
    public partial class AddCustomer : Form
    {
        Customer customer;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtName, txtAddress,txtPhone,txtEmail };
            if (validation.validate(Fld)) //validate inputs
            {
                customer = new Customer(); //Initialized new Customer
                customer.Name = txtName.Text;
                customer.Address = txtAddress.Text;
                customer.Phone = txtPhone.Text;
                customer.Email = txtEmail.Text;
                customer.Type = 1; //customer type=1 for regular customers
                customer.Notes = txtNotes.Text;
                if (DataAccess.InsertCustomer(customer) == 1) //add new customer
                {
                    //Show message if success 
                    MessageBox.Show("New Customer is added successfully, customer code=" + String.Format("CUS{0:0000}", customer.CusCode), "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show(DataAccess.GetError(), "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if error occurs
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        public Customer GetNewCustomer()
        {
            // return newly added customer
            return customer;
        }
    }
}