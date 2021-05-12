using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productInitialization;
        private readonly ICartsRepository cartsRepository;
        private readonly IComparisonRepository comparisonRepository;


        public HomeController(IProductRepository productInitialization, ICartsRepository cartsRepository, IComparisonRepository comparisonRepository)
        {
            this.productInitialization = productInitialization;
            this.cartsRepository = cartsRepository;
            this.comparisonRepository = comparisonRepository;
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
        public IActionResult AddToComparison(int productId)
        {
            var selectedProducts = productInitialization.Products.FirstOrDefault(p => p.Id == productId);
            comparisonRepository.AddToComparison(selectedProducts);
            return RedirectToAction("Index");
        }
    }
}
