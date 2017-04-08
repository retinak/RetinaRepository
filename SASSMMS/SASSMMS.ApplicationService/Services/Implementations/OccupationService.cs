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
    public class OccupationService:IOccupationService
    {
        private UnitOfWork unitOfWork;

        public OccupationService()
        {
            unitOfWork=new UnitOfWork();
        }
     

        public bool InsertOccupation(Occupation occupation)
        {
            unitOfWork.OccupationRepository.Insert(occupation);
            return unitOfWork.Save();
        }

        public bool UpdateOccupation(Occupation occupation)
        {
            unitOfWork.OccupationRepository.Update(occupation);
            return unitOfWork.Save();
        }

        public bool DeleteOccupationn(Occupation occupation)
        {
           unitOfWork.OccupationRepository.Update(occupation);
            return unitOfWork.Save();
        }

        public List<Occupation> GetOccupations()
        {
            return unitOfWork.OccupationRepository.GetAll().ToList();
        }

        public Occupation GetOccupation(Guid? id)
        {
            return unitOfWork.OccupationRepository.GetById(id);
        }

        public IEnumerable<Occupation> Get(Expression<Func<Occupation, bool>> filter = null, Func<IQueryable<Occupation>, IOrderedQueryable<Occupation>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Occupation> FindBy(Expression<Func<Occupation, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
