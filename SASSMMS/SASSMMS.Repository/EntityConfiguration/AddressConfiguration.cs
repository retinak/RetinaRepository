using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.Repository.EntityConfiguration
{
    public class AddressConfiguration :EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            //HasRequired(w=>w.Woreda).WithMany().HasForeignKey(fk=>fk.WoredaId).WillCascadeOnDelete(false);
            //HasRequired(m=>m.Member).WithMany().HasForeignKey(fk=>fk.MemberId).WillCascadeOnDelete(false);
        }
    }
}
