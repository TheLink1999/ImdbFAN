using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Imdb
{
    class User : Person, IActiveForUser, IReserve, ISearch, Ilists
    {
        //fields
        private string login;
        private Password pass;
        private bool isLogin = false;
        private bool isCritic = false;
        public static bool isStafff = false;
        protected double cart;
        //Lists
        protected List<Film> Whatchlist = new List<Film>();
        protected List<Film> ReserevFilm = new List<Film>();
        protected List<Film> SearchFilms = new List<Film>();
        protected List<Cinemaman> SearchCinemamen = new List<Cinemaman>();
        protected List<Film> Notifications = new List<Film>();//peta artael urish dzev
        protected List<Film> Pracat = new List<Film>();//peta artael
        protected List<Film> BuyFilms = new List<Film>();//peta artael
        //properties
        public string Login
        {
            get
            {
                return login;
            }
            private set
            {
                if (Name == "gweast")
                {

                    login = null;
                }
                else
                {
                    login = value;

                }
            }
        }
        public Password Pass { get { return pass; } }
        public double Cart { get { return cart; } }
        //constructor
        public User(string n, string p, string l, Password pass,double cart) : base(n, p)
        {
            Login = l;
            this.pass = pass;
            this.cart = cart;
        }
        public User() { }

        //methods
        public void Search(List<Film> films, List<Cinemaman> men, string s)
        {
            ConsoleKeyInfo cki;
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            int forRem = 0;
            
            

                for (int i = 0; i < films.Count; i++)
                {
                    if (films[i].Name.Contains(s))
                    {
                        if (forRem == 0)
                        {
                            Console.WriteLine("FILMS");
                            Console.WriteLine("=====");
                            Console.WriteLine();
                            forRem = 1;
                        }
                        Console.WriteLine($"{i + 1} : {films[i]}");
                        Console.WriteLine();
                    }

                }
                forRem = 0;

                for (int i = 0; i < men.Count; i++)
                {
                    if (men[i].name.Contains(s))
                    {
                        if (forRem == 0)
                        {
                            Console.WriteLine("Cinemamen");
                            Console.WriteLine("=========");
                            Console.WriteLine();
                            forRem = 1;
                        }
                        Console.WriteLine($"{i + 1} : {films[i]}");
                        Console.WriteLine();
                    }

                }
                Console.SetCursorPosition(left,top);
            

        }

        public void SearchHistory()
        {
            //out/SearchFilms
            Console.WriteLine("SEARCH FILMS");
            Console.WriteLine("============");
            Console.WriteLine();
            for (int i = 0; i < SearchFilms.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {SearchFilms[i]}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("SEARCH CNEMAMEN");
            Console.WriteLine("===============");
            Console.WriteLine();
            //out/SearchCinemamen
            for (int i = 0; i < SearchCinemamen.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {SearchCinemamen[i]}");
                Console.WriteLine();
            }

        }

        public void addSearchCinemamen(Cinemaman search) {
            SearchCinemamen.Add(search);
        }
        public void ReserveFilmForWhatching(Film reserveFilm)
        {
            string[] n = { $"{Name} | {reserveFilm.Name} - {DateTime.Now}", "\n" };
            IEnumerable<string> l = n;
            File.AppendAllLines("FilmManagment.txt", l);
            ReserevFilm.Add(reserveFilm);
        }
        public void RevmovFromeReserveFilm(Film reserveFilm)
        {
            for (int i = 0; i < ReserevFilm.Count; i++)
            {
                if (i != 0 && (ReserevFilm[i].Name == BuyFilms[i].Name)&&(ReserevFilm[i].Name==Pracat[i].Name))
                {
                    ReserevFilm.Remove(ReserevFilm[i]);
                }
            }
        }
        public void Active()
        {
            System.Diagnostics.Process.Start($"{Login}.txt");
        }
        public void ActiveAdd()
        {
            string[] n = { $"{ DateTime.Now.ToString() } | login","\n"};
            IEnumerable<string> l = n;
            File.AppendAllLines($"{Login}.txt", l);
        }
        public  void LogOut()
        {
            string[] n = { $"{ DateTime.Now.ToString() } | log out", "\n" };
            IEnumerable<string> l = n;
            File.AppendAllLines($"{Login}.txt", l);
            isLogin = false;
        }
        public  bool LogInfo()
        {
            return isLogin;
        }
        public void LogIn() {
            isLogin = true;
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
            film.FilmGivingTime = DateTime.Now;
            Pracat.Add(film);
            Stuff.AllMoneyOfDay += film.Priceforprocat;
        }

        public void AddBuyFilms(Film film)
        {
            film.FilmGivingTime = DateTime.Now;
            BuyFilms.Add(film);          
            Stuff.AllMoneyOfDay += film.Priceforprocat;
        }
        public void BECritic() {
            isCritic = true;
        }
        public bool IsCritic() {
            return isCritic;
        }
        public void ReturnAfilm() {
            for (int i = 0; i < Pracat.Count; i++)
            {
                if (i!=0 && (Pracat[i].FilmGivingTime.AddDays(Pracat[i].FilmPracatTime) < DateTime.Now))
                {
                    string[] n = {$"{Name}   {Pracat[i].Name}  {Pracat[i].FilmGivingTime.Day}:{Pracat[i].FilmGivingTime.Month}:{Pracat[i].FilmGivingTime.Year} - {DateTime.Now.Day}:{DateTime.Now.Month}:{DateTime.Now.Year}","\n"};
                    IEnumerable<string> l = n;
                    File.AppendAllLines("ReturnAfilm.txt", l);
                    Pracat.Remove(Pracat[i]);
                }
            }
        }
    }

}
