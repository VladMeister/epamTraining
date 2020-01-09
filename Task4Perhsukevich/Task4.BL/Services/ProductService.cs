using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BL.DTO;
using Task4.BL.Exceptions;
using Task4.DAL.Entities;
using Task4.DAL.Repositories;

namespace Task4.BL.Services
{
    public class ProductService : ISalesService<ProductDTO>
    {
        private ProductRepository _productRepository;

        public ProductService(string connectionString)
        {
            _productRepository = new ProductRepository(connectionString);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(_productRepository.GetAll());
        }

        public ProductDTO GetProductById(int id)
        {
            if (id < 0)
            {
                return null;
                throw new InvalidIdException("Invalid id input!");
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
                return mapper.Map<Product, ProductDTO>(_productRepository.GetById(id));
            }
        }

        public void AddProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            _productRepository.Add(product);
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
