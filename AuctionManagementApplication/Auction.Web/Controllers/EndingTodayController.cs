using System.Web.Mvc;
using Auction.Services.User;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class EndingTodayController : Controller
    {
        [System.Obsolete]
        public ActionResult Index(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy, int? pageNo)
        {
            int pageSize = 9;
            ShopViewModel model = new ShopViewModel
            {
                SearchText = searchTxt,
                FeaturedCategories = EndingTodayService.Instance.GetFeaturedNotNullItemCategory(),
                MaximumPrice = EndingTodayService.Instance.GetMaximumPrice(),
                MinimumPrice = EndingTodayService.Instance.GetMinimumPrice()
            };

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryId;

            int totalCount = EndingTodayService.Instance.SearchProductCount(searchTxt, minimumPrice, maximumPrice, categoryId, sortBy);
            model.Products = EndingTodayService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return View(model);

        }

        [System.Obsolete]
        public ActionResult FilterProduct(string searchTxt, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy, int? pageNo)
        {
            int pageSize = 9;
            FilterProductsViewModel model = new FilterProductsViewModel();

            model.SearchText = searchTxt;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryId;

            int totalCount = EndingTodayService.Instance.SearchProductCount(searchTxt, minimumPrice, maximumPrice, categoryId, sortBy);
            model.Products = EndingTodayService.Instance.SearchProduct(searchTxt, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);
            return PartialView(model);

        }
    }
}