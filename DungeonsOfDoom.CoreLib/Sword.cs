using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public class Sword : Weapon, IPackable
    {
        public Sword(string name, int price, int weight, int damage) : base(name, price, weight, damage)
        {
        }

        public override void ModifyPlayer(Character character)
        {
            character.ActiveArchetype.Strength += 10;
        }
    }
}
