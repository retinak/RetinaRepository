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
   public class ApplicantService : IApplicantInterface

   {
       private UnitOfWork unitOfWork;

       public ApplicantService()
       {
           unitOfWork=new UnitOfWork();
       }
       public void InsertApplicant(Applicant applicant)
       {
            unitOfWork.ApplicantRepository.Insert(applicant);
       }

       public void UpdateApplicant(Applicant applicant)
       {
           unitOfWork.ApplicantRepository.Update(applicant);
       }

       public void DeleteApplicant(Guid applicantId)
       {
          unitOfWork.ApplicantRepository.Delete(applicantId);
       }

       public List<Applicant> GetApplicantss()
       {
           return unitOfWork.ApplicantRepository.GetAll().ToList();
       }
    }
}
