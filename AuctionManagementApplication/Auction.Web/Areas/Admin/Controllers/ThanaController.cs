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
            var districts = DistrictService.Instance.GetAll();
            
            return PartialView("_Create",districts);
        }

        [HttpPost]
        public ActionResult Create(Thana thana)
        {
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
            var thana = ThanaService.Instance.GetById(id);
            return PartialView("_Edit", thana);
        }

        [HttpPost]
        public ActionResult Edit(Thana thana)
        {
            JsonResult json = new JsonResult();

            if (ModelState.IsValid)
            {
                json.Data = ThanaService.Instance.Update(thana) ? new { Success = true } : new { Success = false };
            }

            return json;
        }

        public ActionResult Delete(int id)
        {
            JsonResult json = new JsonResult
            {
                Data = ThanaService.Instance.Delete(id) ? new { Success = true } : new { Success = false }
            };
            return json;
        }
    }
}