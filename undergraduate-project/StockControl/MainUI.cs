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
    public partial class MainUI : Form
    {

        DBConnection conn; // Database connection 
        public static bool allowexit=false;

        public MainUI()
        {
            InitializeComponent();
        }
        public Login fLogin;

        // Activate user menus and tools bar according to user category
        private void ActivateMenus(User user) {
            if (user != null && Authentication.IsAuthenticated()) // if Authenticated user 
            {
                // enable menus and tool buttons common for all user
                mnuFileLogout.Enabled = true;
                mnuFileLogin.Enabled = false;
                mnuSales.Enabled = true;
                mnuPayments.Enabled = true;
                mnuTools.Enabled = true;
                mnuToolschangePassword.Enabled = true;
                toolbar.Enabled = true;
                toolbar.Visible = true;
                mnnItems.Enabled = true;
                mnuCategories.Enabled = true;
                mnuCustomers.Enabled = true;
                mnuSupliers.Enabled = true;

                switch (user.Category)
                {
                    case 1:
                        // enable menus and tool buttons for administrator only
                        mnuOrders.Enabled = true;
                        mnuItemsAdd.Enabled = true;
                        mnuCategoriesAdd.Enabled = true;
                        mnuCustomersAdd.Enabled = true;
                        mnuSupliersAdd.Enabled = true;
                        mnuToolsUsers.Enabled = true;
                        mnuReports.Enabled = true;
                        mnuToolsTransactionLog.Enabled = true;
                        tbUsers.Enabled = true;
                        mnuBackup.Enabled = true;
                        break;
                    case 2:
                        // enable/disbale menus and tool buttons for Manager
                        mnuOrders.Enabled = true;
                        mnuItemsAdd.Enabled = true;
                        mnuCategoriesAdd.Enabled = true;
                        mnuCustomersAdd.Enabled = true;
                        mnuSupliersAdd.Enabled = true;
                        mnuToolsUsers.Enabled = false;
                        mnuReports.Enabled = true;
                        mnuToolsTransactionLog.Enabled = false;
                        tbUsers.Enabled = false;
                        mnuBackup.Enabled = false;
                        break;
                    case 3:
                    default:
                        // enable/disbale menus and tool buttons for other users
                        mnuOrders.Enabled = false;
                        mnuItemsAdd.Enabled = false;
                        mnuCategoriesAdd.Enabled = false;
                        mnuCustomersAdd.Enabled = false;
                        mnuSupliersAdd.Enabled = false;
                        mnuToolsUsers.Enabled = false;
                        mnuToolsTransactionLog.Enabled = false;
                        tbUsers.Enabled = false;
                        mnuBackup.Enabled = false;
                        break;
                }
            }
            else
            { // disbale all if un-Authenticated user 
                mnuFileLogout.Enabled = false;
                mnuFileLogin.Enabled = true; // enable login
                mnuSales.Enabled = false;
                mnuPayments.Enabled = false;
                mnuOrders.Enabled = false;
                mnnItems.Enabled = false;
                mnuCategories.Enabled = false;
                mnuCustomers.Enabled = false;
                mnuSupliers.Enabled = false;

                mnuTools.Enabled = false;
                mnuToolsUsers.Enabled = false;
                mnuReports.Enabled = false;
                mnuToolschangePassword.Enabled = false;
                toolbar.Enabled = false;
                toolbar.Visible = false;
                mnuBackup.Enabled = false;
            }
        }
          
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            // exiting to system
            if (allowexit)
                return;
            if (MessageBox.Show("Are you sure want to exit?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) // Show confirming message 
                e.Cancel = true;

        }

        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            // dispose this form and exit to system
            this.Dispose();
            Environment.Exit(0);
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            
            
        }

        private void MainUI_Shown(object sender, EventArgs e)
        {
            try
            {
                conn = new DBConnection();  //Initialized Database connection
                fLogin = new Login(); //Initialized login form
                fLogin.ShowDialog(); // show login form to capture username/ password
                ActivateMenus(Authentication.GetUser()); // Active menus according to user
            }
            catch (Exception ex) // if error occurs
            {
                // show any error and terminate application 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }


        private void mnuSalesNew_Click(object sender, EventArgs e)
        {
            // show AddInvoice form
            AddInvoice fAddInvoice = new AddInvoice();
            fAddInvoice.ShowDialog();
        }

        private void mnuOrdersNew_Click(object sender, EventArgs e)
        {
            AddOrder fAddOrder = new AddOrder();
            fAddOrder.ShowDialog();
        }

   
        private void mnuSalesView_Click(object sender, EventArgs e)
        {
            // show Invoices form
            Invoices fInvoices = new Invoices();
            fInvoices.ShowDialog();
        }

        private void mnuPaymentsAdd_Click(object sender, EventArgs e)
        {
            // show AddPayment form
            AddPayment fAddPayment = new AddPayment();
            fAddPayment.ShowDialog();
        }

        private void mnuPaymentsView_Click(object sender, EventArgs e)
        {
            // show Payments form
            Payments fPayments = new Payments();
            fPayments.ShowDialog();
        }

        private void mnuOrdersView_Click(object sender, EventArgs e)
        {
            // show Orders form
            Orders fOrders = new Orders();
            fOrders.ShowDialog();
        }

        private void mnuOrdersReceived_Click(object sender, EventArgs e)
        {
            // show AddReceivedOrder form
            AddReceivedOrder fAddReceivedOrder = new AddReceivedOrder();
            fAddReceivedOrder.ShowDialog();
        }

        private void mnuFileLogin_Click(object sender, EventArgs e)
        {
            // show Login form and activate menus
            fLogin = new Login();
            fLogin.ShowDialog();
            ActivateMenus(Authentication.GetUser());
        }

        private void mnuFileLogout_Click(object sender, EventArgs e)
        {
            // clear current authentication and De-Activate Menus 
            Authentication.clear();
            ActivateMenus(Authentication.GetUser());
        }

        private void mnuReportsSales_Click(object sender, EventArgs e)
        {
            // show Reports form and load sales report
            Reports fReports = new Reports();
            fReports.reportType = 1;
            fReports.SetReportSource(DataAccess.Sales(null, null));
            fReports.DisplayToolBar(true);
            fReports.ShowDialog();
        }

        private void mnuHelpUserManual_Click(object sender, EventArgs e)
        {
          
        }

        private void mnuToolsUsers_Click(object sender, EventArgs e)
        {
            // show Users form 
            Users fUsers = new Users();
            fUsers.ShowDialog();
        }

        private void mnuToolschangePassword_Click(object sender, EventArgs e)
        {
            // show ChangePassword form 
            ChangePassword fChangePassword = new ChangePassword();
            fChangePassword.SetUser(Authentication.GetUser());
            fChangePassword.ShowDialog();
        }

        private void mnuToolsTransactionLog_Click(object sender, EventArgs e)
        {
            // show TransactionLog form 
            TransactionLog fLog = new TransactionLog();
            fLog.ShowDialog();
        }

        private void tbSale_Click(object sender, EventArgs e)
        {
            mnuSalesNew.PerformClick();
        }

        private void tbPayment_Click(object sender, EventArgs e)
        {
            mnuPaymentsAdd.PerformClick();
        }

        private void tbInvoices_Click(object sender, EventArgs e)
        {
            mnuSalesView.PerformClick();
        }

        private void tbItems_Click(object sender, EventArgs e)
        {
            mnuItemsView.PerformClick();
        }

        private void tbCustomers_Click(object sender, EventArgs e)
        {
            mnuCustomersView.PerformClick();
        }

        private void tSupliers_Click(object sender, EventArgs e)
        {
            mnuSupliersView.PerformClick();
        }

        private void tbUsers_Click(object sender, EventArgs e)
        {
            mnuToolsUsers.PerformClick();
        }

        private void mnuReportsCurrentInventory_Click(object sender, EventArgs e)
        {
            // show Reports form and load current inventory report
            Reports fReports = new Reports();
            fReports.reportType = 2;
            fReports.SetReportSource(DataAccess.CurrentInventory());
            fReports.DisplayToolBar(false);
            fReports.ShowDialog();
        }

        private void mnuReportsStockDemand_Click(object sender, EventArgs e)
        {
            // show Reports form and load stock demand report
            Reports fReports = new Reports();
            fReports.reportType = 3;
            fReports.SetReportSource(DataAccess.StockDemand(null,null));
            fReports.DisplayToolBar(true);
            fReports.ShowDialog();
        }

        private void mnuReportsorders_Click(object sender, EventArgs e)
        {
            // show Reports form and load orders report
            Reports fReports = new Reports();
            fReports.reportType = 4;
            fReports.SetReportSource(DataAccess.Orders());
            fReports.DisplayToolBar(false);
            fReports.ShowDialog();
        }

        private void mnuItemsAdd_Click(object sender, EventArgs e)
        {
            // show AddItem form 
            AddItem fAddItem = new AddItem();
            fAddItem.ShowDialog();
        }

        private void mnuItemsView_Click(object sender, EventArgs e)
        {
            // show Items form 
            Items fItems = new Items();
            fItems.ShowDialog();
        }

        private void mnuCategoriesAdd_Click(object sender, EventArgs e)
        {
            // show AddCategory form 
            AddCategory fAddCategory = new AddCategory();
            fAddCategory.ShowDialog();
        }

        private void mnuCategoriesView_Click(object sender, EventArgs e)
        {
            // show Cetegories form 
            Categories fCategories = new Categories();
            fCategories.ShowDialog();
        }

        private void mnuCustomersAdd_Click(object sender, EventArgs e)
        {
            // show AddCustomer form 
            AddCustomer fAddCustomer = new AddCustomer();
            fAddCustomer.ShowDialog();
        }

        private void mnuCustomersView_Click(object sender, EventArgs e)
        {
            // show Customers form 
            Customers fCustomers = new Customers();
            fCustomers.ShowDialog();
        }

        private void mnuSupliersAdd_Click(object sender, EventArgs e)
        {
            // show AddSupplier form 
            AddSupplier fAddSupplier = new AddSupplier();
            fAddSupplier.ShowDialog();
        }

        private void mnuSupliersView_Click(object sender, EventArgs e)
        {
            // show Supplier form 
            Suppliers fSuppliers = new Suppliers();
            fSuppliers.ShowDialog();
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            // show Backup form 
            Backup fBackup = new Backup();
            fBackup.ShowDialog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            // show About form 
            About fAbout = new About();
            fAbout.ShowDialog();
        }

        }
}