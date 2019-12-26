﻿using System.Linq;
using Auction.Entities;
using Auction.Services.UserAccountService;
using Auction.Web.ViewModels;
using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Services.User;

namespace Auction.Web.Controllers
{
    public class UserController : Controller
    {
        #region UserAccount

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
           // JsonResult json = new JsonResult();

            if (ModelState.IsValid)
            {
                var User = UserAccountService.Instance.IsRegisteredUser(model);
                
                if(User == null)
                {
                    ModelState.AddModelError("Error", "Email or password is not correct");
                }
                else if (!User.IsActive)
                {
                    // json.Data = new {message = "Sorry ! Your account has been blocked"};
                    ModelState.AddModelError("Error", "Sorry ! Your account has been deactivated");
                }
                else if (User != null)
                {
                    //Session["FirstName"] = User.FirstName;
                    //Session["Id"] = User.Id;
                    Session["UserData"] = User;

                   return RedirectToAction("MyAds");
                }
                
               
            }
            
            return View();

        }

        [HttpGet]
        public ActionResult Register()
        {
            var districts = DistrictService.Instance.GetAll();
            return View(districts);
        }

        [HttpPost]
        public ActionResult Register(User model)
        {

            JsonResult jason = new JsonResult
            {
                Data = UserAccountService.Instance.AddUser(model) ? new {Success = true} : new {Success = false}
            };
            return jason;
        }

        public ActionResult Logout()
        {
            //Session.Abandon();

            Session["UserData"] = null;

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region OtherMethod

        public JsonResult GetThanaByDistrictId(int districtId)
        {
            var thanas = UserThanaService.Instance.GetThanaByDistrictId(districtId).Select(x => new { x.Id, x.Name });

            return Json(thanas, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region UserDetails

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (Session["UserData"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult NewAd()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            var userData = Session["UserData"] as User;
            model.UserId = userData.Id;
            model.Category = CategoryService.Instance.GetAllActiveCategory();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewAd(Product product)
        {
            JsonResult json = new JsonResult
            {
                Data = UserProductService.Instance.AddNewPost(product)
                    ? new {Success = true}
                    : new {Success = false}
            };

            return json;
        }


        [HttpGet]
        public ActionResult MyAds()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            var userData = Session["UserData"] as User;
            model.PenddingAds = UserProductService.Instance.GetAdByUserId(userData.Id).Where(x => x.IsActive == false)
                .ToList();
            model.ActiveAds = UserProductService.Instance.GetAdByUserId(userData.Id).Where(x => x.IsActive)
                .ToList();

            return View(model);
        }




        #endregion

    }
}