using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IRegionService :IDisposable
    {
        bool Add(Region entity);
        bool Edit(Region entity);
        bool Delete(Region entity);
        List<Region> FindBy(Expression<Func<Region, bool>> predicate);
        //Region FindById(int Id);
        Region FindById(Guid?Id);
        IEnumerable<Region> Get(
           Expression<Func<Region, bool>> filter = null,
           Func<IQueryable<Region>, IOrderedQueryable<Region>> orderBy = null,
           string includeProperties = "");
        List<Region> GetAll();

        
    }
}
