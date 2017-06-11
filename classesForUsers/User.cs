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
        private bool isLogin = false;
        protected bool isCritic = false;
        protected bool isStafff = false;
        protected double cart;
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


        //methods
        public void Search(List<Film> films, List<Cinemaman> men)
        {
            ConsoleKeyInfo cki;
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            int forRem = 0;
            cki = Console.ReadKey(true);
            if (cki.KeyChar >= 0 && cki.KeyChar <= 9 && cki.KeyChar >= 'a' && cki.KeyChar <= 'z' && cki.KeyChar >= 'A' && cki.KeyChar <= 'Z')
            {

                for (int i = 0; i < films.Count; i++)
                {
                    if (films[i].NAme.Contains(cki.ToString()))
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
                    if (men[i].name.Contains(cki.ToString()))
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

        public void addSearchHistory(object search) {
            if (search.GetType().Equals("Film"))
            {

            }
        }
        public void ReserveFilmForWhatching(Film reserveFilm)
        {
            ReserevFilm.Add(reserveFilm);
        }

        public void Active()
        {
            System.Diagnostics.Process.Start($"{Name}.txt");
        }
        public void ActiveAdd(DateTime dateTime, string textPath)
        {
            System.IO.StreamWriter a = new System.IO.StreamWriter(textPath);
            a.WriteLine($"{Name} : {dateTime}");
        }
        public  void LogOut()
        {
            isLogin = false;
        }
        public  bool LogInfo()
        {
            return isLogin;
        }
        public void LogIn() {
            isLogin = true;
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        private static string Pasword(int t, string b = "")

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
                Console.ResetColor();
            }
            while (key.Key != ConsoleKey.Enter || incorect);
            return pass;
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
