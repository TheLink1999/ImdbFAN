using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    interface Ilists
    {
        void AddTOWhatchList(Film film);
        void AddSearchFilms(Film film);
        void AddNotifications(Film film);
        void AddPracat(Film film);
        void AddBuyFilms(Film film);

    }
}
