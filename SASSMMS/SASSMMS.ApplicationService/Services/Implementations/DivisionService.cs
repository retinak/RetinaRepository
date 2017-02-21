using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class DivisionService:IDivisionService
    {
        readonly UnitOfWork unitOfWork =new UnitOfWork();

        public DivisionService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertDivision(Division division)
        {
           unitOfWork.DivisionRepository.Insert(division);
           return unitOfWork.Save();
        }

        public bool UpdateDivision(Division division)
        {
            unitOfWork.DivisionRepository.Update(division);
            return unitOfWork.Save();
        }
        
        public bool DeleteDivision(Division division)
        {
            unitOfWork.DivisionRepository.Delete(division);
            return unitOfWork.Save();

        }

        public List<Division> GetDivisions()
        {

            return unitOfWork.DivisionRepository.GetAll().ToList();
        }


        public Division FindById(Guid? Id)
        {
            return unitOfWork.DivisionRepository.GetById(Id);

        }

        public IEnumerable<Division> Get(Expression<Func<Division, bool>> filter = null, Func<IQueryable<Division>, IOrderedQueryable<Division>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
