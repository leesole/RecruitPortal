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
            var model = new ViewModels.Dashboard.IndexModel();

            model.NumberOfRecuitmentCompanies = (context.RecruitmentCompanies.Select(c => c)).Count();
            

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
