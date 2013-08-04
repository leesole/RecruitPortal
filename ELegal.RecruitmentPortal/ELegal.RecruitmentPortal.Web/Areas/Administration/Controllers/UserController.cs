using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Web.Areas.Administration.ViewModels.User;
using ELegal.RecruitmentPortal.Web.Models;
using WebMatrix.WebData;

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

        public ActionResult Create(int id = 0)
        {
            var model = PopulateUserEditModel(-1);
            model.ScreenType = ScreenType.Create;

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                WebSecurity.CreateUserAndAccount(model.UserProfile.UserName, "Password");
                Roles.AddUsersToRoles(new[] {model.UserProfile.UserName}, new[] {"Administration"});
                var userProfile = context.UserProfile.FirstOrDefault(o => o.UserName == model.UserProfile.UserName);
                if (userProfile != null)
                {
                    userProfile.FirstName = model.UserProfile.FirstName;
                    userProfile.LastName = model.UserProfile.LastName;

                }
                context.SaveChanges();
                return RedirectToAction("Index", "User", new {area = "Administration"});
            }
            else
            {
                return View("Edit", model);
            }
        }












        private UserEditModel PopulateUserEditModel(int id)
        {
            var model = new UserEditModel();
            var userProfile = context.UserProfile.FirstOrDefault(o => o.UserId == id);
            if (userProfile != null){
                model.UserProfile = userProfile;
                model.CurrentRoles = userProfile.Roles.ToList();
            }
            model.Roles = context.Role.Select(o => o).ToList();
            return model;
        }


        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
