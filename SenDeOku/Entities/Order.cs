using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int BookCount { get; set; }
        public Book Book { get; set; }
        public Receipt Receipt { get; set; }
    }
}