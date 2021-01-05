using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Resideo.Models;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Resideo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts(bool fullUrl = false)
        {
            try
            {
                var homePage = Sitecore.Context.Database.GetItem(Constants.SiteHomePage);
                var items = homePage?.GetChildren().Where(w => w?.TemplateID == Constants.ProductsTemplateId)?.ToList();
                List<Product> products = new List<Product>();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        var linkField = (LinkField)item.Fields[Templates.Product.Fields.ProductLink];
                        var imageField = (ImageField)item.Fields[Templates.Product.Fields.ProductImage];
                        Product product = new Product()
                        {
                            ProductTitle = item.Fields[Templates.Product.Fields.ProductTitle].Value,
                            ProductDescription = item.Fields[Templates.Product.Fields.ProductDescription].Value,
                            ProductImageUrl =(fullUrl)?MediaManager.GetMediaUrl(imageField?.MediaItem, new MediaUrlOptions { AlwaysIncludeServerUrl = true }): MediaManager.GetMediaUrl(imageField?.MediaItem),
                            ProductLink = linkField?.Url,
                            ProductLinkText = linkField?.Text
                        };
                        products.Add(product);
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductRepository)}::{nameof(GetProducts)}", ex, Context.User);
                return new List<Product>();
            }
        }
    }
}