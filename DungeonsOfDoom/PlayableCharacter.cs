using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class PlayableCharacter : Character
    {
        public PlayableCharacter(int health, int x, int y, string name) : base(health, name)
        {
            X = x;
            Y = y;
            MaxCarryingCapacity = 15;
        }

        public int MaxCarryingCapacity { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
