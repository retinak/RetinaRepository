using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;
using System.Linq.Expressions;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IParentService
    {
        bool InsertParent(Parent parent);
        bool UpdateParent(Parent parent);
        bool DeleteParent(Parent parent);
        List<Parent> GetParents();
        Parent GetParent(Guid? id);
        IEnumerable<Parent> Get(
         Expression<Func<Parent, bool>> filter = null,
         Func<IQueryable<Parent>, IOrderedQueryable<Parent>> orderBy = null,
         string includeProperties = "");
        List<Parent> FindBy(Expression<Func<Parent, bool>> predicate);
    }
}
