using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class ParentController : Controller
    {
        private readonly IParentService parentService;

        public ParentController()
        {
            parentService=new ParentService();
        }
        // GET: Parent

        private List<ParentModel> GetParentModels(List<Parent> lstParents)
        {
            var lstParentModels=new List<ParentModel>();
            foreach (var item in lstParents)
            {
                var parentModel = new ParentModel
                {
                    ParentId = item.ParentId,
                  
                    FirstName = item.FirstName,
                    FatherName = item.FatherName,
                    GrandfatherName = item.GrandfatherName,
                    Gender = item.Gender,
                    Occupation = item.Occupation,
                    DateOfBirth = item.DateOfBirth
                };
                lstParentModels.Add(parentModel);



            }
            return lstParentModels;
        }

        

        public ActionResult Index()
        {
            var parents = parentService.GetParents();


            return View(GetParentModels(parents));
        }

        // GET: Parent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,FatherName,GrandFatherName,Occupation,DateOfBirth,Gender")] Parent collection)
        {
            try
            {
                var parent = new Parent
                {
                    ParentId = Guid.NewGuid(),
                    FirstName = collection.FirstName,
                    FatherName = collection.FatherName,
                    GrandfatherName = collection.GrandfatherName,
                    Gender = collection.Gender,
                    Occupation = collection.Occupation,
                    DateOfBirth = collection.DateOfBirth
                };
                parentService.InsertParent(parent);
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parent/Edit/5
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

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parent/Delete/5
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
