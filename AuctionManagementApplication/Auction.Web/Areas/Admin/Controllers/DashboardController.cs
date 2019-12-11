using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Web.Areas.Admin.Models;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            //DashboardViewModel model=new DashboardViewModel();
            dynamic model = new System.Dynamic.ExpandoObject();
            model.CategoryCount = DashboardService.Instance.GetCategoryCount();
            model.AdRequestCount = 0;
            model.LiveAdCount = 0;
            model.BlockedAdCount = 0;
            model.UserCount = 0;
            model.BlockedUserCount = 0;
            model.DistrictCount = DashboardService.Instance.GetDistrictCount();
            model.ThanaCount = DashboardService.Instance.GetThanaCount();

            return View(model);
        }
    }
}