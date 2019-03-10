using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FirstClassLib
{
    public static class TextUtils
    {
        public static void AnimateText(string text, int delay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void PressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(true);
        }
    }
}