using Microsoft.EntityFrameworkCore;
using SenDeOku.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenDeOku.Models
{
    public class OfficeContext : DbContext
    {
        public OfficeContext(DbContextOptions<OfficeContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Alinti> Alinties { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
