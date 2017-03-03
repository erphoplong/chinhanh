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
    public class KhoTAHCMController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: TruongAnHCM/KhoTAHCM
        public ActionResult Index()
        {
            var dM_KHO = db.DM_KHO.Include(d => d.CCTC_CONG_TY).Include(d => d.DM_KHO2);
            return View(dM_KHO.ToList());
        }

        // GET: TruongAnHCM/KhoTAHCM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_KHO dM_KHO = db.DM_KHO.Find(id);
            if (dM_KHO == null)
            {
                return HttpNotFound();
            }
            return View(dM_KHO);
        }

        // GET: TruongAnHCM/KhoTAHCM/Create
        public ActionResult Create()
        {
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY");
            ViewBag.MA_KHO_CHA = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO");
            return View();
        }

        // POST: TruongAnHCM/KhoTAHCM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_KHO,TEN_KHO,DIA_CHI_KHO,MA_KHO_CHA,TRUC_THUOC,GHI_CHU")] DM_KHO dM_KHO)
        {
            if (ModelState.IsValid)
            {
                db.DM_KHO.Add(dM_KHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", dM_KHO.TRUC_THUOC);
            ViewBag.MA_KHO_CHA = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_KHO.MA_KHO_CHA);
            return View(dM_KHO);
        }

        // GET: TruongAnHCM/KhoTAHCM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_KHO dM_KHO = db.DM_KHO.Find(id);
            if (dM_KHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", dM_KHO.TRUC_THUOC);
            ViewBag.MA_KHO_CHA = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_KHO.MA_KHO_CHA);
            return View(dM_KHO);
        }

        // POST: TruongAnHCM/KhoTAHCM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_KHO,TEN_KHO,DIA_CHI_KHO,MA_KHO_CHA,TRUC_THUOC,GHI_CHU")] DM_KHO dM_KHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dM_KHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", dM_KHO.TRUC_THUOC);
            ViewBag.MA_KHO_CHA = new SelectList(db.DM_KHO, "MA_KHO", "TEN_KHO", dM_KHO.MA_KHO_CHA);
            return View(dM_KHO);
        }

        // GET: TruongAnHCM/KhoTAHCM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_KHO dM_KHO = db.DM_KHO.Find(id);
            if (dM_KHO == null)
            {
                return HttpNotFound();
            }
            return View(dM_KHO);
        }

        // POST: TruongAnHCM/KhoTAHCM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DM_KHO dM_KHO = db.DM_KHO.Find(id);
            db.DM_KHO.Remove(dM_KHO);
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
