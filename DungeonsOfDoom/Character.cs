using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    abstract class Character : IPackable
    {
        protected Random numberGenerator = new Random();

        private string name;

        public Character(int health, string name)
        {
            Health = health;
            Name = name;
            //ActiveArchetype = new MonsterArchetype();
            SetArchetype(new MonsterArchetype());
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length < 2)
                    throw new Exception("Has to be 2 or more characters long");
                else if (value.Length > 15)
                    throw new Exception("Has to be shorter than 15 characters long");
                else if (value == String.Empty)
                    throw new Exception("Can't be an empty string");
                name = value;
            }
        }

        public int Health { get; set; }
        public int Damage { get; set; }
        public int Weight { get; set; }
        public int Money { get; set; }

        public Inventory CharacterInventory { get; set; }
        public Archetype ActiveArchetype { get; set; }

        public virtual void Attack(IAttackable target)
        {
            if (Damage < ActiveArchetype.Strength)
                Damage = ActiveArchetype.Strength;

            target.Health -= Damage;
        }

        public virtual void SetArchetype(Archetype archetype)
        {
            ActiveArchetype = archetype;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Health: {Health}, Class: {ActiveArchetype}";
        }
    }
}
