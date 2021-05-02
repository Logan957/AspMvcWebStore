﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public decimal Cost { get; set; }
       public string Description { get; set; }
       public string ImagePath { get; set; }
    }
}
