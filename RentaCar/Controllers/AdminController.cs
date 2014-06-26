
using RentaCarBll;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentaCar.Controllers
{
    public class AdminController : BaseController
    {
        VehicleManager _VehcileManager = new VehicleManager();
        MemberManager _MemberManager = new MemberManager();

        [RentaCar.Functions.Permissons]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogoutAdmin()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetVehicle()
        {
            return View(_VehcileManager.GetAll().ToList());
        
        }
       public ActionResult GetMember()
        {
            return View(_MemberManager.GetAll().ToList());

        }

    }
}
