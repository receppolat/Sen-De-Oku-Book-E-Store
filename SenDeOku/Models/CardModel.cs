using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class CardModel
    {
        public List<Card> Cards { get; set; }
        public List<Book> Book { get; set; }
        public List<Author> Author { get; set; }
        public List<Publisher> Publisher { get; set; }
    }
}
