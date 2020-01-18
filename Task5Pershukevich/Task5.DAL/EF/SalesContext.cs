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
            modelBuilder.Entity<Manager>().Property(p => p.Lastname).HasMaxLength(25);

            modelBuilder.Entity<Client>().Property(p => p.Firstname).HasMaxLength(20);
            modelBuilder.Entity<Client>().Property(p => p.Lastname).HasMaxLength(25);

            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(30);


            base.OnModelCreating(modelBuilder);
        }
    }
}
