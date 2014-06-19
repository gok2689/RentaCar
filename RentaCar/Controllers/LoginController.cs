using RentaCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCarEntities;
using RentaCarBll;
using System.Web.Security;

namespace RentaCar.Controllers
{
    public class LoginController : BaseController
    {

        MemberManager _manager = new MemberManager();
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(Member kullanici)
        {
            if (ModelState.IsValid)
            {
                var result = _manager.IsLogin
                    (kullanici.Email,
                    kullanici.Password);

                
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Email, true);
                    Session["UserName"] = kullanici.Email;
                    return RedirectToAction("UserIndex", "Member");

                }

                ViewBag.ErrorMessage = "Hatalı Email veya parola";
            }
            return View("Login", kullanici);
        }

        

    }
}
