using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class SubcityController : Controller
    {
        //private readonly MainContext db = new MainContext();
        private readonly ISubcityService subcityService;
        private readonly IRegionService regionService;
        public SubcityController()
        {
            subcityService=new SubcityService();
            regionService=new RegionService();
        }

      

        private List<SubcityViewModel> GetSubcityViewModels(IEnumerable<Subcity> lstSubcities )
        {
            return lstSubcities.Select(GetSubcityViewModel).ToList();
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
            var subcity = subcityService.GetSubcity(id);

            if (subcity == null)
            {
                return HttpNotFound();
            }
            return View(GetSubcityViewModel(subcity));
        }
        private SubcityViewModel GetSubcityViewModel(Subcity subcity)
        {
            var subcityViewModel = new SubcityViewModel
            {
                SubcityId = subcity.SubcityId,
                SubcityName = subcity.SubcityName,
                RegionId = subcity.RegionId,
                RegionName = subcity.Region.RegionName

            };
            return subcityViewModel;
        }
        // GET: Subcities/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "RegionId", "RegionName");
            return View();
        }

        // POST: Subcities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubcityId,RegionId,SubcityName")] SubcityViewModel subcityViewModel)
        {
            var subcity = GetSubcity(subcityViewModel);
            subcity.SubcityId = Guid.NewGuid();
            if (ModelState.IsValid)
            {
            
                subcityService.InsertSubcity(subcity);
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(regionService.GetAll(), "RegionId", "RegionName", subcity.RegionId);
            return View(GetSubcityViewModel(subcity));
        }

        // GET: Subcities/Edit/5
        private Guid ? tempSub;
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
               
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
            }
            var subcity = subcityService.GetSubcity(id);
            tempSub = id;
            if (subcity == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "RegionId", "RegionName", subcity.RegionId);
            return View(GetSubcityViewModel(subcity));
        }


        // POST: Subcities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubcityId,RegionId,SubcityName")] SubcityViewModel subcityViewModel)
        {
            

            var subcity = subcityService.GetSubcity(subcityViewModel.SubcityId);
            subcity.RegionId = subcityViewModel.RegionId;
            subcity.SubcityName = subcityViewModel.SubcityName;
            if (ModelState.IsValid)
            {

                subcityService.UpdateSubcity(subcity);
                
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "RegionId", "RegionName", subcity.RegionId);
            return View(GetSubcityViewModel(subcity));
        }
        //public ActionResult Edit([Bind(Include = "DivisionId,DepartmentName,Phone,Email")] DivisionModel divisionModel)
        //{
        //    var division = divisionService.FindById(divisionModel.DivisionId);
        //    division.DepartmentName = divisionModel.DepartmentName;
        //    division.Email = divisionModel.Email;
        //    division.Phone = divisionModel.Phone;

        //    if (ModelState.IsValid)
        //    {
        //        divisionService.UpdateDivision(division);
        //        return RedirectToAction("Index");
        //    }
        //    return View(GetDivisionModel(division));
        //}
        // GET: Subcities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subcity = subcityService.GetSubcity(id);
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
            var subcity = subcityService.GetSubcity(id);
            subcityService.DeleteSubcity(subcity);
            return RedirectToAction("Index");
        }

        private Subcity GetSubcity(SubcityViewModel subcityViewModel)
        {
            var subcity = new Subcity
            {
                SubcityId = subcityViewModel.SubcityId,
                SubcityName = subcityViewModel.SubcityName,
                RegionId = subcityViewModel.RegionId,

            };
            return subcity;
        }

        //private SubcityViewModel GetSubcityViewModel(Subcity subcity)
        //{
        //    var subcityViewModel = new SubcityViewModel
        //    {
        //        SubcityId = subcity.SubcityId,
        //        RegionId = subcity.RegionId,
        //        SubcityName = subcity.SubcityName,
        //        RegionName = subcity.Region.RegionName
        //    };
        //    return subcityViewModel;
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                subcityService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
