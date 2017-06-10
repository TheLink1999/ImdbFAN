using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Film : IComparable<Film>
    {
        //fields
        private string name;
        private DateTime filmProducetime;
        private string janr;
        private double rev = 0;
        private double revC = 0;
        public  int searchCount = 0;
        private List<Actor> Cast = new List<Actor>();
        private List<Director> Directors = new List<Director>();
        private List<Operator> Operators = new List<Operator>();
        private List<Writer> Writers = new List<Writer>();
        private List<Rev> revs = new List<Rev>();
        public static int forSorting = 0;
        //properties

        //constructors
        public Film(string n, string jan, DateTime fd)
        {
            name = n;
            filmProducetime = fd;
            janr = jan;
            searchCount++;
        }
        //methods
        public void AddRev(Rev r)
        {
            revs.Add(r);
        }
        public override string ToString()
        {
            REvsUSerMijin(revs);
            return $"{name} : {filmProducetime.Year} : {janr} : {rev}";
        }
        public int CompareTo(Film obj)
        {
            if (forSorting == 1)
            {
                if (this.rev > obj.rev)
                {
                    return 1;
                }
                else if (obj.rev == this.rev)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (forSorting == 2)
            {
                if (this.searchCount > obj.searchCount)
                {
                    return 1;
                }
                else if (obj.searchCount == this.searchCount)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if(forSorting == 3) 
            {
                if (this.name[0] > obj.name[0])
                {
                    return 1;
                }
                else if (obj.name[0] == this.name[0])
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (this.revC > obj.revC)
                {
                    return 1;
                }
                else if (obj.revC == this.revC)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
        private double REvsUSerMijin(List<Rev> r)
        {
            int g = 0;
            for (int i = 0; i < r.Count; i++)
            {
                if (r[i].UR != 0)
                {
                    rev += r[i].UR;
                }
            }
            return rev / g;
        }
        private double REvsCriticMijin(List<Rev> r)
        {
            int g = 0;
            for (int i = 0; i < r.Count; i++)
            {
                if (r[i].CR != 0)
                {
                    rev += r[i].CR;
                    g++;
                }
            }
            return rev / g;
        }
        public void InfoAddOrChanjeForCritics() {
            System.Diagnostics.Process.Start($"{name}.txt");
        }
    }
}
