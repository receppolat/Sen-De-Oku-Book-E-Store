using Microsoft.AspNetCore.Mvc.Rendering;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class CustomerUpdateModel
    {
        public Customer Customer { get; set; }
        public SelectList City { get; set; }
    }
}
