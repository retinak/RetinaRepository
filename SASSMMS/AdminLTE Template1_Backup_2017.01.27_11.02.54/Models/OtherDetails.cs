using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSWebUI.Models
{
    public class OtherDetails
    {
       [Key]
        public  Guid MemberId { get; set; }

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


    }
}