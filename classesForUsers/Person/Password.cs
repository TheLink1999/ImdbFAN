using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Imdb
{
    public class Password
    {
        //field
        private string pass;
        //properties
        public string Pass
        {
            get {
                return pass;
            }
            set
            {
                pass = value;
            }
        }
        
        //constructors
        public Password(string p)
        {
            Pass = p;
            
        }
        //Methods
        static public string Passsecurity(string pass)
        {
            string pass1 = "";
            string key = "everybody goes to the rapture";
            for (int i = 0; i < pass.Length - 1; i++)
            {
                pass1 += (char)((pass[i] + pass[i + 1]) + key[i]);
            }
            return pass1;
        }
        public override string ToString()
        {
            return pass;
        }
        public string chengePassWithOldPass(string oidPass)
        {
            if (oidPass == pass)
            {
                return "Geve new Password";
            }
            else
            {
                throw new Exception("Password are incorect");
            }
        }       
    }
}
