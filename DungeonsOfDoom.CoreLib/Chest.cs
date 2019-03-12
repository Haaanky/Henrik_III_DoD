using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    class Chest : Item, IAttackable, IPackable
    {
        public Chest(string name, int price, int weight) : base(name, price, weight)
        {
            ActiveArchetype = new MonsterArchetype();
        }

        public int Health { get; set; }
        public Archetype ActiveArchetype { get; set; }

        public virtual void Attack(IAttackable target)
        {
            if (Damage < ActiveArchetype.Strength)
                Damage = ActiveArchetype.Strength;

            target.Health -= Damage;
        }
    }
}
