using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Writer : Cinemaman
    {
        //fields
        public List<Film> WriterFilms = new List<Film>();
        //constructor
        public Writer(string n):base(n) {

        }
        //methods
        public void Add(Film film)
        {
            WriterFilms.Add(film);
        }
        public override string professy()
        {
            return "Writer";
        }
    }
}
