using System;
using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.User;
using Auction.Services.UserAccountService;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        public ActionResult Index()
        {
            var userData = Session["UserData"] as User;

            TestimonialViewModel model = new TestimonialViewModel();
            if (userData != null)
            {
                model.User = userData;
            }
            else
            {
                model.User = null;
            }
           
            model.FeaturedCategories = UserCategoryService.Instance.GetFeaturedNotNullItemCategory();
            model.Testimonials = TestimonialService.Instance.GetAllTestimonials();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Testimonial model)
        {
            if (Session["UserData"] == null) { return RedirectToAction("Login", "User"); }
            var userData = Session["UserData"] as User;
            model.DateTime=DateTime.Now;
            model.UserId = userData.Id;
            JsonResult json = new JsonResult
            {
                Data = TestimonialService.Instance.Add(model)?new {Success=true}:new {Success=false}
            };
            return json;
        }


    }
}