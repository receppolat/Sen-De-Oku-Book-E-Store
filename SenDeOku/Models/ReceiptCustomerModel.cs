using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class ReceiptCustomerModel
    {
        public Customer Customer{ get; set; }
        public Receipt Receipt { get; set; }
    }
}
