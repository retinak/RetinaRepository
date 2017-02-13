using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IStatusService
    {
        bool InsertStatus(Status status);
        bool UpdateStatus(Status status);
        bool DeleteStatus(Status status);
        List<Status> GetStatuses();
        Status GetCategory(Guid id);
        IEnumerable<Status> Get(
         Expression<Func<Status, bool>> filter = null,
         Func<IQueryable<Status>, IOrderedQueryable<Status>> orderBy = null,
         string includeProperties = "");
        List<Status> FindBy(Expression<Func<Status, bool>> predicate);
    }
}
