using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
            
        }
        public IActionResult Buy()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Orders.Add(cart);
            cartsRepository.CartClear(Constants.UserId);
            return View();
        }
    }
}
