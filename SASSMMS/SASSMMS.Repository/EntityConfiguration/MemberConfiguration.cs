using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.Repository.EntityConfiguration
{
    public class MemberConfiguration :EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            //HasRequired(d=>d.Division).WithMany().HasForeignKey(fk=>fk.DivisionId).WillCascadeOnDelete(false);
            //HasRequired(d => d.CategoryLevel).WithMany().HasForeignKey(fk => fk.CategoryLevelId).WillCascadeOnDelete(false);
            
        }
    }
}
