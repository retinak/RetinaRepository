using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
   public interface IOccupationService
    {
        bool InsertOccupation(Occupation occupation);
        bool UpdateOccupation(Occupation occupation);
        bool DeleteOccupationn(Occupation occupation);
        List<Occupation> GetOccupations();
        Occupation GetOccupation(Guid? id);
        IEnumerable<Occupation> Get(
         Expression<Func<Occupation, bool>> filter = null,
         Func<IQueryable<Occupation>, IOrderedQueryable<Occupation>> orderBy = null,
         string includeProperties = "");
        List<Occupation> FindBy(Expression<Func<Occupation, bool>> predicate);
    }
}
