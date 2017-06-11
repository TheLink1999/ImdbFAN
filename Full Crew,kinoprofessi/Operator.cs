using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Operator : Cinemaman
    {
        //fields
        public List<Film> OperatorFilms = new List<Film>();
        //constructor
        public Operator(string n):base(n) {

        }
        //methods
        public void Add(Film film)
        {
            OperatorFilms.Add(film);
        }
        public override string professy()
        {
            return "Operator";
        }
    }
}
