using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SASSMMS.Domain.Entities
{
    public class Region
    {
        public Guid RegionId { get; set; }
        [DisplayName("Region Name")]
        public string RegionName { get; set; }
        public virtual  List<Subcity> Subcities { get; set; } 
        
    }
}
