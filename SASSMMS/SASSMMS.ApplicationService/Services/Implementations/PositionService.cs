using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class PositionService:IPositionService
    {
        private UnitOfWork unitOfWork;
        public PositionService()
        {
            unitOfWork = new UnitOfWork();
        }
        public bool InsertPosition(Position position)
        {
            unitOfWork.PositionRepository.Insert(position);
            return unitOfWork.Save();
        }

        public bool UpdatePosition(Position position)
        {
            unitOfWork.PositionRepository.Update(position);
            return unitOfWork.Save();
        }

        public bool DeletePosition(Position position)
        {
            unitOfWork.PositionRepository.Delete(position);
            return unitOfWork.Save();
        }

        public List<Position> GetPositions()
        {
            return unitOfWork.PositionRepository.GetAll().ToList();
        }

        public Position GetPosition(Guid? id)
        {
            return unitOfWork.PositionRepository.GetById(id);
        }

        public IEnumerable<Qualification> Get(Expression<Func<Position, bool>> filter = null, Func<IQueryable<Position>, IOrderedQueryable<Position>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> Get(Expression<Func<Position, bool>> filter = null, Func<IQueryable<Qualification>, IOrderedQueryable<Qualification>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Position> FindBy(Expression<Func<Position, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

