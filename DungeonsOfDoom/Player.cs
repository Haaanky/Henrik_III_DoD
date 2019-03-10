using FirstClassLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Player : PlayableCharacter, IAttackable
    {
        public Player(string name) : base(30, RandomUtils.RandomGenerator(0, ConsoleGame.gameBoardX), RandomUtils.RandomGenerator(0, ConsoleGame.gameBoardY), name)
        {
        }
    }
}