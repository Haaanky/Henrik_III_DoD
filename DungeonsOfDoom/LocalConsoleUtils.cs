using System;
using System.Collections.Generic;
using System.Text;
using static DungeonsOfDoom.Archetype;
using System.Drawing;

namespace DungeonsOfDoom
{
    static class LocalConsoleUtils
    {
        //internal static ConsoleColor ConvertArchetypeColorToConsoleColor(ArchetypeColors colors) // Regular console color change
        //{
        //    switch (colors)
        //    {
        //        case ArchetypeColors.Green:
        //            return ConsoleColor.Green;
        //        case ArchetypeColors.Blue:
        //            return ConsoleColor.Blue;
        //        case ArchetypeColors.Red:
        //            return ConsoleColor.Red;
        //        case ArchetypeColors.Purple:
        //            return ConsoleColor.Magenta;
        //        case ArchetypeColors.Yellow:
        //            return ConsoleColor.Yellow;
        //        case ArchetypeColors.Orange:
        //            return ConsoleColor.DarkYellow;
        //        case ArchetypeColors.Pink:
        //            throw new NotImplementedException();
        //        case ArchetypeColors.DarkBlue:
        //            return ConsoleColor.DarkBlue;
        //        case ArchetypeColors.DarkGreen:
        //            return ConsoleColor.DarkGreen;
        //        case ArchetypeColors.DarkRed:
        //            return ConsoleColor.DarkRed;
        //        case ArchetypeColors.Gray:
        //            return ConsoleColor.Gray;
        //        case ArchetypeColors.Cyan:
        //            return ConsoleColor.Cyan;
        //        case ArchetypeColors.DarkCyan:
        //            return ConsoleColor.DarkCyan;
        //        default:
        //            return ConsoleColor.White;
        //    }
        //}

        internal static Color ConvertArchetypeColorToConsoleColor(ArchetypeColors colors)
        {
            switch (colors)
            {
                case ArchetypeColors.Green:
                    return Color.Green;
                case ArchetypeColors.Blue:
                    return Color.Blue;
                case ArchetypeColors.Red:
                    return Color.Red;
                case ArchetypeColors.Purple:
                    return Color.Magenta;
                case ArchetypeColors.Yellow:
                    return Color.Yellow;
                case ArchetypeColors.Orange:
                    return Color.Orange;
                case ArchetypeColors.Pink:
                    return Color.HotPink;
                case ArchetypeColors.DarkBlue:
                    return Color.DarkBlue;
                case ArchetypeColors.DarkGreen:
                    return Color.DarkGreen;
                case ArchetypeColors.DarkRed:
                    return Color.DarkRed;
                case ArchetypeColors.Gray:
                    return Color.Gray;
                case ArchetypeColors.Cyan:
                    return Color.Cyan;
                case ArchetypeColors.DarkCyan:
                    return Color.DarkCyan;
                case ArchetypeColors.Indigo:
                    return Color.Indigo;
                case ArchetypeColors.MediumSlateBlue:
                    return Color.MediumSlateBlue;
                default:
                    return Color.White;
            }
        }

    }
}
