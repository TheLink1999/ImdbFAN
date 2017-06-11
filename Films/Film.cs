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
        protected double price;
        protected double priceforprocat;
        protected double filmPracatTime;
        protected DateTime filmGivingTime;
        public int searchCount = 0;
        protected int filmsThereAre;
        protected int pracatRevCount;
        protected int pracatOut;
        protected int selesFilms;
        public static int forSorting = 0;
        private List<Actor> Cast = new List<Actor>();
        private List<Director> Directors = new List<Director>();
        private List<Operator> Operators = new List<Operator>();
        private List<Writer> Writers = new List<Writer>();
        private List<Rev> revs = new List<Rev>();
        public static int qanakObyakti = 0;
        //properties
        public DateTime FilmGivingTime
        {
            get { return filmGivingTime; }
            set { filmGivingTime = value; }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (User.isStafff)
                {
                    price = value;
                }
            }
        }
        public double Priceforprocat
        {
            get
            {
                return priceforprocat;
            }
            set
            {
                if (User.isStafff)
                {
                    priceforprocat = value;
                }
            }
        }
        public int ForSorting
        {
            get
            {
                return forSorting;
            }
            set
            {
                if (User.isStafff)
                {
                    forSorting = value;
                }
            }
        }
        public string FilmPAth
        {
            get { return $"{name}{filmProducetime.Year} "; }
        }
        public int PracatRevCount
        {
            get
            {
                return pracatRevCount;
            }
            set
            {
                if (User.isStafff)
                {
                    pracatRevCount = value;
                }
            }
        }
        public int PracatOut
        {
            get
            {
                return pracatOut;
            }
            set
            {
                if (User.isStafff)
                {
                    pracatOut = value;
                }
            }
        }
        public int SelesFilms
        {
            get
            {
                return selesFilms;
            }
            set
            {
                if (User.isStafff)
                {
                    selesFilms = value;
                }
            }
        }
        public string Name
        {
            get { return name; }
        }
        public string JAnr
        {
            get { return janr; }
        }
        public DateTime FilmData
        {
            get { return filmProducetime; }
        }
        public double REvC
        {
            get { return revC; }
        }
        public double REv
        {
            get { return rev; }
        }
        public double FilmPracatTime
        {
            get
            {
                return filmPracatTime;
            }
            set
            {
                if (User.isStafff)
                {
                    filmPracatTime = value;
                }
            }
        }
        public int FilmThereAre
        {
            get { return filmsThereAre; }
            set
            {
                if (User.isStafff)
                {
                    filmsThereAre = value;
                }
            }
        }
        //constructors
        public Film(string n, string jan, DateTime fd)
        {
            name = n;
            filmProducetime = fd;
            janr = jan;
            searchCount++;
            if (qanakObyakti == 0)
            {
                System.IO.File.CreateText($"{name}{filmProducetime.Year}.txt");
                qanakObyakti++;
            }
        }
        //methods
        public void AddRev(Rev r)
        {
            revs.Add(r);
        }
        public override string ToString()
        {
            REvsUSerMijin();
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
            else if (forSorting == 3)
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
        public double REvsUSerMijin()
        {
            int g = 0;
            for (int i = 0; i < revs.Count; i++)
            {
                if (revs[i].UR != 0)
                {
                    rev += revs[i].UR;
                }
            }
            return rev / g;
        }
        public double REvsCriticMijin()
        {
            int g = 0;
            for (int i = 0; i < revs.Count; i++)
            {
                if (revs[i].CR != 0)
                {
                    rev += revs[i].CR;
                    g++;
                }
            }
            return rev / g;
        }
        public void InfoAddOrChanjeForStaff()
        {
            System.Diagnostics.Process.Start($"{name}{filmProducetime.Year}.txt");
        }
        public void AddAcors(Actor actor)
        {
            Cast.Add(actor);
        }
        public void AddDircts(Director direct)
        {
            Directors.Add(direct);
        }
        public void AddOperators(Operator op)
        {
            Operators.Add(op);
        }
        public void AddWriters(Writer wr)
        {
            Writers.Add(wr);
        }

    }
}
