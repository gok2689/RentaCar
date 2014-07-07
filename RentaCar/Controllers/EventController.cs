using RentaCar.Models;
using RentaCarBll;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class EventController : BaseController
    {
        EventManager _manager = new EventManager();
        VehicleManager _vehicleManager = new VehicleManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateEvent(Event model)
        {
            if (ModelState.IsValid)
            {

                _manager.Add(model);
                RedirectToAction("Info", "Event");
              
            }

            return View("Index", model);
        }
      
        [HttpPost]
        public PartialViewResult Filtre(string searchText)
        {
            List<Vehicle> _vehicles= _vehicleManager.Filtre(searchText);
            VehicleModel vehicleModel = new VehicleModel();
            vehicleModel.Vehicles = _vehicles;

            return PartialView(vehicleModel);

        }
        [HttpGet]
        public ActionResult Rezervasyon(int vehicleId)
        {
           
            return View();

        }
        [HttpPost]
        public ActionResult RezervasyonYap(Event model, int vehicleId)
        {
            if (ModelState.IsValid)
            {
                model.VehicleId = vehicleId;
                model.MemberId = Convert.ToInt32(Session["KulId"].ToString());
            
             

                _manager.Add(model);
                ViewBag.Bildiri = "İşleminiz Onay için beklemektedir Bilgileriniz Mail Adressinize gönderilecektir ";
               
            }
            
            return RedirectToAction("UserIndex", "Member");



        }

    }
}
