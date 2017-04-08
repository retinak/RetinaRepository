using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class SchoolService:ISchoolService
    {
        UnitOfWork unitOfWork;

        public SchoolService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertSchool(School school)
        {
            unitOfWork.SchoolRepository.Insert(school);
            return unitOfWork.Save();
        }

        public bool UpdateSchool(School school)
        {
           unitOfWork.SchoolRepository.Update(school);
            return unitOfWork.Save();
        }

        public bool DeleteSchool(School school)
        {
           unitOfWork.SchoolRepository.Delete(school);
            return unitOfWork.Save();
        }

        public School GetSchool(Guid? id)
        {
            return  unitOfWork.SchoolRepository.GetById(id);
        }

        public List<School> GetSchools()
        {
            return unitOfWork.SchoolRepository.GetAll().ToList();
        }

        public List<School> FindBy(Expression<Func<School, bool>> predicate)
        {
           throw new NotImplementedException();
        }

        public IEnumerable<School> Get(Expression<Func<School, bool>> filter = null, Func<IQueryable<School>, IOrderedQueryable<School>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
