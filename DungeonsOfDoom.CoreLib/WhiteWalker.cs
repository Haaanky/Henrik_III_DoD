﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public class WhiteWalker : Monster, IPackable, IAttackable
    {
        public WhiteWalker(int health, string name) : base(health, name)
        {
        }
    }
}
