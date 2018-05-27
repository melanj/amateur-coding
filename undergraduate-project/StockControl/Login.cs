using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StockControl
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
         }

        private void OK_Click(object sender, EventArgs e)
        {
            Control[] Fld = { UsernameTextBox,PasswordTextBox };
            if (validation.validate(Fld))  //validate inputs
            {
                if (Authentication.authenticate(this.UsernameTextBox.Text, this.PasswordTextBox.Text))
                { //authenticate user
                this.Close();
                this.Dispose();
            }
            else{
                // show error message if invalid username/password
                MessageBox.Show("Username and Password Combination is Invalid", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        else MessageBox.Show("Username and password required", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information); // show error message if validation error occurs
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // focus Password field when enter key pressed
                PasswordTextBox.Focus();
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Perform ok button click when enter key pressed
                OK.PerformClick();
        }
    }
}