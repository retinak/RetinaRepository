using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSWebUI.Models
{
    public class ParentModel
    {
        public Guid ParentId { get; set; }
        public string ParentCode { get; set; }
        public  string FirstName { get; set; }
        public  string FatherName { get; set; }
        public  string GrandfatherName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string Gender { get; set; }
        public  string Occupation { get; set; }
    }
}