using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Model
{
    public class ItemCategory
    {
        private int _Id;
        private string _Name;

        public ItemCategory() { }

        public ItemCategory(int id, string name) { _Id = id; _Name = name; }

        public int Id {
            set { _Id = value; }
            get { return _Id; }
        }

        public string Name {
            set { _Name = value; }
            get { return _Name; }
        }
    }
}
