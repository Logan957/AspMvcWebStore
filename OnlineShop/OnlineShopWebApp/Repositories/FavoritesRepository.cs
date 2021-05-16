using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private List<Product> selectedProducts;
        public List<Product> SelectedProducts { get => selectedProducts; }
        public FavoritesRepository() 
        {
          selectedProducts = new List<Product>();
        }

        public void AddToFavorites(Product product)
        {
            if (!selectedProducts.Contains(product))
            {
                selectedProducts.Add(product);
            }
        }

    }
}
