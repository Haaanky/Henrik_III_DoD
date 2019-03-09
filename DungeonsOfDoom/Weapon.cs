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

<<<<<<< HEAD
        //public int Damage { get; set; }
=======
        public int Damage { get; set; } // VERY IMPORTANT STUFF DO NOT REMOVE
>>>>>>> 17bf09e... Update Weapon.cs
        public int Durability { get; set; }
    }
}
