using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Entities;
using Auction.Services.Admin;
using Auction.Services.UserAccountService;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class UserAccountController : Controller
    {
        public ActionResult Index()
        {
            var allUsers = UserAccountService.Instance.GetAllUsers();
                //.Select(x => new { x.Id, x.FirstName, x.LastName, x.Email, x.IsActive }).ToList();
            return View(allUsers);
        }
        

        [HttpPost]
        public ActionResult Edit(int userId)
        {
            JsonResult json = new JsonResult
            {
                Data = UserAccountService.Instance.Update(userId) ? new {Success = true} : new {Success = false}
            };


            return json;
        }

       
    }
}