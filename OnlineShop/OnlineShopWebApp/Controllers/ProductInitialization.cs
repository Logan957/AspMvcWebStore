using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductInitialization : IProductInitialization
    {

        public List<Product> Products => new List<Product>
        {

            new Product
            { Id = 1, Name = "Ботинки",
             Cost = 500,
             Description = "Туристические ботинки для походов",
             ImagePath ="/Images/image1.jpg"

            },
            new Product
            { Id = 2, Name = "Мужская обувь",
             Cost = 300,
             Description = "Повседневная обувь",
             ImagePath ="/Images/image2.jpg"
            },
            new Product
            { Id = 3, Name = "Кроссовки",
             Cost = 700,
             Description = "Кроссовки для бега",
             ImagePath ="/Images/image3.jpg"
            }

        };









    }
}
