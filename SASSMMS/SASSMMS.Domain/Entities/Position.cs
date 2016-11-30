using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Position
    {
       public  Guid PositionId { get; set; }
       public  string PositionName { get; set; }
       public  List<Member> Members { get; set; } 
    }
}
