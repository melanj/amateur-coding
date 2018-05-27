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
    public partial class TransactionLog : Form
    {
        //Initialized variables
        List<Event> transactions;

        public TransactionLog()
        {
            InitializeComponent();
        }

        private void TransactionLog_Load(object sender, EventArgs e)
        {
            ListViewItem listItem;
            transactions = DataAccess.GetTransactionLog(); // get Transaction log from database
            foreach (Event a in transactions) // add each Transaction to listview
            {
                listItem = lstTransaction.Items.Add(a.user);
                listItem.SubItems.Add(a.time.ToString());
                listItem.SubItems.Add(a.description);
            }
        }

        private void lstTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show selected Transaction details
            if (lstTransaction.SelectedItems.Count > 0) {
                txtUser.Text = transactions[lstTransaction.SelectedItems[0].Index].user;
                txtTime.Text = transactions[lstTransaction.SelectedItems[0].Index].time.ToString();
                txtDescription.Text = transactions[lstTransaction.SelectedItems[0].Index].description.Replace(", ","\r\n");
            }
        }
    }
}