using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IQualificationService
    {
        bool InsertQualification(Qualification qualification);
        bool UpdateQualification(Qualification qualification);
        bool DeleteQualification(Qualification qualification);
        List<Qualification> GetQualifications();
        Qualification GetQualification(Guid? id);
        IEnumerable<Qualification> Get(
         Expression<Func<Qualification, bool>> filter = null,
         Func<IQueryable<Qualification>, IOrderedQueryable<Qualification>> orderBy = null,
         string includeProperties = "");
        List<Qualification> FindBy(Expression<Func<Qualification, bool>> predicate);
    }
}
