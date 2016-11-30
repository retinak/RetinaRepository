using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{/// <summary>
 /// This is lookup class indicates member status 
 /// if the member is in temporary, permanent, dismissed, and so on 
 /// </summary>
    public class Status
    {
    public Guid  StatusId { get; set; }
    public  string StatusName { get; set; }
        //public DateTime StatusChangeDate { get; set; }
        public List<Member> Members { get; set; }
    }
}
