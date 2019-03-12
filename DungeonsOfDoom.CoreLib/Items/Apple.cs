using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib.Items
{
    public class Apple : Item, IPackable
    {
        public Apple(int price, int weight ) : base ("Apple", price, weight)
        {
        }

        public override void ModifyPlayer(Character character)
        {
            character.Health += 10;
        }
    }
}