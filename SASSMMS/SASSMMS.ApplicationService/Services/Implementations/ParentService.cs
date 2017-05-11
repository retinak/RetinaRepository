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
    public class ParentService :IParentService
    {
        private UnitOfWork unitOfWork;

        public ParentService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertParent(Parent parent)
        {
            unitOfWork.ParentRepository.Insert(parent);
            return unitOfWork.Save();
        }

        public bool UpdateParent(Parent parent)
        {
            unitOfWork.ParentRepository.Update(parent);
            return unitOfWork.Save();
        }

        public bool DeleteParent(Parent parent)
        {
            unitOfWork.ParentRepository.Delete(parent);
            return unitOfWork.Save();
        }

        public List<Parent> GetParents()
        {
            return unitOfWork.ParentRepository.GetAll().ToList();
        }

        public Parent GetParent(Guid? id)
        {
            return unitOfWork.ParentRepository.GetById(id);
        }

        public IEnumerable<Parent> Get(Expression<Func<Parent, bool>> filter = null, Func<IQueryable<Parent>, IOrderedQueryable<Parent>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Parent> FindBy(Expression<Func<Parent, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
