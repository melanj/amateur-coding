using System;
using System.Collections.Generic;
using System.Text;
using StockControl.Model;
using System.Data;
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;

namespace StockControl
{
    public class DataAccess
    {
        private static string errmsg=null;

        // set error message
        private static void SetErrMsg(String msg) {
            errmsg = msg;
        }

        public static bool IsError()
        {
            return (errmsg != null);
        }

        // Get error message
        public static String GetError()
        {
            String lasterror;
            lasterror = errmsg;
            errmsg = null;
            return lasterror;
        }

        // get items using configured Database connection
        public static List<Item> GetItems(Supplier s, ItemCategory c, IDictionary<String, String> filter)
        {
            List<Item> items = new List<Item>();
            try
            {
                String SqlQuery = "select * from itemview where SupplierID like ? AND CategoryID like ? AND ItemCode like ? AND Description like ?";
                if (filter.ContainsKey("reorderonly"))
                    SqlQuery += " AND ReorderQty >= Quantity";
                OdbcCommand scmd = new OdbcCommand(SqlQuery, DBConnection.getConnection());
                scmd.Parameters.Add("@Supplier", OdbcType.VarChar).Value = (s == null) ? "%" : s.SupCode.ToString();
                scmd.Parameters.Add("@Category", OdbcType.VarChar).Value = (c == null) ? "%" : c.Id.ToString();
                scmd.Parameters.Add("@ItemCode", OdbcType.VarChar).Value = (filter.ContainsKey("Code")) ? (filter["Code"] + "%") : "%";
                scmd.Parameters.Add("@Description", OdbcType.VarChar).Value = (filter.ContainsKey("Description")) ? (filter["Description"] + "%") : "%";
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Item item = new Item();
                    item.ItemCode = Convert.ToInt32(sdr["ItemCode"]);
                    item.Description = sdr["Description"].ToString();
                    item.Category = new ItemCategory(Convert.ToInt32(sdr["CategoryID"]), sdr["Category"].ToString());
                    item.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);
                    item.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    item.MinOrderQty = Convert.ToInt32(sdr["MinOrderQty"]);
                    item.ReorderQty = Convert.ToInt32(sdr["ReorderQty"]);
                    Supplier supplier = new Supplier();
                    supplier.SupCode = Convert.ToInt32(sdr["SupplierID"]);
                    supplier.Name = sdr["Supplier"].ToString();
                    item.Supplier = supplier;
                    items.Add(item);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
               SetErrMsg(ex.Message);
            }
            return items;
        }

        //inserts a item using configured Database connection
        public static int InsertItem(Item item) {
            int i=0;
            try
            {
            OdbcCommand scmd = new OdbcCommand("INSERT INTO item (Description,Category,UnitPrice,Quantity,MinOrderQty,ReorderQty,SupCode) VALUES(?,?,?,?,?,?,?)", DBConnection.getConnection());
            scmd.Parameters.Add("@Description", OdbcType.VarChar).Value = item.Description;
            scmd.Parameters.Add("@Category", OdbcType.Int).Value = item.Category.Id;
            scmd.Parameters.Add("@UnitPrice", OdbcType.Double).Value = item.UnitPrice;
            scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = item.Quantity;
            scmd.Parameters.Add("@MinOrderQty", OdbcType.Int).Value = item.MinOrderQty;
            scmd.Parameters.Add("@ReorderQty", OdbcType.Int).Value = item.ReorderQty;
            scmd.Parameters.Add("@Supplier", OdbcType.Int).Value = item.Supplier.SupCode;
            i = scmd.ExecuteNonQuery();
            item.ItemCode = GetLastInsert();
        }
        catch (Exception e)
        {
            SetErrMsg(e.Message);
        }
            return i;
        }

