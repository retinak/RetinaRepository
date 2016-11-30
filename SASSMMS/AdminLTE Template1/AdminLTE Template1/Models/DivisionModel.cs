using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;
namespace SSWebUI.Models
{
    public class DivisionModel
    {
        [Key]
        public Guid DivisionId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}