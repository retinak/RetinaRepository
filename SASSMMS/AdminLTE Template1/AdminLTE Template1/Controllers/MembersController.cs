using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SSWebUI.Controllers
{
    public class MembersController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.Division).Include(m => m.Parent).Include(m => m.School);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DepartmentName");
            ViewBag.ParentId = new SelectList(db.Parents, "ParentId", "ParentCode");
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,AttendanceNmumber,ParentId,CurrentStatus,Company,SchoolId,DivisionId,CategoryLevelId,FirstName,FatherName,GrandfatherName,DateOfBirth,Gender,Occupation")] Member member)
        {
            if (ModelState.IsValid)
            {
                member.MemberId = Guid.NewGuid();
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DepartmentName", member.DivisionId);
            ViewBag.ParentId = new SelectList(db.Parents, "ParentId", "ParentCode", member.ParentId);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", member.SchoolId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DepartmentName", member.DivisionId);
            ViewBag.ParentId = new SelectList(db.Parents, "ParentId", "ParentCode", member.ParentId);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", member.SchoolId);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,AttendanceNmumber,ParentId,CurrentStatus," +
                                                 "Company,SchoolId,DivisionId,CategoryLevelId,FirstName," +
                                                 "FatherName,GrandfatherName,DateOfBirth,Gender,Occupation")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DepartmentName", member.DivisionId);
            ViewBag.ParentId = new SelectList(db.Parents, "ParentId", "ParentCode", member.ParentId);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", member.SchoolId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
