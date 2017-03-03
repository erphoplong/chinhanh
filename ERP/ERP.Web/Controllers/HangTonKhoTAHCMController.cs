using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;
using ERP.Web.Models.BusinessModel;

namespace ERP.Web.Areas.TruongAnHCM.Controllers
{
    [AuthorizeBussiness]
    public class HangTonKhoTAHCMController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: TruongAnHCM/HangTonKhoTAHCM
        public ActionResult Index()
        {
            var dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Include(d => d.DM_HANG_HOA).Include(d => d.DM_KHO);
            return View(dM_HANG_TON_KHO.ToList());
        }

        // GET: TruongAnHCM/HangTonKhoTAHCM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            if (dM_HANG_TON_KHO == null)
            {
                return HttpNotFound();
            }
            return View(dM_HANG_TON_KHO);
        }

        // GET: TruongAnHCM/HangTonKhoTAHCM/Create
        public ActionResult Create()
        {
            ViewBag.MA_HANG_HT = new SelectList(db.DM_HANG_HOA, "MA_HANG_HT", "MA_HANG_NHAP");
            ViewBag.MA_KHO = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: TruongAnHCM/HangTonKhoTAHCM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_HANG_HT,MA_KHO,SL_TON")] DM_HANG_TON_KHO dM_HANG_TON_KHO)
        {
            if (ModelState.IsValid)
            {
                db.DM_HANG_TON_KHO.Add(dM_HANG_TON_KHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_HANG_HT = new SelectList(db.DM_HANG_HOA, "MA_HANG_HT", "MA_HANG_NHAP", dM_HANG_TON_KHO.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_HANG_TON_KHO.MA_KHO);
            return View(dM_HANG_TON_KHO);
        }

        // GET: TruongAnHCM/HangTonKhoTAHCM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            if (dM_HANG_TON_KHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_HANG_HT = new SelectList(db.DM_HANG_HOA, "MA_HANG_HT", "MA_HANG_NHAP", dM_HANG_TON_KHO.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_HANG_TON_KHO.MA_KHO);
            return View(dM_HANG_TON_KHO);
        }

        // POST: TruongAnHCM/HangTonKhoTAHCM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_HANG_HT,MA_KHO,SL_TON")] DM_HANG_TON_KHO dM_HANG_TON_KHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dM_HANG_TON_KHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_HANG_HT = new SelectList(db.DM_HANG_HOA, "MA_HANG_HT", "MA_HANG_NHAP", dM_HANG_TON_KHO.MA_HANG_HT);
            ViewBag.MA_KHO = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_HANG_TON_KHO.MA_KHO);
            return View(dM_HANG_TON_KHO);
        }

        // GET: TruongAnHCM/HangTonKhoTAHCM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            if (dM_HANG_TON_KHO == null)
            {
                return HttpNotFound();
            }
            return View(dM_HANG_TON_KHO);
        }

        // POST: TruongAnHCM/HangTonKhoTAHCM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DM_HANG_TON_KHO dM_HANG_TON_KHO = db.DM_HANG_TON_KHO.Find(id);
            db.DM_HANG_TON_KHO.Remove(dM_HANG_TON_KHO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
