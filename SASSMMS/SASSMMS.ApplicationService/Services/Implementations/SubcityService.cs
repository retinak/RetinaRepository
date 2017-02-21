using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class SubcityService :ISubcityService
    {
        private UnitOfWork unitOfWork;

        public SubcityService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertSubcity(Subcity subcity)
        {
            unitOfWork.SubcityRepository.Insert(subcity);
            return unitOfWork.Save();
        }

        public bool UpdateSubcity(Subcity subcity)
        {
            unitOfWork.SubcityRepository.Update(subcity);
            return unitOfWork.Save();
        }

        public bool DeleteSubcity(Subcity subcity)
        {
          unitOfWork.SubcityRepository.Delete(subcity);
            return unitOfWork.Save();
        }

        public Subcity GetSubcity(Guid ? id)
        {
            return unitOfWork.SubcityRepository.GetById(id);
        }

        public List<Subcity> FindBy(Expression<Func<Subcity, bool>> predicate)
        {
            return unitOfWork.SubcityRepository.Get(predicate).ToList();
        }

        public IEnumerable<Subcity> Get(Expression<Func<Subcity, bool>> filter = null,
            Func<IQueryable<Subcity>, IOrderedQueryable<Subcity>> orderBy = null, string includeProperties = "")
        {
            return unitOfWork.SubcityRepository.Get(filter).ToList();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public List<Subcity> GeSubcities()
        {
            return unitOfWork.SubcityRepository.GetAll().ToList();
        }
    }
}
