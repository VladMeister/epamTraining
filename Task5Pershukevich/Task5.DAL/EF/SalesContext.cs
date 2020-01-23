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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public SalesContext(string connectionString) : base(connectionString)
        {

        }

        public SalesContext() : base() //?
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(s => s.HasMaxLength(30));

            modelBuilder.Entity<Order>().Property(o => o.Cost).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Cost).HasColumnType("float");
            modelBuilder.Entity<Order>().Property(o => o.Date).IsRequired();

            modelBuilder.Entity<Manager>().Property(m => m.Lastname).IsRequired();
            modelBuilder.Entity<Manager>().Property(m => m.Lastname).HasColumnType("varchar");
            modelBuilder.Entity<Manager>().HasIndex(m => m.Lastname).IsUnique();

            modelBuilder.Entity<Client>().Property(c => c.Firstname).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.Lastname).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.Firstname).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(c => c.Lastname).HasColumnType("varchar");
            modelBuilder.Entity<Client>().HasIndex(c => c.Lastname).IsUnique();

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar");
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("varchar");
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("varchar");
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(8);

            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.Name).HasColumnType("varchar");
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public class RoleDbInitializer : DropCreateDatabaseAlways<SalesContext> //<- ?
        {
            protected override void Seed(SalesContext db)
            {
                Role admin = new Role { Name = "admin" };
                Role user = new Role { Name = "user" };
                db.Roles.Add(admin);
                db.Roles.Add(user);
                db.Users.Add(new User
                {
                    Email = "mr.vlad0207@mail.ru",
                    Password = "12345678",
                    Role = admin
                });

                base.Seed(db);
            }
        }
    }
}
