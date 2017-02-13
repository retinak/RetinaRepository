using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSWebUI.Models
{
    public class AddressModel
    {
        public Guid AddressId { get; set; }
        public string Kebele { get; set; }
        public string Town { get; set; }
        public Guid WoredaId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string HouseNo { get; set; }
        public string PoBox { get; set; }
        public string SpecialAddress { get; set; }
        public Guid MemberId { get; set; }

    }
}