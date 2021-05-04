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
        private readonly Constants constants;
        private readonly ProductInitialization productInitialization;
        private readonly CartsRepository cartsRepository;

        public ProductController(Constants constants , ProductInitialization productInitialization, CartsRepository cartsRepository)
        {
            this.constants = constants;
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index(int? Id)
        {
            if (cartsRepository.TryGetByUserId(constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            var selectedProducts = productInitialization.Products.Where(p => p.Id == Id);
            return View(selectedProducts);
            
           
        }        
    }
}
