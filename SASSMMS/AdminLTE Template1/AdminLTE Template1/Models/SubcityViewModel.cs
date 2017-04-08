using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SASSMMS.Domain.Entities;

namespace SSWebUI.Models
{
    public class SubcityViewModel
    {
        public Guid SubcityId { get; set; }
        public Guid RegionId { get; set; }
        public string SubcityName { get; set; }
        public string RegionName { get; set; }
        public virtual Region Region { get; set; }
    }
}