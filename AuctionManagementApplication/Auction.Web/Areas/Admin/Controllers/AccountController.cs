using System;
using System.Linq;
using System.Web.Mvc;
using Auction.Database;
using Auction.Entities;
using Auction.Web.Areas.Admin.Models;

namespace Auction.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel loginViewModel=new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AuctionDbContext())
                {
                    var admin = context.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                    if ( admin != null)
                    {
                        //Session["FirstName"] = context.Admins.FirstOrDefault(x => x.Email == model.Email).FirstName;
                        //Session["ID"] = context.Admins.FirstOrDefault(x => x.Email == model.Email).Id;
                        Session["AdminData"] = admin;
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Email or Password is not valid");
                        return View();
                    }
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                using (var context = new AuctionDbContext())
                {
                    if (context.Admins.Any(x => x.Email == model.Email))
                    {
                        ModelState.AddModelError("EmailError", "Email address is already exits!");
                        return View();

                    }
                    else
                    {
                        if (model.Code == "12345")
                        {
                            Entities.Admin admin = new Entities.Admin
                            {
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                Email = model.Email,
                                Password = model.Password,

                            };

                            context.Admins.Add(admin);
                            context.SaveChanges();
                            return RedirectToAction("Login");
                            //return View();
                        }
                        else
                        {
                            ModelState.AddModelError("CodeError", "Code is not correct");

                            return View();
                        }

                        
                    }
                }

            }
        }

        public ActionResult Logout()
        {
            //Session.Abandon();

            Session["AdminData"] = null;

            return RedirectToAction("Login", "Account");
        }

    }
}