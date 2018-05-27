using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StockControl;
using StockControl.Model;
using System.Data.Odbc;

namespace StockControlTest
{
    [TestFixture]
    public class UnitTest
    {

        DBConnection conn;
        User user;
        string userid;
        string password;
        ItemCategory category;
        Supplier supplier;
        Item item;
        Customer customer;
        SoldItem solditem_a;
        SoldItem solditem_b;
        Invoice invoice;
        Payment payment;
        OrderItem orderItem_a;
        OrderItem orderItem_b;
        Order order;

        List<ItemCategory> categories;
        List<Supplier> suppliers;
        List<Item> items;
        List<Customer> customers;
        List<Invoice> invoices;
        List<Order> orders;

        [SetUp]
        public void init()
        {
            // settingup database connection
            config.SetConfigFile(@"config.xml");
            conn = new DBConnection();
            categories = DataAccess.GetItemCategories();
            suppliers = DataAccess.GetSuppliers(new Dictionary<String, String>());
            items = DataAccess.GetItems(null, null, new Dictionary<String, String>());
            customers = DataAccess.GetCustomers(new Dictionary<String, String>());
        }


        [Test]
        public void Test01_ConfigFile()
        {
            
        }

        [Test]
        public void Test02_DBConnection()
        {
            Assert.That(DBConnection.getConnection(), Is.Not.Null);
        }

        [Test]
        public void Test03_UserLogin()
        {
            user = new User();
            userid = "admin";
            password = "admin";
            user.Name = userid;
            user.Password = password;
            Assert.AreEqual(true, DataAccess.isUser(user));
            Assert.AreEqual(true, Authentication.authenticate(userid, password));
        }

        [Test]
        public void Test04_InsertCategory()
        {
            category = new ItemCategory();
            category.Name = "Test Stationery";
            Assert.AreEqual(1, DataAccess.InsertItemCategory(category));
        }

        [Test]
        public void Test05_DeleteCategory()
        {
            Assert.AreEqual(1, DataAccess.DeleteCategory(category));
        }

        [Test]
        public void Test06_InsertSupplier()
        {
            supplier = new Supplier();
            supplier.Name = "Officeworks (pvt) Ltd";
            supplier.Address = "Matara";
            supplier.Phone = "0415555555";
            supplier.Email = "Officeworks@test.org";
            supplier.Description = "Stationery supplier";
            Assert.AreEqual(1, DataAccess.InsertSupplier(supplier));
        }

        [Test]
        public void Test07_DeleteSupplier()
        {
            Assert.AreEqual(1, DataAccess.DeleteSupplier(supplier));
        }

        [Test]
        public void Test08_InsertItem()
        {
            item = new Item();
            item.Category = categories[0];
            item.Supplier = suppliers[0];
            item.Description = "400 pcs Book";
            item.UnitPrice = 100.50;
            item.Quantity = 5;
            item.MinOrderQty = 100;
            item.ReorderQty = 25;
            Assert.AreEqual(1, DataAccess.InsertItem(item));
        }

        [Test]
        public void Test09_DeleteItem()
        {
            Assert.AreEqual(1, DataAccess.DeleteItem(item));
        }

        [Test]
        public void Test10_InsertCustomer()
        {
            customer = new Customer();
            customer.Name = "Mr. Silva";
            customer.Address = "Matara";
            customer.Phone = "0415555555";
            customer.Email = "silva@test.lk";
            customer.Notes = "This is a test";
            Assert.AreEqual(1, DataAccess.InsertCustomer(customer));
        }


        [Test]
        public void Test11_DeleteCustomer()
        {
            Assert.AreEqual(1, DataAccess.DeleteCustomer(customer));
        }


        [Test]
        public void Test12_InsertInvoice()
        {
            double total = 0;
            solditem_a = new SoldItem();
            solditem_a.Item = items[0];
            solditem_a.UnitPrice = items[0].UnitPrice;
            solditem_a.Quantity = 2;
            total += solditem_a.UnitPrice * solditem_a.Quantity;
            solditem_b = new SoldItem();
            solditem_b.Item = items[1];
            solditem_b.UnitPrice = items[1].UnitPrice;
            solditem_b.Quantity = 12;
            total += solditem_b.UnitPrice * solditem_b.Quantity;

            invoice = new Invoice();
            invoice.Customer = customers[0];
            invoice.IsPaid = false;
            invoice.IsCredit = true;
            invoice.Total = total;

            Assert.AreEqual(1, DataAccess.InsertInvoice(invoice));
        }

        [Test]
        public void Test13_InsertSoldItems()
        {

            solditem_a.Invoice = invoice;
            solditem_b.Invoice = invoice;
            Assert.AreEqual(1, DataAccess.InsertSoldItem(solditem_a));
            Assert.AreEqual(1, DataAccess.InsertSoldItem(solditem_b));
        }

