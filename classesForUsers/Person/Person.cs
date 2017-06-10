﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
   abstract class Person
    {
        //fields
        public string name;
        private string phone;
        private 
        //proprties
        string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value[0] == '0' && value.Length == 9)
                {
                    phone = value;
                }
                else
                {
                    throw new Exception(" Please enter your phoneNomber just like this //094526314 ");
                }
            }
        }
        //constractors
        public Person(string n, string p)
        {
            Name = n;
            Phone = p;
        }

        public Person()
        {
            Name = "gweast";
        }
        public Person(string n) {
            Name = n;
        }
        //Methods
        public override string ToString()
        {
            return name + " : " + phone;
        }
    }

}
