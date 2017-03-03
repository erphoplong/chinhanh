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
    public class HangHoaTAHCMController : Controller
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: TruongAnHCM/HangHoaTAHCM
        public ActionResult Index()
        {
            var dM_HANG_HOA = db.DM_HANG_HOA.Include(d => d.DM_HANG_SP).Include(d => d.DM_TAI_KHOAN_HACH_TOAN).Include(d => d.DM_TAI_KHOAN_HACH_TOAN1).Include(d => d.DM_TAI_KHOAN_HACH_TOAN2);
            return View(dM_HANG_HOA.ToList());
        }

        // GET: TruongAnHCM/HangHoaTAHCM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            if (dM_HANG_HOA == null)
            {
                return HttpNotFound();
            }
            return View(dM_HANG_HOA);
        }

        // GET: TruongAnHCM/HangHoaTAHCM/Create
        public ActionResult Create()
        {
            ViewBag.MA_NHOM_HANG = new SelectList(db.DM_HANG_SP, "MA_NHOM_HANG", "TEN_NHOM_HANG");
            ViewBag.TK_HACH_TOAN_KHO = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK");
            ViewBag.TK_DOANH_THU = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK");
            ViewBag.TK_CHI_PHI = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK");
            return View();
        }

        // POST: TruongAnHCM/HangHoaTAHCM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_HANG_HT,MA_HANG_NHAP,TEN_HANG,MA_NHOM_HANG,SERI,DON_VI_TINH,MODEL_DAC_BIET,HINH_ANH,DAC_TINH,GHI_CHU,TK_HACH_TOAN_KHO,TK_DOANH_THU,TK_CHI_PHI")] DM_HANG_HOA dM_HANG_HOA)
        {
            if (ModelState.IsValid)
            {
                db.DM_HANG_HOA.Add(dM_HANG_HOA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_NHOM_HANG = new SelectList(db.DM_HANG_SP, "MA_NHOM_HANG", "TEN_NHOM_HANG", dM_HANG_HOA.MA_NHOM_HANG);
            ViewBag.TK_HACH_TOAN_KHO = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_HACH_TOAN_KHO);
            ViewBag.TK_DOANH_THU = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_DOANH_THU);
            ViewBag.TK_CHI_PHI = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_CHI_PHI);
            return View(dM_HANG_HOA);
        }

        // GET: TruongAnHCM/HangHoaTAHCM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            if (dM_HANG_HOA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.DM_HANG_SP, "MA_NHOM_HANG", "TEN_NHOM_HANG", dM_HANG_HOA.MA_NHOM_HANG);
            ViewBag.TK_HACH_TOAN_KHO = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_HACH_TOAN_KHO);
            ViewBag.TK_DOANH_THU = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_DOANH_THU);
            ViewBag.TK_CHI_PHI = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_CHI_PHI);
            return View(dM_HANG_HOA);
        }

        // POST: TruongAnHCM/HangHoaTAHCM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_HANG_HT,MA_HANG_NHAP,TEN_HANG,MA_NHOM_HANG,SERI,DON_VI_TINH,MODEL_DAC_BIET,HINH_ANH,DAC_TINH,GHI_CHU,TK_HACH_TOAN_KHO,TK_DOANH_THU,TK_CHI_PHI")] DM_HANG_HOA dM_HANG_HOA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dM_HANG_HOA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_NHOM_HANG = new SelectList(db.DM_HANG_SP, "MA_NHOM_HANG", "TEN_NHOM_HANG", dM_HANG_HOA.MA_NHOM_HANG);
            ViewBag.TK_HACH_TOAN_KHO = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_HACH_TOAN_KHO);
            ViewBag.TK_DOANH_THU = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_DOANH_THU);
            ViewBag.TK_CHI_PHI = new SelectList(db.DM_TAI_KHOAN_HACH_TOAN, "SO_TK", "TEN_TK", dM_HANG_HOA.TK_CHI_PHI);
            return View(dM_HANG_HOA);
        }

        // GET: TruongAnHCM/HangHoaTAHCM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            if (dM_HANG_HOA == null)
            {
                return HttpNotFound();
            }
            return View(dM_HANG_HOA);
        }

        // POST: TruongAnHCM/HangHoaTAHCM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DM_HANG_HOA dM_HANG_HOA = db.DM_HANG_HOA.Find(id);
            db.DM_HANG_HOA.Remove(dM_HANG_HOA);
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
