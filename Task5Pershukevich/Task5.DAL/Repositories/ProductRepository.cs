using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Update(Product product)
        {
            _salesContext.Entry(product).State = EntityState.Modified;
            _salesContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            Product productToDelete = _salesContext.Products.FirstOrDefault(p => p.Id == product.Id);

            if (productToDelete != null)
            {
                _salesContext.Products.Remove(productToDelete);
            }
            _salesContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _salesContext.Products.ToList();
        }

        public IEnumerable<Product> GetFilteredByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _salesContext.Products.ToList();
            }
            return _salesContext.Products.Where(p => p.Name == name).ToList();
        }

        public Product GetById(int? id)
        {
            return _salesContext.Products.Find(id);
        }
    }
}
