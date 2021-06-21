using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public string Date { get; set; }
        public float TotalPrice { get; set; }
        public string Details { get; set; }
        public Shipper Shipper { get; set; }
        public Customer customer { get; set; }
    }
}
