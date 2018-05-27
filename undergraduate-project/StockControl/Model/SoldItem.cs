using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class SoldItem
    {
        private int _Ref;
        private Item _Item;
        private Invoice _Invoice;
        private int _Quantity;
        private double _UnitPrice;
        
        public int Ref
        {
            get { return _Ref; }
            set { _Ref = value; }
        }

        public Item Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        
        public Invoice Invoice
        {
            get { return _Invoice; }
            set { _Invoice = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

    }
}
