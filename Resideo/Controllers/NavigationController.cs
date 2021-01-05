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
        public ActionResult GetNavigation()
        {
            var user = Context.User;
            return View("~/Views/Navigation/Navigation.cshtml");
        }

        public ActionResult GetProducts()
        {
            try
            {
                ProductRepository productRepository = new ProductRepository();
                List<Product> products = productRepository.GetProducts();
                return View("~/Views/Navigation/Products.cshtml", products);
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductRepository)}::{nameof(GetProducts)}", ex, Context.User);
                return View("~/Views/Navigation/Products.cshtml", new List<Product>());
            }
        }
    }
} 