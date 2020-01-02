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
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            //DashboardViewModel model=new DashboardViewModel();
            dynamic model = new System.Dynamic.ExpandoObject();
            model.CategoryCount = DashboardService.Instance.GetCategoryCount();
            model.AdRequestCount = DashboardService.Instance.GetPendingPostedAdCount();
            model.LiveAdCount = DashboardService.Instance.GetActivePostedAdCount();
            model.BlockedAdCount = 0;
            model.UserCount = DashboardService.Instance.GetActiveUserCount();
            model.BlockedUserCount = DashboardService.Instance.GetDeactivateUserCount();
            model.DistrictCount = DashboardService.Instance.GetDistrictCount();
            model.ThanaCount = DashboardService.Instance.GetThanaCount();

            return View(model);
        }
    }
}