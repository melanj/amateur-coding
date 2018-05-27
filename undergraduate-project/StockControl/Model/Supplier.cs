using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Supplier
    {
        private int _SupCode;
        private string _Name;
        private string _Address;
        private string _Phone;
        private string _Description;
        private string _Email;

        public int SupCode
        {
            get { return _SupCode; }
            set { _SupCode = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
