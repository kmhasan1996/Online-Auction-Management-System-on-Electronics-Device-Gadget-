using Auction.Services.UserAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model=new HomeViewModel();

            model.Categories = UserCategoryService.Instance.GetAll();
            model.Districts = DistrictService.Instance.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}