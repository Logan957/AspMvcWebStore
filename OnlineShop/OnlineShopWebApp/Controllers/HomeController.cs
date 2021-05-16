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
        private readonly IProductRepository productRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IComparisonRepository comparisonRepository;
        private readonly IFavoritesRepository favoritesRepository;


        public HomeController(IProductRepository productRepository, ICartsRepository cartsRepository, IComparisonRepository comparisonRepository, IFavoritesRepository favoritesRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
            this.comparisonRepository = comparisonRepository;
            this.favoritesRepository = favoritesRepository;
        }
        public IActionResult Index()
        {
          return View(productRepository.Products);
        }
       
       

    }
}
