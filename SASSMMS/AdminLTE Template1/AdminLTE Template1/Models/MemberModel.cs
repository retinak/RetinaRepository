using SASSMMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSWebUI.Models
{
    public class MemberModel
    {
        public Guid MemberId { get; set; }

        public string AttendanceNmumber { get; set; }

        //public  Guid SubDivisionId { get; set; }
        public Guid ParentId { get; set; }
        public string CurrentStatus { get; set; }
        public string Company { get; set; }
        public Guid SchoolId { get; set; }

        #region Navigation 
        public virtual School School { get; set; }
        public virtual List<Qualification> Qualifications { get; set; }
        public virtual List<Position> Positions { get; set; }
        public virtual Parent Parent { get; set; }
        public Guid DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public Guid CategoryLevelId { get; set; }
        public virtual Category CategoryLevel { get; set; }

        public virtual List<Status> Statuses { get; set; }

        public virtual List<Address> Addresses { get; set; }
        //public virtual List<Division> Divisions { get; set; }// can a member be in Division and at the same time in sub division?
        #endregion

        public  string FirstName { get; set; }
        public  string FatherName { get; set; }
        public  string GrandfatherName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string Gender { get; set; }
        public  string Occupation { get; set; }
    }
}