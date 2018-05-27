using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Payment
    {
        private int _Ref;
        private Invoice _Invoice;
        private DateTime _PaidDate;
        private double _Amount;
        private double _Balance;
       
        public int Ref
        {
            get { return _Ref; }
            set { _Ref = value; }
        }

        public Invoice Invoice
        {
            get { return _Invoice; }
            set { _Invoice = value; }
        }

        public DateTime PaidDate
        {
            get { return _PaidDate; }
            set { _PaidDate = value; }
        }

        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

    }
}
