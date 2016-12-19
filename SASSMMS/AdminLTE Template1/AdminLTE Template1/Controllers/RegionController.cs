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
    public class RegionController : Controller
    {
        private readonly IRegionService regionService;
         
        public RegionController()
        {
            regionService = new RegionService();
        }


        public RegionViewModel GetRegionModel(Region region)
        {
            var regionModel=new RegionViewModel();
            regionModel.RegionId = region.RegionId;
            regionModel.RegionName = region.RegionName;
            return regionModel;
        }

        private List<RegionViewModel> GetRegionsModel(List<Region> lstRegions )
        {
            var lstRegionModel=new List<RegionViewModel>();
            foreach (var region in lstRegions)
            {
                
                lstRegionModel.Add(GetRegionModel(region));
            }
            return lstRegionModel;
        } 
        // GET: Regions
        public ActionResult Index()
        {
           
            var regions = regionService.GetAll();

            return View(GetRegionsModel(regions));
        }

        // GET: Regions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            var region = regionService.FindById(id);
            var regionModel = GetRegionModel(region);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(regionModel);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      

        public ActionResult Create([Bind(Include = "RegionId,RegionName")]RegionViewModel regionViewModel)
        {
            var region = ToRegion(regionViewModel);

            if (ModelState.IsValid)
            {
                regionService.Add(region);
                return RedirectToAction("Index");
            }

            return View(regionViewModel);
        }

        // GET: Regions/Edit/5

       

        private Region ToRegion(RegionViewModel regionViewModel)
        {
            var region = new Region
            {
                RegionId = Guid.NewGuid(),
                RegionName = regionViewModel.RegionName
            };
            return region;
        }
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var region = regionService.FindById(id);

            if (region == null)
            {
                return HttpNotFound();
            }
            return View(GetRegionModel(region));
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionId,RegionName")] RegionViewModel regionViewModel)
        {
            var region = regionService.FindById(regionViewModel.RegionId);
            region.RegionName = regionViewModel.RegionName;
           
            if (ModelState.IsValid)
            {
                regionService.Edit(region);
                return RedirectToAction("Index");
            }
            return View(regionViewModel);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = regionService.FindById(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var region = regionService.FindById(id);
            regionService.Delete(region);
            return RedirectToAction("Index");
        }

      
        
    }
}
