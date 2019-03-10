using FirstClassLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Skeleton : Monster, IPackable, IAttackable
    {
        public Skeleton(int health, string name) : base (health, name)
        {
            //ActiveArchetype.Strength = numberGenerator.Next(5, 7);
            ActiveArchetype.Strength = RandomUtils.RandomGenerator(5, 7);
        }

        public override void Attack(IAttackable target)
        {
            if (target.ActiveArchetype.Strength >= 2 * ActiveArchetype.Strength)
                Damage = 2;
            else
                Damage = 5;

            target.Health -= Damage;
        }
    }
}