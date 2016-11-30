using System;

namespace SASSMMS.Domain.Entities
{
    public class School
    {
        public Guid SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
    }
}
