using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public Guid Id { get; set;}
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Cost 
        {
            get 
            {
                return Items.Sum(p => p.FullPrice);

            }
        }
    }
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal FullPrice
        {
            get 
            {
                return Product.Cost * Amount;
            }
        }

    }
}