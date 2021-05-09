using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public interface IOrdersRepository
    {
        List<Cart> Orders { get; }

        void Add(Cart cart);
        Cart TryGetByUserId(string userId);
    }
}