using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    interface ISearch
    {
        void Search(List<Film> films, List<Cinemaman> men);
        void SearchHistory();
    }
}
