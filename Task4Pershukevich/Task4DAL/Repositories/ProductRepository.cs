﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4DAL.Entities;
using Task4DAL.EF;

namespace Task4DAL.Repositories
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        private SalesContext _salesContext { get; }

        public ProductRepository(string connectionString) : base(connectionString)
        {
            _salesContext = salesContext;
        }

        public void Add(Product product)
        {
            _salesContext.Products.Add(product);
            _salesContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _salesContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _salesContext.Products.Find(id);
        }
    }
}
