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
        private readonly ProductInitialization productInitialization;
        public CartController()
        {
            productInitialization = new ProductInitialization();
        }

        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            if (CartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = CartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(cart);
        }
        public IActionResult Add (int productId)
        {
            var product = productInitialization.Products.FirstOrDefault(p => p.Id == productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }



    }
}
