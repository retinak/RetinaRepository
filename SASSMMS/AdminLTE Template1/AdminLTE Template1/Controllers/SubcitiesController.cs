using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class SubcitiesController : Controller
    {
        private MainContext db = new MainContext();
        private ISubcityService subcityService;

        public SubcitiesController()
        {
            subcityService=new SubcityService();
        }

        private SubcityViewModel GetSubcityViewModel(Subcity subcity)
        {
            var subcityViewModel = new SubcityViewModel
            {
                SubcityId = subcity.SubcityId,
                SubcityName = subcity.SubcityName,
                RegionId = subcity.SubcityId,
                RegionName=subcity.Region.RegionName
                
                

            };
            return subcityViewModel;
        }

        private List<SubcityViewModel> GetSubcityViewModels(List<Subcity> lstSubcities )
        {
            var lstSubcityViewModels=new List<SubcityViewModel>();

            foreach (var subcity in lstSubcities)
            {
                lstSubcityViewModels.Add(GetSubcityViewModel(subcity));
            }
            return lstSubcityViewModels;
        } 
        // GET: Subcities

        public ActionResult Index()
        {
           // var subcities = db.Subcities.Include(s => s.Region);
            var sub = subcityService.GeSubcities();
            var regionModels = GetSubcityViewModels(sub);
            return View(regionModels);
        }

        // GET: Subcities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcity subcity = db.Subcities.Find(id);
            if (subcity == null)
            {
                return HttpNotFound();
            }
            return View(subcity);
        }

        // GET: Subcities/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View();
        }

        // POST: Subcities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubcityId,RegionId,SubcityName")] Subcity subcity)
        {
            if (ModelState.IsValid)
            {
                subcity.SubcityId = Guid.NewGuid();
                db.Subcities.Add(subcity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", subcity.RegionId);
            return View(subcity);
        }

        // GET: Subcities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcity subcity = db.Subcities.Find(id);
            if (subcity == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", subcity.RegionId);
            return View(subcity);
        }

        // POST: Subcities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubcityId,RegionId,SubcityName")] Subcity subcity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName", subcity.RegionId);
            return View(subcity);
        }

        // GET: Subcities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcity subcity = db.Subcities.Find(id);
            if (subcity == null)
            {
                return HttpNotFound();
            }
            return View(subcity);
        }

        // POST: Subcities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Subcity subcity = db.Subcities.Find(id);
            db.Subcities.Remove(subcity);
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
