using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repositories
{
    public class ComparisonRepository : IComparisonRepository
    {
        private List<Product> selectedProducts;

        public List<Product> SelectedProducts { get => selectedProducts; }

        public ComparisonRepository()
        {
            selectedProducts = new List<Product>();
        }
        public void Clear() 
        {
            selectedProducts.Clear();
        }
        public void AddToComparison(Product product) 
        {
            if (selectedProducts.Contains(product)) 
            {
              return;
            }
            else 
            {
                selectedProducts.Add(product);
            }
        }
    }
}
