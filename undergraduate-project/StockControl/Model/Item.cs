using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class Item
    {
        private int _ItemCode;
        private string _Description;
        private ItemCategory _Category;
        private double _UnitPrice;
        private int _Quantity;
        private int _MinOrderQty;
        private int _ReorderQty;
        private Supplier _Supplier; 

        public int ItemCode {
            get { return _ItemCode; }
            set { _ItemCode = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public ItemCategory Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public int MinOrderQty
        {
            get { return _MinOrderQty; }
            set { _MinOrderQty = value; }
        }

        public int ReorderQty
        {
            get { return _ReorderQty; }
            set { _ReorderQty = value; }
        }

        public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        } 
    }
}
