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
    public partial class AddOrder : Form
    {
        //Initialized suppliers, items, order,orderitems 
        List<Supplier> suppliers;
        List<Item> items = new List<Item>();
        Order order;
        List<OrderItem> orderitems = new List<OrderItem>();
        int itemcount = 0;
        double total = 0;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            suppliers = DataAccess.GetSuppliers(new Dictionary<String,String>()); // get supplier list
            foreach (Supplier a in suppliers) // add each supplier supplier combobox
                cmbSupplier.Items.Add(String.Format("{0} [{1:0000}]", a.Name, a.SupCode));
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear all current order when supplier changed
            cmbItems.Items.Clear();
            items.Clear();
            cmdRemoveAll_Click(sender, e);
            items = DataAccess.GetItems(suppliers[cmbSupplier.SelectedIndex], null, new Dictionary<String, String>());
            foreach (Item a in items)
                cmbItems.Items.Add(a.Description);

        }

        // adding purchase order
        private void cmdProceed_Click(object sender, EventArgs e)
        {
            if (lstItems.Items.Count > 0) { // check whether order is not empty
                if (cmbSupplier.SelectedIndex == -1) // check whether supplier selected 
                {
                    // show error message if supplier not selected
                    MessageBox.Show("Please select supplier!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else {
                    order = new Order(); //Initialized new order
                    order.Supplier = suppliers[cmbSupplier.SelectedIndex];
                    order.Total = total;
                    order.OrderDate = DateTime.Now;
                    if (DataAccess.InsertOrder(order) == 1) // add order to database
                    {
                        foreach (OrderItem a in orderitems)
                        {
                            a.Order = order;
                            DataAccess.InsertOrderItem(a); // add each orderietms to database
                        }
                        //Show message if success 
                        MessageBox.Show("Order Added Successfully!", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (chkPrint.Checked) // if print order selected
                        {
                            try
                        {
                            docOrder.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
                            docOrder.Print(); // print order
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
                    else {
                        // show error message if error occurs
                        MessageBox.Show("An error occurred while processing your request!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            
            }
            else MessageBox.Show("You cannot add a empty order!", "empty order", MessageBoxButtons.OK, MessageBoxIcon.Information); // show error message if order is empty
        }

        //add items to order
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ListViewItem SelectedItem;
            Item item;
            OrderItem orderitem;
            Control[] Fld = { cmbItems,txtPrice };
            if (validation.validate(Fld)) //validate inputs
            {
                item = items[cmbItems.SelectedIndex];
                if (!isAlready(String.Format("{0:0000}", item.ItemCode))) //check item Already added
                {
                    orderitem = new OrderItem(); //Initialized new order item
                        itemcount++;
                        SelectedItem = lstItems.Items.Add(itemcount.ToString());
                        SelectedItem.SubItems.Add(item.Description);
                        orderitem.Item = item;
                        orderitem.UnitCost = Convert.ToDouble(txtPrice.Text);
                        orderitem.Quantity = Convert.ToInt32(txtQuantity.Value);
                        orderitems.Add(orderitem);
                        SelectedItem.SubItems.Add(txtQuantity.Value.ToString());
                        SelectedItem.SubItems.Add(String.Format("{0:0.00}", orderitem.UnitCost));
                        SelectedItem.SubItems.Add(String.Format("{0:0.00}", orderitem.UnitCost * Convert.ToDouble(txtQuantity.Value)));
                }
                else
                {
                    // show error message if item already added
                    MessageBox.Show("Item Already in Bucket List!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdateTotal(); //update total 
            }
            else MessageBox.Show(validation.getMessage()); // show error message if validation error occurs
        }
        private bool isAlready(string itemcode) // function for check item Already added
        {
            int i = 0;
            ListViewItem item;
            for (i = 0; i < lstItems.Items.Count; i++)
            {
                item = lstItems.Items[i];
                if (item.SubItems[1].Text.Equals(itemcode))
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateTotal() // function for update
        {
            int i = 0;
            total = 0;
            ListViewItem item;
            for (i = 0; i < lstItems.Items.Count; i++)
            {
                item = lstItems.Items[i];
                total += Convert.ToDouble(item.SubItems[4].Text);
            }
            lbTotal.Text = string.Format("{0:0.00}", total);
        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set quantity to item's minimum order quantity and claer price when item changed
            txtQuantity.Minimum = items[cmbItems.SelectedIndex].MinOrderQty;
            txtQuantity.Value = txtQuantity.Minimum;
            txtPrice.Text = "";
        }

        private void cmdRemove_Click(object sender, EventArgs e) // function for remove item
        {
            int i = 0;
            ListViewItem item;
            if (lstItems.SelectedItems.Count > 0)
            {
                itemcount--;
                orderitems.RemoveAt(lstItems.SelectedItems[0].Index);
                lstItems.Items.Remove(lstItems.SelectedItems[0]);
                for (i = 0; i < lstItems.Items.Count; i++)
                {
                    item = lstItems.Items[i];
                    item.SubItems[0].Text = (i + 1).ToString();
                }
            }
            UpdateTotal();
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e) // function for remove all items
        {
            lstItems.Items.Clear();
            orderitems.Clear();
            itemcount = 0;
            UpdateTotal();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            this.Close();
            this.Dispose();
        }

        private void docOrder_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //prepare purchase order documnet
            Document.Order(order, orderitems, e);
        }
    }
}