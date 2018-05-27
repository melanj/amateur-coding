namespace StockControl
{
    partial class Users
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ColUserName = new System.Windows.Forms.ColumnHeader();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.ColFullName = new System.Windows.Forms.ColumnHeader();
            this.ColCategory = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = global::StockControl.Properties.Resources.remove_icon16;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(300, 282);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(67, 25);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Image = global::StockControl.Properties.Resources.repeat_icon;
            this.cmdModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModify.Location = new System.Drawing.Point(163, 255);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(119, 25);
            this.cmdModify.TabIndex = 12;
            this.cmdModify.Text = "Change Password";
            this.cmdModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Image = global::StockControl.Properties.Resources.she_user_remove_icon16;
            this.cmdRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemove.Location = new System.Drawing.Point(83, 255);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(74, 25);
            this.cmdRemove.TabIndex = 11;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = global::StockControl.Properties.Resources.she_user_add_icon16;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 255);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(65, 25);
            this.cmdAdd.TabIndex = 10;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ColUserName
            // 
            this.ColUserName.Text = "User Name";
            this.ColUserName.Width = 98;
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColUserName,
            this.ColFullName,
            this.ColCategory});
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.GridLines = true;
            this.lstUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstUsers.Location = new System.Drawing.Point(12, 12);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstUsers.ShowGroups = false;
            this.lstUsers.ShowItemToolTips = true;
            this.lstUsers.Size = new System.Drawing.Size(355, 237);
            this.lstUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstUsers.TabIndex = 9;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // ColFullName
            // 
            this.ColFullName.Text = "Full Name";
            this.ColFullName.Width = 136;
            // 
            // ColCategory
            // 
            this.ColCategory.Text = "Category";
            this.ColCategory.Width = 96;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 319);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdModify);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lstUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Users";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdModify;
        internal System.Windows.Forms.Button cmdRemove;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.ColumnHeader ColUserName;
        internal System.Windows.Forms.ListView lstUsers;
        internal System.Windows.Forms.ColumnHeader ColFullName;
        internal System.Windows.Forms.ColumnHeader ColCategory;
    }
}