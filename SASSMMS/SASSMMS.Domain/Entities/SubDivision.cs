using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSMMS.Domain.Entities
{
   public class SubDivision
    {

       public Guid SubDivisionId { get; set; }
       public string SubDivisionName { get; set; }
        //[ForeignKey("ChairManId")]
        public Guid DivisionId { get; set; }

        //public Guid SecretaryId { get; set; }
        
        public virtual Division Division { get; set; }
    }
}
