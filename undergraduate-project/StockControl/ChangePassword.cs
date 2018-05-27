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
    public partial class ChangePassword : Form
    {
        //Initialized user
        private User user;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public void SetUser(User user)
        {
            //set user to change password
            this.user = user;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtPasswd, txtRePasswd };
            if (validation.validate(Fld)) //validate inputs
            {
                if (txtPasswd.Text == txtRePasswd.Text) // check password = confrim password 
                {
                   user.Password = txtPasswd.Text;
                   if (DataAccess.UpdateUser(user) == 1) // update user password
                   {
                       //Show message if success 
                       MessageBox.Show("Password for user \"" + user.Name + "\" has been changed", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       this.Close();
                       this.Dispose();
                   }
                   else MessageBox.Show("Unable to change the password on this account due to error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); // show error message if error occurs
                }
                else MessageBox.Show("Both passwords must match!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if password mis-match
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        private void txtPasswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // focus Confirm Password when enter key pressed
                txtRePasswd.Focus();
        }

        private void txtRePasswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // focus OK button when enter key pressed
                cmdOK.Focus();
        }
    }
}