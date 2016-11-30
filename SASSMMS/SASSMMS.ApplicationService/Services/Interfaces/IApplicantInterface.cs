using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IApplicantInterface
    {

        void InsertApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        //string GetCode();
        void DeleteApplicant(Guid applicantId);
        List<Applicant> GetApplicantss();
    }
}
