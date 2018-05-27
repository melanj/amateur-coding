using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Diagnostics;
namespace StockControl
{
    public partial class Backup : Form
    {
        int isRestore = 0; // is system restored 
        bool isfirst = true; // is from close clicked in first time

        private delegate void changeBackupPBCall();
        private delegate void changeRestorePBCall();
        
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {

        }
        
         //change backup Progress bar 
        private void changeBackupPB()
        {
            if (BackupProgress.InvokeRequired)
           {
               changeBackupPBCall callback = new changeBackupPBCall(changeBackupPB);
                Invoke(callback);
           }
            else BackupProgress.Style = ProgressBarStyle.Blocks;
        }

        //change Restore Progress bar 
        private void changeRestorePB()
        {
            if (RestoreProgress.InvokeRequired)
            {
                changeRestorePBCall callback = new changeRestorePBCall(changeRestorePB);
                Invoke(callback);
            }
            else RestoreProgress.Style = ProgressBarStyle.Blocks;
        }

        // backup database
        void backup(object file_name)
        {
            string tmpfile = System.Environment.GetEnvironmentVariable("TEMP") + "\\stockbackup.sql";
            String filename = (String)file_name;
            try
            {
                StreamWriter file = new StreamWriter(tmpfile);
                ProcessStartInfo proc = new ProcessStartInfo();
                string cmd = string.Format(@"-u{0} -p{1} -h{2} {3}", config.getValue("User"), config.getValue("Password"), config.getValue("Server"), config.getValue("Database"));
                proc.FileName = "mysqldump"; //mysqldump exe name
                proc.RedirectStandardInput = false;
                proc.RedirectStandardOutput = true;
                proc.Arguments = cmd;
                proc.UseShellExecute = false;
                Process p = Process.Start(proc); // start mysqldump process
                string res;
                res = p.StandardOutput.ReadToEnd(); // get mysqldump output to string
                file.WriteLine(res); // write  output text to file
                p.WaitForExit();
                file.Close();
                FileStream inFile = new FileStream(tmpfile, FileMode.Open); // re-open SQL file to compress 
                FileStream outFile = File.Create(filename); //create GZip file
                GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress);
                byte[] Data = new byte[inFile.Length];
                inFile.Read(Data, 0, Data.Length);
                Compress.Write(Data, 0, Data.Length); //write SQL file content to GZip file
                Compress.Flush();
                Compress.Close();
                inFile.Close();
                File.Delete(tmpfile); //delete temp file
                changeBackupPB(); // change prograss bar
                //Show message if success 
                MessageBox.Show("Backup complete!\nFile: " + filename, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception) // if error occurs when starting mysqldump.exe 
            {
                changeRestorePB();
                MessageBox.Show("Mysql command-line tools not installed on system or you have not added the MySQL bin directory to your Windows PATH", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (IOException ex) // if input/output error occurs
            {
                changeBackupPB();
                MessageBox.Show("Cannot backup because of an I/O device error : " + ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex) // if other error occurs
            {
                changeBackupPB();
                MessageBox.Show("Cannot Backup: " + ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //restore database
        void restore(object file_name)
        {
            String tmpfile = System.Environment.GetEnvironmentVariable("TEMP") + "\\stockrestore.sql";
            String filename = (String)file_name;
            RestoreProgress.Style = ProgressBarStyle.Marquee;
            try
            {
                FileInfo fi = new FileInfo(filename);
                FileStream inFile = fi.OpenRead(); // open GZip file
                FileStream outFile = File.Create(tmpfile); //open new SQL file
                GZipStream Compress = new GZipStream(inFile, CompressionMode.Decompress);
                int len = 0;
                while (Compress.ReadByte() != -1)
                    len++; //get length of total text
                Compress.Close();
                inFile.Close();
                inFile = fi.OpenRead();
                Compress = new GZipStream(inFile, CompressionMode.Decompress);
                byte[] Data = new byte[len]; // create byte array length of toatl text
                Compress.Read(Data, 0, Data.Length); //read decompress data from GZip file to byte array
                outFile.Write(Data, 0, Data.Length); //read byte array to output SQL file
                outFile.Flush();
                outFile.Close();

                StreamReader file = new StreamReader(tmpfile); //re-open SQL file for restore 
                string input = file.ReadToEnd(); //read all data to string
                file.Close();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql"; //mysql exe file
                psi.RedirectStandardInput = true;
                psi.RedirectStandardError = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", config.getValue("User"), config.getValue("Password"), config.getValue("Server"), config.getValue("Database"));
                psi.UseShellExecute = false;
                Process process = Process.Start(psi); // start mysql process
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                StreamReader stderr = process.StandardError;
                process.Close();
                string restext = stderr.ReadToEnd();
                if (restext != "")
                {
                    //if any stderror occurs when running mysql.exe
                    throw new Exception("unable to access server under current security context");
                }
                inFile.Close();
                File.Delete(tmpfile); // delete temp SQL file
                changeRestorePB();
                //Show message if success 
                MessageBox.Show("Restore complete!", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isRestore = 1; // set restore=1
            }
            catch (Win32Exception)  // if error occurs when starting mysql.exe 
            {
                changeRestorePB();
                MessageBox.Show("Mysql command-line tools not installed on system or you have not added the MySQL bin directory to your Windows PATH", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (IOException) // if input/output error occurs
            {
                changeRestorePB();
                MessageBox.Show("a required file is either corrupted or not available.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex) // if other error occurs
            {
                changeRestorePB();
                MessageBox.Show("Error:" + ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

         private void cmdBackup_Click(object sender, EventArgs e)
        {
            DlgSave.FileName = String.Format("Backup_{0:yyyyMMdd_hhmm}",DateTime.Now);
            if (DlgSave.ShowDialog() == DialogResult.OK) // if save dialog success 
            {
               BackupProgress.Style = ProgressBarStyle.Marquee;
               Thread BackupThread = new Thread(backup);
               BackupThread.Start(DlgSave.FileName); // start backup in new Thread
               cmdBackup.Enabled = false;
            }

        }

        private void cmdBrowse_Click(object sender, EventArgs e) // browse restore file
        {
            if (DlgOpen.ShowDialog() == DialogResult.OK) {
                lbPath.Text = DlgOpen.FileName;
            }
        }

        private void cmdRestore_Click(object sender, EventArgs e)
        {
            
            if (lbPath.Text.Length > 0) { // if restore file browsed
                if (MessageBox.Show("All data will be lost if any error occurs!!\nAre you sure wanted to continue restore process? Please make sure existing backup files clear and correct format!", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RestoreProgress.Style = ProgressBarStyle.Marquee;
                    Thread RestoreThread = new Thread(restore);
                    RestoreThread.Start(lbPath.Text); // start restore in new Thread
                    cmdRestore.Enabled = false;
            }               

            }
            else MessageBox.Show("Please select a file", "Restore from", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            // close and dispose this form
            Close();
            Dispose();
        }

        private void Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRestore == 1 && isfirst) //if restore success 
            {
                isfirst = false;
                MessageBox.Show("Application will be quit after a restore process,Please re-start application", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainUI.allowexit = true; // set Mainform's allowexit=true for exit without prompt 
                Application.Exit(); // exit application
            }
        }
    }
}