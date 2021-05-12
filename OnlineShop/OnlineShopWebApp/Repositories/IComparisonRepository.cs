using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public interface IComparisonRepository
    {
        List<Product> SelectedProducts { get; }
        public void AddToComparison(Product product);
    }
}