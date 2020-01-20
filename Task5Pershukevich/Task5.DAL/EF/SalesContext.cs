using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Entities;

namespace Task5.DAL.EF
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(s => s.HasMaxLength(30));

            modelBuilder.Entity<Order>().Property(o => o.Cost).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Date).IsRequired();

            modelBuilder.Entity<Manager>().Property(o => o.Lastname).IsRequired();

            modelBuilder.Entity<Client>().Property(o => o.Firstname).IsRequired();
            modelBuilder.Entity<Client>().Property(o => o.Lastname).IsRequired();

            modelBuilder.Entity<Product>().Property(o => o.Name).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
