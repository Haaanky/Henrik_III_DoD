using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Player : PlayableCharacter, IAttackable
    {
        public Player(int health, int x, int y, string name) : base(health, x, y, name)
        {

        }

        //public string ActiveArchetype
        //{
        //    get
        //    {
        //        if (Bard != null)
        //            activeArchetype = Bard.ArchtypeName;
        //        else if (FightingMan != null)
        //            activeArchetype = FightingMan.ArchtypeName;
        //        else if (MagicUser != null)
        //            activeArchetype = MagicUser.ArchtypeName;
        //        else if (Theif != null)
        //            activeArchetype = Theif.ArchtypeName;
        //        return activeArchetype;
        //    }
        //    private set
        //    {
        //    }
        //}

    }
}