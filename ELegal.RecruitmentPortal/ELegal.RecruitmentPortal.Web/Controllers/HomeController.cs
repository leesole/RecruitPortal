﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELegal.RecruitmentPortal.Web.Controllers
{
    public class HomeController :Controller
    {
       
        public ActionResult Index()
        {
            var user = User.Identity;
            if (User.IsInRole("Administration"))
             return RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            //if (HttpContext.User.IsInRole("Recruitment"))
            //    return RedirectToAction("Index", "Dashboard", new { area = "Recruitment" });
            //if (HttpContext.User.IsInRole("HR"))
            //    return RedirectToAction("Index", "Dashboard", new { area = "HR" });
            return View();
           
        }

        
    }
}
