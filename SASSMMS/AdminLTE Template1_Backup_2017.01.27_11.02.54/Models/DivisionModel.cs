using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;
namespace SSWebUI.Models
{
    public class DivisionModel
    {
        public Guid DivisionId { get; set; }
        [Required]
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}