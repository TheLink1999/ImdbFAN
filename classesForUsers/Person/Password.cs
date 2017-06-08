using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.classesForUsers.Person
{
    class Password
    {
        //field
        private string pass;
        protected string secretQwuestion;
        private string scretAnswerd;
        //properties
        public string Pass
        {
            set
            {
                pass = value;
            }
        }
        public string SQ
        {
            get
            {
                return $"Secret question : {secretQwuestion}";
            }
            set
            {
                secretQwuestion = value;
            }
        }
        public string SA
        {
            get
            {
                return $"Secret answerd : {scretAnswerd}";
            }
            set
            {
                scretAnswerd = value;
            }
        }
        //constructors
        public Password(string p, string sQ, string sA)
        {
            Pass = p;
            SQ = sQ;
            SA = sA;
        }
        public Password(string p)
        {
            Pass = p;
        }
        //Methods
        private void Shrifavanie(string s)
        {

        }
        public override string ToString()
        {
            return pass;
        }
        public void chengePassWithOldPass()
        {
            
            
        }
        public void chengePassWithEmail()
        {

        }
        public void chengePasswithSA()
        {

        }
    }
}
