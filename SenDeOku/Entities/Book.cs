using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public string Translater { get; set; }
        public int Count { get; set; }
        public int PageCount { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public string Language { get; set; }
        public string Photo { get; set; }
        public string Information { get; set; }
        public Category category { get; set; }
        public Publisher Publisher { get; set; }
    }
}
