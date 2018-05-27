using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Order
    {
        private int _OrderNo;
        private Supplier _Supplier;
        private DateTime _OrderDate; 
        private double _Total;
        private Boolean _IsReceived;

          public int OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }

          public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public Boolean IsReceived
        {
            get { return _IsReceived; }
            set { _IsReceived = value; }
        }
    }
}
