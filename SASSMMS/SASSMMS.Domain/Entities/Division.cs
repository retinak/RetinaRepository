using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SASSMMS.Domain.Entities
{
    public class Division
    {
        public Guid DivisionId { get; set; }
        [DisplayName("Department")]
       public string DepartmentName { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }


        public virtual List<Member> Members { get; set; }
    }
}
