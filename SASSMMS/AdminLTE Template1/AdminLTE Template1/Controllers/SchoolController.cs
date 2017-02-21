using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;

namespace SSWebUI.Controllers
{[Authorize]
    public class SchoolController : Controller
    {
        //private MainContext db = new MainContext();

        private readonly ISchoolService schoolService;

        public SchoolController()
        {
            schoolService=new SchoolService();
        }
        // GET: School
        public ActionResult Index()
        {
            return View(schoolService.GetSchools().ToList());
        }

        // GET: School/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = schoolService.GetSchool(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }
        public JsonResult GetSchools()
        {
            var schools =schoolService.GetSchools();
            return Json(schools.Select(t => new { Text = t.SchoolName, Value = t.SchoolId }), JsonRequestBehavior.AllowGet);
        }
        // GET: School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchoolId,SchoolName,SchoolAddress")] School school)
        {
            if (ModelState.IsValid)
            {
                school.SchoolId = Guid.NewGuid();
                schoolService.InsertSchool(school);
               
                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: School/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = schoolService.GetSchool(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: School/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchoolId,SchoolName,SchoolAddress")] School school)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(school).State = EntityState.Modified;
                schoolService.UpdateSchool(school);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: School/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = schoolService.GetSchool(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            schoolService.GetSchool(id);
            //db.Schools.Remove(school);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            schoolService.Dispose();
           
        }
    }
}
