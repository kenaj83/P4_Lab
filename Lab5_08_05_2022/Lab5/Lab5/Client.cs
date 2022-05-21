using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5
{

    [Table("Klient")]
    internal class Client

 
    {

        public Client()
        {
            Orders = new List<Orders>();

        }
        public int Id { get; set; } 

        public string Name { get; set; }

        //[Required]
        //[MaxLength]
        //[Column(TypeName = "text")]
        //[NotMapped]
        public List<Orders> Orders { get; set; }    
    }
}
