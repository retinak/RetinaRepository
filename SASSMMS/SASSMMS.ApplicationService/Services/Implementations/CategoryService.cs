using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class CategoryService :ICategoryService
    {
        private UnitOfWork unitOfWork;

        public CategoryService()
        {
            unitOfWork=new UnitOfWork();
        }
      

        public bool InsertCategory(Category category)
        {
            unitOfWork.CategoryRepository.Insert(category);
            return unitOfWork.Save();
        }

        public bool UpdateCategory(Category category)
        {
            unitOfWork.CategoryRepository.Update(category);
            return unitOfWork.Save();
        }

        public bool DeleteCategory(Category category)
        {
            unitOfWork.CategoryRepository.Delete(category);
            return unitOfWork.Save();
        }

        public List<Category> GetCategories()
        {
            return unitOfWork.CategoryRepository.GetAll().ToList();
        }

        public Category GetCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(Guid ? id)
        {
            return unitOfWork.CategoryRepository.GetById(id);
        }

        public IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Category> FindBy(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
