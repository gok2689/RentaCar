
using RentaCarBll;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail; 
using System.Net.Security;
using System.Net.Sockets;
using RentaCar.Models;

namespace RentaCar.Controllers
{
    public class AdminController : BaseController
    {
        VehicleManager _VehcileManager = new VehicleManager();
        BrandManager _brandManager = new BrandManager();
        BranchManager _branchManager = new BranchManager();
        MemberManager _MemberManager = new MemberManager();
        EventManager _eventManager = new EventManager();

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
        public IEnumerable<SelectListItem> GetEmailsSelectList()
        {
            List<SelectListItem> SelectList = (from m in _eventManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Selected = false,
                                                   Text = m._kulEmail,
                                                   Value = m.Id.ToString()
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
        [HttpGet]
        public ActionResult GetEvent()
        {
            return View(_eventManager.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult GetEditEvent(int Id)
        {
            ViewData["Members"] = GetEmailsSelectList();
            return View(_eventManager.Get(Id));
        }
        [HttpPost]
        public ActionResult EditEvent(Event item)
        {
            

            
            if (ModelState.IsValid)
            {
                
                MailMessage Mesaj = new MailMessage();
               
                try
                {
                    var member = _MemberManager.Get(item.MemberId);
                    var vehicle = _VehcileManager.Get(item.VehicleId);
                    TimeSpan fark = item.EndDate- item.StartDate;
                    decimal totalPrice = Convert.ToDecimal(fark.Days) * vehicle.PricePerDay;
                    TcpClient Tcpclient = new TcpClient();
                    Tcpclient.Connect("pop.gmail.com", 995);       
                    SslStream Guvenlik = new SslStream(Tcpclient.GetStream());
                    Guvenlik.AuthenticateAsClient("pop.gmail.com");
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("goktug.dulkan@gmail.com");
                    mail.To.Add(member.Email);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Bilgi"; mail.Body = "Sayın <strong>"+member.NameSurName+"</strong>, kiralama talebinde bulunduğunuz <strong>"+vehicle.Plate+"</strong> plakalı <strong>"+vehicle.Model+"</strong> marka araç onaylanmıştır.Aracı <strong>"+item.EndDate.ToShortDateString()+"</strong> tarihine kadar teslim etmeniz gerekmektedir.Göstermiş olduğunuz ilgi için teşekkür ederiz.Ücretiniz "+totalPrice.ToString("0.00")+" TL'dir.<br/>İyi günler...";
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("gdulkan@gmail.com",
                          "goktugdulkan");
                          
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                
            }
            return RedirectToAction("GetEvent");
        }
        [HttpGet]
        public ActionResult GetDeleteEvent(int Id)
        {
            return View( _eventManager.Get(Id));
        }
        [HttpPost]
        public ActionResult DeleteEvent(int Id)
        {
            if (ModelState.IsValid)
            {
                _eventManager.Delete(Id);
            }
            return RedirectToAction("GetEvent");
        }
    }
}
