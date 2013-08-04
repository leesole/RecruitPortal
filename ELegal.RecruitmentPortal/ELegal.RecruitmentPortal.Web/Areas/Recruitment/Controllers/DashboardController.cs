using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Areas.Recruitment.Controllers
{
    public class DashboardController : Controller
    {
        private RpContext context = new RpContext();
        //
        // GET: /Recruitment/Dashboard/

        public ActionResult Index()
        {
            var model = new ELegal.RecruitmentPortal.Web.Areas.Recruitment.ViewModels.Dashboard.IndexModel();

            var recruitmentUser = context.RecruitmentUsers.FirstOrDefault(o => o.UserProfile.UserName == User.Identity.Name);
            if (recruitmentUser != null) model.NumberOfCandidates = recruitmentUser.Candidates.Count;
            return View(model);
        }

    }
}
