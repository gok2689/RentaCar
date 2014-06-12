using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCarBll;

namespace RentaCar.Controllers
{
    public class MemberController : BaseController
    {
       MemberManager _manager =new MemberManager();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            if (ModelState.IsValid)
            {
                _manager.Add(member);
                ViewBag.Result = "Kayıdınız yapıldı";
            }

            return RedirectToAction("Index", "Home");
        
        
        }

    }
}
