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
    public class ProductController : Controller
    {
        public IActionResult Index(int? Id)
        {
            var database = new ProductInitialization();
            var selectedProducts = database.Products.Where(p => p.Id == Id);
            return View(selectedProducts);
            
           
        }        
    }
}
