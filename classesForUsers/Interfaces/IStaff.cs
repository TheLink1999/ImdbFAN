using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    interface IStaff
    {
        void ClientHistory(List<User> client);
        void FilmHistory();
        void Films();
        void FilmPrakatGiving();
        void GiveAFilme();
        void CalendarManagment();
        void ReturnABook();
        void FinanceManegmant();
        void FilmManagment();
    }
}
