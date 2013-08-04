﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class RecruitmentUserController : Controller
    {
        private RpContext context = new RpContext();

//        //
//        // GET: /Administration/RecruitmentCompany/

//        public ActionResult Index()
//        {
//            return View(context.RecruitmentUsers.Where(o => o.Deleted == false).ToList());
//        }

//        //
//        // GET: /Administration/RecruitmentCompany/Details/5

//        public ActionResult Details(int id = 0)
//        {
//            ////Re recruitmentcompany = context.RecruitmentCompanies.Find(id);
//            //if (recruitmentcompany == null)
//            //{
//            //    return HttpNotFound();
//            //}
//            return View();
//        }

//        //
//        // GET: /Administration/RecruitmentCompany/Create

        public ActionResult Create()
        {
            return View();
        }

//        //
//        // POST: /Administration/RecruitmentCompany/Create

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(RecruitmentCompany recruitmentcompany)
//        {
//            if (ModelState.IsValid)
//            {
//                context.RecruitmentCompanies.Add(recruitmentcompany);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(recruitmentcompany);
//        }

//        //
//        // GET: /Administration/RecruitmentCompany/Edit/5

//        public ActionResult Edit(int id = 0)
//        {
//            var model = new RecruitmentCompanyEditModel();
//            var recruitmentCompany = context.RecruitmentCompanies.FirstOrDefault(o => o.RecruitmentCompanyId == id);
//            if (recruitmentCompany != null)
//            {
//                //Set Recruitment Company
//                model.RecruitmentCompany = recruitmentCompany;

//                //Set List of Users
//                model.RecruitmentUserItems = (from usr in recruitmentCompany.RecruitmentUsers
//                                              select new RecruitmentUserItem()
//                                              {
//                                                  RecruitmentUserId = usr.RecruitmentUserId,
//                                                  FirstName = usr.UserProfile.FirstName,
//                                                  LastName = usr.UserProfile.LastName
//                                              }).ToList();




//                //Set Ratings
//                var ratingList = context.MetaKeyValues.Where(o => o.EntityType == "RecruitmentCompany" && o.MetaType == "Rating");
//                if (ratingList.Any())
//                {
//                    foreach (var rating in ratingList)
//                    {
//                        model.RatingsList.Add(new SelectListItem()
//                        {
//                            Text = rating.Value,
//                            Value = rating.MetaKeyValueId.ToString()
//                        });
//                    }
//                }
//            }
//            return View(model);
//        }

//        //
//        // POST: /Administration/RecruitmentCompany/Edit/5

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(RecruitmentCompanyEditModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var recruitmentCompany = context.RecruitmentCompanies.FirstOrDefault(o => o.RecruitmentCompanyId == model.RecruitmentCompany.RecruitmentCompanyId);

//                if (recruitmentCompany != null)
//                {
//                    recruitmentCompany.CompanyName = model.RecruitmentCompany.CompanyName;
//                    recruitmentCompany.Address1 = model.RecruitmentCompany.Address1;
//                    recruitmentCompany.Address2 = model.RecruitmentCompany.Address2;
//                    recruitmentCompany.Address3 = model.RecruitmentCompany.Address3;
//                    recruitmentCompany.Address4 = model.RecruitmentCompany.Address4;
//                    recruitmentCompany.City = model.RecruitmentCompany.City;
//                    recruitmentCompany.County = model.RecruitmentCompany.County;
//                    recruitmentCompany.Postcode = model.RecruitmentCompany.Postcode;
//                    recruitmentCompany.Telephone = model.RecruitmentCompany.Telephone;
//                    recruitmentCompany.EmailAddress = model.RecruitmentCompany.EmailAddress;
//                    recruitmentCompany.LogoUrl = model.RecruitmentCompany.LogoUrl;
//                    recruitmentCompany.Rating = model.RecruitmentCompany.Rating;

//                    context.SaveChanges();
//                }
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        //
//        // GET: /Administration/RecruitmentCompany/Delete/5

//        public ActionResult Delete(int id = 0)
//        {
//            RecruitmentCompany recruitmentcompany = context.RecruitmentCompanies.Find(id);
//            if (recruitmentcompany == null)
//            {
//                return HttpNotFound();
//            }
//            return View(recruitmentcompany);
//        }

//        //
//        // POST: /Administration/RecruitmentCompany/Delete/5

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            RecruitmentCompany recruitmentcompany = context.RecruitmentCompanies.Find(id);
//            recruitmentcompany.Deleted = true;
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}