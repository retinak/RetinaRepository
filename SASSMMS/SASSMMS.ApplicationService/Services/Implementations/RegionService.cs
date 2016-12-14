﻿using System;
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
    public class RegionService :IRegionService
    {
        private UnitOfWork unitOfWork;
        public RegionService()
        {
            unitOfWork=new UnitOfWork();
        }
        public bool Add(Region entity)
        {

            unitOfWork.RegionRepository.Insert(entity);

            return unitOfWork.Save();
        }

        public bool Edit(Region entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Region entity)
        {
            throw new NotImplementedException();
        }

        public List<Region> FindBy(Expression<Func<Region, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        //public Region FindById(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        public Region FindById(Guid? Id)
        {
            return unitOfWork.RegionRepository.GetById(Id);
        }

        public IEnumerable<Region> Get(Expression<Func<Region, bool>> filter = null, Func<IQueryable<Region>, IOrderedQueryable<Region>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public List<Region> GetAll()
        {
            return unitOfWork.RegionRepository.GetAll().ToList();
        }
    }
}
