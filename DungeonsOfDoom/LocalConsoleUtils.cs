using System;
using System.Collections.Generic;
using System.Text;
using static DungeonsOfDoom.Archetype;

namespace DungeonsOfDoom
{
    static class LocalConsoleUtils
    {
        internal static ConsoleColor ConvertArchetypeColorToConsoleColor(ArchetypeColors colors)
        {
            switch (colors)
            {
                case ArchetypeColors.Green:
                    return ConsoleColor.Green;
                case ArchetypeColors.Blue:
                    return ConsoleColor.Blue;
                case ArchetypeColors.Red:
                    return ConsoleColor.Red;
                case ArchetypeColors.Purple:
                    return ConsoleColor.Magenta;
                case ArchetypeColors.Yellow:
                    return ConsoleColor.Yellow;
                case ArchetypeColors.Orange:
                    return ConsoleColor.DarkYellow;
                case ArchetypeColors.Pink:
                    throw new NotImplementedException();
                case ArchetypeColors.DarkBlue:
                    return ConsoleColor.DarkBlue;
                case ArchetypeColors.DarkGreen:
                    return ConsoleColor.DarkGreen;
                case ArchetypeColors.DarkRed:
                    return ConsoleColor.DarkRed;
                case ArchetypeColors.Gray:
                    return ConsoleColor.Gray;
                case ArchetypeColors.Cyan:
                    return ConsoleColor.Cyan;
                case ArchetypeColors.DarkCyan:
                    return ConsoleColor.DarkCyan;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
