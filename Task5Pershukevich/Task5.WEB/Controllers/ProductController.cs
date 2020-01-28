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
    [Authorize]
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
            IEnumerable<ProductDTO> productDtos = _productService.GetProductsByName(searchString);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);

            return View(products);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductDTO productDTO = _productService.GetProductById(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductEditModel>()).CreateMapper();
            ProductEditModel product = mapper.Map<ProductDTO, ProductEditModel>(productDTO);

            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ProductEditModel productModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductEditModel, ProductDTO>()).CreateMapper();
                ProductDTO product = mapper.Map<ProductEditModel, ProductDTO>(productModel);

                _productService.UpdateProduct(product);

                return RedirectToAction("Index", "Product");
            }

            return View(productModel);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductDTO product = _productService.GetProductById(id);

            _productService.DeleteProduct(product);

            return RedirectToAction("Index", "Product");
        }

        protected override void Dispose(bool disposing)
        {
            _productService.Dispose();
            base.Dispose(disposing);
        }
    }
}