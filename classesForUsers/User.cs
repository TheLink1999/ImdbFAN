using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class User : Person, IActiveForPerson
    {
        //fields

        //properties

        //constructor
        public User(string n, string p)
        {

        }
        //methods
        public void Active()
        {
            throw new NotImplementedException();
        }
    }
}
