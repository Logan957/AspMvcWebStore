using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IComparisonRepository comparisonRepository;
        private readonly IProductRepository productRepository;

        public ComparisonController(IComparisonRepository comparisonRepository, IProductRepository productRepository)
        {
            this.comparisonRepository = comparisonRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var selectedProduts = comparisonRepository.SelectedProducts;
            return View( selectedProduts);
        }
        public IActionResult Clear() 
        {
            comparisonRepository.SelectedProducts.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult AddToComparison(int productId)
        {
            var selectedProducts = productRepository.Products.FirstOrDefault(p => p.Id == productId);
            comparisonRepository.AddToComparison(selectedProducts);
            return RedirectToAction("Index","Home");
        }
    }
}
