using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public interface IFavoritesRepository
    {
        List<Product> SelectedProducts { get; }

        void AddToFavorites(Product product);
    }
}