        [Test]
        public void Test14_InsertPayment()
        {
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Paid", "0");
         //   invoices = invoice;
            payment = new Payment();
            payment.Invoice = invoice;
            payment.Amount = (invoice.Total - 50);
            payment.Balance = 50;
            payment.PaidDate = DateTime.Now;
            Assert.AreEqual(1, DataAccess.InsertPayment(payment));
        }

        [Test]
        public void Test15_InsertOrder()
        {
            double total = 0;
            orderItem_a = new OrderItem();
            orderItem_a.Item = items[0];
            orderItem_a.Quantity = items[0].MinOrderQty;
            orderItem_a.ReceivedQuantity = 0;
            orderItem_a.UnitCost = (items[0].UnitPrice - items[0].UnitPrice / 10);
            total += orderItem_a.UnitCost * orderItem_a.Quantity;
            orderItem_b = new OrderItem();
            orderItem_b.Item = items[1];
            orderItem_b.Quantity = items[1].MinOrderQty;
            orderItem_b.ReceivedQuantity = 0;
            orderItem_b.UnitCost = (items[1].UnitPrice - items[1].UnitPrice / 10);
            total += orderItem_b.UnitCost * orderItem_b.Quantity;
            order = new Order();
            order.Supplier = suppliers[0];
            order.OrderDate = DateTime.Now;
            order.IsReceived = false;
            order.Total = total;
            Assert.AreEqual(1, DataAccess.InsertOrder(order));
            //orderItem_a.Order = order;
            //orderItem_b.Order = order;
            //Assert.AreEqual(1, DataAccess.InsertOrderItem(a));
            //Assert.AreEqual(1, DataAccess.InsertOrderItem(b));
        }

        [Test]
        public void Test16_InsertOrderItems()
        {
           orderItem_a.Order = order;
           orderItem_b.Order = order;
           Assert.AreEqual(1, DataAccess.InsertOrderItem(orderItem_a));
           Assert.AreEqual(1, DataAccess.InsertOrderItem(orderItem_b));
        }

        [Test]
        public void Test17_InsertUser()
        {
            user = new User();
            user.Name = "Test";
            user.Password = "Test";
            user.Category = 3;
            user.FullName = "Test user";
            Assert.AreEqual(1, DataAccess.InsertUser(user));
        }

        [Test]
        public void Test18_Orderreceived()
        {
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Received", "0");
            orders = DataAccess.GetOrders(null, filter);
            List<OrderItem> OrderItems = DataAccess.GetOrderItems(order);
            foreach (OrderItem a in OrderItems)
            {
                ReceivedItem b = new ReceivedItem();
                b.OrderItem = a;
                b.Quantity = a.Quantity;
                Assert.AreEqual(1, DataAccess.InsertReceivedItem(b));
            }
        }

        [Test]
        public void Test19_UpdateUser()
        {
            user.Password = "TestTest";
            Assert.AreEqual(1, DataAccess.UpdateUser(user));
        }

        [Test]
        public void Test20_DeleteUser()
        {
            Assert.AreEqual(1, DataAccess.DeleteUser(user));
        }

        [Test]
        public void Test21_UpdateCustomer()
        {
            Random rnd = new Random();
            customer = customers[0];
            customer.Address = "Galle";
            customer.Phone = "09155" + String.Format("{00000}", rnd.Next(99999));
            Assert.AreEqual(1, DataAccess.UpdateCustomer(customer));

        }


        [Test]
        public void Test22_UpdateSupplier()
        {
            Random rnd = new Random();
            supplier = suppliers[0];
            supplier.Address = "Galle";
            supplier.Phone = "09155" + String.Format("{00000}", rnd.Next(99999));
            Assert.AreEqual(1, DataAccess.UpdateSupplier(supplier));
        }

        [Test]
        public void Test23_UpdateItem()
        {
            item = items[0];
            Random rnd = new Random();
            item.UnitPrice = 100 + (100 * rnd.NextDouble());
            Assert.AreEqual(1, DataAccess.UpdateItem(item));

        }


        [Test]
        public void Test24_UpdateInvoice()
        {
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Paid", "0");
            invoices = DataAccess.GetInvoices(null, filter);
            invoice = invoices[0];
            invoice.IsPaid = true;
            Assert.AreEqual(1, DataAccess.UpdateInvoice(invoice));

        }

        [Test]
        public void Test25_UpdateOrder()
        {
            Console.Out.WriteLine("Test Test");
            IDictionary<String, String> filter = new Dictionary<String, String>();
            filter.Add("Received", "0");
            orders = DataAccess.GetOrders(null, filter);
            order = orders[0];
            order.IsReceived = true;
            Assert.AreEqual(1, DataAccess.UpdateOrder(order));

        }

        [Test]
        public void Test26_UpdateItemQuantity()
        {
            item = items[0];
            Assert.AreEqual(1, DataAccess.UpdateItemQuantity(item, 1));

        }
    }
}
