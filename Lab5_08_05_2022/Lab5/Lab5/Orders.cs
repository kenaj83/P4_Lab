using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Orders
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        //[ForeignKey("Client")]
        public int ClientID { get; set; }

        public Client Client { get; set; }

       

    }
}
