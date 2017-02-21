using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface ISchoolService
    {
        bool InsertSchool(School school);
        bool UpdateSchool(School school);
        bool DeleteSchool(School school);
        School GetSchool(Guid? id);
        List<School> GetSchools();

        List<School> FindBy(Expression<Func<School, bool>> predicate);
        IEnumerable<School> Get(
           Expression<Func<School, bool>> filter = null,
           Func<IQueryable<School>, IOrderedQueryable<School>> orderBy = null,
           string includeProperties = "");

        void Dispose();
    }
}
