using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class OrderModel
    {
        public List<Receipt> Receipt { get; set; }      
        public List<Shipper>  Shipper{ get; set; }      
    }
}
