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
    public partial class Users : Form
    {
        //Initialized variables
        List<User> users;
        User SelectedUser;
        ListViewItem SelectedListItem;
        string[] category = { "Administrator", "Manager", "Sales" }; 

        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            users = DataAccess.GetUsers(); //get users from database
            foreach (User a in users)
            {
                UserToListViewItem(lstUsers, a); // add user to listview
            }
        }

        private void UserToListViewItem(ListView listview, User user)
        {
            // add user to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(user.Name);
            listItem.SubItems.Add(user.FullName);
            listItem.SubItems.Add(category[user.Category-1]);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                SelectedListItem = lstUsers.SelectedItems[0]; 
                SelectedUser = users[SelectedListItem.Index]; // get selected user
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddUser fAddUser = new AddUser();//Initialized AddUser form
            if (fAddUser.ShowDialog() == DialogResult.OK)  // show AddUser form and if success
            {
                //get newly add user form AddUser form and add to list
                users.Add(fAddUser.GetNewUser());
                UserToListViewItem(lstUsers, fAddUser.GetNewUser());
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0) // check is any user is selected
            {
                // show confirm message box 
                if (MessageBox.Show("Are you sure you want to remove user: " + SelectedUser.Name, "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                //check current user = admin
                if (SelectedUser.Name == "admin" && SelectedUser.Category == 1)
                {
                    MessageBox.Show("Cannot remove administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (DataAccess.DeleteUser(SelectedUser) == 1) // delet user
                {
                    lstUsers.Items.Remove(SelectedListItem);
                    users.Remove(SelectedUser);
                }
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0) // check is any user is selected
            {
                ChangePassword fChangePassword = new ChangePassword();
                fChangePassword.SetUser(SelectedUser); // user selected user
                fChangePassword.ShowDialog(); // show chagepassword form
            }
        }
    }
}