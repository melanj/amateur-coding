using System;
using System.Xml;

namespace StockControl
{
    public class config
    {
        static XmlDocument configXML=null; 
        static XmlNode configRoot=null;
        static string configfile = "config.xml"; // defults

        //Initialized with defaults configuration file
        public static void init(){
        init(configfile);
        }

        // Initialized with given configuration file 
        public static void init(String file)
        {
            configfile = file;
            configXML = new XmlDocument();
            configXML.Load(configfile); // load XML config file
            configRoot = configXML.DocumentElement;
        }

        // get configure file path
        public static void SetConfigFile(String file)
        {
            configfile = file;
        }

        // get value of given XML Element 
        public static string  getValue(string name){
        if (configXML!=null && configRoot!=null)
            return configRoot[name].InnerText;
        else return "";
        }

        }
}
