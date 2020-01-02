using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class ThanaController : Controller
    {
        // GET: Admin/Thana
        public ActionResult Index()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var thanas = ThanaService.Instance.GetAll();
            return View(thanas);
        }

        public bool UniqueName(Thana thana)
        {
           
            return ThanaService.Instance.UniqueName(thana);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var districts = DistrictService.Instance.GetAll();
            
            return PartialView("_Create",districts);
        }

        [HttpPost]
        public ActionResult Create(Thana thana)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult();
            if (ModelState.IsValid)
            {
                json.Data = ThanaService.Instance.Add(thana) ? new { Success = true } : new { Success = false };

            }

            return json;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var thana = ThanaService.Instance.GetById(id);
            return PartialView("_Edit", thana);
        }

        [HttpPost]
        public ActionResult Edit(Thana thana)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult();

            if (ModelState.IsValid)
            {
                json.Data = ThanaService.Instance.Update(thana) ? new { Success = true } : new { Success = false };
            }

            return json;
        }

        public ActionResult Delete(int id)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult json = new JsonResult
            {
                Data = ThanaService.Instance.Delete(id) ? new { Success = true } : new { Success = false }
            };
            return json;
        }
    }
}