using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class Sprzet
    {
        public int Id { get; set; }

        public string NazwaSprzetu { get; set; }

        public string Dział { get; set; }


        public Osoba Osoba { get; set; }

        public int OsobaID { get; set; }

        public List<Dostawca> Dostawcy { get; set; }
    }
}
