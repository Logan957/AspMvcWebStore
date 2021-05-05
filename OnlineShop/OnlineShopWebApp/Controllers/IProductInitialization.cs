using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public interface IProductInitialization
    {
      public List<Product> Products { get;  }
    }
}