using Microsoft.AspNetCore.Mvc.Rendering;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class BookAddModel
    {
        public Book Book { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Authors { get; set; }
        public SelectList Publishers { get; set; }
    }
}
