using System;
using System.Web.Mvc;
using Auction.Services.User;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Products(Boolean isLatestProducts, int? categoryId)
        {
            ProductWidgetViewmodel model = new ProductWidgetViewmodel {IsLatestProduct = isLatestProducts};
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                model.ByCategory = true;


            }


            if (isLatestProducts)
            {
                model.Products = UserProductService.Instance.GetLatestProductPosts(8);
            }
            else if (categoryId.HasValue && categoryId.Value > 0)
            {
                model.Products = UserProductService.Instance.GetProductsByCategory(categoryId.Value, 4);
            }
            else
            {
                model.Products = UserProductService.Instance.GetEightProducts(8);
            }

            return PartialView("_Products",model);
        }
    }
}