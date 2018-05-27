namespace StockControl
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSales = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaymentsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaymentsView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnnItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemsView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategoriesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategoriesView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomersView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupliers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupliersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupliersView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdersNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdersView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdersReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportsSales = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportsCurrentInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportsStockDemand = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportsorders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolschangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsTransactionLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpUserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.tbSale = new System.Windows.Forms.ToolStripButton();
            this.tbPayment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbInvoices = new System.Windows.Forms.ToolStripButton();
            this.tbItems = new System.Windows.Forms.ToolStripButton();
            this.tbCustomers = new System.Windows.Forms.ToolStripButton();
            this.tSupliers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUsers = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSales,
            this.mnuPayments,
            this.mnnItems,
            this.mnuCategories,
            this.mnuCustomers,
            this.mnuSupliers,
            this.mnuOrders,
            this.mnuReports,
            this.mnuTools,
            this.mnuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(774, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "Mainmenu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileLogin,
            this.mnuFileLogout,
            this.mnuFileSeparator,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileLogin
            // 
            this.mnuFileLogin.Name = "mnuFileLogin";
            this.mnuFileLogin.Size = new System.Drawing.Size(107, 22);
            this.mnuFileLogin.Text = "&Login";
            this.mnuFileLogin.ToolTipText = "login to system";
            this.mnuFileLogin.Click += new System.EventHandler(this.mnuFileLogin_Click);
            // 
            // mnuFileLogout
            // 
            this.mnuFileLogout.Enabled = false;
            this.mnuFileLogout.Name = "mnuFileLogout";
            this.mnuFileLogout.Size = new System.Drawing.Size(107, 22);
            this.mnuFileLogout.Text = "L&ogout";
            this.mnuFileLogout.Click += new System.EventHandler(this.mnuFileLogout_Click);
            // 
            // mnuFileSeparator
            // 
            this.mnuFileSeparator.Name = "mnuFileSeparator";
            this.mnuFileSeparator.Size = new System.Drawing.Size(104, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(107, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnuSales
            // 
            this.mnuSales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalesNew,
            this.mnuSalesView});
            this.mnuSales.Enabled = false;
            this.mnuSales.Name = "mnuSales";
            this.mnuSales.Size = new System.Drawing.Size(44, 20);
            this.mnuSales.Text = "&Sales";
            // 
            // mnuSalesNew
            // 
            this.mnuSalesNew.Name = "mnuSalesNew";
            this.mnuSalesNew.Size = new System.Drawing.Size(139, 22);
            this.mnuSalesNew.Text = "New Sale";
            this.mnuSalesNew.Click += new System.EventHandler(this.mnuSalesNew_Click);
            // 
            // mnuSalesView
            // 
            this.mnuSalesView.Name = "mnuSalesView";
            this.mnuSalesView.Size = new System.Drawing.Size(139, 22);
            this.mnuSalesView.Text = "View Invoices";
            this.mnuSalesView.Click += new System.EventHandler(this.mnuSalesView_Click);
            // 
            // mnuPayments
            // 
            this.mnuPayments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPaymentsAdd,
            this.mnuPaymentsView});
            this.mnuPayments.Enabled = false;
            this.mnuPayments.Name = "mnuPayments";
            this.mnuPayments.Size = new System.Drawing.Size(66, 20);
            this.mnuPayments.Text = "Payments";
            // 
            // mnuPaymentsAdd
            // 
            this.mnuPaymentsAdd.Name = "mnuPaymentsAdd";
            this.mnuPaymentsAdd.Size = new System.Drawing.Size(146, 22);
            this.mnuPaymentsAdd.Text = "Add Payment";
            this.mnuPaymentsAdd.Click += new System.EventHandler(this.mnuPaymentsAdd_Click);
            // 
            // mnuPaymentsView
            // 
            this.mnuPaymentsView.Name = "mnuPaymentsView";
            this.mnuPaymentsView.Size = new System.Drawing.Size(146, 22);
            this.mnuPaymentsView.Text = "View Payments";
            this.mnuPaymentsView.Click += new System.EventHandler(this.mnuPaymentsView_Click);
            // 
            // mnnItems
            // 
            this.mnnItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemsAdd,
            this.mnuItemsView});
            this.mnnItems.Enabled = false;
            this.mnnItems.Name = "mnnItems";
            this.mnnItems.Size = new System.Drawing.Size(46, 20);
            this.mnnItems.Text = "Items";
            // 
            // mnuItemsAdd
            // 
            this.mnuItemsAdd.Enabled = false;
            this.mnuItemsAdd.Name = "mnuItemsAdd";
            this.mnuItemsAdd.Size = new System.Drawing.Size(96, 22);
            this.mnuItemsAdd.Text = "Add";
            this.mnuItemsAdd.Click += new System.EventHandler(this.mnuItemsAdd_Click);
            // 
            // mnuItemsView
            // 
            this.mnuItemsView.Name = "mnuItemsView";
            this.mnuItemsView.Size = new System.Drawing.Size(96, 22);
            this.mnuItemsView.Text = "View";
            this.mnuItemsView.Click += new System.EventHandler(this.mnuItemsView_Click);
            // 
            // mnuCategories
            // 
            this.mnuCategories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategoriesAdd,
            this.mnuCategoriesView});
            this.mnuCategories.Enabled = false;
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new System.Drawing.Size(71, 20);
            this.mnuCategories.Text = "Categories";
            // 
            // mnuCategoriesAdd
            // 
            this.mnuCategoriesAdd.Enabled = false;
            this.mnuCategoriesAdd.Name = "mnuCategoriesAdd";
            this.mnuCategoriesAdd.Size = new System.Drawing.Size(96, 22);
            this.mnuCategoriesAdd.Text = "Add";
            this.mnuCategoriesAdd.Click += new System.EventHandler(this.mnuCategoriesAdd_Click);
            // 
            // mnuCategoriesView
            // 
            this.mnuCategoriesView.Name = "mnuCategoriesView";
            this.mnuCategoriesView.Size = new System.Drawing.Size(96, 22);
            this.mnuCategoriesView.Text = "View";
            this.mnuCategoriesView.Click += new System.EventHandler(this.mnuCategoriesView_Click);
            // 
            // mnuCustomers
            // 
            this.mnuCustomers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCustomersAdd,
            this.mnuCustomersView});
            this.mnuCustomers.Enabled = false;
            this.mnuCustomers.Name = "mnuCustomers";
            this.mnuCustomers.Size = new System.Drawing.Size(70, 20);
            this.mnuCustomers.Text = "Customers";
            // 
            // mnuCustomersAdd
            // 
            this.mnuCustomersAdd.Enabled = false;
            this.mnuCustomersAdd.Name = "mnuCustomersAdd";
            this.mnuCustomersAdd.Size = new System.Drawing.Size(96, 22);
            this.mnuCustomersAdd.Text = "Add";
            this.mnuCustomersAdd.Click += new System.EventHandler(this.mnuCustomersAdd_Click);
            // 
            // mnuCustomersView
            // 
            this.mnuCustomersView.Name = "mnuCustomersView";
            this.mnuCustomersView.Size = new System.Drawing.Size(96, 22);
            this.mnuCustomersView.Text = "View";
            this.mnuCustomersView.Click += new System.EventHandler(this.mnuCustomersView_Click);
            // 
            // mnuSupliers
            // 
            this.mnuSupliers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSupliersAdd,
            this.mnuSupliersView});
            this.mnuSupliers.Enabled = false;
            this.mnuSupliers.Name = "mnuSupliers";
            this.mnuSupliers.Size = new System.Drawing.Size(56, 20);
            this.mnuSupliers.Text = "Supliers";
            // 
            // mnuSupliersAdd
            // 
            this.mnuSupliersAdd.Enabled = false;
            this.mnuSupliersAdd.Name = "mnuSupliersAdd";
            this.mnuSupliersAdd.Size = new System.Drawing.Size(96, 22);
            this.mnuSupliersAdd.Text = "Add";
            this.mnuSupliersAdd.Click += new System.EventHandler(this.mnuSupliersAdd_Click);
            // 
            // mnuSupliersView
            // 
            this.mnuSupliersView.Name = "mnuSupliersView";
            this.mnuSupliersView.Size = new System.Drawing.Size(96, 22);
            this.mnuSupliersView.Text = "View";
            this.mnuSupliersView.Click += new System.EventHandler(this.mnuSupliersView_Click);
            // 
            // mnuOrders
            // 
            this.mnuOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOrdersNew,
            this.mnuOrdersView,
            this.mnuOrdersReceived});
            this.mnuOrders.Enabled = false;
            this.mnuOrders.Name = "mnuOrders";
            this.mnuOrders.Size = new System.Drawing.Size(52, 20);
            this.mnuOrders.Text = "O&rders";
            // 
            // mnuOrdersNew
            // 
            this.mnuOrdersNew.Name = "mnuOrdersNew";
            this.mnuOrdersNew.Size = new System.Drawing.Size(132, 22);
            this.mnuOrdersNew.Text = "New Order";
            this.mnuOrdersNew.Click += new System.EventHandler(this.mnuOrdersNew_Click);
            // 
            // mnuOrdersView
            // 
            this.mnuOrdersView.Name = "mnuOrdersView";
            this.mnuOrdersView.Size = new System.Drawing.Size(132, 22);
            this.mnuOrdersView.Text = "View Orders";
            this.mnuOrdersView.Click += new System.EventHandler(this.mnuOrdersView_Click);
            // 
            // mnuOrdersReceived
            // 
            this.mnuOrdersReceived.Name = "mnuOrdersReceived";
            this.mnuOrdersReceived.Size = new System.Drawing.Size(132, 22);
            this.mnuOrdersReceived.Text = "Received";
            this.mnuOrdersReceived.Click += new System.EventHandler(this.mnuOrdersReceived_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportsSales,
            this.mnuReportsCurrentInventory,
            this.mnuReportsStockDemand,
            this.mnuReportsorders});
            this.mnuReports.Enabled = false;
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(57, 20);
            this.mnuReports.Text = "R&eports";
            // 
            // mnuReportsSales
            // 
            this.mnuReportsSales.Name = "mnuReportsSales";
            this.mnuReportsSales.Size = new System.Drawing.Size(162, 22);
            this.mnuReportsSales.Text = "Sales";
            this.mnuReportsSales.Click += new System.EventHandler(this.mnuReportsSales_Click);
            // 
            // mnuReportsCurrentInventory
            // 
            this.mnuReportsCurrentInventory.Name = "mnuReportsCurrentInventory";
            this.mnuReportsCurrentInventory.Size = new System.Drawing.Size(162, 22);
            this.mnuReportsCurrentInventory.Text = "Current Inventory";
            this.mnuReportsCurrentInventory.Click += new System.EventHandler(this.mnuReportsCurrentInventory_Click);
            // 
            // mnuReportsStockDemand
            // 
            this.mnuReportsStockDemand.Name = "mnuReportsStockDemand";
            this.mnuReportsStockDemand.Size = new System.Drawing.Size(162, 22);
            this.mnuReportsStockDemand.Text = "Stock Demand";
            this.mnuReportsStockDemand.Click += new System.EventHandler(this.mnuReportsStockDemand_Click);
            // 
            // mnuReportsorders
            // 
            this.mnuReportsorders.Name = "mnuReportsorders";
            this.mnuReportsorders.Size = new System.Drawing.Size(162, 22);
            this.mnuReportsorders.Text = "Orders";
            this.mnuReportsorders.Click += new System.EventHandler(this.mnuReportsorders_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsUsers,
            this.mnuToolschangePassword,
            this.mnuToolsTransactionLog,
            this.mnuBackup});
            this.mnuTools.Enabled = false;
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuToolsUsers
            // 
            this.mnuToolsUsers.Enabled = false;
            this.mnuToolsUsers.Name = "mnuToolsUsers";
            this.mnuToolsUsers.Size = new System.Drawing.Size(160, 22);
            this.mnuToolsUsers.Text = "Users";
            this.mnuToolsUsers.Click += new System.EventHandler(this.mnuToolsUsers_Click);
            // 
            // mnuToolschangePassword
            // 
            this.mnuToolschangePassword.Enabled = false;
            this.mnuToolschangePassword.Name = "mnuToolschangePassword";
            this.mnuToolschangePassword.Size = new System.Drawing.Size(160, 22);
            this.mnuToolschangePassword.Text = "Change Password";
            this.mnuToolschangePassword.Click += new System.EventHandler(this.mnuToolschangePassword_Click);
            // 
            // mnuToolsTransactionLog
            // 
            this.mnuToolsTransactionLog.Enabled = false;
            this.mnuToolsTransactionLog.Name = "mnuToolsTransactionLog";
            this.mnuToolsTransactionLog.Size = new System.Drawing.Size(160, 22);
            this.mnuToolsTransactionLog.Text = "Transaction Log";
            this.mnuToolsTransactionLog.Click += new System.EventHandler(this.mnuToolsTransactionLog_Click);
            // 
            // mnuBackup
            // 
            this.mnuBackup.Enabled = false;
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(160, 22);
            this.mnuBackup.Text = "Backup";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpUserManual,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpUserManual
            // 
            this.mnuHelpUserManual.Name = "mnuHelpUserManual";
            this.mnuHelpUserManual.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpUserManual.Text = "User Manual";
            this.mnuHelpUserManual.Visible = false;
            this.mnuHelpUserManual.Click += new System.EventHandler(this.mnuHelpUserManual_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolbar
            // 
            this.toolbar.Enabled = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSale,
            this.tbPayment,
            this.toolStripSeparator1,
            this.tbInvoices,
            this.tbItems,
            this.tbCustomers,
            this.tSupliers,
            this.toolStripSeparator2,
            this.tbUsers});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(774, 68);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.Visible = false;
            // 
            // tbSale
            // 
            this.tbSale.Image = global::StockControl.Properties.Resources.shopping_cart_icon48x48;
            this.tbSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSale.Name = "tbSale";
            this.tbSale.Size = new System.Drawing.Size(55, 65);
            this.tbSale.Text = "New Sale";
            this.tbSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbSale.Click += new System.EventHandler(this.tbSale_Click);
            // 
            // tbPayment
            // 
            this.tbPayment.Image = global::StockControl.Properties.Resources.Money_icon;
            this.tbPayment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.Size = new System.Drawing.Size(77, 65);
            this.tbPayment.Text = "New Payment";
            this.tbPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbPayment.Click += new System.EventHandler(this.tbPayment_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 68);
            // 
            // tbInvoices
            // 
            this.tbInvoices.Image = global::StockControl.Properties.Resources.invoice_icon;
            this.tbInvoices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbInvoices.Name = "tbInvoices";
            this.tbInvoices.Size = new System.Drawing.Size(52, 65);
            this.tbInvoices.Text = "Invoices";
            this.tbInvoices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbInvoices.Click += new System.EventHandler(this.tbInvoices_Click);
            // 
            // tbItems
            // 
            this.tbItems.Image = global::StockControl.Properties.Resources.folder_item_icon;
            this.tbItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbItems.Name = "tbItems";
            this.tbItems.Size = new System.Drawing.Size(52, 65);
            this.tbItems.Text = "Items";
            this.tbItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbItems.Click += new System.EventHandler(this.tbItems_Click);
            // 
            // tbCustomers
            // 
            this.tbCustomers.Image = global::StockControl.Properties.Resources.folder_customer_icon;
            this.tbCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCustomers.Name = "tbCustomers";
            this.tbCustomers.Size = new System.Drawing.Size(62, 65);
            this.tbCustomers.Text = "Customers";
            this.tbCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbCustomers.Click += new System.EventHandler(this.tbCustomers_Click);
            // 
            // tSupliers
            // 
            this.tSupliers.Image = global::StockControl.Properties.Resources.Uptight_icon;
            this.tSupliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSupliers.Name = "tSupliers";
            this.tSupliers.Size = new System.Drawing.Size(52, 65);
            this.tSupliers.Text = "Supliers";
            this.tSupliers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSupliers.Click += new System.EventHandler(this.tSupliers_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 68);
            // 
            // tbUsers
            // 
            this.tbUsers.Enabled = false;
            this.tbUsers.Image = global::StockControl.Properties.Resources.she_users_icon;
            this.tbUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUsers.Name = "tbUsers";
            this.tbUsers.Size = new System.Drawing.Size(52, 65);
            this.tbUsers.Text = "Users";
            this.tbUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbUsers.ToolTipText = "Manage Users";
            this.tbUsers.Click += new System.EventHandler(this.tbUsers_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 484);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(774, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StockControl.Properties.Resources.pgg_1360x768;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(774, 506);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Control and Billing System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainUI_FormClosed);
            this.Shown += new System.EventHandler(this.MainUI_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
        private System.Windows.Forms.ToolStripSeparator mnuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSales;
        private System.Windows.Forms.ToolStripMenuItem mnuOrders;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpUserManual;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesNew;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesView;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdersNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdersView;
        private System.Windows.Forms.ToolStripMenuItem mnuPayments;
        private System.Windows.Forms.ToolStripMenuItem mnuPaymentsAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuPaymentsView;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdersReceived;
        private System.Windows.Forms.ToolStripMenuItem mnuReportsSales;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuToolschangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTransactionLog;
        private System.Windows.Forms.ToolStripButton tbSale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbPayment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbUsers;
        private System.Windows.Forms.ToolStripButton tbInvoices;
        private System.Windows.Forms.ToolStripButton tbCustomers;
        private System.Windows.Forms.ToolStripButton tbItems;
        private System.Windows.Forms.ToolStripButton tSupliers;
        private System.Windows.Forms.ToolStripMenuItem mnuReportsCurrentInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuReportsStockDemand;
        private System.Windows.Forms.ToolStripMenuItem mnuReportsorders;
        private System.Windows.Forms.ToolStripMenuItem mnnItems;
        private System.Windows.Forms.ToolStripMenuItem mnuItemsAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuItemsView;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuCategoriesAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuCategoriesView;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomersAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomersView;
        private System.Windows.Forms.ToolStripMenuItem mnuSupliers;
        private System.Windows.Forms.ToolStripMenuItem mnuSupliersAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuSupliersView;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
    }
}

