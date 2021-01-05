using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;
using Sitecore.Resideo.Models;
using Sitecore.Resideo.Repositories;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Resideo.Controllers
{
    public class NavigationController : SitecoreController
    {
        //private readonly IProductRepository _productsRepository;

        //public NavigationController(IProductRepository productRepository)
        //{
        //    _productsRepository = productRepository;
        //}
        // GET: Navigation
        public ActionResult GetNavigation()
        {
            var user = Context.User;
            return View("~/Views/Navigation/Navigation.cshtml");
        }

        public ActionResult GetProducts()
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
                            ProductImageUrl = MediaManager.GetMediaUrl(imageField?.MediaItem, new MediaUrlOptions { AlwaysIncludeServerUrl = true }),
                            ProductLink = linkField?.Url,
                            ProductLinkText = linkField?.Text
                        };
                        products.Add(product);
                    }
                }
                return View("~/Views/Navigation/Products.cshtml", products);
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductRepository)}::{nameof(GetProducts)}", ex, Context.User);
                return View("~/Views/Navigation/Products.cshtml", new List<Product>());
            }
            //try
            //{
            //    var products = _productsRepository.GetProducts();
            //    return View("~/Views/Navigation/Products.cshtml", products);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"{typeof(ProductsController)}::{nameof(GetProducts)}", ex, Context.User);
            //    return View("~/Views/Navigation/Products.cshtml", new List<Product>());
            //}
        }
    }
} 