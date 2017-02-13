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
    public class StatusService :IStatusService
    {
        private UnitOfWork unitOfWork;

        public StatusService()
        {
            unitOfWork=new UnitOfWork();
            
        }
        public bool InsertStatus(Status status)
        {
            unitOfWork.StatusRepository.Insert(status);
            return unitOfWork.Save();
        }

        public bool UpdateStatus(Status status)
        {
            unitOfWork.StatusRepository.Update(status);
            return unitOfWork.Save();
        }

        public bool DeleteStatus(Status status)
        {
            unitOfWork.StatusRepository.Delete(status);
            return unitOfWork.Save();
        }

        public List<Status> GetStatuses()
        {
            return unitOfWork.StatusRepository.GetAll().ToList();
        }

        public Status GetCategory(Guid id)
        {
            return unitOfWork.StatusRepository.GetById(id);
        }

        public IEnumerable<Status> Get(Expression<Func<Status, bool>> filter = null, Func<IQueryable<Status>, IOrderedQueryable<Status>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Status> FindBy(Expression<Func<Status, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
