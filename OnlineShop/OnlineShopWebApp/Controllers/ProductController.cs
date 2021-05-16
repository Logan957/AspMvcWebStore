using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public ProductController( IProductRepository productRepository, ICartsRepository cartsRepository)
        {
            
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index(int? Id)
        {
            var selectedProducts = productRepository.Products.Where(p => p.Id == Id);
            return View(selectedProducts);
            
           
        }
       
    }
}
