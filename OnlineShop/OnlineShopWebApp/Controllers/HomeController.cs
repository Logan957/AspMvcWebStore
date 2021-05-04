using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Controllers;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductInitialization productInitialization;
        private readonly ICartsRepository cartsRepository;
        

        public HomeController(IProductInitialization productInitialization, ICartsRepository cartsRepository)
        {
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
            
        }
        public IActionResult Index()
        {
            if (cartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(productInitialization.Products);
        }

    }
}
