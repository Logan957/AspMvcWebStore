using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductInitialization productInitialization;
        private readonly ICartsRepository cartsRepository;

        public ProductController( IProductInitialization productInitialization, ICartsRepository cartsRepository)
        {
            
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index(int? Id)
        {
            if (cartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            var selectedProducts = productInitialization.Products.Where(p => p.Id == Id);
            return View(selectedProducts);
            
           
        }        
    }
}
