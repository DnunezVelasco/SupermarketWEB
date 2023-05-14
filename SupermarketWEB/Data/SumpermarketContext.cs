using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions options) : base(options)
        {
        }

     
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<PayMode> PayModes { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public DbSet<Detail> ProviDetailders { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

       

    }
}
