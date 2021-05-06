using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartsRepository : ICartsRepository
    {
        private List<Cart> carts;
        
        public List<Cart> Carts { get => carts; }

        public CartsRepository() 
        {
            carts = new List<Cart>();
        }
        public void  CartClear( string userId) 
        {
            var existingCart = TryGetByUserId(userId);
            existingCart.Items.Clear();
        }
        public void ChangeCount( Product product, string userId,string operation ) 
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.
                     FirstOrDefault(p => p.Product.Id == product.Id);
            //Очень странная проблема , если я передам string как "-" и "+" ,то он почему-то "-" обрабатывает правильно , а при "+" в CartController прилетит null
            if (operation == "+")
            {
                existingCartItem.Amount += 1;
            }
            else
            {
                if ( existingCartItem.Amount == 1) 
                {
                    existingCart.Items.Remove(existingCartItem);
                }
                else
                existingCartItem.Amount -= 1;
                
            }

        }
        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.
                     FirstOrDefault(p => p.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }
    }
}
