using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SASSMMS.Domain.Entities;

namespace SASSMMS.ApplicationService.Services.Interfaces
{
    public interface IMemberService
    {
        bool InsertMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(Member member);
        List<Member> GetMembers();
        Member GetMember(Guid? id);
        IEnumerable<Member> Get(
         Expression<Func<Member, bool>> filter = null,
         Func<IQueryable<Member>, IOrderedQueryable<Member>> orderBy = null,
         string includeProperties = "");
        List<Member> FindBy(Expression<Func<Member, bool>> predicate);
    }
}
