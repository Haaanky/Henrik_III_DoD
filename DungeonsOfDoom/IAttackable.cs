using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    interface IAttackable
    {
        int Health { get; set; }
        int Damage { get; set; }

        Archetype ActiveArchetype { get; set; }

        void Attack(IAttackable target);
    }
}