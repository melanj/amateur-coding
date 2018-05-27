using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace Installer
{
    public partial class MainUI : Form
    {
        OdbcConnection conn;
        OdbcCommand scmd;
        OdbcDataReader srd;
        string dirpath;
        bool finishwork = false;
        bool finishworkwitherror = false;
        bool IsServer = false;
        bool IsCreateDB = true;
        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            //431, 298
            this.Height = 298;
            this.Width = 431;
            this.Update();
            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\StockControl";
        }

        private delegate void changePBCall();

        private void changePB()
        {
            if (prgInstall.InvokeRequired)
            {
                changePBCall callback = new changePBCall(changePB);
                Invoke(callback);
            }
            else { prgInstall.Style = ProgressBarStyle.Blocks;

            prgInstall.Value = 100;
            }
        }


        private void CreateConfig(String filename, String DbHost, String Db, String user, String password)
        {
            try
            {
                XmlWriter writer = XmlWriter.Create(filename, new XmlWriterSettings());
                writer.WriteStartDocument();
                writer.WriteStartElement("Configuration");
                writer.WriteElementString("Driver", "MySQL ODBC 5.1 Driver");
                writer.WriteElementString("Server", DbHost);
                writer.WriteElementString("Database", Db);
                writer.WriteElementString("User", user);
                writer.WriteElementString("Password", password);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (Exception)
            {
                throw new Exception("Cannot create configration file");
            }
        }

        private void install(Object par) {

            List<string> param = (List<string>)par;
            try
            {
                Directory.CreateDirectory(dirpath);
                DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
                if (IsServer)
                {
                    if (IsCreateDB)
                    {
                        String CreateDBSQL = "CREATE DATABASE IF NOT EXISTS " + param[0];
                        OdbcCommand CreateDB = new OdbcCommand(CreateDBSQL, conn);
                        CreateDB.ExecuteNonQuery();
                    }
                    Restore(Directory.GetCurrentDirectory() + "\\template.sql", "localhost", param[0], param[1], param[2]);
                }
                foreach (FileInfo fi in di.GetFiles())
                {
                    File.Copy(fi.FullName, dirpath + "\\" + fi.Name, true);

                }
                IWshRuntimeLibrary.WshShellClass WshShell = new IWshRuntimeLibrary.WshShellClass();
                IWshRuntimeLibrary.IWshShortcut Shortcut1;
                Shortcut1 = (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Stock Control and Billing System.lnk");
                Shortcut1.TargetPath = dirpath + "\\StockControl.exe";
                Shortcut1.Description = "Stock Control and Billing System";
                Shortcut1.WorkingDirectory = dirpath;
                Shortcut1.Save();
                IWshRuntimeLibrary.IWshShortcut Shortcut2;
                //   Directory.CreateDirectory(Environment.SpecialFolder.StartMenu + "\\Stock Control and Billing System");
                Shortcut2 = (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\Stock Control and Billing System.lnk");
                Shortcut2.TargetPath = dirpath + "\\StockControl.exe";
                Shortcut2.Description = "Stock Control and Billing System";
                Shortcut2.WorkingDirectory = dirpath;
                Shortcut2.Save();
                changePB();
                finishwork = true;
            }
            catch (Exception e)
            {
                finishworkwitherror = true;
                changePB();
                MessageBox.Show("Setup cannot continue because " + e.Message + "\n\n", "Error - Setup cannot continue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                finishwork = true;
            }
        }

    
        private void Restore(String filename, String DbHost, String Db, String user, String password)
        {
            bool IsStdErr=false;
            try
            {
                StreamReader file = new StreamReader(filename);
                string input = file.ReadToEnd();
                file.Close();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                //    psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", user, password, DbHost, Db);
                psi.UseShellExecute = false;
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                StreamReader stderr = process.StandardError;
                process.Close();
                string restext = stderr.ReadToEnd();
                if (restext != "")
                {
                    IsStdErr = true;
                    throw new Exception("unable to access server under current security context");
                }
            }
            catch (Win32Exception)
            {
                throw new Exception("Mysql command-line tools not installed on system or you have not added the MySQL bin directory to your Windows PATH");
            }
            catch (IOException)
            {
                throw new Exception("a required file is either corrupted or not available.");
            }
            catch (Exception e) {
                if( IsStdErr)
                    throw new Exception(e.Message);
                else
                    throw new Exception("an unknown wrror has occurred");
            }
        }


        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length <= 0) {
                MessageBox.Show("Please select installtion folder", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!optClinet.Checked && !OptServer.Checked)
            {
                MessageBox.Show("Please select one option", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (optClinet.Checked)
            {
                pfirst.Visible = false;
                pClient.Top = pfirst.Top;
                pClient.Left = pfirst.Left;
                pClient.Visible = true;
                txtServer.Focus();
            }
            else {
                pfirst.Visible = false;
                pServer.Top = pfirst.Top;
                pServer.Left = pfirst.Left;
                pServer.Visible = true;
                txtSUser.Focus();
            }
            dirpath = txtPath.Text;
        }

        private void cmdCBack_Click(object sender, EventArgs e)
        {
            pClient.Visible = false;
            pfirst.Visible = true;
        }

        private void cmdSBack_Click(object sender, EventArgs e)
        {
            pServer.Visible = false;
            pfirst.Visible = true;
        }

        private void cmbDB_Enter(object sender, EventArgs e)
        {
            String conStr;
            Control[] fld = { txtServer, txtuid, txtpasswd};
            if (Validation.validate(fld))
            {
                try
                {
                    if (cmbDB.Items.Count == 0)
                    {
                        conStr = "Driver={MySQL ODBC 5.1 Driver};";
                        conStr += "server=" + txtServer.Text + ";";
                        conStr += "uid=" + txtuid.Text + ";";
                        conStr += "password=" + txtpasswd.Text + ";";
                        conn = new OdbcConnection(conStr);
                        conn.Open();
                        scmd = new OdbcCommand("show databases", conn);
                        srd = scmd.ExecuteReader();
                        while (srd.Read())
                        {
                            cmbDB.Items.Add(srd.GetString(0));
                        }
                        srd.Close();
                        conn.Close();

                    }
                }
                catch (Exception)
                {
                 //   MessageBox.Show("please enter valid infomration before select database");
                }
            }
           // else MessageBox.Show(Validation.getMessage());
        }

        private void cmdCNext_Click(object sender, EventArgs e)
        {
            String conStr;
            Control[] fld = { txtServer, txtuid, txtpasswd,cmbDB};
            if (Validation.validate(fld))
            {
                cmdCNext.Enabled = false;
            try
            {
                conStr = "Driver={MySQL ODBC 5.1 Driver};";
                conStr += "server=" + txtServer.Text + ";";
                conStr += "database=" + cmbDB.Text + ";";
                conStr += "uid=" + txtuid.Text + ";";
                conStr += "password=" + txtpasswd.Text + ";";
                conn = new OdbcConnection(conStr);
                conn.Open();
                CreateConfig("config.xml", txtServer.Text, cmbDB.Text, txtuid.Text, txtpasswd.Text);
                pClient.Visible = false;
                pfinish.Top = pfirst.Top;
                pfinish.Left = pfirst.Left;
                pfinish.Visible = true;
            }
            catch (Exception)
            {
                cmdCNext.Enabled = true;
                MessageBox.Show("cannot connect to mysql server with current connection details. Make sure server is running and connecting details are correct!", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        else MessageBox.Show("Please fill out all required fields", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdSNext_Click(object sender, EventArgs e)
        {
            String conStr;
            Control[] fld = { cmbSDB, txtSUser,txtSpw};
            if (Validation.validate(fld))
            {
                cmdSNext.Enabled = false;
            try
            {
                conStr = "Driver={MySQL ODBC 5.1 Driver};";
                conStr += "server=localhost;";
                if (!chkCreateDB.Checked)
                    conStr += "database=" + cmbSDB.Text + ";";
                conStr += "uid=" + txtSUser.Text + ";";
                conStr += "password=" + txtSpw.Text + ";";
                conn = new OdbcConnection(conStr);
                conn.Open();
                IsServer = true;
                //if (chkCreateDB.Checked) {
                //    String CreateDBSQL = "CREATE DATABASE IF NOT EXISTS " + cmbSDB.Text;
                //    OdbcCommand CreateDB = new OdbcCommand(CreateDBSQL, conn);
                //    CreateDB.ExecuteNonQuery();
                //}
                //Restore(Directory.GetCurrentDirectory()+ "\\template.sql", "localhost", cmbSDB.Text, txtSUser.Text, txtSpw.Text);
                CreateConfig("config.xml", "localhost", cmbSDB.Text, txtSUser.Text, txtSpw.Text);
                pServer.Visible = false;
                pfinish.Top = pfirst.Top;
                pfinish.Left = pfirst.Left;
                pfinish.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to mysql server on localhost with current connection details. Make sure server is running on localhost and connecting details are correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmdSNext.Enabled = true;
            }
        }
        else MessageBox.Show("Please fill out all required fields", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkCreateDB_CheckedChanged(object sender, EventArgs e)
        {
            cmbSDB.DropDownStyle = (chkCreateDB.Checked) ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList;
        }

        private void cmbSDB_Enter(object sender, EventArgs e)
        {
            String conStr;
            Control[] fld = { txtSUser, txtSpw };
            if (Validation.validate(fld))
            {
                try
                {
                    if (cmbSDB.Items.Count == 0 && cmbSDB.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        conStr = "Driver={MySQL ODBC 5.1 Driver};";
                        conStr += "server=localhost;";
                        conStr += "uid=" + txtSUser.Text + ";";
                        conStr += "password=" + txtSpw.Text + ";";
                        conn = new OdbcConnection(conStr);
                        conn.Open();
                        scmd = new OdbcCommand("show databases", conn);
                        srd = scmd.ExecuteReader();
                        while (srd.Read())
                        {
                            cmbSDB.Items.Add(srd.GetString(0));
                        }
                        srd.Close();
                        conn.Close();

                    }
                }
                catch (Exception){
                  //  MessageBox.Show(ex.Message);
                }
            }
          //  else MessageBox.Show(Validation.getMessage());
        }

        private void cmdFinish_Click(object sender, EventArgs e)
        {
            List<string> par = new List<string>();
            if (IsServer) {
                par.Add(cmbSDB.Text);
                par.Add(txtSUser.Text);
                par.Add(txtSpw.Text);
                IsCreateDB = chkCreateDB.Checked;
            }
            cmdFinish.Enabled = false;
            lbfinish.Text = "Please wait until installation is complete.";
            prgInstall.Style = ProgressBarStyle.Marquee;
            Thread InstallThread = new Thread(install);
            InstallThread.Start(par);
            WaitforExit.Enabled = true;
          //  this.Close();
          //  this.Dispose();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                if (folderBrowser.SelectedPath.EndsWith("\\"))
                txtPath.Text = folderBrowser.SelectedPath + "StockControl";
                else
                txtPath.Text = folderBrowser.SelectedPath + "\\StockControl";
            }
        }

        private void WaitforExit_Tick(object sender, EventArgs e)
        {
            if (finishwork)
            {
                WaitforExit.Enabled = false;
                if(!finishworkwitherror)
                MessageBox.Show("The Installer has successfully installed Stock Control and Billing System.\nyou can log to system now using default using and password.\n\nUser ID:  admin\tPassword: admin\n\n","Successfully installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Dispose();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finishwork)
                return;
            if (MessageBox.Show("Are you sure you want to cancel stock Control and Billing System installation", "Stock Control and Billing System Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void cmdSCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdFCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtuid.Focus();
        }

        private void txtuid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtpasswd.Focus();
        }

        private void txtpasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmbDB.Focus();
        }

        private void cmbDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmdCNext.Focus();
        }

        private void txtSUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtSpw.Focus();
        }

        private void txtSpw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmbSDB.Focus();
        }

        private void cmbSDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                cmdSNext.Focus();
        }


        }
}