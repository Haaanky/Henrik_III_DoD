using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.CoreLib
{
    public abstract class Item : IPackable
    {
        public Item(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Damage = 0;
        }

        public int Damage { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public virtual void ModifyPlayer(Character character)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name}| Value: {Price}| Weight: {Weight}kg";
        }
    }
}
