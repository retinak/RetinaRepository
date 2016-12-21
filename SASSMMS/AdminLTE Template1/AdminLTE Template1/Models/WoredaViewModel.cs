using System;
using System.ComponentModel;
using SASSMMS.Domain.Entities;

namespace SSWebUI.Models
{
    public class WoredaViewModel
    {
        public Guid WoredaId { get; set; }
        public Guid SubcityId { get; set; }
        [DisplayName("Subcity")]
        public string SubcityName { get; set; }
        [DisplayName("Woreda")]
        public string WoredaName { get; set; }
        //public virtual Subcity Subcity { get; set; }
        
    }
}