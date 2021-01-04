using Sitecore.Resideo.Models;
using System.Collections.Generic;

namespace Sitecore.Resideo.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
