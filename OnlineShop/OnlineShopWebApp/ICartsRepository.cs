using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        
        List<Cart> Carts { get; } 
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
    }
}