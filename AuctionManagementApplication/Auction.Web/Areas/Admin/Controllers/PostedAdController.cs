using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;
using Auction.Services.UserAccountService;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class PostedAdController : Controller
    {
        // GET: Admin/PostedAd
        public ActionResult Index()
        {
           
           var allPostedAd = PostedAdService.Instance.GetAllPostedAd();
            return View(allPostedAd);
        }

        [HttpPost]
        public ActionResult ActivateDeactivatePostedAd(int postId)
        {
            JsonResult json = new JsonResult
            {
                Data = PostedAdService.Instance.ActivateDeactivatePostedAd(postId)
                    ? new {Success = true}
                    : new {Success = false}
            };


            return json;
        }

        [HttpGet]
        public ActionResult GetPostedAdById(int productId)
        {
            var product = PostedAdService.Instance.GetPostedAdById(productId);
            return PartialView("_ViewAndUpdate", product);
        }

        public ActionResult UserDetails(int userId)
        {
            var user = UserAccountService.Instance.GetUserById(userId);

            return PartialView("_UserDetails", user);
        }
    }
}