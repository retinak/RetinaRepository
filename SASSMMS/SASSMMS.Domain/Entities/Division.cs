using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Division
    {
        public Guid DivisionId { get; set; }
       public string DepartmentName { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }


        public virtual List<Member> Members { get; set; }
    }
}
