using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSWebUI.Models
{
    public class RegionViewModel
    {
        [Key]
        public Guid RegionId { get; set; }
        [DisplayName("Region Name")]
        public string RegionName { get; set; }
    }
}