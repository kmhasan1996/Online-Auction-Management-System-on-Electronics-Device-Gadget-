using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;
using System.Data.Entity;
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
            var oldUserData = Session["UserData"] as User;

            var userData = (dynamic)null;
            if (oldUserData !=null)
            {
                userData = UserAccountService.Instance.IsRegisteredUser(oldUserData);
            }
           

            Bidder bidder = new Bidder();
            PostDetailsViewModel model = new PostDetailsViewModel();
            if (userData != null)
            {

                bidder.UserId = userData.Id;
                bidder.ProductId = postId;
            

                //var product = userData.Products.FirstOrDefault(x => x.Id == postId);
                var product = UserProductService.Instance.GetAdByIdAndUserId(userData.Id,postId);

                if (product != null)
                {
                    model.OwnAd = true;
                }
                else
                {
                    model.OwnAd = false;
                }
            }
            else
            {
                model.OwnAd = false;
            }

            

            var isExist = UserProductService.Instance.ExistBidder(bidder);

            if (isExist !=null)
            {
                model.ExistenceBidder = true;
            }
            else
            {
                model.ExistenceBidder = false;
            }
            
            model.User = userData;
            model.Product = PostedAdService.Instance.GetPostedAdById(postId);
            model.Bidders = UserProductService.Instance.Bidders(postId);
                
            
            return View(model);
        }
    }
}