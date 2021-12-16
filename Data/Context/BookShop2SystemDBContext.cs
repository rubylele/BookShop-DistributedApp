using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BookShop2SystemDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
