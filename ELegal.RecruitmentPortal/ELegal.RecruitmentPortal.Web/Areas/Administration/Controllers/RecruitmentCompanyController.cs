using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Model;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.Controllers
{
    public class RecruitmentCompanyController : Controller
    {
        private RpContext db = new RpContext();

        //
        // GET: /Administration/RecruitmentCompany/

        public ActionResult Index()
        {
            return View(db.RecruitmentCompanies.ToList());
        }

        //
        // GET: /Administration/RecruitmentCompany/Details/5

        public ActionResult Details(int id = 0)
        {
            RecruitmentCompany recruitmentcompany = db.RecruitmentCompanies.Find(id);
            if (recruitmentcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentcompany);
        }

        //
        // GET: /Administration/RecruitmentCompany/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administration/RecruitmentCompany/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecruitmentCompany recruitmentcompany)
        {
            if (ModelState.IsValid)
            {
                db.RecruitmentCompanies.Add(recruitmentcompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruitmentcompany);
        }

        //
        // GET: /Administration/RecruitmentCompany/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RecruitmentCompany recruitmentcompany = db.RecruitmentCompanies.Find(id);
            if (recruitmentcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentcompany);
        }

        //
        // POST: /Administration/RecruitmentCompany/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecruitmentCompany recruitmentcompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruitmentcompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruitmentcompany);
        }

        //
        // GET: /Administration/RecruitmentCompany/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecruitmentCompany recruitmentcompany = db.RecruitmentCompanies.Find(id);
            if (recruitmentcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentcompany);
        }

        //
        // POST: /Administration/RecruitmentCompany/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruitmentCompany recruitmentcompany = db.RecruitmentCompanies.Find(id);
            db.RecruitmentCompanies.Remove(recruitmentcompany);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}