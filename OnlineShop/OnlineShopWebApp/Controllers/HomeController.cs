using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var database = new ProductInitialization();
            return  View(database.products);

        }        
    }
}
