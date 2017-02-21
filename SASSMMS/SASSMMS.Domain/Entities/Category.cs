using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{/// <summary>
/// This class  serves as lookup class that holds levels data (like, beginner, medium level , Adults) 
/// </summary>
    public class Category
    {
        public  Guid CategoryId { get; set; }
        public  string CategoryName { get; set; }

        public virtual List<Member> Members { get; set; } 
    }
}
