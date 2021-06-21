using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class BookAdminListView
    {
        public List<Book> Books { get; set; }
        public List<Category> Categories { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Author> Authors { get; set; }
    }
}
