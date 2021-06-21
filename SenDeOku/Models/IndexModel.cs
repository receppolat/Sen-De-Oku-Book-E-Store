using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class IndexModel
    {
        public List<Slider> Sliders { get; set; }
        public List<BookNAuthorModel> BookNAuthor { get; set; }
        public List<BookAuthorBestModel> BookNAuthorBest { get; set; }
        public List<BookAuthorOrderByDateModel> BookNAuthorOrderByDate { get; set; }
        public List<BookAuthorOrderByDiscountModel> BookNAuthorOrderByDiscount { get; set; }
        public List<BookAuthorSHKModel> BookAuthorSHK { get; set; }
        public List<BookAuthorKPSSModel> BookAuthorKPSS { get; set; }


    }
}
