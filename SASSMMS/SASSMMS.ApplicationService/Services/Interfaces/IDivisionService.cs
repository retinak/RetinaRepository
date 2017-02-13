using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public  interface IDivisionService
    {

        bool InsertDivision(Division division);
        bool UpdateDivision(Division division);
        bool DeleteDivision(Division division);
        //string GetCode();
        List<Division> GetDivisions();
        
        Division FindById(Guid? Id);
        IEnumerable<Division> Get(
           Expression<Func<Division, bool>> filter = null,
           Func<IQueryable<Division>, IOrderedQueryable<Division>> orderBy = null,
           string includeProperties = "");

        void Dispose();
    }
}
