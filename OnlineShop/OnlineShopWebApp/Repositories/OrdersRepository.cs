using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private List<Order> orders;

        public List<Order> Orders { get => orders; }
        public OrdersRepository()
        {
            orders = new List<Order>();
        }
        public void Add(Cart cart,ByersData byersData)
        {
            var newOrder = new Order { ByersData = byersData, Cart = cart };
            orders.Add(newOrder);
        }
       
    }
}