using Didar.Packaging.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Infrastructure
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(string id);
        Task<Member> GetByNationalId(string nationalId);
        Task<IEnumerable<Member>> GetByName(string name);
        Task Create(Member product);
        Task<bool> Update(Member member);
        Task<bool> Delete(string id);
    }
}
