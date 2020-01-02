using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Services.User;
using Auction.Services.UserAccountService;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult ProductDetails(int postId)
        {
            PostDetailsViewModel model = new PostDetailsViewModel
            {

                Product = PostedAdService.Instance.GetPostedAdById(postId),
                Bidders = UserProductService.Instance.Bidders(postId)
                
            };
            return View(model);
        }
    }
}