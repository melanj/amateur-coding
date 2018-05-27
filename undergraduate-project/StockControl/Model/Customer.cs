using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Customer
    {
        private int _CusCode;
        private string _Name;
        private string _Address;
        private string _Phone;
        private string _Email;
        private int _Type;
        private string _Notes;
        
        public int CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; }
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
                
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
    }
}
