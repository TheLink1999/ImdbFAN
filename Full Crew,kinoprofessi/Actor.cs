using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Actor : Cinemaman
    {
        //fields
        public List<Film> ActorFilms = new List<Film>();
        //constructor
        public Actor(string n):base(n) {
            
        }
        //methods
        public void Add(Film film ) {
            ActorFilms.Add(film);
        }
        public override string professy()
        {
            return "Actor";
        }
    }
}
