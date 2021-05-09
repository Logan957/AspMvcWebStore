using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrdersRepository : IOrdersRepository
    {
        private List<Cart> orders;

        public List<Cart> Orders { get => orders; }
        public OrdersRepository()
        {
            orders = new List<Cart>();
        }
        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
        public Cart TryGetByUserId(string userId)
        {
            return orders.FirstOrDefault(c => c.UserId == userId);
        }
    }
}