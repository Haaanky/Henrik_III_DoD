using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    class Inventory
    {
        private int _weight;

        public List<IPackable> ListOfItems { get; set; }
        public int Weight
        {
            get
            {
                _weight = 0;
                for (int i = 0; i < ListOfItems.Count; i++)
                {
                    _weight += ListOfItems[i].Weight;
                }

                return _weight;
            }
            private set => _weight = value;
        }
    }
}
