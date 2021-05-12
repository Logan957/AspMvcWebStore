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

        public ComparisonController(IComparisonRepository comparisonRepository)
        {
            this.comparisonRepository = comparisonRepository;
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
    }
}
