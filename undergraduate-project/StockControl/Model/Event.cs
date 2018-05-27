using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Event
    {
        private string _user;
        private string _description;
        private DateTime _time;

        public string user {
            set { _user = value; }
            get { return _user; }
        }

        public string description
        {
            set { _description = value; }
            get { return _description; }
        }

        public DateTime time
        {
            set { _time = value; }
            get { return _time; }
        }
    }
}
