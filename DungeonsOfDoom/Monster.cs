using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : NonPlayerCharacter, IPackable, IAttackable
    {
        public Monster(int health, string name) : base(health, name)
        {
            ActiveArchetype = new MonsterArchetype();
            NumberOfMonsters++;
        }

        public static int NumberOfMonsters { get; set; }
    }
}