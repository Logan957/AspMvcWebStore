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
        private readonly ProductInitialization productInitialization;
        private readonly CartsRepository cartsRepository;
        private readonly Constants constants;

        public HomeController(Constants constants , ProductInitialization productInitialization, CartsRepository cartsRepository)
        {
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }
        public IActionResult Index()
        {
            if (cartsRepository.TryGetByUserId(constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(productInitialization.Products);
        }

    }
}
