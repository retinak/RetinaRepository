﻿using SASSMMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SSWebUI.Models
{
    public class MemberModel
    {

        public Guid MemberId { get; set; }
      
        public string AttendanceNmumber { get; set; }

        //public  Guid SubDivisionId { get; set; }
        public Guid ParentId { get; set; }
  
        public string CurrentStatus { get; set; }
        public virtual List<Occupation> Occupations { get; set; } 
     
        public string Company { get; set; }
        public Guid SchoolId { get; set; }
        public Guid StatusId { get; set; }
        public  string StatusName { get; set; }
        #region Navigation 
        public  Guid PositionId { get; set; }
        public Guid RegionId { get; set; }
        public string SchoolName { get; set; }
        public  Guid QualificationId { get; set; }
        public virtual List<Qualification> Qualifications { get; set; }
        public virtual List<Position> Positions { get; set; }
        public  string ParentFullName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid CategoryLevelId { get;set; }
      
        public string CategoryLevel { get; set; }
        public virtual  School School { get; set; }
        public Guid SubcityId { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string PoBox { get; set; }
        public  string SpecialAddress { get; set; }
        #endregion

        public  string FirstName { get; set; }
        public  string FatherName { get; set; }
        public  string GrandfatherName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string Gender { get; set; }
        public  string Occupation { get; set; }
    }
}