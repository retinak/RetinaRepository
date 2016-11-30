using System;
using System.Collections.Generic;

namespace SASSMMS.Domain.Entities
{
    public class Address
    {
        
            
            public Guid AddressId { get; set; }
            public string HouseNo { get; set; }
            public Guid WoredaId { get; set; }
            public string City { get; set; }       
             
            public string Country { get; set; }
      
            public string Email { get; set; }
            public string HomePhone { get; set; }
            public string OfficePhone { get; set; }
            public string MobilePhone { get; set; }
          
            public string PoBox { get; set; }
            public string SpecialAddress { get; set; }
            //public Guid MemberId { get; set; }



        #region Navigation
        //public  virtual Member Member { get; set; }
        // public virtual Woreda Woreda { get; set; }
        #endregion

    }
}
