using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class Dostawca
    {
        public int Id { get; set; }

        public string NazwaFirmy { get; set; }

        public List<Faktury> Faktury { get; set; } = new List<Faktury>();

        public List<Sprzet> Sprzet { get; set; }


    }
}
