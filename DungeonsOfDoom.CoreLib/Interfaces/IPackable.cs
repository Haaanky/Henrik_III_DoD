using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfDoom.CoreLib
{
    public interface IPackable
    {
        string Name { get; }
        int Weight { get; }
    }
}
