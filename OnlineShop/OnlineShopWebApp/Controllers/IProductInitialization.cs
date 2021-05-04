using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public interface IProductInitialization
    {
        List<Product> Products { get; }
    }
}