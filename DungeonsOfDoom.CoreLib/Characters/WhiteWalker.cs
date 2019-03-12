using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib.Characters
{
    public class WhiteWalker : Monster, IPackable, IAttackable
    {
        public WhiteWalker(int health, string name) : base(health, name)
        {
        }
    }
}
