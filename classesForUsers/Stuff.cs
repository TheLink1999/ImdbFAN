using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Stuff : User,IStaff
    {
        //fields
        
        //properties

        //constructor
        public Stuff(string n, string p,string l,Password pass) : base(n,p,l,pass)
        {
            isStafff = true;
        }
        //methods
        public void CalendarManagment()
        {
            throw new NotImplementedException();
        }

        public void ClientHistory(List<User> client)
        {
            throw new NotImplementedException();
        }

        public void FilmHistory()
        {
            throw new NotImplementedException();
        }

        public void FilmManagment()
        {
            throw new NotImplementedException();
        }

        public void FilmPrakatGiving()
        {
            throw new NotImplementedException();
        }

        public void Films()
        {
            throw new NotImplementedException();
        }

        public void FinanceManegmant()
        {
            throw new NotImplementedException();
        }

        public void GiveAFilme()
        {
            throw new NotImplementedException();
        }

        public void ReturnABook()
        {
            throw new NotImplementedException();
        }

    }
}
