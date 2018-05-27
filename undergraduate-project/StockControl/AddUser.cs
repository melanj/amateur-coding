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
    public partial class AddUser : Form
    {
        //Initialized user 
        User user;

        public AddUser()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Control[] Fld = { txtUserID,txtPasswd,txtRePasswd,cmdCategory };
            if (validation.validate(Fld)) //validate inputs
            {
                if (txtPasswd.Text == txtRePasswd.Text) //validate is password=confrim password
                {
                    user = new User(); //Initialized new user
                    user.Name = txtUserID.Text;
                    user.FullName = txtFullName.Text;
                    user.Password = txtPasswd.Text;
                    user.Category = cmdCategory.SelectedIndex + 1;
                    if (DataAccess.InsertUser(user) == 1) // add user to database
                    {
                        //Show message if success
                        MessageBox.Show("New user is added successfully", "New user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else MessageBox.Show("Can't add a new user, user may already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); // show error message if error occurs
                }
                else MessageBox.Show("Both passwords must match!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if password not match to confrim password 
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // show error message if validation error occurs
        }

        public User GetNewUser()
        {
            // return newly added user
            return user;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }
    }
}