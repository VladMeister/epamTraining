using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DAL.Entities;

namespace Task4.DAL.EF
{
    public class SalesContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        public SalesContext(string connectionString) : base(connectionString)
        {

        }
    }
}
