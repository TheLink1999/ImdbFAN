using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
namespace Imdb
{
    class Program
    {
        static string filePath = @"../../Film.text";
        static string userPath = @"../../Users.txt";
        static string [] lines;
        public static void Main(string[] args)
        {
            lines = File.ReadAllLines(userPath);
            for (int i = 0; i < lines.Length; i++)
            {

            }
        }
    }
}

