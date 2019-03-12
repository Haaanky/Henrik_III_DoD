using FirstClassLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    class Player : PlayableCharacter, IAttackable
    {
        public Player(string name) : base(30, RandomUtils.RandomGenerator(0, World.gameBoardX), RandomUtils.RandomGenerator(0, World.gameBoardY), name)
        {
        }
    }
}