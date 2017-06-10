using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Rev
    {
        private int CritcsRev;
        private int UserRev;
        public int CR {
            get { return CritcsRev; }
            set {
                if (value <= 100 && value >=0)
                {
                    CritcsRev = value;
                }
                else
                {
                    throw new Exception("Pease enter 0 - 100 numbers");
                }
            }
        }
        public int UR {
            get { return UserRev; }
            set {
                if (value>=0 && value<=10)
                {
                    UserRev = value;
                }
                else
                {
                    throw new Exception("Please enter 1 - 10 numbers");
                }

            }
        }
    }
}
