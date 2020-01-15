using System;
using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Services.User;
using Auction.Services.UserAccountService;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class WinnerController : Controller
    {
        [System.Obsolete]
        public ActionResult Index(string searchTxt, DateTime? todayDateTime, int? districtId, int? thanaId, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy, int? pageNo)
        {
            int pageSize = 9;
            EndAdViewModel model = new EndAdViewModel()
            {
                SearchText = searchTxt,
                FeaturedCategories = EndingTodayService.Instance.GetFeaturedNotNullItemCategory(),
                Districts = DistrictService.Instance.GetAll(),
                MaximumPrice = EndingTodayService.Instance.GetMaximumPrice(),
                MinimumPrice = EndingTodayService.Instance.GetMinimumPrice()
            };

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryId;
            model.DistrictId = districtId;

            
            int totalCount = EndingTodayService.Instance.SearchProduct(searchTxt, todayDateTime, districtId, thanaId, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize).Count;
            model.Products = EndingTodayService.Instance.SearchProduct(searchTxt, todayDateTime, districtId, thanaId, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize);
            
            model.Winner = EndingTodayService.Instance.Winners(model.Products);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return View(model);

        }

        [System.Obsolete]
        public ActionResult FilterProduct(string searchTxt, DateTime? todayDateTime,int? districtId, int? thanaId, int? minimumPrice, int? maximumPrice, int? categoryId, int? sortBy, int? pageNo)
        {
            int pageSize = 9;
            FilterProductsViewModel model = new FilterProductsViewModel {SearchText = searchTxt};

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryId;
            model.DistrictId = districtId;

            int totalCount = EndingTodayService.Instance.SearchProduct(searchTxt, todayDateTime, districtId, thanaId, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize).Count;
            model.Products = EndingTodayService.Instance.SearchProduct(searchTxt, todayDateTime, districtId, thanaId, minimumPrice, maximumPrice, categoryId, sortBy, pageNo.Value, pageSize);
            model.Bidders = EndingTodayService.Instance.Winners(model.Products);
            model.Pager = new Pager(totalCount, pageNo, pageSize);
            return PartialView(model);

        }
    }
}