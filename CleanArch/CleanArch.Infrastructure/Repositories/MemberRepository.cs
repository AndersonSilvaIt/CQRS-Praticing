using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbContext _db;

        public MemberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Member> GetMemberById(int id)
        {
            var member = await _db.Members.FindAsync(id);

            if (member == null)
                throw new ArgumentNullException(nameof(member));

            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var memberList = await _db.Members.ToListAsync();

            return memberList ?? Enumerable.Empty<Member>();
        }

        public async Task<Member> AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            await _db.Members.AddAsync(member);
            return member;
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            _db.Members.Update(member);
        }

        public async Task<Member> DeleteMember(int id)
        {
            var member = await GetMemberById(id);

            if (member == null)
                throw new InvalidOperationException("member not found");

            _db.Members.Remove(member);
            return member;
        }
    }
}
