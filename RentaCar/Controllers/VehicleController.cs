﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentaCar.Controllers
{
    public class VehicleController : BaseController
    {
        //
        // GET: /Vehicle/

        public ActionResult Index()
        {
            return View();
        }

    }
}
