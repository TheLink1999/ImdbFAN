using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace Imdb
{
    class User : Person, IActiveForUser, IReserve, ISearch, Ilists
    {
        //fields
        private string login;
        private Password pass;
        private static bool isLogin = false;
        protected bool isCritic = false;
        protected bool isStafff = false;
        //Lists
        protected List<Film> Whatchlist = new List<Film>();
        protected List<Film> ReserevFilm = new List<Film>();
        protected List<Film> SearchFilms = new List<Film>();
        protected List<Cinemaman> SearchCinemamen = new List<Cinemaman>();
        protected List<Film> Notifications = new List<Film>();
        protected List<Film> Pracat = new List<Film>();
        protected List<Film> BuyFilms = new List<Film>();
        //properties
        public string Login
        {
            get
            {
                return login;
            }
            private set
            {
                if (name == "gweast")
                {

                    login = null;
                }
                else
                {
                    login = value;

                }
            }
        }
        //constructor
        public User(string n, string p, string l, Password pass) : base(n, p)
        {
            Login = l;
            this.pass = pass;
        }


        //methods
        public void Search()
        {
            throw new NotImplementedException();
        }

        public void SearchHistory()
        {
            //out/SearchFilms
            for (int i = 0; i < SearchFilms.Count; i++)
            {
                //artatel
            }
            //out/SearchCinemamen
            for (int i = 0; i < SearchCinemamen.Count; i++)
            {

            }

        }


        public void ReserveFilmForWhatching(Film reserveFilm)
        {
            ReserevFilm.Add(reserveFilm);
        }

        public void Active()
        {
            System.Diagnostics.Process.Start($"{name}.txt");
        }
        public void ActiveAdd(DateTime dateTime, string textPath)
        {
            System.IO.StreamWriter a = new System.IO.StreamWriter(textPath);
            a.WriteLine($"{name} : {dateTime}");
        }
        public static void LogOut()
        {
            isLogin = false;
        }
        public static bool LogInfo()
        {
            return isLogin;
        }
        public void AddTOWhatchList(Film film)
        {
            Whatchlist.Add(film);
        }
        public void PrintList(List<object> Listname)
        {
            for (int i = 0; i < Listname.Count; i++)
            {
                //tpum
            }
        }

        public void AddSearchFilms(Film film)
        {
            SearchFilms.Add(film);

        }

        public void AddNotifications(Film film)
        {
            Notifications.Add(film);
        }

        public void AddPracat(Film film)
        {
            Pracat.Add(film);
        }

        public void AddBuyFilms(Film film)
        {
            BuyFilms.Add(film);
        }
    }

}
