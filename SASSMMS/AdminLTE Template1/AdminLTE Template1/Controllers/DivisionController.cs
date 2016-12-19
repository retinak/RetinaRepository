using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class DivisionController : Controller
    {
        private MainContext db = new MainContext();
        private readonly IDivisionService divisionService;

        public DivisionController()
        {
            divisionService=new DivisionService();
        }
        // GET: Division
        public ActionResult Index()
        {
            var divisions = divisionService.GetDivisions();

            return View(GetRegionsModels(divisions));
        }
        private List<DivisionModel> GetRegionsModels(List<Division> lstDivisions)
        {
            var lstDivisionModel = new List<DivisionModel>();
            foreach (var division in lstDivisions)
            {

                lstDivisionModel.Add(GetDivisionModel(division));
            }
            return lstDivisionModel;
        }
        private DivisionModel GetDivisionModel(Division division)
        {
            var divisionViewModel = new DivisionModel
            {
                DivisionId = division.DivisionId,
                DepartmentName = division.DepartmentName,
                Phone = division.Phone,
                Email = division.Email
            };

            return divisionViewModel;
        }


        // GET: Division/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var division = divisionService.FindById(id);
            var divisionModel = GetDivisionModel(division);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(divisionModel);
        }

        // GET: Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivisionId,DepartmentName,Phone,Email")] DivisionModel divisionModel)
        {
            var division = GetDivision(divisionModel);
            if (ModelState.IsValid)
            {
                
                divisionService.InsertDivision(division);
                return RedirectToAction("Index");
            }

            return View(divisionModel);


        }
    
        private Division GetDivision(DivisionModel divisionModel)
        {
            var division = new Division
            {
                DivisionId = Guid.NewGuid(),
                DepartmentName = divisionModel.DepartmentName,
                Email = divisionModel.Email,
                Phone = divisionModel.Phone
            };
            return division;
        }
        // GET: Division/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var division = divisionService.FindById(id);

            if (division == null)
            {
                return HttpNotFound();
            }
            return View(GetDivisionModel(division));
        }

        // POST: Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivisionId,DepartmentName,Phone,Email")] DivisionModel divisionModel)
        {
            var division = divisionService.FindById(divisionModel.DivisionId);
            division.DepartmentName = divisionModel.DepartmentName;
            division.Email = divisionModel.Email;
            division.Phone = divisionModel.Phone;
            
            if (ModelState.IsValid)
            {
                divisionService.UpdateDivision(division);
                return RedirectToAction("Index");
            }
            return View(GetDivisionModel(division));
        }

        // GET: Division/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var division = divisionService.FindById(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var division = divisionService.FindById(id);
            divisionService.DeleteDivision(division);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               divisionService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