        // updates a item using configured Database connection
        public static int UpdateItem(Item item)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE item SET Description=?,UnitPrice=?,Quantity=?,MinOrderQty=?,ReorderQty=? WHERE ItemCode=?", DBConnection.getConnection());
                scmd.Parameters.Add("@Description", OdbcType.VarChar).Value = item.Description;
                scmd.Parameters.Add("@UnitPrice", OdbcType.Double).Value = item.UnitPrice;
                scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = item.Quantity;
                scmd.Parameters.Add("@MinOrderQty", OdbcType.Int).Value = item.MinOrderQty;
                scmd.Parameters.Add("@ReorderQty", OdbcType.Int).Value = item.ReorderQty;
                scmd.Parameters.Add("@ItemCode", OdbcType.Int).Value = item.ItemCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // updates a item's quantity using configured Database connection
        public static int UpdateItemQuantity(Item item,int shift)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE item SET Quantity=Quantity+? WHERE ItemCode=?", DBConnection.getConnection());
                scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = shift;
                scmd.Parameters.Add("@ItemCode", OdbcType.Int).Value =item.ItemCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // get last insert id of mysql database
        public static int GetLastInsert() {
            OdbcCommand scmd = new OdbcCommand("SELECT LAST_INSERT_ID()", DBConnection.getConnection());
            OdbcDataReader getLastInsert;
            getLastInsert = scmd.ExecuteReader();
            getLastInsert.Read();
            return Convert.ToInt32(getLastInsert[0]);
        }

