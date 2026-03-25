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

        public void Befizetes(List<Bankszamla> adatok, decimal deposit)
        {
           foreach (var item in adatok)
            {
                if (item.GetSzamlaszam() == szamlaszam)
                {
                    item.egyenleg += deposit;
                    tranzakciok.Add(new DateTime(), item.egyenleg, "befizetés");
                }
            }
        }

        public bool Kifizetes(List<Bankszamla> adatok, decimal withdraw)
        {
            foreach (var item in adatok)
            {
                if (item.GetSzamlaszam() == szamlaszam)
                {
                    if (item.egyenleg >= withdraw)
                    {
                        item.egyenleg -= withdraw;
                        tranzakciok.Add(new DateTime(), item.egyenleg, "kifizetés");
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"\nSzámlaszám: {szamlaszam}\nTulajdonos: {tulajdonos}\nEgyenleg: {egyenleg} Ft";
        }
    }
}
