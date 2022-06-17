using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }


        public Osoba()
        {
            Sprzety = new List<Sprzet>();
        }
        
      public List<Sprzet> Sprzety { get; set; } = new List<Sprzet>();
    }
}
