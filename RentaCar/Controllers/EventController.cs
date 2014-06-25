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
                  ViewBag.Result = "İşleminiz gerçekleişyor Bilgileriniz Mail adressinize gönderilecektir";
            }
           
           return View("Index", model);
        }
        [HttpGet]
        public ViewResult Info(Event model)
        {
            return View();
        
        
        }
        [HttpPost]
        public PartialViewResult Filtre(string searchText)
        {
            return PartialView(_vehicleManager.Filtre(searchText));

        }
        [HttpGet]
        public ViewResult Rezervasyon()
        {
            return View();
        
        }

    }
}
