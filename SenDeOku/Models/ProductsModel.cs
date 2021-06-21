using Microsoft.AspNetCore.Identity;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class ProductsModel
    {
        public string Name { get; set; }
        public List<BookPublisherDetailModel> BookPublisherSameDetailModel { get; set; }
    }
}
