using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public interface IProductRepository
    {
      public List<Product> Products { get;  }
    }
}