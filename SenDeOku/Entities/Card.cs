using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Card
    {
        public int CardID { get; set; }
        public int BookCount { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
    }
}
