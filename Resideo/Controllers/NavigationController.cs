using Sitecore.Diagnostics;
using Sitecore.Mvc.Controllers;
using Sitecore.Resideo.Models;
using Sitecore.Resideo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Resideo.Controllers
{
    public class NavigationController : SitecoreController
    {
        private readonly IProductRepository _productsRepository;
        public NavigationController(IProductRepository productRepository)
        {
            _productsRepository = productRepository;
        }
        // GET: Navigation
        public ActionResult Index()
        {
            var user = Context.User;
            return View("~/Views/Navigation/Navigation.cshtml");
        }

        public ActionResult GetProducts()
        {
            try
            {
                var products = _productsRepository.GetProducts();
                return View("~/Views/Navigation/Products.cshtml", products);
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductsController)}::{nameof(GetProducts)}", ex, Context.User);
                return View("~/Views/Navigation/Products.cshtml", new List<Product>());
            }
        }
    }
}