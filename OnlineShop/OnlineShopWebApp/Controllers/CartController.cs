using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        
        private readonly IProductRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(  IProductRepository productRepository, ICartsRepository cartsRepository)
        {
            
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add (int productId)
        {
            var product = productRepository.Products.FirstOrDefault(p => p.Id == productId);
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
            var product = productRepository.Products.FirstOrDefault(p => p.Id == productId);
            cartsRepository.ChangeCount( product, Constants.UserId, operation);
            return RedirectToAction("Index");

        }
      


    }
}
