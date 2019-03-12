using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public class World
    {
        public const int gameBoardX = 20;
        public const int gameBoardY = 5;

        public Room[,] Map { get; set; }

        //Gör world med prop room
        //Enkel bara typ vara en 2d room array
    }
}