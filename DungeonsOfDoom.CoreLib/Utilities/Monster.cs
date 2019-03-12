using DungeonsOfDoom.CoreLib.Archetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.CoreLib
{
    public abstract class Monster : NonPlayerCharacter, IPackable, IAttackable
    {
        public Monster(int health, string name) : base(health, name)
        {
            ActiveArchetype = new MonsterArchetype();
        }

        public static int NumberOfMonsters { get; set; }
    }
}