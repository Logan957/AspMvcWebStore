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
        ProductInitialization productInitialization;
        public ProductController()
        {
            productInitialization = new ProductInitialization();
        }
        public IActionResult Index(int? Id)
        {
            if (CartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = CartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            var selectedProducts = productInitialization.Products.Where(p => p.Id == Id);
            return View(selectedProducts);
            
           
        }        
    }
}
