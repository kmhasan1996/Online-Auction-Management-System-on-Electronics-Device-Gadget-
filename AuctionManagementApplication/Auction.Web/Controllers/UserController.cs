using System;
using System.Linq;
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
            model.Credit = 100;
            JsonResult jason = new JsonResult
            {
                Data = UserAccountService.Instance.AddUser(model) ? new {Success = true} : new {Success = false}
            };
            return jason;
        }
        public ActionResult TermAndCondition()
        {
            return PartialView("_TermAndCondition");
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
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }

            return View();
        }

        [HttpGet]
        public ActionResult NewAd()
        {
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }

            dynamic model = new System.Dynamic.ExpandoObject();
            var userData = Session["UserData"] as User;
            model.UserId = userData.Id;
            model.Category = CategoryService.Instance.GetAllActiveCategory();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewAd(Product product)
        {
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }

            product.CurrentBidPrice = 0;
            product.IsActive = false;
            product.IsPending = true;
            product.IsRejected = false;


            product.StarDateTime= DateTime.Now;
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
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }
            var userData = Session["UserData"] as User;

            MyAdsViewModel model = new MyAdsViewModel
            {
                User = userData,
                PendingAds = UserProductService.Instance.GetAdByUserId(userData.Id).Where(x => x.IsPending)
                    .ToList(),
                RejectAds = UserProductService.Instance.GetAdByUserId(userData.Id).Where(x => x.IsRejected)
                    .ToList(),
                ActiveAds = UserProductService.Instance.GetAdByUserId(userData.Id).Where(x => x.IsActive)
                    .ToList()
            };


            return View(model);
        }

        //[HttpGet]
        //public ActionResult UpdateInformation()
        //{

        //}

        [HttpGet]
        public ActionResult MyCredit()
        {
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }
            var userData = Session["UserData"] as User;

            dynamic model=new System.Dynamic.ExpandoObject();

            model.credit = UserAccountService.Instance.MyCredit(userData.Id);

            return View(model);

        }

        [HttpPost]
        public ActionResult MyCredit(double credit)
        {
            if (Session["UserData"] == null) { return RedirectToAction("Login"); }
            var userData = Session["UserData"] as User;

            UserAccountService.Instance.UpdateMyCredit(userData.Id, credit);

            dynamic model = new System.Dynamic.ExpandoObject();

            model.credit = UserAccountService.Instance.MyCredit(userData.Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteAd(int id)
        {
            if (Session["UserData"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            JsonResult json = new JsonResult
            {
                Data = UserProductService.Instance.DeleteAd(id) ? new {Success = true} : new {Success = false}
            };
            return json;
        }
        #endregion
    }



}