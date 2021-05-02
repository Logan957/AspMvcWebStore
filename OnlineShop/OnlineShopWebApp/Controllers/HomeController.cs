﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Controllers;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductInitialization productInitialization;

        public HomeController()
        {
            productInitialization = new ProductInitialization();
        }
        public IActionResult Index()
        {
            if (CartsRepository.TryGetByUserId(Constants.UserId) != null)
            {
                var count = CartsRepository.TryGetByUserId(Constants.UserId).Items.Sum(p => p.Amount);
                ViewBag.Count = count;
            }
            return View(productInitialization.Products);
        }

    }
}
