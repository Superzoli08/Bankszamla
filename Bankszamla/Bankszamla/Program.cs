using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            Console.WriteLine("Üdvözlünk a Bankban!");
            Console.WriteLine("Kérem adja meg a bankszámlas");
        }

        static void HitelkeretBeallitas(List<Bankszamla> lista)
        {
            decimal hitelkeret = int.MinValue;
            Console.WriteLine("Üdvözöljük a Bankba!");
            Console.WriteLine("Még nem volt beállítva hitelkerete");
            Console.WriteLine("Ha nem szeretné, akkor automatikusan 20%-a lesz az ön nyitóegyenlegének");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CSAK most tudja beállítani! Késöbb nem módosítható!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Szeretné beállítani? (I/N) ");
            string valasz = Console.ReadLine().ToUpper();
            Console.Clear();
            if (valasz == "I")
            {
                Console.Write("Kérem adja meg a hitelkeret százalékát: ");
                hitelkeret = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"{hitelkeret}%-os hitelkeret beállítva.");
                Thread.Sleep(3000);
            }
            else if (valasz == "N")
            {
                Console.WriteLine("20%-os hitelkeret beállítva.");
                hitelkeret = 20;
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Hibás válasz, automatikusan 20% lesz a hitelkeret");
                hitelkeret = 20;
                Thread.Sleep(3000);

            }
            Console.Clear();
        }

    }
}
