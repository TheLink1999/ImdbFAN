using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    interface IStaff
    {
        void ClientHistory();
        void FilmHistory();
        void Films();
        void FilmPrakatGiving(User u,Film film);
        void GiveAFilme(User u, Film f);
        void CalendarManagment();
        void ReturnAfilm();
        void FinanceManegmant(Film f,string s);
        void FilmManagment();
    }
}
