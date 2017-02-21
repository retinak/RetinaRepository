using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Woreda
    {
        public  Guid WoredaId { get; set; }
        public  Guid SubcityId { get; set; }
        public  string WoredaName { get; set; }
        public  virtual  Subcity Subcity { get; set; }

        public virtual List<Address> Addresses { get; set; }

    }
}