        // get Customers using configured Database connection
        public static List<Customer> GetCustomers(IDictionary<String, String> filter)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("SELECT * FROM customer WHERE cuscode LIKE ? AND Name LIKE ? AND Address LIKE ? AND Phone LIKE ? AND Email LIKE ?", DBConnection.getConnection());
                scmd.Parameters.Add("@cuscode", OdbcType.VarChar).Value = (filter.ContainsKey("Code")) ? (filter["Code"] + "%") : "%";
                scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = (filter.ContainsKey("Name")) ? (filter["Name"] + "%") : "%";
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = (filter.ContainsKey("Address")) ? (filter["Address"] + "%") : "%";
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = (filter.ContainsKey("Phone")) ? (filter["Phone"] + "%") : "%";
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = (filter.ContainsKey("Email")) ? (filter["Email"] + "%") : "%";
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Customer customer = new Customer();
                    customer.CusCode = Convert.ToInt32(sdr["CusCode"]);
                    customer.Name = sdr["Name"].ToString();
                    customer.Address = sdr["Address"].ToString();
                    customer.Phone = sdr["Phone"].ToString();
                    customer.Email = sdr["Email"].ToString();
                    customer.Type = Convert.ToInt32(sdr["Type"]);
                    customer.Notes = sdr["Notes"].ToString();
                    customers.Add(customer);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return customers;
        }

        // get Suppliers using configured Database connection
        public static List<Supplier> GetSuppliers(IDictionary<String, String> filter)
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("SELECT * FROM supplier  WHERE SupCode LIKE ? AND Name LIKE ? AND Address LIKE ? AND Phone LIKE ? AND Email LIKE ?", DBConnection.getConnection());
                scmd.Parameters.Add("@SupCode", OdbcType.VarChar).Value = (filter.ContainsKey("Code")) ? (filter["Code"] + "%") : "%";
                scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = (filter.ContainsKey("Name")) ? (filter["Name"] + "%") : "%";
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = (filter.ContainsKey("Address")) ? (filter["Address"] + "%") : "%";
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = (filter.ContainsKey("Phone")) ? (filter["Phone"] + "%") : "%";
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = (filter.ContainsKey("Email")) ? (filter["Email"] + "%") : "%";
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupCode = Convert.ToInt32(sdr["SupCode"]);
                    supplier.Name = sdr["Name"].ToString();
                    supplier.Address = sdr["Address"].ToString();
                    supplier.Phone = sdr["Phone"].ToString();
                    supplier.Email = sdr["Email"].ToString();
                    supplier.Description = sdr["Description"].ToString();
                    suppliers.Add(supplier);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return suppliers;
        }

        // get Categories using configured Database connection
        public static List<ItemCategory> GetItemCategories()
        {
            List<ItemCategory> Categories = new List<ItemCategory>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("select * from itemcategory", DBConnection.getConnection());
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    ItemCategory category = new ItemCategory();
                    category.Id = Convert.ToInt32(sdr["CatID"]);
                    category.Name = sdr["Description"].ToString();
                    Categories.Add(category);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return Categories;
        }

        // inserts a customer using configured Database connection
        public static int InsertCustomer(Customer customer)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO customer (Name, Address, Phone, email, Type, Notes) VALUES(?,?,?,?,?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = customer.Name;
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = customer.Address;
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = customer.Phone;
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = customer.Email;
                scmd.Parameters.Add("@Type", OdbcType.Int).Value = customer.Type;
                scmd.Parameters.Add("@Notes", OdbcType.VarChar).Value = customer.Notes;
                i = scmd.ExecuteNonQuery();
                customer.CusCode = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // updates a customer using configured Database connection
        public static int UpdateCustomer(Customer customer)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE customer SET Address=?, Phone=?, email=?, Notes=? WHERE CusCode=?", DBConnection.getConnection());
                // scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = customer.Name;
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = customer.Address;
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = customer.Phone;
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = customer.Email;
                //  scmd.Parameters.Add("@Type", OdbcType.Int).Value = customer.Type;
                scmd.Parameters.Add("@Notes", OdbcType.VarChar).Value = customer.Notes;
                scmd.Parameters.Add("@CusCode", OdbcType.VarChar).Value = customer.CusCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a supplier using configured Database connection
        public static int InsertSupplier(Supplier supplier)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO supplier (Name, Address, Phone, Description, Email) VALUES(?,?,?,?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = supplier.Name;
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = supplier.Address;
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = supplier.Phone;
                scmd.Parameters.Add("@Notes", OdbcType.VarChar).Value = supplier.Description;
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = supplier.Email;
                i = scmd.ExecuteNonQuery();
                supplier.SupCode = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // updates a supplier using configured Database connection
        public static int UpdateSupplier(Supplier supplier)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE supplier SET Address=?, Phone=?, Description=?, email=? WHERE SupCode=?", DBConnection.getConnection());
                // scmd.Parameters.Add("@Name", OdbcType.VarChar).Value = supplier.Name;
                scmd.Parameters.Add("@Address", OdbcType.VarChar).Value = supplier.Address;
                scmd.Parameters.Add("@Phone", OdbcType.VarChar).Value = supplier.Phone;
                scmd.Parameters.Add("@Description", OdbcType.VarChar).Value = supplier.Description;
                scmd.Parameters.Add("@Email", OdbcType.VarChar).Value = supplier.Email;
                scmd.Parameters.Add("@SupCode", OdbcType.VarChar).Value = supplier.SupCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a Category using configured Database connection
        public static int InsertItemCategory(ItemCategory category)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO itemcategory (Description) VALUES(?)", DBConnection.getConnection());
                scmd.Parameters.Add("Description", OdbcType.VarChar).Value = category.Name;
                i = scmd.ExecuteNonQuery();
                category.Id = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // check  authentication of  user
        public static Boolean isUser(User user)
        {
            OdbcCommand SqlCmd;
            OdbcDataReader passwdread;
            string SqlStr = "SELECT * from user where UserName = '" + user.Name + "' AND passwd = password('" + user.Password + "')";
            SqlCmd = new OdbcCommand(SqlStr,DBConnection.getConnection());
            try
            {
                passwdread = SqlCmd.ExecuteReader();
                if (passwdread.Read())
                {
                    if (passwdread["UserName"].ToString() == user.Name)
                    {
                        user.FullName = passwdread["FullName"].ToString();
                        user.Category = Convert.ToInt32(passwdread["Category"]);
                        SetSessionUser(); // set username in mysql session
                        return true;
                    }
                }
                
            }
            catch (Exception){}
            return false;  
        }

        // set current username in database session
        public static void SetSessionUser(){
            try
            {
                OdbcCommand SqlCmd;
                SqlCmd = new OdbcCommand("SET @user='" + Authentication.GetUser().Name + "'", DBConnection.getConnection());
                SqlCmd.ExecuteScalar();
            }
            catch (Exception)
            {
            }    
        }

        // inserts a user using configured Database connection
        public static int InsertUser(User user)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO user (UserName, FullName, Passwd, Category) VALUES(?,?,password(?),?)", DBConnection.getConnection());
                scmd.Parameters.Add("@UserID", OdbcType.VarChar).Value = user.Name;
                scmd.Parameters.Add("@FullName", OdbcType.VarChar).Value = user.FullName;
                scmd.Parameters.Add("@password", OdbcType.VarChar).Value = user.Password;
                scmd.Parameters.Add("@Category", OdbcType.VarChar).Value = user.Category;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // updates a user using configured Database connection
        public static int UpdateUser(User user)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE user SET FullName=?, Passwd=password(?) WHERE UserName=?", DBConnection.getConnection());
                scmd.Parameters.Add("@FullName", OdbcType.VarChar).Value = user.FullName;
                scmd.Parameters.Add("@password", OdbcType.VarChar).Value = user.Password;
                scmd.Parameters.Add("@UserID", OdbcType.VarChar).Value = user.Name;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // deletes a user using configured Database connection
        public static int DeleteUser(User user)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("DELETE FROM user WHERE UserName=?", DBConnection.getConnection());
                scmd.Parameters.Add("@UserID", OdbcType.VarChar).Value = user.Name;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a Sold item using configured Database connection
        public static int InsertSoldItem(SoldItem item)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO solditem (ItemCode, InvoiceNo, Quantity, UnitPrice) VALUES(?,?,?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@ItemCode", OdbcType.Int).Value = item.Item.ItemCode;
                scmd.Parameters.Add("@InvoiceNo", OdbcType.Int).Value = item.Invoice.InvoiceNo;
                scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = item.Quantity;
                scmd.Parameters.Add("@UnitPrice", OdbcType.Double).Value = item.UnitPrice;
                i = scmd.ExecuteNonQuery();
                //item.Ref = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a ordered item using configured Database connection
        public static int InsertOrderItem(OrderItem item)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO orderitem (ItemCode, OrderNo, Quantity, UnitCost) VALUES(?,?,?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@ItemCode", OdbcType.Int).Value = item.Item.ItemCode;
                scmd.Parameters.Add("@OrderNo", OdbcType.Int).Value = item.Order.OrderNo;
                scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = item.Quantity;
                scmd.Parameters.Add("@UnitCost", OdbcType.Double).Value = item.UnitCost;
                i = scmd.ExecuteNonQuery();
                //item.Ref = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a Received Item using configured Database connection
        public static int InsertReceivedItem(ReceivedItem item)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO receiveditem (ItemRef, Quantity,receivedDate) VALUES(?,?,curdate())", DBConnection.getConnection());
                scmd.Parameters.Add("@ItemRef", OdbcType.Int).Value = item.OrderItem.Ref;
                scmd.Parameters.Add("@Quantity", OdbcType.Int).Value = item.Quantity;
                i = scmd.ExecuteNonQuery();
                //item.Ref = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a Payment using configured Database connection
        public static int InsertPayment(Payment payment)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO payment (InvoiceNo, PaidDate, Amount, Balance) VALUES(?,now(),?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@ItemRef", OdbcType.Int).Value = payment.Invoice.InvoiceNo;
                scmd.Parameters.Add("@Amount", OdbcType.Double).Value = payment.Amount;
                scmd.Parameters.Add("@Balance", OdbcType.Double).Value = payment.Balance;
                i = scmd.ExecuteNonQuery();
                payment.Ref = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a Invoice using configured Database connection
        public static int InsertInvoice(Invoice invoice)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO invoice (CusCode, InvoiceDate, Total, IsCredit, IsPaid) VALUES(?,curdate(),?,?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@CusCode", OdbcType.Int).Value = invoice.Customer.CusCode;
                scmd.Parameters.Add("@Total", OdbcType.Double).Value = invoice.Total;
                scmd.Parameters.Add("@IsCredit", OdbcType.TinyInt).Value = invoice.IsCredit;
                scmd.Parameters.Add("@IsPaid", OdbcType.TinyInt).Value = invoice.IsPaid;
                i = scmd.ExecuteNonQuery();
                invoice.InvoiceNo = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // inserts a order using configured Database connection
        public static int InsertOrder(Order order)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("INSERT INTO `order`(SupCode, OrderDate, Total,received) VALUES(?,curdate(),?,?)", DBConnection.getConnection());
                scmd.Parameters.Add("@SupCode", OdbcType.Int).Value = order.Supplier.SupCode;
                scmd.Parameters.Add("@Total", OdbcType.Double).Value = order.Total;
                scmd.Parameters.Add("@received", OdbcType.TinyInt).Value = order.IsReceived;
                i = scmd.ExecuteNonQuery();
                order.OrderNo = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // get users using configured Database connection
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("select * from user", DBConnection.getConnection());
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    User user = new User();
                    user.Name = sdr["UserName"].ToString();
                    user.FullName = sdr["FullName"].ToString();
                    user.Category = Convert.ToInt32(sdr["Category"]);
                    users.Add(user);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return users;
        }

        // get list of Invoices using configured Database connection
        public static List<Invoice> GetInvoices(Customer c, IDictionary<String, String> filter)
        {
            List<Invoice> invoices = new List<Invoice>();
            try
            {
                String SqlQuery = "SELECT i.InvoiceNo, i.CusCode, k.Name, i.InvoiceDate, i.Total, i.IsCredit, i.IsPaid from Invoice i, Customer k Where i.CusCode=k.CusCode AND k.CusCode like ? AND isPaid like ? AND i.IsCredit like ? AND i.InvoiceNo like ?";
                if (filter.ContainsKey("from") && filter.ContainsKey("to"))
                    SqlQuery += " AND InvoiceDate between date('" + filter["from"] + "') AND date('" + filter["to"] + "') ";
                OdbcCommand scmd = new OdbcCommand(SqlQuery, DBConnection.getConnection());
                scmd.Parameters.Add("@CusCode", OdbcType.VarChar).Value = (c == null) ? "%" : c.CusCode.ToString();
                scmd.Parameters.Add("@ispaid", OdbcType.VarChar).Value = (filter.ContainsKey("Paid")) ? (filter["Paid"]) : "%";
                scmd.Parameters.Add("@Credit", OdbcType.VarChar).Value = (filter.ContainsKey("Credit")) ? (filter["Credit"]) : "%";
                scmd.Parameters.Add("@InvoiceNo", OdbcType.VarChar).Value = (filter.ContainsKey("Code")) ? (filter["Code"]) : "%";
                
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.InvoiceNo = Convert.ToInt32(sdr["InvoiceNo"]);
                    Customer customer = new Customer();
                    customer.CusCode = Convert.ToInt32(sdr["CusCode"]);
                    customer.Name = sdr["Name"].ToString();
                    invoice.Customer = customer;
                    invoice.InvoiceDate = Convert.ToDateTime(sdr["InvoiceDate"]);
                    invoice.IsCredit = Convert.ToBoolean(sdr["IsCredit"]);
                    invoice.IsPaid = Convert.ToBoolean(sdr["IsPaid"]);
                    invoice.Total = Convert.ToDouble(sdr["Total"]);
                    invoices.Add(invoice);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return invoices;
        }

        // get list of Orders using configured Database connection
        public static List<Order> GetOrders(Supplier s, IDictionary<String, String> filter)
        {
            List<Order> orders = new List<Order>();
            try
            {
            String SqlQuery = "SELECT i.OrderNo, i.SupCode, j.Name, i.OrderDate, i.Total,i.received FROM `order` i, supplier j WHERE i.SupCode=j.SupCode AND i.SupCode like ? AND i.received like ? AND i.OrderNo like ?";
                if (filter.ContainsKey("from") && filter.ContainsKey("to"))
                    SqlQuery += " AND OrderDate between date('" + filter["from"] + "') AND date('" + filter["to"] + "') ";
                OdbcCommand scmd = new OdbcCommand(SqlQuery, DBConnection.getConnection());
                scmd.Parameters.Add("@SupCode", OdbcType.VarChar).Value = (s == null) ? "%" : s.SupCode.ToString();
                scmd.Parameters.Add("@received", OdbcType.VarChar).Value = (filter.ContainsKey("Received")) ? (filter["Received"]) : "%";
                scmd.Parameters.Add("@OrderNo", OdbcType.VarChar).Value = (filter.ContainsKey("Code")) ? (filter["Code"] + "%") : "%";
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Order order = new Order();
                    order.OrderNo = Convert.ToInt32(sdr["OrderNo"]);
                    Supplier supplier = new Supplier();
                    supplier.SupCode = Convert.ToInt32(sdr["SupCode"]);
                    supplier.Name = sdr["Name"].ToString();
                    order.Supplier = supplier;
                    order.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);
                    order.Total = Convert.ToDouble(sdr["Total"]);
                    order.IsReceived = Convert.ToBoolean(sdr["received"]);
                    orders.Add(order);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return orders;
        }

        // get list of SoldItems using configured Database connection
        public static List<SoldItem> GetSoldItems(Invoice invoice)
        {
            List<SoldItem> items = new List<SoldItem>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("SELECT i.Ref, i.ItemCode, j.Description, i.InvoiceNo, i.Quantity, i.UnitPrice FROM solditem i, item j WHERE i.ItemCode=j.ItemCode AND i.InvoiceNo = ?", DBConnection.getConnection());
                scmd.Parameters.Add("@invoice", OdbcType.Int).Value = invoice.InvoiceNo;
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    SoldItem solditem = new SoldItem();
                    solditem.Ref = Convert.ToInt32(sdr["Ref"]);
                    Item item = new Item();
                    item.ItemCode = Convert.ToInt32(sdr["ItemCode"]);
                    item.Description = sdr["Description"].ToString();
                    solditem.Item = item;
                    solditem.Invoice = invoice;
                    solditem.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    solditem.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]); 
                    items.Add(solditem);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return items;
        }

        // get list of OrderItems using configured Database connection
        public static List<OrderItem> GetOrderItems(Order order)
        {
            List<OrderItem> items = new List<OrderItem>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("CALL OrderitemView(?)", DBConnection.getConnection());
                scmd.CommandType = System.Data.CommandType.StoredProcedure;
                scmd.Parameters.Add("@order", OdbcType.Int).Value = order.OrderNo;
                
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    OrderItem orderitem = new OrderItem();
                    orderitem.Ref = Convert.ToInt32(sdr["Ref"]);
                    Item item = new Item();
                    item.ItemCode = Convert.ToInt32(sdr["ItemCode"]);
                    item.Description = sdr["Description"].ToString();
                    orderitem.Item = item;
                    orderitem.Order= order;
                    orderitem.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    orderitem.ReceivedQuantity = Convert.ToInt32(sdr["ReceivedQuantity"]);
                    orderitem.UnitCost = Convert.ToDouble(sdr["UnitCost"]);
                    items.Add(orderitem);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return items;
        }
        // updates a invoice using configured Database connection
        public static int UpdateInvoice(Invoice invoice)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE invoice SET IsPaid=? WHERE InvoiceNo=?", DBConnection.getConnection());
                scmd.Parameters.Add("@IsPaid", OdbcType.TinyInt).Value = invoice.IsPaid;
                scmd.Parameters.Add("@InvoiceNo", OdbcType.TinyInt).Value = invoice.InvoiceNo;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // updates a Order using configured Database connection
        public static int UpdateOrder(Order order)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("UPDATE `order` SET received=? WHERE OrderNo=? ", DBConnection.getConnection());
                scmd.Parameters.Add("@received", OdbcType.TinyInt).Value = order.IsReceived;
                scmd.Parameters.Add("@OrderNo", OdbcType.Int).Value = order.OrderNo;
                i = scmd.ExecuteNonQuery();
                order.OrderNo = GetLastInsert();
            }
            catch (Exception e)
            {
                SetErrMsg(e.Message);
            }
            return i;
        }

        // get list of Payments using configured Database connection
        public static List<Payment> GetPayments(Invoice i, IDictionary<String, String> filter)
        {
            List<Payment> payments = new List<Payment>();
            try
            {
                String SqlQuery = "SELECT * FROM payment i where i.InvoiceNo ";
                if (filter.ContainsKey("invoices"))
                    SqlQuery += ("IN (" + filter["invoices"] + ")");
                else
                    SqlQuery += (i == null) ? "like '%'" : ("like '" + i.InvoiceNo.ToString() + "'"); 
                if (filter.ContainsKey("from") && filter.ContainsKey("to"))
                    SqlQuery += " AND PaidDate between date('" + filter["from"] + "') AND date('" + filter["to"] + "') ";
                OdbcCommand scmd = new OdbcCommand(SqlQuery,DBConnection.getConnection());
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Payment payment = new Payment();
                    payment.Ref = Convert.ToInt32(sdr["Ref"]);
                    Invoice invoice = new Invoice();
                    invoice.InvoiceNo = Convert.ToInt32(sdr["InvoiceNo"]);
                    payment.Invoice = invoice;
                    payment.PaidDate = Convert.ToDateTime(sdr["PaidDate"]);
                    payment.Amount = Convert.ToDouble(sdr["Amount"]);
                    payment.Balance = Convert.ToDouble(sdr["Balance"]);
                    payments.Add(payment);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return payments;
        }

        // get list of Transactions using configured Database connection
        public static List<Event> GetTransactionLog()
        {
            List<Event> events = new List<Event>();
            try
            {
                OdbcCommand scmd = new OdbcCommand("SELECT * FROM transaction_log order by `time` desc", DBConnection.getConnection());
                OdbcDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Event e= new Event();
                    e.user = sdr["user_id"].ToString();
                    e.description = String.Format("{0} {1:0000} {2}",sdr["subject"],Convert.ToInt32(sdr["subjectRef"]),sdr["description"]);
                    e.time = Convert.ToDateTime(sdr["time"]);
                    events.Add(e);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            return events;
        }

        // genarate Current Inventory report 
        public static ReportClass CurrentInventory()
        {
            OdbcDataAdapter reportAdapter;
            DataSet reportDataSet;
            ReportClass currentReport = null;
            reportAdapter = new OdbcDataAdapter("call CurrentInventory()", DBConnection.getConnection());
            reportDataSet = new reportDS();
            reportAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            reportAdapter.Fill(reportDataSet, "CurrentInventory");
            if (reportDataSet.Tables["CurrentInventory"].Rows.Count > 0)
            {
                currentReport = new RptCurrentInventory();
                currentReport.SetDataSource(reportDataSet);
            }
            return currentReport;
        }
        // genarate order report 
        public static ReportClass Orders()
        {
            OdbcDataAdapter reportAdapter;
            DataSet reportDataSet;
            ReportClass currentReport = null;
            reportAdapter = new OdbcDataAdapter("call OrderView()", DBConnection.getConnection());
            reportDataSet = new reportDS();
            reportAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            reportAdapter.Fill(reportDataSet, "Orders");
            if (reportDataSet.Tables["Orders"].Rows.Count > 0)
            {
                currentReport = new RptOrders();
                currentReport.SetDataSource(reportDataSet);
            }
            return currentReport;
        }

        // genarate Stock Demand report 
        public static ReportClass StockDemand(DateTime? from,DateTime? To)
        {
            OdbcDataAdapter reportAdapter;
            DataSet reportDataSet;
            ReportClass currentReport = null;
            reportAdapter = new OdbcDataAdapter("call StockDemand(?,?)", DBConnection.getConnection());
            reportAdapter.SelectCommand.Parameters.Add("@from", OdbcType.VarChar).Value = (from==null )?"":String.Format("{0:yyyy-MM-dd}", from);
            reportAdapter.SelectCommand.Parameters.Add("@to", OdbcType.VarChar).Value = (To == null) ? "" : String.Format("{0:yyyy-MM-dd}", To);
            reportDataSet = new reportDS();
            reportAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            reportAdapter.Fill(reportDataSet, "StockDemand");
            if (reportDataSet.Tables["StockDemand"].Rows.Count > 0)
            {
                currentReport = new RptStockDemand();
                currentReport.SetDataSource(reportDataSet);
            }
            return currentReport;
        }

        // genarate Sales report 
        public static ReportClass Sales(DateTime? from, DateTime? To)
        {
            OdbcDataAdapter reportAdapter;
            DataSet reportDataSet;
            ReportClass currentReport = null;
            if (from == null || To == null)
                reportAdapter = new OdbcDataAdapter("select * from salesview", DBConnection.getConnection());
            else
            {
                reportAdapter = new OdbcDataAdapter("select * from salesview where InvoiceDate between date(?) and date(?)", DBConnection.getConnection());
                reportAdapter.SelectCommand.Parameters.Add("@from", OdbcType.VarChar).Value = String.Format("{0:yyyy-MM-dd}", from);
                reportAdapter.SelectCommand.Parameters.Add("@to", OdbcType.VarChar).Value = String.Format("{0:yyyy-MM-dd}", To);
            }
            reportDataSet = new reportDS();

            reportAdapter.Fill(reportDataSet, "sales");
            if (reportDataSet.Tables["sales"].Rows.Count > 0)
            {
                currentReport = new RptSales();
                currentReport.SetDataSource(reportDataSet);
            }
            return currentReport;
        }

        //delete an item
        public static int DeleteItem(Item item)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("DELETE from item where ItemCode=?", DBConnection.getConnection());
                scmd.Parameters.Add("@ItemCode", OdbcType.Int).Value = item.ItemCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SetErrMsg("This item cannot be deleted as this item  is referred to in invoices");
            }
            return i;
        }

        //delete an supplier
        public static int DeleteSupplier(Supplier supplier)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("delete from supplier where SupCode=?", DBConnection.getConnection());
                scmd.Parameters.Add("@Code", OdbcType.Int).Value = supplier.SupCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SetErrMsg("This Supplier cannot be deleted as this Supplier is referred to in orders or items");
            }
            return i;
        }

        //delete a customer
        public static int DeleteCustomer(Customer customer)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("delete from customer where CusCode=?", DBConnection.getConnection());
                scmd.Parameters.Add("@Code", OdbcType.Int).Value = customer.CusCode;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SetErrMsg("This Customer cannot be deleted as this Customer is referred to in invoices");
            }
            return i;
        }

        //delete a Category
        public static int DeleteCategory(ItemCategory category)
        {
            int i = 0;
            try
            {
                OdbcCommand scmd = new OdbcCommand("delete from ItemCategory where CatID=?", DBConnection.getConnection());
                scmd.Parameters.Add("@CatID", OdbcType.Int).Value = category.Id;
                i = scmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SetErrMsg("You cannot delete a category which contains items");
            }
            return i;
        }



    }
}
