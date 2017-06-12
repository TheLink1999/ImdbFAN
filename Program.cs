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
    class Program
    {
        static string filmePath = @"../../Film.txt";
        static string userPath = @"../../Users.txt";
        static string stuffPath = @"../../Stuffs.txt";
        static string[] lines;
        static User loginedUser;
        static Stuff loginedStaff;
        static string loginedUsep = "";
        //static int userIndex = -1;
        //methods//
        static int FindUser(string name)
        {
            int i;
            for (i = 0; i < users.Count; i++)
            {
                if (users[i].Login.Equals(name))
                    return i;
            }
            return -1;
        }
        static int FindStuff(string name)
        {
            int i;
            for (i = 0; i < users.Count; i++)
            {
                if (stuffs[i].Login.Equals(name))
                    return i;
            }
            return -1;
        }
        static void LogIn()
        {
            Console.Clear();
            string f = "";
            int i;
            while (true)
            {
                Console.Write("Stuff or User : ");
                f = Console.ReadLine();
                if (f.ToLower() == "stuff")
                {
                    Console.Write("Insert username :");
                    i = FindStuff(Console.ReadLine());
                    if (i == -1) Console.WriteLine("No Such stuff!! \nRepeat?(Yes or No)");
                    else break;
                    if (Console.ReadLine().Equals("No")) break;
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Insert username :");
                    i = FindUser(Console.ReadLine());
                    if (i == -1) Console.WriteLine("No Such user!! \nRepeat?(Yes or No)");
                    else break;
                    if (Console.ReadLine().Equals("No")) break;
                    Console.WriteLine();
                }
            }
            if (i == -1)
                return;
            int ada = 0;
            while (true)
            {
                string a = ClonsoleWork.Pasword(0);
                if (f.ToLower() == "stuff" && stuffs[i].Pass.Equals(Password.Passsecurity(a)))
                {
                    stuffs[i].LogIn();
                    loginedUsep = "stuff";
                    loginedStaff = stuffs[i];
                }
                else if (users[i].Pass.Equals(Password.Passsecurity(a)))
                {
                    users[i].LogIn();
                    users[i].ActiveAdd();
                    loginedUsep = "user";
                    loginedUser = users[i];
                }
                break;

                if (ada == 0) Console.WriteLine("Password incorrect \nYou can scoll up and see your password, But noooo!!\n");
                if (ada == 1) Console.WriteLine("Password incorrect \nAgain??\n");
                if (ada == 2) Console.WriteLine("Password incorrect \nWhats wrong with you??\n");
                if (ada == 3) Console.WriteLine("Password incorrect \nYou'r hopless @@\n");
                ada++;
            }
        }
        static void LogOut()
        {
            if (loginedUsep == "")
                Console.WriteLine("Not logged in");
            else
            {
                loginedUsep = "";
                loginedStaff = null;
                loginedUser = null;
                Console.WriteLine("Done!!))");
            }
        }
        static void FIlmInfo(Film film, User u = null, Stuff s = null)
        {
            Console.Clear();
            if (loginedUsep == "user")
                Console.WriteLine($" 1)Buy({film.Price}$) 2) BuyPracat({film.Priceforprocat}$) 3) AddToWhatchList 4)Rate\n=============================================\n");
            if (loginedUsep == "staff")
                Console.WriteLine($" 5)Change\n=============================================\n");
            Console.WriteLine($"  {film}" + "\n\n 0)GoHome\n\n");

            int a = 0;
            bool f = true;
            while (true)
            {
                while (f)
                {
                    try
                    {
                        Console.Write(">");

                        a = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter only numbers");
                        continue;
                    }
                    f = false;
                }
                f = true;
                if (a == 0)
                {
                    Console.Clear();
                    break;
                }
                if (a == 1 && loginedUsep == "user")
                {
                    if (u.Cart < film.Price)
                    {
                        u.ReserveFilmForWhatching(film);
                    }
                    else
                    {
                        u.AddBuyFilms(film);
                        loginedStaff.FinanceManegmant(film, u.Name);

                    }
                }
                if (a == 2 && loginedUsep == "user")
                {
                    if (u.Cart < film.Priceforprocat)
                    {
                        u.ReserveFilmForWhatching(film);
                    }
                    else
                    {
                        u.AddPracat(film);
                        loginedStaff.FinanceManegmant(film, u.Name);
                    }
                }
                if (a == 3 && loginedUsep == "user")
                {
                    u.AddTOWhatchList(film);
                }
                if (a == 5 && loginedUsep == "user")
                {
                    Rev r = new Rev();
                    r.UR = Convert.ToInt32(Console.ReadLine());
                    film.AddRev(r);
                }
                if (a == 5 && loginedUsep == "stuff")
                {
                    Console.Clear();
                    Console.Write("Film price (only nombers) : ");
                    film.Price = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Film pracat price (only nombers) : ");
                    film.Priceforprocat = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                }
            }
        }
        //Lists//
        static List<User> users = new List<User>();
        static List<Film> films = new List<Film>();
        static List<Stuff> stuffs = new List<Stuff>();
        public static void Main(string[] args)
        {


            lines = File.ReadAllLines(userPath);
            if (lines.Length != 0 && lines[0]!="")
            {
                for (int i = 0; i < lines.Length; i += 6)
                {
                    users.Add(new User(lines[i], lines[i + 1], lines[i + 2], new Password(lines[i + 3]), Convert.ToDouble(lines[i + 4])));
                }
            }

            lines = File.ReadAllLines(stuffPath);
            if (lines.Length != 0 && lines[0] != "")
            {
                for (int i = 0; i < lines.Length; i += 6)
                {
                    stuffs.Add(new Stuff(lines[i], lines[i + 1], lines[i + 2], new Password(lines[i + 3]), Convert.ToDouble(lines[i + 4])));
                }
            }

            lines = File.ReadAllLines(filmePath);
            if (lines.Length != 0 && lines[0] != "")
            {
                for (int i = 0; i < lines.Length; i += 4)
                {
                    films.Add(new Film(lines[i], lines[i + 1], lines[i + 2]));
                }
            }

            int a = 1;
            bool f = true;
            while (true)
            {
                Console.Clear();
                if (loginedUsep == "user")
                {
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("                           IMDb FAN                            ");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("         1)HOME  2)FILMS  3)SEARCH  4)ACCOUNT 5)LogOut         ");
                    Console.WriteLine("===============================================================");
                }
                else if (loginedUsep == "stuff")
                {
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("                           IMDb FAN                            ");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("1)HOME  2)FILMS  3)SEARCH  4)ACCOUNT 6)AddFilm 5)LogOut 7)Users");
                    Console.WriteLine("             8)FilmPracatGiving 9)FilmGiving                   ");
                    Console.WriteLine("===============================================================");
                }
                else
                {
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("                           IMDb FAN                            ");
                    Console.WriteLine("                                                               ");
                    Console.WriteLine("         1)HOME  2)FILMS  3)SEARCH  10)LogIn  11)Register      ");
                    Console.WriteLine("===============================================================");
                }
                Console.WriteLine("\n\nPress 1 Fore Info of this program, there in important info");
                while (f)
                {
                    try
                    {
                        Console.Write(">");

                        a = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter only numbers");
                        continue;
                    }
                    f = false;
                }
                f = true;
                if (a == 1)
                    System.Diagnostics.Process.Start("Info.txt");
                if (a == 10)//Login
                {
                    Console.Clear();
                    if (loginedUsep != "")
                    {
                        Console.WriteLine("Already logged in");
                    }
                    LogIn();
                }
                if (a == 11)//register
                {
                    Console.Clear();
                    bool e = true;
                    string username = "";
                    string[] password = new string[2];
                    string phone;
                    string name;
                    double cart;
                    int left = Console.CursorLeft;
                    int top = Console.CursorTop;
                    Console.Write("Name : ");
                    name = Console.ReadLine();
                    Console.Write("Phone (just like this 095457321) : ");
                    phone = Console.ReadLine();
                    Console.Write("Please enter Money");
                    cart = Convert.ToDouble(Console.ReadLine());

                    while (true)
                    {
                        Console.Write("Insert login : ");
                        left = Console.CursorLeft;
                        username = Console.ReadLine();

                        top = Console.CursorTop;
                        int t = username.Length;
                        if (FindUser(username) != -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(2, top);
                            Console.Write("Username already taken");
                            Console.ResetColor();
                        }

                        else
                        {
                            ClonsoleWork.ClearCurrentConsoleLine();
                            break;
                        }
                        Console.SetCursorPosition(left + t, 0);
                        ClonsoleWork.ClearCurrentConsoleLine();


                    }

                    password[0] = ClonsoleWork.Pasword(0);

                    Console.Write("Repeat : ");
                    password[1] = ClonsoleWork.Pasword(1, password[0]);
                    e = true;


                    users.Add(new User(name, phone, username, new Password(Password.Passsecurity(password[0])), cart));
                    File.CreateText($"{username}.txt");
                    if (e)
                        Console.WriteLine("Finally!! what took you so long??");
                    Console.Clear();
                }

                if (a == 2)//films
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("  nomber        name          date       rete  ");
                    Console.WriteLine("===============================================");
                    for (int i = 0; i < films.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}  {films[i].Name}       {films[i].FilmData}    {films[i].REvsUSerMijin()}  ");
                    }
                    while (f)
                    {
                        try
                        {
                            Console.Write(">");

                            a = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter only numbers");
                            continue;
                        }
                        f = false;
                    }
                    f = true;
                    FIlmInfo(films[a - 1]);
                }

                if (a == 3)//search
                {
                    Console.WriteLine("\n");
                    Console.Write(">");
                    string search = Console.ReadLine();
                    for (int i = 0; i < films.Count; i++)
                    {
                        if (films[i].Name.Contains(search))
                        {
                            Console.WriteLine($"  {i + 1}  {films[i].Name}       {films[i].FilmData}    {films[i].REvsUSerMijin()}  ");
                        }
                    }
                    while (f)
                    {
                        try
                        {
                            Console.Write(">");

                            a = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter only numbers");
                            continue;
                        }
                        f = false;
                    }
                    f = true;
                    FIlmInfo(films[a - 1]);
                }
            }


            
            if (a == 5 && loginedUsep != "")//Logout
            {
                LogOut();
            }
            if (a == 7)//users
            {
                Console.Clear();
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($" {i + 1}  {users[i].Name}");
                }
                Console.Read();
            }
            if (a == 4 && loginedUsep != "")
            {
                if (loginedUsep == "stuff")
                {
                    Console.WriteLine($"{loginedStaff.Name}                                                  ");

                    Console.WriteLine(" ==========================================================");
                    Console.WriteLine(" 1)Finance Managmant 2)ClientHistory 3)FilmManegmant 0)Home ");
                    while (true)
                    {
                        while (f)
                        {
                            try
                            {
                                Console.Write(">");

                                a = Convert.ToInt32(Console.ReadLine());

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please enter only numbers");
                                continue;
                            }
                            f = false;
                        }
                        f = true;
                        if (a == 1)
                        {
                            System.Diagnostics.Process.Start("FilmManagment.txt");
                        }
                        if (a == 2)
                        {
                            System.Diagnostics.Process.Start("ClientHistory.txt");
                        }
                        if (a == 3)
                        {
                            System.Diagnostics.Process.Start("FilmManagment.txt");
                        }
                        if (a == 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{loginedUser.Name}                                                  ");

                    Console.WriteLine(" ==========================================================================");
                    Console.WriteLine(" 1)ActiveHistory 2)Whachlist 3)BuyFilms 4)PracatFilms 5)ReserveFilms 0)Home");
                    while (true)
                    {
                        while (f)
                        {
                            try
                            {
                                Console.Write(">");

                                a = Convert.ToInt32(Console.ReadLine());

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please enter only numbers");
                                continue;
                            }
                            f = false;
                        }
                        f = true;
                        if (a == 1)
                        {
                            loginedUser.Active();
                        }
                        if (a == 2)
                        {
                            Console.WriteLine("-----------------------");

                            for (int i = 0; i < loginedUser.Whatchlist.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} + {loginedUser.Whatchlist[i]}");
                            }
                        }
                        if (a == 3)
                        {
                            Console.WriteLine("-----------------------");

                            for (int i = 0; i < loginedUser.BuyFilms.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} + {loginedUser.BuyFilms[i]}");
                            }
                        }
                        if (a == 4)
                        {
                            Console.WriteLine("-----------------------");

                            for (int i = 0; i < loginedUser.Pracat.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} + {loginedUser.Pracat[i]}");
                            }
                        }
                        if (a == 5)
                        {
                            Console.WriteLine("-----------------------");
                            for (int i = 0; i < loginedUser.ReserevFilm.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} + {loginedUser.ReserevFilm[i]}");
                            }
                        }
                        if (a == 0)
                        {
                            break;
                        }
                    }
                }

            }
            if (a == 6 && loginedUsep == "stuff")//AddFilm
            {
                Console.Clear();
                Console.Write("Films name : ");
                string name = Console.ReadLine();
                Console.Write("Film janr : ");
                string janr = Console.ReadLine();
                Console.Write("Film date : ");
                string date = Console.ReadLine();
                films.Add(new Film(name, janr, date));
                Console.Write("Film Price(please enter only int nombers) : ");
                films[films.Count - 1].Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Film Pracat Price(please enter only int nombers) : ");
                films[films.Count - 1].Priceforprocat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ThankYou");
                Console.ReadKey();
            }
            if (a == 8)//givingPrakat
            {
                Console.Write("USer Name : ");
                string name = Console.ReadLine();
                int i = FindUser(name);
                if (i != -1)
                {
                    Console.Write("Filme name : ");
                    string film = Console.ReadLine();
                    for (int k = 0; k < films.Count; k++)
                    {
                        if (film == films[i].Name)
                        {
                            users[i].AddPracat(films[i]);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sory");

                }
            }
            if (a == 9)//givingBuy
            {
                Console.Write("USer Name : ");
                string name = Console.ReadLine();
                int i = FindUser(name);
                if (i != -1)
                {
                    Console.Write("Filme name : ");
                    string film = Console.ReadLine();
                    for (int k = 0; k < films.Count; k++)
                    {
                        if (film == films[i].Name)
                        {
                            users[i].AddBuyFilms(films[i]);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sory");

                }

            }
            a = 1;
            File.WriteAllText(userPath, "");
            File.WriteAllText(filmePath, "");
            File.WriteAllText(stuffPath, "");
            if (a==1 || a!=1)
            {
                StreamWriter file2 = new StreamWriter(stuffPath);
                StreamWriter file1 = new StreamWriter(userPath);
                StreamWriter file3 = new StreamWriter(filmePath);

                foreach (User u in users)
                {
                    file1.WriteLine(u.Name);
                    file1.WriteLine(u.Phone);
                    file1.WriteLine(u.Login);
                    file1.WriteLine(u.Pass);
                    file1.WriteLine(u.Cart);
                }
                file1.Flush();
                file1.Close();
                foreach (Stuff stuff in stuffs)
                {
                    file2.WriteLine(stuff.Name);
                    file2.WriteLine(stuff.Phone);
                    file2.WriteLine(stuff.Login);
                    file2.WriteLine(stuff.Pass);
                    file2.WriteLine(stuff.Cart);
                }
                file2.Flush();
                file2.Close();
                foreach (Film film in films)
                {
                    file3.WriteLine(film.Name);
                    file3.WriteLine(film.JAnr);
                    file3.WriteLine(film.FilmData);

                }
                file3.Flush();
                file3.Close();
                if (a == 1)
                    System.Diagnostics.Process.Start("Info.txt");

            }
        }
    }

}