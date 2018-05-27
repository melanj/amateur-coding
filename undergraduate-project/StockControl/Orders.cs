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
    public partial class Orders : Form
    {
        //Initialized orders,suppliers,orderitems
        List<Order> orders = new List<Order>();
        List<Supplier> suppliers = new List<Supplier>();
        List<OrderItem> orderitems= new List<OrderItem>();
       
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            dteFrom.MaxDate = DateTime.Today;
            dteTo.MaxDate = DateTime.Today;
            FillOrderList(null, new Dictionary<String, String>()); // fill order listview
            suppliers = DataAccess.GetSuppliers(new Dictionary<String, String>()); // get suppliers list
           
            foreach (Supplier a in suppliers)
            {
                cmbfltSupplier.Items.Add(a.Name); // add suppliers to combo
            } 
           
        }

        private void OrderToListViewItem(ListView listview, Order order)
        {
            // add order to listviw
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("ORD{0:0000}", order.OrderNo));
            listItem.SubItems.Add(String.Format("SUP{0:0000}", order.Supplier.SupCode));
            listItem.SubItems.Add(order.Supplier.Name);
            listItem.SubItems.Add(String.Format("{0:yyyy-MM-dd}", order.OrderDate));
            listItem.SubItems.Add(String.Format("{0:f}", order.Total));
            listItem.SubItems.Add(order.IsReceived.ToString());
        }

        private void OrderItemToListViewItem(ListView listview, OrderItem item)
        {
            // add orderitem to listview
            ListViewItem listItem;
            listItem = listview.Items.Add(String.Format("ITM{0:0000}", item.Item.ItemCode));
            listItem.SubItems.Add(item.Item.Description);
            listItem.SubItems.Add(item.Quantity.ToString());

            listItem.SubItems.Add((item.Order.IsReceived)?item.ReceivedQuantity.ToString():"n\\a");
            listItem.SubItems.Add(String.Format("{0:f}", item.UnitCost));
            listItem.SubItems.Add((item.Order.IsReceived) ? String.Format("{0:f}", (Convert.ToDouble(item.ReceivedQuantity) * item.UnitCost)) : "n\\a");

        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrders.SelectedItems.Count > 0)  // check whether order is selected
            {
                //clear current orderitems
                lstItems.Items.Clear();
                orderitems.Clear();
                orderitems = DataAccess.GetOrderItems(orders[lstOrders.SelectedItems[0].Index]); // get orderitem in current order
                foreach (OrderItem a in orderitems)
                {
                    OrderItemToListViewItem(lstItems, a); // add orderitems to listview
                }
            }
        }


        private void FillOrderList(Supplier supplier, IDictionary<String, String> filter)
        {
            //clear current order list
            orders.Clear();
            lstOrders.Items.Clear();
            lstItems.Items.Clear();
            orderitems.Clear();
            orders = DataAccess.GetOrders(supplier, filter); // get order list
            foreach (Order a in orders)
            {
                OrderToListViewItem(lstOrders, a); // add orders to listview
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //prepair filters for searching
            IDictionary<String, String> filter = new Dictionary<String, String>();
            Supplier supplier = null;
            if (chkCode.Checked && txtfltCode.Text.Length > 0)
                filter.Add("Code", Convert.ToInt32(txtfltCode.Text).ToString());
            if (chkSupplier.Checked)
            {
                if (cmbfltSupplier.SelectedIndex >= 0)
                    supplier = suppliers[cmbfltSupplier.SelectedIndex];
            }
            if (chkDate.Checked)
            {
                filter.Add("from", String.Format("{0:yyyy-MM-dd}", dteFrom.Value));
                filter.Add("to", String.Format("{0:yyyy-MM-dd}", dteTo.Value.AddDays(1)));
            }
            if (chkReceived.Checked)
            {
                if (cmbReceived.SelectedIndex >= 0)
                    filter.Add("Received", cmbReceived.SelectedIndex.ToString());
            }
            FillOrderList(supplier, filter); // fill listview with search results
            chkfilter.Checked = false;
        }

        private void chkfilter_CheckedChanged(object sender, EventArgs e)
        {
            // hide/show filter panel according to "filers" click 
            pnlfilter.Visible = chkfilter.Checked;
            if (pnlfilter.Visible) cmdSearch.Focus();
        }

        private void pnlfilter_Leave(object sender, EventArgs e)
        {
            //hide filter panel when lostfocus
            chkfilter.Checked = false;
        }

        private void chkCode_CheckedChanged(object sender, EventArgs e)
        {
            txtfltCode.Enabled = chkCode.Checked;
        }

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            cmbfltSupplier.Enabled = chkSupplier.Checked;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dteFrom.Enabled = chkDate.Checked;
            dteTo.Enabled = chkDate.Checked;
        }

        private void chkReceived_CheckedChanged(object sender, EventArgs e)
        {
            cmbReceived.Enabled = chkReceived.Checked;
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            //show all orders
            FillOrderList(null, new Dictionary<String, String>());
        }
    }
}