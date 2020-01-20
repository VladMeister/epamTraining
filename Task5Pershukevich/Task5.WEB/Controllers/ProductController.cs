using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.BL.DTO;
using Task5.BL.Services;
using Task5.WEB.Models;

namespace Task5.WEB.Controllers
{
    public class ProductController : Controller
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Sales"].ConnectionString;

        private ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService(_connectionString);
        }

        public ActionResult Index(string searchString)
        {
            IEnumerable<ProductDTO> productDtos = _productService.GetAll();
            if (productDtos.Any())
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
                var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);

                if (string.IsNullOrEmpty(searchString))
                {
                    return View(products);
                }
                else
                {
                    var filteredProducts = products.Where(p => p.Name == searchString);

                    return View(filteredProducts);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _productService.Dispose();
            base.Dispose(disposing);
        }
    }
}