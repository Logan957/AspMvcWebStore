using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public interface ICartsRepository
    {
        
        List<Cart> Carts { get; } 
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void CartClear(string userId);
        void ChangeCount(Product product , string operation, string userId);
    }
}