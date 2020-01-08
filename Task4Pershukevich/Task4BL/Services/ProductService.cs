using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4BL.DTO;
using Task4DAL.Repositories;
using AutoMapper;
using Task4DAL.Entities;
using Task4BL.Exceptions;

namespace Task4BL.Services
{
    public class ProductService : ISalesService<ProductDTO>
    {
        private ProductRepository productRepository { get; }

        public ProductService(string connectionString)
        {
            productRepository = new ProductRepository(connectionString);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productRepository.GetAll());
        }

        public ProductDTO GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
                return mapper.Map<Product, ProductDTO>(productRepository.GetById(id));
            }
        }

        public void AddProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            productRepository.Add(product);
        }

        public void Save()
        {
            productRepository.Save();
        }

        public void Dispose()
        {
            productRepository.Dispose();
        }
    }
}
