using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class RecruitmentUserController : Controller
    {
        private RpContext context = new RpContext();

        //
        // GET: /Administration/RecruitmentUser/

        public ActionResult Index()
        {
            return View(context.RecruitmentUsera.Where(o => o.Deleted == false).ToList());
        }

        //
        // GET: /Administration/RecruitmentUser/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = PopulateRecruitmentUserEditModel(id);


            model.ScreenType = ScreenType.Details;
            if (model.RecruitmentUser == null)
            {
                return HttpNotFound();
            }
            return View("Edit", model);
        }

        //
        // GET: /Administration/RecruitmentUser/Create

        public ActionResult Create()
        {
            var model = PopulateRecruitmentUserEditModel(-1);
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
                context.RecruitmentUsera.Add(model.RecruitmentUser);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        //
        // GET: /Administration/RecruitmentUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var model = PopulateRecruitmentUserEditModel(id);
            model.ScreenType = ScreenType.Edit;
            if (model.RecruitmentUser == null)
                return HttpNotFound();

            return View(model);
        }

        private RecruitmentUserEditModel PopulateRecruitmentUserEditModel(int id)
        {
            var model = new RecruitmentUserEditModel();
            var RecruitmentUser = context.RecruitmentUsera.FirstOrDefault(o => o.RecruitmentUserId == id);
            if (RecruitmentUser != null)
            {
                //Set Recruitment Company
                model.RecruitmentUser = RecruitmentUser;

                //Set List of Users
                model.RecruitmentUserItems = (from usr in RecruitmentUser.RecruitmentUsers
                                              select new RecruitmentUserItem()
                                              {
                                                  RecruitmentUserId = usr.RecruitmentUserId,
                                                  FirstName = usr.UserProfile.FirstName,
                                                  LastName = usr.UserProfile.LastName
                                              }).ToList();



            }
            //Set Ratings
            var ratingList = context.MetaKeyValues.Where(o => o.EntityType == "RecruitmentUser" && o.MetaType == "Rating");
            if (ratingList.Any())
            {
                foreach (var rating in ratingList)
                {
                    model.RatingsList.Add(new SelectListItem()
                    {
                        Text = rating.Value,
                        Value = rating.MetaKeyValueId.ToString()
                    });
                }
            }
            return model;
        }

        //
        // POST: /Administration/RecruitmentUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecruitmentUserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var RecruitmentUser = context.RecruitmentUsera.FirstOrDefault(o => o.RecruitmentUserId == model.RecruitmentUser.RecruitmentUserId);

                if (RecruitmentUser != null)
                {
                    RecruitmentUser.CompanyName = model.RecruitmentUser.CompanyName;
                    RecruitmentUser.Address1 = model.RecruitmentUser.Address1;
                    RecruitmentUser.Address2 = model.RecruitmentUser.Address2;
                    RecruitmentUser.Address3 = model.RecruitmentUser.Address3;
                    RecruitmentUser.Address4 = model.RecruitmentUser.Address4;
                    RecruitmentUser.City = model.RecruitmentUser.City;
                    RecruitmentUser.County = model.RecruitmentUser.County;
                    RecruitmentUser.Postcode = model.RecruitmentUser.Postcode;
                    RecruitmentUser.Telephone = model.RecruitmentUser.Telephone;
                    RecruitmentUser.EmailAddress = model.RecruitmentUser.EmailAddress;
                    RecruitmentUser.LogoUrl = model.RecruitmentUser.LogoUrl;
                    RecruitmentUser.Rating = model.RecruitmentUser.Rating;

                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Administration/RecruitmentUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecruitmentUser RecruitmentUser = context.RecruitmentUsera.Find(id);
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
            RecruitmentUser RecruitmentUser = context.RecruitmentUsera.Find(id);
            RecruitmentUser.Deleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
