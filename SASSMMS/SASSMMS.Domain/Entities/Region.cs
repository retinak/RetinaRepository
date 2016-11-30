using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public virtual  List<Subcity> Subcities { get; set; } 
        
    }
}
