﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Aboutus()
        {
            return View();
        
        }

        public ViewResult Contact()
        {
            return View();
        }

        

    }
}
