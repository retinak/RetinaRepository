using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SSWebUI.Controllers
{
    public class WoredaController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Woredas
        public ActionResult Index()
        {
            var woredas = db.Woredas.Include(w => w.Subcity);
            return View(woredas.ToList());
        }

        // GET: Woredas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woreda woreda = db.Woredas.Find(id);
            if (woreda == null)
            {
                return HttpNotFound();
            }
            return View(woreda);
        }

        // GET: Woredas/Create
        public ActionResult Create()
        {
            ViewBag.SubcityId = new SelectList(db.Subcities, "SubcityId", "SubcityName");
            return View();
        }

        // POST: Woredas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WoredaId,SubcityId")] Woreda woreda)
        {
            if (ModelState.IsValid)
            {
                woreda.WoredaId = Guid.NewGuid();
                woreda.Name = woreda.Name;
                db.Woredas.Add(woreda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubcityId = new SelectList(db.Subcities, "SubcityId", "SubcityName", woreda.SubcityId);
            return View(woreda);
        }

        // GET: Woredas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woreda woreda = db.Woredas.Find(id);
            if (woreda == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubcityId = new SelectList(db.Subcities, "SubcityId", "SubcityName", woreda.SubcityId);
            return View(woreda);
        }

        // POST: Woredas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WoredaId,SubcityId")] Woreda woreda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woreda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubcityId = new SelectList(db.Subcities, "SubcityId", "SubcityName", woreda.SubcityId);
            return View(woreda);
        }

        // GET: Woredas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woreda woreda = db.Woredas.Find(id);
            if (woreda == null)
            {
                return HttpNotFound();
            }
            return View(woreda);
        }

        // POST: Woredas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Woreda woreda = db.Woredas.Find(id);
            db.Woredas.Remove(woreda);
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
