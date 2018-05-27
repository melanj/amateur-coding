using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using StockControl.Model;

namespace StockControl
{
    public partial class AddReceivedOrder : Form
    {
        //Initialized orders,orderitems, receiveditems  
        List<Order> orders;
        List<OrderItem> orderitems = new List<OrderItem>();
        List<ReceivedItem> receiveditems = new List<ReceivedItem>();

        public AddReceivedOrder()
        {
            InitializeComponent();
        }

        private void AddReceivedItem_Load(object sender, EventArgs e)
        {
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Received", "0"); //prepair filter to get only unreceived order 
            orders = DataAccess.GetOrders(null, filter); // get order list(unreceived only)
            foreach (Order a in orders)
                cmbOrder.Items.Add(String.Format("{0:0000}", a.OrderNo)); //add each order to order combo box
        }

        private void OrderItemToListViewItem(ListView listview, OrderItem item)
        {
            // add items to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("{0:0000}", item.Ref));
            listItem.SubItems.Add(String.Format("ITM{0:0000}", item.Item.ItemCode));
            listItem.SubItems.Add(item.Item.Description);
            listItem.SubItems.Add(item.Quantity.ToString());

        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //claer and add new items accrding to selected order 
            lstItems.Items.Clear();
            orderitems.Clear();
            orderitems = DataAccess.GetOrderItems(orders[cmbOrder.SelectedIndex]);
            foreach (OrderItem a in orderitems)
            {
                OrderItemToListViewItem(lstItems, a); 
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable change button and quantity text box when item selected
            if (lstItems.SelectedItems.Count > 0)
            {
                    cmdChange.Enabled = true;
                    txtQuantity.Enabled = true; 
            }
            else {
                cmdChange.Enabled = false;
                txtQuantity.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            int count=0;
            int index = 0;
            ReceivedItem item;
            if (cmbOrder.SelectedIndex >= 0) // if whether order is selected
            {
                foreach (OrderItem a in orderitems)
                {
                    if (lstItems.Items[count].Checked == true) //get only check items
                    {
                        item = new ReceivedItem();
                        item.OrderItem = orderitems[count];
                        item.Quantity = orderitems[count].Quantity; 
                        receiveditems.Add(item);
                        DataAccess.InsertReceivedItem(item);// add received items to database
                        DataAccess.UpdateItemQuantity(orderitems[count].Item, item.Quantity); // update stock
                        index++;
                    }
                    count++;
                }
                if (index == 0) //check whether items are selected
                {
                    // show error message if no items selected
                    MessageBox.Show("Received items cannot be empty!, please select received items", "info", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                orders[cmbOrder.SelectedIndex].IsReceived = true;
                DataAccess.UpdateOrder(orders[cmbOrder.SelectedIndex]); // set order received status to true in database
                MessageBox.Show("Infomration Added Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information); //Show message if success 
                  if (chkPrint.Checked) // if print grn checked
                  {
                        try
                        {
                         docGRN.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                         docGRN.Print(); // print GRN
                        }
                         catch (InvalidPrinterException)
                         {
                             // show error message if error occurs while printing
                             MessageBox.Show("An error occurred while printing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         }
                 }
                 // close and dispose this form
                this.Close();
                this.Dispose();
            }
            else MessageBox.Show("Please select a order!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information); // show error message if no order selected 
        }

        private void docGRN_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // prepair GRn for printing
            Document.GRN(orders[cmbOrder.SelectedIndex], receiveditems, e);
        }

        private void lstItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // enable change button and quantity text box when item checked
            lstItems.Items[e.Item.Index].Selected = true;
            if (e.Item.Checked)
            {
                cmdChange.Enabled = true;
                txtQuantity.Enabled = true;
            }
            else {
                cmdChange.Enabled = false;
                txtQuantity.Enabled = false;
            }
        }

        //change Quantity
        private void cmdChange_Click(object sender, EventArgs e)
        {
            Control[] req ={ txtQuantity };
            if (validation.validate(req))  //validate inputs
            {
                //change to new quantity
                lstItems.SelectedItems[0].SubItems[3].Text = txtQuantity.Text;
                orderitems[lstItems.SelectedItems[0].Index].Quantity = Convert.ToInt32(txtQuantity.Text);
            }
            else MessageBox.Show(validation.getMessage(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}