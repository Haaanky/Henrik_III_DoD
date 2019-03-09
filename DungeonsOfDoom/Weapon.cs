using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    abstract class Weapon : Item, IPackable
    {
        public Weapon(string name, int price, int weight, int damage) : base(name, price, weight)
        {
            Damage = damage;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Value: {Price} | Weight: {Weight}kg | Damage: {Damage}";
        }

        public int Durability { get; set; }
    }
}
