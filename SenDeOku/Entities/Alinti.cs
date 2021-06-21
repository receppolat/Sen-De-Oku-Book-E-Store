using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Alinti
    {
        public int AlintiID{ get; set; }
        public string AlintiInformation { get; set; }
        public string Date { get; set; }
        public Book Book { get; set; }
    }
}
