using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool InsertDivision(Region division)
        {
           unitOfWork.RegionRepository.Insert(division);
           return unitOfWork.Save();
        }

        public bool UpdateDivision(Region division)
        {
            unitOfWork.RegionRepository.Update(division);
            return unitOfWork.Save();
        }

        public List<Region> GetDivisions()
        {
            return unitOfWork.RegionRepository.GetAll().ToList();
        }
    }
}
