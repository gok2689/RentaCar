
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
            return RedirectToAction("GetMember");
        }
        [HttpPost]
        public ActionResult DeleteMember(int Id)
        {
            
            
                _MemberManager.Delete(Id);
            
            return RedirectToAction("GetMember");
        }
        [HttpGet]
        public ActionResult GetBranch()
        {
            return View(_branchManager.Getall().ToList());
        }
        [HttpGet]
        public ActionResult GetCreateBranch()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEditBranch(int Id)
        {
            return View(_branchManager.Get(Id));
        }
        [HttpGet]
        public ActionResult GetDeleteBranch(int Id)
        {
            _branchManager.Get(Id);
            return View("DeleteBranch");
        }
        
        [HttpPost]
        public ActionResult EditBranch(Branch item)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Update(item);
            }
            return RedirectToAction("GetBranch");
        }

        [HttpPost]
        public ActionResult CreateBranch(Branch item)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Add(item);
            }
            return RedirectToAction("GetBranch");
        }
        [HttpPost]
        public ActionResult DeleteBranch(int Id)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Delete(Id);
            } 
            
            return RedirectToAction("GetBranch");
        }
        [HttpGet]
        public ActionResult GetBrand()
        {
            return View(_brandManager.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult GetCreateBrand()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEditBrand(int Id)
        {
            return View(_brandManager.Get(Id));
        }
        [HttpGet]
        public ActionResult GetDeleteBrand(int Id)
        {
            _brandManager.Get(Id);
            return View("DeleteBrand");
        }

        [HttpPost]
        public ActionResult EditBranch(Brand item)
        {
            if (ModelState.IsValid)
            {
                _brandManager.Update(item);
            }
            return RedirectToAction("GetBrand");
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand item)
        {
            if (ModelState.IsValid)
            {
                _brandManager.Add(item);
            }
            return RedirectToAction("GetBrand");
        }
        [HttpPost]
        public ActionResult DeleteBrand(int Id)
        {
           
            
                _brandManager.Delete(Id);
            
            return RedirectToAction("GetBrand");
        }
    }
}
