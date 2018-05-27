using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class OrderItem
    {
        private int _Ref;
        private Order _Order;
        private Item _Item;
        private int _Quantity;
        private int _ReceivedQuantity;
        private double _UnitCost;
        
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
        
        public Order Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public int ReceivedQuantity
        {
            get { return _ReceivedQuantity; }
            set { _ReceivedQuantity = value; }
        }

        public double UnitCost
        {
            get { return _UnitCost; }
            set { _UnitCost = value; }
        }
    }
}
