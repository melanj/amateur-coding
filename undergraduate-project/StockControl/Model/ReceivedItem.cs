using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class ReceivedItem
    {
        private int _Id;
        private OrderItem _OrderItem;
        private int _Quantity;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public OrderItem OrderItem
        {
            get { return _OrderItem; }
            set { _OrderItem = value; }
        }

         public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
    }
}
