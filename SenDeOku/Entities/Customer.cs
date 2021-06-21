using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cell { get; set; }
        public string Adress { get; set; }
        public string CardNumber { get; set; }
        public City City { get; set; }
    }
}
