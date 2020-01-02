using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login","Account"); }
            var categories = CategoryService.Instance.GetAllCategory();
            return View(categories);
        }

        public bool UniqueName(Category category)
        {
            return CategoryService.Instance.UniqueName(category);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            Category model=new Category();
            return PartialView("_Create", model);

        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult jason = new JsonResult();

            if (ModelState.IsValid)
            {
                jason.Data = CategoryService.Instance.Create(category) ? new { Success = true, Message = "Saved Successfully" } : new { Success = false, Message = "Unable to Save" };
            }


            return jason;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            var category = CategoryService.Instance.GetCategoryById(id);
            return PartialView("_Edit", category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            JsonResult jason = new JsonResult();
            //var existingCategory = CategoryService.Instance.GetCategoryById(category.Id);
            //existingCategory.Name = category.Name;
            //existingCategory.ImageUrl = category.ImageUrl;
            //existingCategory.IsActive = category.IsActive;

            if (ModelState.IsValid)
            {
                jason.Data = CategoryService.Instance.Update(category) ? new { Success = true, Message = "Updated Successfully" } : new { Success = true, Message = "Unable to Update" };
            }


            return jason;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (Session["AdminData"] == null) { return RedirectToAction("Login", "Account"); }
            CategoryService.Instance.Delete(id);
            return RedirectToAction("Index");
        }
    }
}