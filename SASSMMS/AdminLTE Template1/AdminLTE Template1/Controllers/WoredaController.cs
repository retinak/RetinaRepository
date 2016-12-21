using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class WoredaController : Controller
    {
        //private MainContext db = new MainContext();
        private readonly IWoredaService woredaService;
        private readonly ISubcityService subcityService;

        public WoredaController()
        {
            woredaService=new WoredaService();
            subcityService=new SubcityService();
        }
        
        // GET: Woredas
        public ActionResult Index()
        {
           // var woredas = db.Woredas.Include(w => w.Subcity);
            var woredas = woredaService.GetWoredas().ToList();
            return View(GetWoredaViewModels(woredas));
        }

        public WoredaViewModel GetWoredaViewModel(Woreda woreda)
        {
            var woredaViewModel = new WoredaViewModel
            {
                WoredaId = woreda.WoredaId,
                WoredaName = woreda.WoredaName,
                SubcityId = woreda.SubcityId,
                SubcityName = woreda.Subcity.SubcityName

            };
            return woredaViewModel;
        }
        private List<WoredaViewModel> GetWoredaViewModels(List<Woreda> lstWoredas)
        {
            var lstWoredaViewModel = new List<WoredaViewModel>();
            foreach (var w in lstWoredas)
            {
                lstWoredaViewModel.Add(GetWoredaViewModel(w));
            }
            return lstWoredaViewModel;
        } 
        // GET: Woredas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var woreda = woredaService.GetWoreda(id);
            if (woreda == null)
            {
                return HttpNotFound();
            }
            return View(GetWoredaViewModel(woreda));
        }

        // GET: Woredas/Create
        public ActionResult Create()
        {
            ViewBag.SubcityId = new SelectList(subcityService.GeSubcities(), "SubcityId", "SubcityName");
            return View();
        }

        // POST: Woredas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WoredaId,SubcityId,WoredaName")] WoredaViewModel  woredaViewModel)
        {

            var woreda = GetWoreda(woredaViewModel);
            woreda.WoredaId = Guid.NewGuid();
            if (ModelState.IsValid)
            {

                woredaService.InsertWoreda(woreda);
                return RedirectToAction("Index");
            }

            ViewBag.SubcityId = new SelectList(subcityService.GeSubcities(), "SubcityId", "SubcityName", woreda.SubcityId);
            return View(GetWoredaViewModel(woreda));
        }

        private Woreda GetWoreda(WoredaViewModel woredaViewModel)
        {
            var woreda = new Woreda
            {
                WoredaName = woredaViewModel.WoredaName,
                SubcityId = woredaViewModel.SubcityId

            };
            return woreda;
        }
        // GET: Woredas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var woreda = woredaService.GetWoreda(id);
            if (woreda == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubcityId = new SelectList(subcityService.GeSubcities(), "SubcityId", "SubcityName", woreda.SubcityId);
            return View(GetWoredaViewModel(woreda));
        }

        // POST: Woredas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WoredaId,SubcityId,WoredaName,SubcityName")] WoredaViewModel woredaViewModel)
        {
            var woreda = woredaService.GetWoreda(woredaViewModel.WoredaId);
            woreda.SubcityId = woredaViewModel.SubcityId;
            woreda.WoredaName = woredaViewModel.WoredaName;

            if (ModelState.IsValid)
            {
                woredaService.UpdateWoreda(woreda);
                return RedirectToAction("Index");
            }
            ViewBag.SubcityId = new SelectList(subcityService.GeSubcities(), "SubcityId", "SubcityName", woreda.SubcityId);
            return View(GetWoredaViewModel(woreda));
        }

        // GET: Woredas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Woreda woreda = woredaService.GetWoreda(id);
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
            Woreda woreda = woredaService.GetWoreda(id);
            woredaService.DeleteWoreda(woreda);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               woredaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
