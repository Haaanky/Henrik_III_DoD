using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    class MonsterArchetype : Archetype
    {
        public MonsterArchetype() : base(30, "Monster", ArchetypeColors.Red)
        {
            Monster.NumberOfMonsters++;
        }
    }
}