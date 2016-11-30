using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.Repository.EntityConfiguration
{
    public class WoredaConfiguration :EntityTypeConfiguration<Woreda>
    {
        public WoredaConfiguration()
        {
            HasRequired(s=>s.Subcity).WithMany().HasForeignKey(fk=>fk.SubcityId).WillCascadeOnDelete(false);
        }
    }
}
