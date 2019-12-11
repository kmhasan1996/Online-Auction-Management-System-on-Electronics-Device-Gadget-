using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class DistrictController : Controller
    {
        // GET: Admin/Address
        public ActionResult Index()
        {
            var districts = DistrictService.Instance.GetAll();
            return View(districts);
        }

        public bool UniqueName(District district)
        {
            return DistrictService.Instance.UniqueName(district);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(District district)
        {
            JsonResult json = new JsonResult();
            if (ModelState.IsValid)
            {
                json.Data = DistrictService.Instance.Add(district) ? new {Success = true} : new {Success = false};

            }

            return json;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var district = DistrictService.Instance.GetById(id);
            return PartialView("_Edit", district);
        }

        [HttpPost]
        public ActionResult Edit(District district)
        {
            JsonResult json=new JsonResult();

            if (ModelState.IsValid)
            {
                json.Data = DistrictService.Instance.Update(district) ? new {Success = true} : new {Success = false};
            }

            return json;
        }

        public ActionResult Delete(int id)
        {
            JsonResult json = new JsonResult
            {
                Data = DistrictService.Instance.Delete(id) ? new { Success = true } : new { Success = false }
            };
            return json;
        }

    }
}