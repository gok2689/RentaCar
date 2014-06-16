
using RentaCarBll;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class AdminController : BaseController
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adminmi(Member tip)
        {

           
            MemberManager _manager =new MemberManager();
            var kultip = tip.Type.Equals(0);
            if (kultip)
            {
                return View("Index", tip);
            }
           
            ViewBag.Mesaj = "Admin hoşgeldin";
            return RedirectToAction("Index", "Login");
        
        
        }

    }
}
