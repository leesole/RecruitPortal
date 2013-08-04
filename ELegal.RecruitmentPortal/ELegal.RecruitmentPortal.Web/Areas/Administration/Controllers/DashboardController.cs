using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Administration/Dashboard/
        private RpContext context = new RpContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            var model = new ViewModels.Dashboard.IndexModel();

            model.NumberOfRecuitmentCompanies = (context.RecruitmentCompanies.Where(c => !c.Deleted).Select(c => c)).Count();
            model.NumberOfUsers = (from c in context.UserProfile
                                   select c.UserName).Count();

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
