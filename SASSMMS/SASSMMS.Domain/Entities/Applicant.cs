using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSMMS.Domain.Entities
{
    public class Applicant 
    {
        public Guid ApplicantId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandfatherName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }


   
        public string  Qualifications { get; set; }
        public string Title { get; set; }
     

       public  string PhoneNumber { get; set; }

        



    }
}
