﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public  interface IWoredaService
    {
        bool InsertWoreda(Woreda woreda);
        bool UpdateWoreda(Woreda woreda);
        bool DeleteWoreda(Woreda woreda);
        Woreda GetWoreda(Guid? id);
        List<Woreda> GetWoredas();
        List<Woreda> FindBy(Expression<Func<Woreda, bool>> predicate);
        void Dispose();
    }
}
