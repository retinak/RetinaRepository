using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSMMS.Domain.Entities
{
    public class Occupation
    {
        public Guid OccupationId { get; set; }
        public string OccupationName { get; set; }
        public virtual List<Member> Members { get; set; } 
    }
}
