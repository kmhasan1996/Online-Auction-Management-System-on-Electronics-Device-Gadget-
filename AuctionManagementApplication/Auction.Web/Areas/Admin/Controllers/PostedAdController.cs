using System.Web.Mvc;
using Auction.Services.Admin;
using Auction.Services.UserAccountService;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class PostedAdController : Controller
    {
        // GET: Admin/PostedAd
        public ActionResult Index()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var allPostedAd = PostedAdService.Instance.GetAllPostedAd();
            return View(allPostedAd);
        }
        public ActionResult PendingAds()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var allPostedAd = PostedAdService.Instance.GetAllPendingAds();
            return View(allPostedAd);
        }
        public ActionResult RejectedAds()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var allPostedAd = PostedAdService.Instance.GetAllRejectedAds();
            return View(allPostedAd);
        }

        [HttpPost]
        public ActionResult ActivateDeactivatePostedAd(int postId)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult
            {
                Data = PostedAdService.Instance.ActivateDeactivatePostedAd(postId)
                    ? new {Success = true}
                    : new {Success = false}
            };


            return json;
        }

        [HttpPost]
        public ActionResult AcceptPostedAd(int postId)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult
            {
                Data = PostedAdService.Instance.AcceptPostedAd(postId)
                    ? new {Success = true}
                    : new {Success = false}
            };


            return json;
        }

        [HttpPost]
        public ActionResult RejectPostedAd(int postId)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult
            {
                Data = PostedAdService.Instance.RejectPostedAd(postId)
                    ? new {Success = true}
                    : new {Success = false}
            };


            return json;
        }

        [HttpGet]
        public ActionResult GetPostedAdById(int productId)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var product = PostedAdService.Instance.GetPostedAdById(productId);
            return PartialView("_ViewAndUpdate", product);
        }

        public ActionResult UserDetails(int userId)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var user = UserAccountService.Instance.GetUserById(userId);

            return PartialView("_UserDetails", user);
        }
    }
}