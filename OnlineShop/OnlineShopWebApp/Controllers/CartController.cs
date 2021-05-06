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
        
        private readonly IProductInitialization productInitialization;
        private readonly ICartsRepository cartsRepository;

        public CartController(  IProductInitialization productInitialization, ICartsRepository cartsRepository)
        {
            
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            if (cartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = cartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(cart);
        }
        public IActionResult Add (int productId)
        {
            var product = productInitialization.Products.FirstOrDefault(p => p.Id == productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsRepository.CartClear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Change(int productId, string operation) 
        {
            var product = productInitialization.Products.FirstOrDefault(p => p.Id == productId);
            cartsRepository.ChangeCount( product, Constants.UserId, operation);
            return RedirectToAction("Index");

        }


    }
}
