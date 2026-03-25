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



        public void Befizetes(List<Bankszamla> adatok, decimal deposit)
        {
            
        }
    }
}
