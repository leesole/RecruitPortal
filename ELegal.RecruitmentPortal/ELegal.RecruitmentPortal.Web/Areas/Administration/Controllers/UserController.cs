using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        private RpContext context = new RpContext();
        //
        // GET: /Administration/User/

        public ActionResult Index()
        {
            var model = context.UserProfile.ToList();

            return View(model);
        }





        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
