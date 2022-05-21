using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ksiazka
    {
        public int Id { get; set; }

        public Autor Autor { get; set; }

        public string Tytul { get; set; }

        public int RokWydania { get; set; }
       
    }
}