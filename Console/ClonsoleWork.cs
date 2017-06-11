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
        static Stack<string> commands = new Stack<string>();

        static string Artahaytuiun(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            int newleft = left;
            int newtop = top;
            ConsoleKeyInfo key;
            string word = "";
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.UpArrow)
                {
                    word += key.KeyChar;
                    newleft++;
                }
            } while (true);
        }

        public static void ClearCurrentConsoleLine(int top)
        {
            int currentLineCursor = top;
            Console.SetCursorPosition(0, top);
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
                    ClearCurrentConsoleLine(a + 1);
                    incorect = false;
                    s = 0;
                }
                Console.ResetColor();
            }
            while (key.Key != ConsoleKey.Enter || incorect);
            return pass;
        }
        public static void Home(User u, List<Film> films =null)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(10, 0);
            Console.Title = "Home";
            if (u.LogInfo())
            {
                Console.WriteLine("===============================================================");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                                                               ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                           IMDb FAN                            ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                                                               ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("     HOME          FILMS         SEARCH           ACCOUNT      ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("===============================================================");

                Console.SetCursorPosition(10, Console.CursorTop + 2);
                if (films!= null && films.Count != 0)
                {
                    Random r = new Random();
                    Film.forSorting = r.Next(2, 3);
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films,10,Console.CursorTop+1,0,0,3);

                    Film.forSorting = 0;
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular Critic Rate Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films, 10, Console.CursorTop + 1, 0, 0, 3);

                    Film.forSorting = 1;
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular User Rate Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films, 10, Console.CursorTop + 1, 0, 0, 3);
                }

            }
            else
            {
                Console.WriteLine("===============================================================");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                                                               ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                           IMDb FAN                            ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("                                                               ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("              HOME          FILMS         SEARCH               ");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine("===============================================================");

                Console.SetCursorPosition(10, Console.CursorTop + 2);
                if (films != null && films.Count != 0)
                {
                    Random r = new Random();
                    Film.forSorting = r.Next(2, 3);
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films, 10, Console.CursorTop + 1, 0, 0, 3);

                    Film.forSorting = 0;
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular Critic Rate Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films, 10, Console.CursorTop + 1, 0, 0, 3);

                    Film.forSorting = 1;
                    films.Sort();
                    Console.SetCursorPosition(10, Console.CursorTop + 2);
                    Console.WriteLine("Popular User Rate Films :");
                    Console.WriteLine("===============");
                    Table.FilmsTable(films, 10, Console.CursorTop + 1, 0, 0, 3);
                }
            }
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();




            } while (true);
        }
    }
}
