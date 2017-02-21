using System;
using System.Collections.Generic;
using System.Linq;
using SASSMMS.Domain.Entities;
using  System.Linq.Expressions;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface ISubcityService
    {
        bool InsertSubcity(Subcity subcity);
        bool UpdateSubcity(Subcity subcity);
        bool DeleteSubcity(Subcity subcity);
        Subcity GetSubcity(Guid ? id);
        List<Subcity> GeSubcities();

        List<Subcity> FindBy(Expression<Func<Subcity, bool>> predicate);
        IEnumerable<Subcity> Get(
           Expression<Func<Subcity, bool>> filter = null,
           Func<IQueryable<Subcity>, IOrderedQueryable<Subcity>> orderBy = null,
           string includeProperties = "");

        void Dispose();
    }
}
