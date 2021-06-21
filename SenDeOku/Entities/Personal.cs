using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Personal
    {
        [Key]
        [StringLength(11, MinimumLength = 11)]
        public string PersonelID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cell { get; set; }
        public string Mail { get; set; }
        public string Rank { get; set; }
        public string Adress { get; set; }
    }
}
