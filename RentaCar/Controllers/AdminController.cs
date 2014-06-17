
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

        [RentaCar.Functions.Permissons]
        public ActionResult Index()
        {
            return View();
        }

       

    }
}
