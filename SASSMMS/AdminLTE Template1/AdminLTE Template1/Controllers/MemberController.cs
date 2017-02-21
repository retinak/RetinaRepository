using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using SASSMMS.ApplicationService.Services.Implementations;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SSWebUI.Models;

namespace SSWebUI.Controllers
{
    public class MemberController : Controller
    {

        private readonly IMemberService memberService;
        private readonly ISchoolService schoolService;
        private readonly IQualificationService qualificationService;
        private readonly IPositionService positionService;
        private readonly ICategoryService categoryService;
        private readonly IStatusService statusService;
        private readonly IRegionService regionService ;
        private readonly ISubcityService subcityService;
        private readonly IWoredaService woredaService;
        private readonly IOccupationService occupationService;
        private readonly IDivisionService divisionService;
        public MemberController()
        {
            memberService= new MemberService();
            schoolService=new SchoolService();
            qualificationService=new QualificationService();
            positionService = new PositionService();
            categoryService= new CategoryService();
            statusService=new StatusService();
            occupationService=new OccupationService();
            regionService=new RegionService();
            subcityService=new SubcityService();
            woredaService = new WoredaService();
            divisionService=new DivisionService();

        }

        private List<MemberModel> GetMemberModels(List<Member> lstMembers)
        {
            var lstMemberModel=new List<MemberModel>();

            foreach (var item in lstMembers)
            {
                var mModel = new MemberModel();
                {
                    mModel.MemberId = item.MemberId;
                    mModel.DivisionId = item.DivisionId;
                    mModel.AttendanceNmumber = item.AttendanceNmumber;
                    mModel.Company = item.Company;
                    mModel.SchoolId = item.SchoolId;
                    mModel.FirstName = item.FirstName;
                    mModel.CategoryLevelId = item.CategoryLevelId;
                    mModel.CategoryLevel = item.CategoryLevel.CategoryName;
                    mModel.CurrentStatus = item.CurrentStatus;
                    mModel.DateOfBirth = item.DateOfBirth;
                    mModel.GrandfatherName = item.GrandfatherName;
                    mModel.Gender = item.Gender;

                };
                lstMemberModel.Add(mModel);
            }
            return lstMemberModel;
        }

        // GET: Member
        public ActionResult Index()
        {
            var lst = memberService.GetMembers().ToList();
            return View(GetMemberModels(lst));
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }
        //public ActionResult OtherInfo()
        //{
        //    return View();
        //}

        public JsonResult GetSchools()
        {
            var schools = schoolService.GetSchools();
            return Json(schools.Select(t => new { Text = t.SchoolName, Value = t.SchoolId }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOccupations()
        {
            var occupations = occupationService.GetOccupations();
            return Json(occupations.Select(n => new { OccupationName = n.OccupationName, OccupationId = n.OccupationId}),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWoredas(Guid id)
        {
            var woredas = woredaService.GetWoredas();
            // var woredas=woreda
            if (id != null)
            {
                woredas = woredas.Where(n => n.SubcityId == id);
            }
            return Json(woredas.Select(n => new {Text = n.WoredaName, Value = n.WoredaId}),
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategories()
        {
            var categories = categoryService.GetCategories();
            return Json(categories.Select(t => new { Text = t.CategoryName, Value = t.CategoryId }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQualifications()
        {
            var qualifications = qualificationService.GetQualifications();
            return Json(qualifications.Select(q => new {Text = q.QualificationName, Value = q.QualificationId}),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegions()
        {
            var regions = regionService.GetAll();
            return Json(regions.Select(t => new {t.RegionName, t.RegionId}), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubcities(Guid? id)
        {
            var subcities = subcityService.GeSubcities();
            if (id != null)
            {
                subcities = subcities.Where(s => s.RegionId==id).ToList();
            }
            
            return Json(subcities.Select(t => new {t.SubcityId, t.SubcityName}), JsonRequestBehavior.AllowGet);

            //var northwind = new SampleEntities();
            //var products = northwind.Products.AsQueryable();

            //if (categories != null)
            //{
            //    products = products.Where(p => p.CategoryID == categories);
            //}

            //return Json(products.Select(p => new { ProductID = p.ProductID, ProductName = p.ProductName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStatuses()
        {
            var statuses = statusService.GetStatuses();
            return Json(statuses.Select(s => new
            {
                Text = s.StatusName,
                Value = s.StatusId

            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPositions()
        {
            var positions = positionService.GetPositions();
            return Json(positions.Select(q => new { Text = q.PositionName, Value = q.PositionId }),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDivisions()
        {
            var divisions = divisionService.GetDivisions();
            return Json(divisions.Select(d => new {Text = d.DepartmentName, Value = d.DivisionId}),
                JsonRequestBehavior.AllowGet);
        }
        public Address GetAddress(MemberModel memberModel)
        {
            var addres = new Address
            {
                AddressId = Guid.NewGuid(),
                HouseNo = memberModel.HouseNo,
                City = memberModel.City,
                MobilePhone = memberModel.MobilePhone,
                HomePhone = memberModel.HomePhone,
                PoBox = memberModel.PoBox,
                OfficePhone = memberModel.OfficePhone,
                Email = memberModel.Email,
                WoredaId = memberModel.WoredaId,
                SpecialAddress = memberModel.SpecialAddress

            

            };
            return addres;

        }

       

       
        // POST: Member/Create.
        [HttpPost]
        public ActionResult Create(MemberModel memberModel)
        {
            try
            {
                if (null != memberModel)
                {
                      var mem=new Member();
                    mem.MemberId = Guid.NewGuid();
                    mem.AttendanceNmumber = memberModel.AttendanceNmumber;
                    mem.Addresses.Add(GetAddress(memberModel));
                   
                    mem.DivisionId = memberModel.DivisionId;
                    mem.FirstName = memberModel.FirstName;
                    mem.FatherName = memberModel.FatherName;
                    mem.GrandfatherName = memberModel.GrandfatherName;
                    mem.CurrentStatus = memberModel.CurrentStatus;
                    mem.Gender = memberModel.Gender;
                    mem.DateOfBirth = memberModel.DateOfBirth;
                    mem.SchoolId = memberModel.SchoolId;
                    mem.Positions = memberModel.Positions;
                    mem.Occupations = memberModel.Occupations;
                    mem.Qualifications=memberModel.Qualifications;
                    mem.CategoryLevelId = memberModel.CategoryLevelId;
                    mem.Statuses = memberModel.Statuses;

                    memberService.InsertMember(mem);


                }


                return View(memberModel);


                // TODO: Add insert logic here

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SaveData([Bind(Include = "HouseNo,AttendanceNmumber")] MemberModel memberModel)
        {
            try
            {

                var mem=new Member();
                mem.AttendanceNmumber = memberModel.AttendanceNmumber;

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }

           
        }
        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Member/Edit/5
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

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
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
