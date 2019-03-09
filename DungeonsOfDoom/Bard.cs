using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom
{
    class Bard : Archetype
    {
        public Bard() : base(30, "Bard")
        {
        }

        public static implicit operator Bard(List<Archetype> v)
        {
            return v;
        }
    }
}
