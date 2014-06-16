using RentaCar.Controllers;
using RentaCar.Models;
using RentaCarEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaCarBll;



namespace RentaCar.Functions
{
    public class Permissons : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          
           
            if (HttpContext.Current.Session["Permission"].ToString() == ((int)Enums.UserTypes.Admin).ToString())
            {
                filterContext.Result = new EmptyResult();
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
               
            }
            base.OnActionExecuting(filterContext);
        }
    }
}