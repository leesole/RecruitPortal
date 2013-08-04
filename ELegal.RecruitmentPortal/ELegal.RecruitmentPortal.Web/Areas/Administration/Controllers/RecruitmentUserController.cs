using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;
using ELegal.RecruitmentPortal.Web.Areas.Administration.ViewModels.RecruitmentUser;
using ELegal.RecruitmentPortal.Web.Models;
using WebMatrix.WebData;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class RecruitmentUserController : Controller
    {
        private RpContext context = new RpContext();

        ////
        //// GET: /Administration/RecruitmentUser/

        //public ActionResult Index()
        //{
        //    return View(context.RecruitmentUsers.Where(o => o.Deleted == false).ToList());
        //}

        //
        // GET: /Administration/RecruitmentUser/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = PopulateRecruitmentUserEditModel(id);
            model.ScreenType = ScreenType.Details;
            if (model.UserName == null)
            {
                return HttpNotFound();
            }
            return View("Edit", model);
        }

        //
        // GET: /Administration/RecruitmentUser/Create

        public ActionResult Create(int id = 0)
        {
            var model = PopulateRecruitmentUserEditModel(-1);

            model.RecruitmentCompanyId = id;
            //Set Company If passed

            var recruitmentCompany = context.RecruitmentCompanies.FirstOrDefault(o => o.RecruitmentCompanyId == id);
            if (recruitmentCompany != null) model.CompanyName = recruitmentCompany.CompanyName;

            model.ScreenType = ScreenType.Create;

            return View("Edit", model);
        }

        //
        // POST: /Administration/RecruitmentUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecruitmentUserEditModel model)
        {
            if (ModelState.IsValid)
            {
                WebSecurity.CreateUserAndAccount(model.UserName, "Password");
                Roles.AddUsersToRoles(new[] { model.UserName }, new[] { "Recruitment" });
                
                var recruitmentUser = new RecruitmentUser();
               
                recruitmentUser.MobileNumber = model.MobileNumber;
                recruitmentUser.TelephoneNumber = model.TelephoneNumber;

                context.RecruitmentUsers.Add(recruitmentUser);
                context.SaveChanges();
                
                //Add to User Profile
                var userProfile = context.UserProfile.FirstOrDefault(o => o.UserName == model.UserName);
                if (userProfile != null)
                {
                    userProfile.FirstName = model.FirstName;
                    userProfile.LastName = model.LastName;
                    recruitmentUser.UserProfile = userProfile;
                }

                //Add to Company
                var recruitmentCompany = context.RecruitmentCompanies.FirstOrDefault(o => o.RecruitmentCompanyId == model.RecruitmentCompanyId);
                if (recruitmentCompany != null) recruitmentCompany.RecruitmentUsers.Add(recruitmentUser);
                
                context.SaveChanges();
                return RedirectToAction("Edit","RecruitmentCompany", new { area = "Administration", id=model.RecruitmentCompanyId});
            }

            return View("Edit", model);
        }

        //
        // GET: /Administration/RecruitmentUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var model = PopulateRecruitmentUserEditModel(id);
            model.ScreenType = ScreenType.Edit;
            if (model.UserName == null)
                return HttpNotFound();

            return View(model);
        }

        

        //
        // POST: /Administration/RecruitmentUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecruitmentUserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var recruitmentUser = context.RecruitmentUsers.FirstOrDefault(o => o.RecruitmentUserId == model.RecruitmentUserId);

                if (recruitmentUser != null)
                {
                    recruitmentUser.MobileNumber = model.MobileNumber;
                    recruitmentUser.UserProfile.FirstName = model.FirstName;
                    recruitmentUser.UserProfile.LastName = model.LastName;
                    recruitmentUser.TelephoneNumber = model.TelephoneNumber;

                    context.SaveChanges();
                }
                return RedirectToAction("Edit", "RecruitmentCompany", new { area = "Administration", id = model.RecruitmentCompanyId });
            }
            return View(model);
        }

        //
        // GET: /Administration/RecruitmentUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecruitmentUser RecruitmentUser = context.RecruitmentUsers.Find(id);
            if (RecruitmentUser == null)
            {
                return HttpNotFound();
            }
            return View(RecruitmentUser);
        }

        //
        // POST: /Administration/RecruitmentUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruitmentUser RecruitmentUser = context.RecruitmentUsers.Find(id);
            RecruitmentUser.Deleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        private RecruitmentUserEditModel PopulateRecruitmentUserEditModel(int id)
        {
            var model = new RecruitmentUserEditModel();
            var recruitmentUser = context.RecruitmentUsers.FirstOrDefault(o => o.RecruitmentUserId == id);
            if (recruitmentUser != null)
            {
                //Set Recruitment Company
                model.RecruitmentUserId = recruitmentUser.RecruitmentUserId;
                model.UserName = recruitmentUser.UserProfile.UserName;
                model.FirstName = recruitmentUser.UserProfile.FirstName;
                model.LastName = recruitmentUser.UserProfile.LastName;
                model.MobileNumber = recruitmentUser.MobileNumber;
                model.TelephoneNumber = recruitmentUser.TelephoneNumber;
                model.RecruitmentCompanyId = recruitmentUser.RecruitmentCompany.RecruitmentCompanyId;
                model.CompanyName = recruitmentUser.RecruitmentCompany.CompanyName;
            }

            return model;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
