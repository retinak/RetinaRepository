using System;

namespace SASSMMS.Domain.Entities
{
    public  abstract class  Person
    {
        public abstract string FirstName { get; set; }
        public abstract string FatherName { get; set; }
        public abstract string GrandfatherName { get; set; }
        public abstract DateTime DateOfBirth { get; set; }
        public abstract string Gender { get; set; }
        public abstract string Occupation { get; set; }
    }
}
