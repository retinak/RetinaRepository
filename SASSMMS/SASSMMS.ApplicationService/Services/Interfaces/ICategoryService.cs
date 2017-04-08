using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface ICategoryService
    {
        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        List<Category> GetCategories();
        Category GetCategory(Guid id);
        IEnumerable<Category> Get(
         Expression<Func<Category, bool>> filter = null,
         Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
         string includeProperties = "");
        List<Category> FindBy(Expression<Func<Category, bool>> predicate);
    }
}
