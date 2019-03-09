using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        private static Random random = new Random();
        public enum DieCondition
        {
            None,
            KeepLowest,
            KeepHighest,
            DropLowest,
            DropHighest,
        }


        public static int RandomGenerator(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static bool CheckPercentage(int percentageValue)
        {
            if (random.Next(0, 100) < percentageValue)
                return true;
            else return false;
        }

        public static List<int> DiceRoller(int numberOfDice, int sidesOnDie, DieCondition conditioner)
        {
            var diceList = new List<int>();

            for (int i = 0; i < numberOfDice; i++)
            {
                diceList.Add(RandomGenerator(1, sidesOnDie + 1));
            }
            diceList.Sort();

            switch (conditioner)
            {
                case DieCondition.None:
                    break;
                case DieCondition.KeepLowest:
                    diceList.RemoveRange(1, diceList.Count - 1);
                    break;
                case DieCondition.KeepHighest:
                    diceList.RemoveRange(0, diceList.Count - 2);
                    break;
                case DieCondition.DropLowest:
                    diceList.RemoveAt(0);
                    break;
                case DieCondition.DropHighest:
                    diceList.RemoveAt(diceList.Count - 1);
                    break;
                default:
                    break;
            }

            return diceList;
        }
    }
}