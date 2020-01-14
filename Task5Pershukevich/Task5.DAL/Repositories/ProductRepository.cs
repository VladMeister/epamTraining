using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.EF;
using Task5.DAL.Entities;

namespace Task5.DAL.Repositories
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        private SalesContext _salesContext;

        public ProductRepository(string connectionString) : base(connectionString)
        {
            _salesContext = new SalesContext(connectionString);
        }

        public int Add(Product product)
        {
            _salesContext.Products.Add(product);
            _salesContext.SaveChanges();

            return product.Id;
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
