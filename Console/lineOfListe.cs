using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class lineOfListe
    {
        string name;
        string janr;
        int number;
        string date;
        string rate = "0.0";
        int CursorTop;
        ConsoleColor BackGroundColor;
        ConsoleColor ForegnColor;
        //constuctor
        public lineOfListe(Film film, int number, ConsoleColor B, ConsoleColor F, int Cursor)
        {
            name = film.Name;
            janr = film.JAnr;
            this.number = number;
            date = film.FilmData;
            if (film.REvsUSerMijin() != 0)
            {
                rate = ("" + film.REvsUSerMijin()).Substring(0, 1);
            }
            BackGroundColor = B;
            ForegnColor = F;
            CursorTop = Cursor;
        }
        //methods
        string stringEditing(string word)
        {
            if (word.Length > 17)
            {
                 word = word.Substring(0, 15) + ".";
            }
            else if (word.Length < 17)
            {
                int i = 0;
                while (word.Length < 17)
                {
                    if (i % 2 == 0)
                    {
                         word = word + " ";
                    }
                    else
                    {
                         word = " " + word;
                    }
                    i++;
                }
            }
            return word;
        }

        public void writeFilm()
        {
            
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine($" {number} | {stringEditing(name)} | {stringEditing(date)} | {stringEditing(janr)} | {rate} ");
            Console.WriteLine("                                                                                                    ");

        }

        void changeColors(ConsoleColor one, ConsoleColor two)
        {
            ForegnColor = two;
            BackGroundColor = one;
        }
        public int ReturnNomber(int Cursor)
        {
            if (Cursor == CursorTop)
            {
                return number;
            }
            return -1;
        }
    }
}
