using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bankszamla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bankszamla> adatok = new List<Bankszamla>();
            StreamReader sr = new StreamReader("szamlak.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] mezok = sr.ReadLine().Split(';');
                adatok.Add(new Bankszamla(mezok[0], mezok[1], decimal.Parse(mezok[2])));
            }
            sr.Close();

            foreach (var item in adatok)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
