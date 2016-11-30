using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Subcity
    {
        public Guid  SubcityId { get; set; }
        public Guid RegionId { get; set; }
        public string SubcityName { get; set; }
        public  virtual  Region Region { get; set; }
       
        public  virtual  List<Woreda> Woredas { get; set; } 
    }
}
