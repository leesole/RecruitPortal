using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Model;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Web.Areas.Recruitment.ViewModels.Candidate;

namespace ELegal.RecruitmentPortal.Web.Areas.Recruitment.Controllers
{
    public class CandidateController : Controller
    {
        private RpContext context = new RpContext();

        //
        // GET: /Recruitment/Candidate/

        public ActionResult Index()
        {
            var model = new ViewModels.Candidate.IndexModel();

            var candidateQuery = from c in context.Candidates
                                 select new
                                     {
                                         c.FirstName,
                                         c.LastName,
                                         c.UpdatedDate
                                     };
            foreach (var candidate in candidateQuery)
            {
                model.CandidateItems.Add(new CandidateItem()
                    {
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        UpdateDate = candidate.UpdatedDate
                    });
            }


            return View(model);
        }

        //public ActionResult Create()
        //{
        //    var model = new EditCandidate();

        //    return View("Edit",model);
        //}

        ////
        //// POST: /Recruitment/Candidate/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(EditCandidate candidate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Candidates.Add(candidate);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(candidate);
        //}

        //////
        ////// GET: /Recruitment/Candidate/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidate);
        //}

        ////
        //// POST: /Recruitment/Candidate/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Candidate candidate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(candidate);
        //}

        ////
        //// GET: /Recruitment/Candidate/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidate);
        //}

        ////
        //// POST: /Recruitment/Candidate/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Candidate candidate = db.Candidates.Find(id);
        //    db.Candidates.Remove(candidate);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}