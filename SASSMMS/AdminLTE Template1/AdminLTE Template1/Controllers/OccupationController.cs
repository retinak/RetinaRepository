using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;

namespace SSWebUI.Controllers
{
    public class OccupationController : Controller
    {
        private readonly IOccupationService occupationService;

        public OccupationController()
        {
            occupationService=new OccupationService();
        }
        // GET: Occupation
        public ActionResult Index()
        {
            var occupations = occupationService.GetOccupations();
            return View(occupations);
        }

        // GET: Occupation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Occupation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occupation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OccupationId,OccupationName")] Occupation occupation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    occupation.OccupationId=Guid.NewGuid();
                    occupationService.InsertOccupation(occupation);

                }
                
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Occupation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Occupation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Occupation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Occupation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
