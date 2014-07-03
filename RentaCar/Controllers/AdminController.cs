
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
            return View(new Event() 
            { StartDate = DateTime.Now, EndDate = DateTime.Now });
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
        [HttpGet]
        public ActionResult GetCreateVehicle()
        {  
                return View("CreateVehicle");
        }

        [HttpPost]
        public ActionResult CreateVehicle(Vehicle item)
        {
            if (ModelState.IsValid)
            {
                _VehcileManager.Add(item);
                ViewBag.Result = "Kayıt başarıyla eklendi.";
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetEditVehicle(int id)
        {
            return View(_VehcileManager.Get(id));
        }

        [HttpPost]
        public ActionResult EditVehcile(Vehicle it)
        {
            if (ModelState.IsValid)
            {
               
                _VehcileManager.Update(it);

                ViewBag.Result = "Kayıt güncellendi";
                
            }
            return RedirectToAction("Index");
        }

       public ActionResult GetMember()
        {
            return View(_MemberManager.GetAll().ToList());

        }



    }
}
