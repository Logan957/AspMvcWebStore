using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login , bool checkResponsible = false)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(Register register )
        {
            return RedirectToAction("Index", "Home");
        }
      
        public IActionResult Register()
        {
            return View();
        }
    }
}
