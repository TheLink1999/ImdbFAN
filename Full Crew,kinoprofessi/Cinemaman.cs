using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    abstract class Cinemaman : Person, IComparable<Cinemaman>
    {
        public int searchCount = 0;
        public string name;
        public Cinemaman(string n):base(n) {
            name = n;
        }
        public  int CompareTo(Cinemaman obj) {
            if (obj.searchCount > this.searchCount)
            {
                return -1;
            }
            else if (obj.searchCount == this.searchCount)
            {
                return 0;
            }
            else {
                return 1;
            }
        }
    }
}
