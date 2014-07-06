
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
        BrandManager _brandManager = new BrandManager();
        BranchManager _branchManager = new BranchManager();
        MemberManager _MemberManager = new MemberManager();

        [RentaCar.Functions.Permissons]
        public ActionResult Index()
        {
            return View(new Event() { StartDate = DateTime.Now, EndDate = DateTime.Now });
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
            ViewData["Brands"] = GetBrandsSelectList();
            ViewData["Branchs"] = GetBranchsSelectList();
            return View("CreateVehicle");
        }
        public IEnumerable<SelectListItem> GetBranchsSelectList()
        {
            List<SelectListItem> SelectList = (from b in _branchManager.Getall()
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = b.Name,
                                                   Value = b.Id.ToString()
                                               }).ToList();

            return SelectList;

        }
        public IEnumerable<SelectListItem> GetBrandsSelectList()
        {
            List<SelectListItem> SelectList = (from b in _brandManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = b.Name,
                                                   Value = b.Id.ToString()
                                               }).ToList();

            return SelectList;

        }

        [HttpPost]
        public ActionResult CreateVehicle(Vehicle item)
        {
            ViewData["Brands"] = GetBrandsSelectList();
            ViewData["Branchs"] = GetBranchsSelectList();
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
        public ActionResult EditVehcile(Vehicle item)
        {
            if (ModelState.IsValid)
            {

                _VehcileManager.Update(item);

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
