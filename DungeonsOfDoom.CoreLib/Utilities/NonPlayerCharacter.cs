using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public abstract class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(int health, string name) : base(health, name)
        {
        }
    }
}
