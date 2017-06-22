using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace Imdb
{
    static class ClonsoleWork
    {
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static string Pasword(int t, string b = "")

        {
            string pass = "";
            if (t != 1)
                Console.Write("Enter your password: ");
            ConsoleKeyInfo key;
            int a = Console.CursorTop;
            int i = Console.CursorLeft;
            int m = i;
            int s = 1;
            bool incorect = true;
            do
            {
                if (s == 0)
                {
                    Console.SetCursorPosition(i, a);
                    s = 1;
                }
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    a = Console.CursorTop;

                    Console.Write("*");
                    i++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {

                    Environment.Exit(0);
                }
                else if (key.Key == ConsoleKey.LeftArrow && i != m)
                {
                    i--;
                    Console.SetCursorPosition(i, a);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    i++;
                    Console.SetCursorPosition(i, a);
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        i--;
                        Console.Write("\b \b");
                    }
                    Console.Write("\b");
                }
                if ((pass.Length > 16 || pass.Length < 8))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(2, a + 1);
                    Console.Write("Your pass must be have length 8 - 16");
                    incorect = true;
                    s = 0;
                }
                else if ((!b.Contains(pass) && t == 1 && !incorect) || (!b.Equals(pass) && t == 1 && !incorect))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(2, a + 1);
                    Console.Write("Your passes not equels");
                    incorect = true;
                    s = 0;
                }
                else
                {
                    Console.SetCursorPosition(2, a + 1);
                    ClearCurrentConsoleLine();
                    incorect = false;
                    s = 0;
                }
                Console.ForegroundColor = ConsoleColor.Green;
            }
            while (key.Key != ConsoleKey.Enter || incorect);
            return pass;
        }
        
    }
}
