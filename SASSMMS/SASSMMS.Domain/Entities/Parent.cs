using System;
using System.ComponentModel;

namespace SASSMMS.Domain.Entities
{
    public class Parent : Person
    {
        public Guid ParentId { get; set; }
       
        public override string FirstName { get; set; }
       
        public override string FatherName { get; set; }
        public override string GrandfatherName { get; set; }
        public override DateTime DateOfBirth { get; set; }
        public override string Gender { get; set; }
        public override string Occupation { get; set; }
    }
}
