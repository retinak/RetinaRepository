using System;
using System.ComponentModel.DataAnnotations;

namespace SSWebUI.Models
{
    public class BasicInformation
    {
       
        [Key]
        public Guid MemberId { get; set; }
        public string AttendanceNmumber { get; set; }
        public Guid ParentId { get; set; }
        //public Guid DivisionId { get; set; }
        public string CurrentStatus { get; set; }
        public Guid DivisionId { get; set; }
        public  string FirstName { get; set; }
        public  string FatherName { get; set; }
        public  string GrandfatherName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string Gender { get; set; }
        public  string Occupation { get; set; }

        public string Company { get; set; }
        public Guid SchoolId { get; set; }

        public string[] Qualification { get; set; }
        public string[] Position { get; set; }


        public string[] CategoryLevel { get; set; }

        public string[] Status { get; set; }
        public string[] Region { get; set; }
        public string[] Subcity { get; set; }
        public string[] Woreda { get; set; }
        public string AdditionalAddress { get; set; }
        public string Kebele { get; set; }
        public string Town { get; set; }
        public Guid WoredaId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string HouseNo { get; set; }
        public string PoBox { get; set; }
        public string SpecialAddress { get; set; }
     

    }
}