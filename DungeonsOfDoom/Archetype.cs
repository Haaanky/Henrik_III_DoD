using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FirstClassLib;

namespace DungeonsOfDoom
{
    abstract class Archetype
    {
        public enum ArchetypeColors
        {
            Green,
            Blue,
            Red,
            Purple,
            Yellow,
            Orange,
            Pink,
            DarkBlue,
            DarkGreen,
            DarkRed,
            Gray,
            Cyan,
            DarkCyan,
        }

        public Archetype(int baseHealth, string aName, ArchetypeColors color)
        {
            BaseHealth = baseHealth;
            ArchtypeName = aName;
            RandomizeStartingStats();
            Damage = Strength;
            ArchetypeColor = color;
            ColorToConsole = LocalConsoleUtils.ConvertArchetypeColorToConsoleColor(color);
        }

        public ConsoleColor ColorToConsole { get; set; }

        private void RandomizeStartingStats()
        {
            var statArray = new List<int> { Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma };
            while (statArray.Sum() < 70)
            {
                for (int i = 0; i < 6; i++)
                {
                    var diceResult = RandomUtils.DiceRoller(4, 6, RandomUtils.DieCondition.DropLowest);
                    switch (i)
                    {
                        case 0: statArray[i] = Strength = diceResult.Sum(); break;
                        case 1: statArray[i] = Dexterity = diceResult.Sum(); break;
                        case 2: statArray[i] = Constitution = diceResult.Sum(); break;
                        case 3: statArray[i] = Intelligence = diceResult.Sum(); break;
                        case 4: statArray[i] = Wisdom = diceResult.Sum(); break;
                        case 5: statArray[i] = Charisma = diceResult.Sum(); break;
                        default:
                            break;
                    }
                }
            }
        }

        public int BaseHealth { get; set; }
        public string ArchtypeName { get; set; }
        private ArchetypeColors ArchetypeColor { get; set; }


        public int Damage { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }


    }
}