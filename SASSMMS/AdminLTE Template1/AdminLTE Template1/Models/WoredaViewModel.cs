using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SASSMMS.Domain.Entities;

namespace SSWebUI.Models
{
    public class WoredaViewModel
    {
        public Guid WoredaId { get; set; }
        public Guid SubcityId { get; set; }
        public string SubcityName { get; set; }
        public string Name { get; set; }
        public virtual Subcity Subcity { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}