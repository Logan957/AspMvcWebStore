using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public interface IOrdersRepository
    {
        List<Order> Orders { get; }
        void Add(Cart cart, ByersData byersData);
    }
}