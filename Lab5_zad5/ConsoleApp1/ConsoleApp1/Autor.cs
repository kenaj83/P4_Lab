using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Autor
    {
        
            public Autor()
            {
                SpisKsiazek = new List<Ksiazka>();
            }
            public int Id { get; set; }

            public string Imie { get; set; }

            public string Nazwisko { get; set; }

            public List<Ksiazka> SpisKsiazek { get; set; }
        
    }
}

