using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Critic : User
    {
        //fields

        //properties

        //constructors
        public Critic(string n, string p, string l, Password pass, double cart) : base(n, p, l, pass, cart)
        {
            isCritic = true;
        }
        //methods

    }
}
