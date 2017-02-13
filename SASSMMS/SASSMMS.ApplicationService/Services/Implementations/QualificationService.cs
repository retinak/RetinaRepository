using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class QualificationService :IQualificationService
    {
        private UnitOfWork unitOfWork;
        public QualificationService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertQualification(Qualification qualification)
        {
            unitOfWork.QualificationRepository.Insert(qualification);
            return unitOfWork.Save();
        }

        public bool UpdateQualification(Qualification qualification)
        {
            unitOfWork.QualificationRepository.Update(qualification);
            return unitOfWork.Save();
        }

        public bool DeleteQualification(Qualification qualification)
        {
            unitOfWork.QualificationRepository.Delete(qualification);
            return unitOfWork.Save();
        }

        public List<Qualification> GetQualifications()
        {
            return unitOfWork.QualificationRepository.GetAll().ToList();
        }

        public Qualification GetQualification(Guid? id)
        {
            return unitOfWork.QualificationRepository.GetById(id);
        }

        public IEnumerable<Qualification> Get(Expression<Func<Qualification, bool>> filter = null, Func<IQueryable<Qualification>, IOrderedQueryable<Qualification>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Qualification> FindBy(Expression<Func<Qualification, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
