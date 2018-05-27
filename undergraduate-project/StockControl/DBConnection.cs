using System;
using System.Data.Odbc;
using System.IO;

namespace StockControl
{
    public class DBConnection
    {
        private static OdbcConnection conn=null;

        // Initialized and open Database Connection 
        public DBConnection() {
            if (conn==null){ // if not Connection already stabilize
                try
                {
                conn = new OdbcConnection(getConnStr()); //Initialized new ODBC Database connection
                conn.Open(); // open database connection 
                }
                catch (OdbcException) // if error occurs when connecting to Database server
                {
                    throw new Exception("Unable to connect to database server:  Server does not exist or access denied");
                }
                catch (NullReferenceException) // if required settings not mention in configuration file 
                {
                    throw new Exception("Unable to read to configuration settings");
                }
                catch (FileNotFoundException) // if configuration file not found
                {
                    throw new Exception("Unable to find configuration file");
                }
                catch (Exception e) // if other error occurs
                {
                    throw new Exception("Following Error found while connecting to databse server: \r\n" + e.Message);
                }
            }
        }

        //get ODBC Connection String from configation file
        private string getConnStr()
        {
            OdbcConnectionStringBuilder ConnStr=new OdbcConnectionStringBuilder();
            config.init(); //Initialized config class
            ConnStr.Add("Driver",config.getValue("Driver")); // read ODBC Driver
            ConnStr.Add("server",config.getValue("Server")); // read database server
            ConnStr.Add("database",config.getValue("Database")); // read database name
            ConnStr.Add("uid",config.getValue("User")); // read database user
            ConnStr.Add("password",config.getValue("Password")); //read database password      
            return ConnStr.ConnectionString.ToString();
        }


        // get current Odbc Connection 
        public static OdbcConnection getConnection()
        {
            return conn;
        }

        // close the Connection
        public void close() {
            conn.Close();
        }

    }
}
