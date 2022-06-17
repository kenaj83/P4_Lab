using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class Faktury
    {
        public int Id { get; set; }

        public string NumerFaktury { get; set; }

        public Dostawca Dostawca { get; set; }
        
        public int DostawcaID { get; set; }
    }
}
