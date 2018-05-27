using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class User
    {
        private string _Name; 
        private string _FullName; 
        private string _Password;
        private int _Category;

        public string Name {
            set {_Name = value; }
            get { return _Name; }
        }

        public string FullName
        {
            set { _FullName = value; }
            get { return _FullName; }
        }

        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }

        public int Category
        {
            set { _Category = value; }
            get { return _Category; }
        }
    }
}
