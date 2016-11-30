using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public  interface IDivisionService
    {

        bool InsertDivision(Region division);
        bool UpdateDivision(Region division);
        //string GetCode();
        List<Region> GetDivisions();

    }
}
