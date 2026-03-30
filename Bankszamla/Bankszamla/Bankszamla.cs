using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankszamla
{
    internal class Bankszamla
    {
        private string szamlaszam;
        private string tulajdonos;
        private decimal egyenleg;
        private decimal hitelkeret; 
        private List<Bankszamla> tranzakciok = new List<Bankszamla>();

        public Bankszamla(string szamlaszam, string tulajdonos, decimal egyenleg)
        {
            this.szamlaszam = szamlaszam;
            this.tulajdonos = tulajdonos;
            this.egyenleg = egyenleg;
        }

        // Add a private constructor for transaction records
        private Bankszamla(decimal osszeg, string tipus)
        {
            this.szamlaszam = "";
            this.tulajdonos = tipus;
            this.egyenleg = osszeg;
        }

        public string GetSzamlaszam()
        {
            return szamlaszam;
        }

        public string GetTulajdonos()
        {
            return tulajdonos;
        }

        public decimal GetEgyenleg()
        {
            return egyenleg;
        }

        public void Befizetes(decimal osszeg)
        {
            this.egyenleg += osszeg;
            tranzakciok.Add(new Bankszamla(osszeg, "befizetés"));
            Console.WriteLine($"{osszeg} Ft befizetve. Új egyenleg: {egyenleg} Ft");
        }

        public bool Kifizetes(decimal osszeg)
        {
            if (egyenleg >= osszeg)
            {
                this.egyenleg -= osszeg;
                tranzakciok.Add(new Bankszamla(osszeg, "kifizetés"));
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"\nSzámlaszám: {szamlaszam}\nTulajdonos: {tulajdonos}\nEgyenleg: {egyenleg} Ft";
        }
    }
}
