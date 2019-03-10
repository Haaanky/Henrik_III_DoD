using System;
using System.Collections.Generic;
using System.Text;

namespace FirstClassLib
{
    public static class ConsoleSpecific
    {
        public static void PressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(true);
        }
    }
}