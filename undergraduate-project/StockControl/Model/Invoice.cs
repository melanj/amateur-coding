using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Invoice
    {
        private int _InvoiceNo;
        private Customer _Customer;
        private DateTime _InvoiceDate; 
        private double _Total;
        private Boolean _IsCredit;
        private Boolean _IsPaid;

        public int InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }

        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public Boolean IsCredit
        {
            get { return _IsCredit; }
            set { _IsCredit = value; }
        }
        public Boolean IsPaid
        {
            get { return _IsPaid; }
            set { _IsPaid = value; }
        }
    }
}
