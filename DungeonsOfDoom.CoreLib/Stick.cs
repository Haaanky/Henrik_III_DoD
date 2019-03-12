using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public class Stick : Weapon, IPackable
    {
        public Stick(int price, int weight, int damage) : base("Stick", price, weight, damage)
        {
        }
    }
}
