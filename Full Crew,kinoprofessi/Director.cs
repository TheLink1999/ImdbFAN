using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Director : Cinemaman
    {
        //fields
        public List<Film> DirectorFilms = new List<Film>();
        //constructor
        public Director(string n):base(n) {

        }
        //methods
        public void Add(Film film)
        {
            DirectorFilms.Add(film);
        }
        public override string professy()
        {
            return "Director";
        }
    }
}
