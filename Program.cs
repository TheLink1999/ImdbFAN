using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Imdb
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter doc = new XmlTextWriter("Users.xml", Encoding.UTF8);
            doc.WriteStartDocument();
            doc.WriteStartElement("head");
            doc.Close();
            XmlDocument document = new XmlDocument();
            document.Load("Users.xml");
            XmlNode element = document.CreateElement("element");
            document.DocumentElement.AppendChild(element); // указываем родителя
            XmlAttribute attribute = document.CreateAttribute("number"); // создаём атрибут
            attribute.Value = "1"; // устанавливаем значение атрибута
            element.Attributes.Append(attribute); // добавляем атрибут
            XmlNode subElement1 = document.CreateElement("subElement1"); // даём имя
            subElement1.InnerText = "Hello"; // и значение
            element.AppendChild(subElement1); // и указываем кому принадлежит
            XmlNode subElement2 = document.CreateElement("subElement2");
            subElement2.InnerText = "Dear";
            element.AppendChild(subElement2);

            XmlNode subElement3 = document.CreateElement("subElement3");
            subElement3.InnerText = "Habr";
            element.AppendChild(subElement3);
            document.Save("Users.xml");
        }
    }
}
