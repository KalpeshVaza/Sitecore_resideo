﻿using System.Collections.Generic;

namespace Sitecore.Resideo.Models
{
    public class Product
    {
        public string ProductTitle { get; set;}
        public string ProductDescription { get; set;}
        public string ProductImageUrl { get; set;}
        public string ProductLink { get; set;}
        public string ProductLinkText { get; set;}
    }

    public class Products
    {
        public List<Product> ProductList { get; set; }
    }
}