using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Resideo.Models;
using Sitecore.Resideo.Repositories;
using Sitecore.Resources.Media;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Sitecore.Resideo.Controllers
{
    [EnableCors("http://localhost:3000", "*","*")]
    public class ProductsController : ServicesApiController
    {
        private readonly IProductRepository _productsRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productsRepository = productRepository;
        }
        public HttpResponseMessage GetItemData(string item)
        {
            if(string.IsNullOrEmpty(item))
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("please provide Item Id")
                };
            }
            try
            {
            Product product = new Product();
            var itemData = Sitecore.Context.Database.GetItem(item);
            if(itemData != null)
            {
                var linkField = (LinkField)itemData.Fields[Templates.Product.Fields.ProductLink];
                var imageField = (ImageField)itemData.Fields[Templates.Product.Fields.ProductImage];
                product.ProductTitle = itemData.Fields[Templates.Product.Fields.ProductTitle].Value;
                product.ProductDescription = itemData.Fields[Templates.Product.Fields.ProductDescription].Value;
                product.ProductImageUrl = MediaManager.GetMediaUrl(imageField?.MediaItem,new MediaUrlOptions { AlwaysIncludeServerUrl = true});
                product.ProductLink = linkField?.Url;
                product.ProductLinkText = linkField?.Text;
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch(Exception ex)
            {
                Log.Error($"{typeof(ProductsController)}::{nameof(GetItemData)}", ex,Context.User);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Something Went Wrong.");
            }
        }

        public HttpResponseMessage GetItems()
        {
            try
            {
                var products = _productsRepository.GetProducts();
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductsController)}::{nameof(GetItems)}", ex, Context.User);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Something Went Wrong.");
            }

        }

        public HttpResponseMessage GetImage(string Url)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            string imagePath = Url;
            if (!File.Exists(imagePath))
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", Url);
                throw new HttpResponseException(response);
            }
            byte[] bytes = File.ReadAllBytes(imagePath);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentLength = bytes.LongLength;

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = Url;

            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(Url));
            return response;
        }
    }
}
