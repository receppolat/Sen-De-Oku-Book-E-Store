using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class BookDetailsModel
    {
        public Book Book { get; set; }
        public List<BookAuthorBestDetailModel> BookAuthorBestDetailModel { get; set; }
        public List<BookAuthorSameDetailModel> BookAuthorSameDetailModel { get; set; }
    }
}
