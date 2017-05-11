using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.ApplicationService.Services.Interfaces;
using SASSMMS.Domain.Entities;
using SASSMMS.Repository;

namespace SASSMMS.ApplicationService.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly UnitOfWork unitOfWork;

        public MemberService()
        {
            unitOfWork=new UnitOfWork();
        }
        public List<Member> FindBy(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Get(Expression<Func<Member, bool>> filter = null, 
            Func<IQueryable<Member>, IOrderedQueryable<Member>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Member GetMember(Guid? id)
        {
            return unitOfWork.MemberRepository.GetById(id);
        }

      

        

        public bool DeleteMember(Member member)
        {
            unitOfWork.MemberRepository.Delete(member);
            return unitOfWork.Save();
        }

        public List<Member> GetMembers()
        {
            return unitOfWork.MemberRepository.GetAll().ToList();
        }

        public bool InsertMember(Member member)
        {
            unitOfWork.MemberRepository.Insert(member);
            return unitOfWork.Save();
        }

        public bool UpdateMember(Member member)
        {
            unitOfWork.MemberRepository.Update(member);
            return unitOfWork.Save();
        }
    }
}
