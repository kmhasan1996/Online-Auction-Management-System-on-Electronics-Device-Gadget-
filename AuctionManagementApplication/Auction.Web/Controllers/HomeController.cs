using Auction.Services.UserAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allCategories = UserCategoryService.Instance.GetAll();

            return View(allCategories);
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