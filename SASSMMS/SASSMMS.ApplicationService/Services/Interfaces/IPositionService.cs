using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IPositionService
    {
        bool InsertPosition(Position position);
        bool UpdatePosition(Position position);
        bool DeletePosition(Position position);
        List<Position> GetPositions();
        Position GetPosition(Guid? id);
        IEnumerable<Qualification> Get(
         Expression<Func<Position, bool>> filter = null,
         Func<IQueryable<Position>, IOrderedQueryable<Position>> orderBy = null,
         string includeProperties = "");
        List<Position> FindBy(Expression<Func<Position, bool>> predicate);
    }
}
