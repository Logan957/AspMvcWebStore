using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IProductRepository productRepository;
        public FavoritesController(IFavoritesRepository favoritesRepository, IProductRepository productRepository)
        {
            this.favoritesRepository = favoritesRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var selectedProduts = favoritesRepository.SelectedProducts;
            return View(selectedProduts);
        }
        public IActionResult Clear()
        {
            favoritesRepository.SelectedProducts.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult AddToFavorites(int productId)
        {
            var selectedProducts = productRepository.Products.FirstOrDefault(p => p.Id == productId);
            favoritesRepository.AddToFavorites(selectedProducts);
            return RedirectToAction("Index", "Home");
        }
    }
}
