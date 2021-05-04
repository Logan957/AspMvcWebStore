using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly Constants constants;
        private readonly ProductInitialization productInitialization;
        private readonly CartsRepository cartsRepository;

        public CartController( Constants constants, ProductInitialization productInitialization, CartsRepository cartsRepository)
        {
            this.constants = constants;
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(constants.UserId);
            if (cartsRepository.TryGetByUserId(constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(cart);
        }
        public IActionResult Add (int productId)
        {
            var product = productInitialization.Products.FirstOrDefault(p => p.Id == productId);
            cartsRepository.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }



    }
}
