using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
     class Table
    {
        //fileds
        private static List<int> cursorPosition = new List<int>();
        private  ConsoleColor beckgroundcolor = ConsoleColor.Black;
        private  ConsoleColor forgroundcolor = ConsoleColor.DarkGreen;
        private int lasttop { get; set; }
        private int lastlisttop { get; set; }
        //properties

        //constructors

        //methods

        //films
        public static  void FilmsTable(List<Film> film, int left, int top,int oldleft =0, int oldtop=0,int n = 0)
        {
            if (n == 0) {
                n = film.Count;
            }
            string line;
            Console.SetCursorPosition(left,top);
            Console.WriteLine(" no.         name              year        janr           rate      ");
            for (int i = 0; i < n; i++)
            {
                line = " " + i + "            " + film[i].Name + "      " + "      " + film[i].FilmData.Year + "      " + film[i].JAnr + "       " + film[i].REvsUSerMijin() + "   ";
                if (line.Length<63)
                {
                    for (int j = line.Length; j < 63; i++)
                    {
                        line += " ";
                    }
                }
                cursorPosition.Add(Console.CursorTop );
                cursorPosition.Add(i);

                Console.WriteLine(line);
                Console.WriteLine();                
            }
            //if(oldleft!=0&& oldtop!=0)
            Console.SetCursorPosition(oldleft,oldtop);
        }
       
        public Film returnFilm(int top,List<Film> film) {
            lasttop = top;

            for (int i = 0; i < cursorPosition.Count; i+=2)
            {
                if (top == cursorPosition[i])
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    ClonsoleWork.ClearCurrentConsoleLine(top - 1);
                    Console.Write("                                                               ");
                    ClonsoleWork.ClearCurrentConsoleLine(top);
                    int j = cursorPosition[i+1];
                    string line = " " + j + "            " + film[j].Name + "      " + "      " + film[j].FilmData.Year + "      " + film[j].JAnr + "       " + film[j].REvsUSerMijin() + "   ";
                    if (line.Length < 63)
                    {
                        for (int h = line.Length; h < 63; i++)
                        {
                            line += " ";
                        }
                    }
                    ClonsoleWork.ClearCurrentConsoleLine(top + 1);
                    Console.Write("                                                               ");
                    lastlisttop = i;
                    return film[j];
                }
                if(lasttop==top-1){
                    Console.BackgroundColor = beckgroundcolor;
                    Console.ForegroundColor = forgroundcolor;
                    ClonsoleWork.ClearCurrentConsoleLine(lasttop - 1);
                    Console.Write("                                                               ");
                    ClonsoleWork.ClearCurrentConsoleLine(lasttop);
                    string line = " " + lastlisttop + "            " + film[lastlisttop].Name + "      " + "      " + film[lastlisttop].FilmData.Year + "      " + film[lastlisttop].JAnr + "       " + film[lastlisttop].REvsUSerMijin() + "   ";
                    if (line.Length < 100)
                    {
                        for (int h = line.Length; h < 100; i++)
                        {
                            line += " ";
                        }
                    }
                    ClonsoleWork.ClearCurrentConsoleLine(top + 1);
                    Console.Write("                                                               ");

                }
            }
            return null;
        }
        //users
        public  void UsersTable(List<Film> film)
        {

        }
        public  void UsersTableWIthCOunt(List<Film> film, int n)
        {

        }
        //
    }
}
