using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Member :Person
    {
        public Guid MemberId  { get; set; }
       
        public string AttendanceNmumber { get; set; }

        //public  Guid SubDivisionId { get; set; }
        public Guid ParentId { get; set; }
        public virtual Parent Parent { get; set; }
        public string CurrentStatus { get; set; }
        public string Company { get; set; }
        public Guid SchoolId { get; set; }

        #region Navigation 
        public virtual School School { get; set; }
        public virtual List<Qualification> Qualifications { get; set; }
        public virtual List<Position> Positions { get; set; }
    
        public Guid DivisionId { get; set; }
        public  virtual  Division Division { get; set; }
        public Guid CategoryLevelId { get; set; }
      public List<Occupation> Occupations { get; set; } 
       
        public virtual Category CategoryLevel { get; set; }

        public virtual List<Status> Statuses { get; set; }

        public virtual List<Address> Addresses { get; set; }
        //public virtual List<Division> Divisions { get; set; }// can a member be in Division and at the same time in sub division?
        #endregion

        public override string FirstName { get; set; }
        public override string FatherName { get; set; }
        public override string GrandfatherName { get; set; }
        public override DateTime DateOfBirth { get; set; }
        public override string Gender { get; set; }
        public override string Occupation { get; set; }
    }
}
