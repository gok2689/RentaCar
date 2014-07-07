
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
            return View();
        }

        public ActionResult LogoutAdmin()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [RentaCar.Functions.Permissons]
        public ActionResult GetVehicle()
        {
            return View(_VehcileManager.GetAll().ToList());

        }
        [RentaCar.Functions.Permissons]
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
        [RentaCar.Functions.Permissons]
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
        [RentaCar.Functions.Permissons]
        [HttpGet]
        public ActionResult GetEditVehicle(int id)
        {
            ViewData["Brands"] = GetBrandsSelectList();
            ViewData["Branchs"] = GetBranchsSelectList();
            return View(_VehcileManager.Get(id));
        }
        [RentaCar.Functions.Permissons]
        [HttpPost]
        public ActionResult EditVehcile(Vehicle item)
        {
            ViewData["Brands"] = GetBrandsSelectList();
            ViewData["Branchs"] = GetBranchsSelectList();
            if (ModelState.IsValid)
            {

                _VehcileManager.Update(item);

                ViewBag.Result = "Kayıt güncellendi";

            }
            return RedirectToAction("Index");
        }

        public ActionResult GetDeleteVehicle(int Id)
        {
            _VehcileManager.Get(Id);
            return View("DeleteVehicle");

        }

        public ActionResult DeleteVehicle(int Id)
        {
            if (ModelState.IsValid)
            {
                _VehcileManager.Delete(Id);
                
                
            }
            
            return RedirectToAction("Index");
        
        }
        [RentaCar.Functions.Permissons]
        [HttpGet]
        public ActionResult GetMember()
        {
            return View(_MemberManager.GetAll().ToList());

        }
        [RentaCar.Functions.Permissons]
        [HttpGet]
        public ActionResult GetCreateMember()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEditMember(int Id)
        {
            return View(_MemberManager.Get(Id));
        }
        [HttpGet]
        public ActionResult GetDeleteMember(int Id)
        {
            _MemberManager.Get(Id);
            return View("DeleteMember");
        }

        
        [HttpPost]
        public ActionResult EditMember(Member item)
        {
            if (ModelState.IsValid)
            {
                _MemberManager.Update(item);
            }
            return RedirectToAction("GetMember");
        }
        [RentaCar.Functions.Permissons]
        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            if (ModelState.IsValid)
            {
                _MemberManager.Add(member);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteMember(int Id)
        {
            if (ModelState.IsValid)
            {
                _MemberManager.Delete(Id);
            }
            return RedirectToAction("GetMember");
        }
    }
}
