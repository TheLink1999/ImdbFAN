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
        private string Shrifavanie(string s)
        {
            string key = "123456gyugygiu9688cycdchv";
            string aNew = "";
            for (int i = 0; i < s.Length; i++)
            {
                aNew += (s[i] + s[i + 1]) * key[i];
            }
            return aNew;
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
