using Microsoft.AspNetCore.Mvc.Rendering;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class OrderDetails
    {
        public List<Book> Books { get; set; }
        public List<Order> Orders { get; set; }
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public Receipt Receipt { get; set; }
        public List<Shipper> Shippers { get; set; }
        //Ekranda Shipper comboboxu için veriler geliyor
        public SelectList ShipperList { get; set; }
        //ComboBoxdan seçtiğimiz shipper buraya gelecek
        public Shipper Shipper { get; set; }
        public List<Customer> Customer { get; set; }
    }
}
