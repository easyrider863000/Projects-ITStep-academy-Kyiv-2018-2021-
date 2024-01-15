using DAL_Paggination;
using DAL_Paggination.Models;
using DAL_Paggination.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Owin;
//using Microsoft.Owin.Host.SystemWeb;

using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DZ.Models;

namespace DZ.Controllers
{
    public class AuthController : Controller
    {
        public PartialViewResult Index(string TableName)
        {
            return PartialView("Login", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Login([Bind(Include = "Email,Password")] LoginModel obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Email == "admin@gmail.com" && obj.Password == "admin")
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,"Admin"),
                        new Claim(ClaimTypes.Email, "admin@gmail.com")
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                    var context = Request.GetOwinContext();
                    var authManager = context.Authentication;
                    authManager.SignIn(identity);

                    ViewBag.PageCount = (int)Math.Ceiling(new GoodRepository().GetAll().Count() / 6.0);
                    return PartialView($"../Home/TableGoods", GetGoods());
                }
            }
            ModelState.AddModelError("", "Email or password is not correct");
            return PartialView("Login", obj);
        }
        
        public List<Good> GetGoods()
        {
            GoodRepository repo = new GoodRepository();
            return repo.GetAll()
                        .Skip((0) * 6)
                         .Take(6)
                          .ToList();
        }
    }
}