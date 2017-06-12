using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.IO;

namespace Imdb
{
    class Stuff : User, IStaff
    {
        //fields
        public static double AllMoneyOfDay;
        //properties

        //constructor
        public Stuff(string n, string p, string l, Password pass, double cart) : base(n, p, l, pass, cart)
        {
            isStafff = true;
        }
        public Stuff() { }
        //methods
        public void CalendarManagment()
        {
            System.Diagnostics.Process.Start("CalendarManagment.txt");//bolor karevor gort 
                }

        public void ClientHistory()
        {

            System.Diagnostics.Process.Start("ClientHistory.txt");//registraciai jamanak avelanuma

        }

        public void FilmHistory()
        {
            System.Diagnostics.Process.Start("FilmHistory.txt");
        }

        public void FilmManagment()
        {
            System.Diagnostics.Process.Start("FilmManagment.txt");//user rserv
        }

        public void FilmPrakatGiving(User u, Film f)
        {
            u.AddPracat(f);
            FinanceManegmant(f,"prakat");
        }

        public void Films()
        {
            System.Diagnostics.Process.Start("Film.txt");
        }

        public void FinanceManegmant(Film f,string s)
        {
            string[] n = { $"{DateTime.Now.ToString()} - {s} : {f.Name} - {AllMoneyOfDay}", "\n" };
            IEnumerable<string> l = n;
            File.AppendAllLines("FinanceManegmant.txt", l);
        }
        public void FinanceManegmantInfo()
        {
            System.Diagnostics.Process.Start("FinanceManegmant.txt");
        }
        public void GiveAFilme(User u, Film f)
        {
            u.AddBuyFilms(f);
            FinanceManegmant(f,"buy");
        }

        public void ReturnAfilm()
        {
            System.Diagnostics.Process.Start("ReturnAfilm.txt");
        }

    }
}
