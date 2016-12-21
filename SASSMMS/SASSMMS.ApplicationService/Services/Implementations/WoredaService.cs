using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class WoredaService :IWoredaService
    {
        private readonly UnitOfWork unitOfWork;

        public WoredaService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool InsertWoreda(Woreda woreda)
        {
          unitOfWork.WoredaRepository.Insert(woreda);
            return unitOfWork.Save();
        }

        public bool UpdateWoreda(Woreda woreda)
        {
            unitOfWork.WoredaRepository.Update(woreda);
            return unitOfWork.Save();
        }

        public bool DeleteWoreda(Woreda woreda)
        {
            unitOfWork.WoredaRepository.Delete(woreda);
            return unitOfWork.Save();
        }

        public Woreda GetWoreda(Guid? id)
        {
            return unitOfWork.WoredaRepository.GetById(id);
        }

        public IEnumerable<Woreda> GetWoredas()
        {
            return unitOfWork.WoredaRepository.GetAll().ToList();
        }

        public List<Woreda> FindBy(Expression<Func<Woreda, bool>> predicate)
        {
            return unitOfWork.WoredaRepository.Get(predicate).ToList();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
