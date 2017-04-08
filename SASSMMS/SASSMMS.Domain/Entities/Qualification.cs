using System;
using System.Collections.Generic;
using System.ComponentModel;
using  System.ComponentModel.DataAnnotations;

namespace SASSMMS.Domain.Entities
{
    public  class Qualification
    {
        public  Guid QualificationId { get; set; }
        [DisplayName("Qualification WoredaName")]
        public string QualificationName { get; set; }
        public virtual List<Member> Members { get; set; }
    }
}
