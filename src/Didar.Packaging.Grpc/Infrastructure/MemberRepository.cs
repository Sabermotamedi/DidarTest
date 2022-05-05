using Didar.Packaging.Grpc.Entities;
using Didar.Packaging.Grpc.Infrastructure.Persistence;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Infrastructure
{

    public class MemberRepository : IMemberRepository
    {
        private readonly IPackagingDbContext _dbContext;

        public MemberRepository(IPackagingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Member member)
        {
            await _dbContext.Members.InsertOneAsync(member);
        }

        public async Task<bool> Delete(Guid id)
        {
            FilterDefinition<Member> filter = Builders<Member>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _dbContext.Members
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _dbContext.Members
                           .Find(p => true)
                           .ToListAsync();
        }

        public async Task<Member> GetById(Guid id)
        {
            return await _dbContext.Members
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Member>> GetByName(string name)
        {
            FilterDefinition<Member> filter = Builders<Member>.Filter.ElemMatch(p => p.Name, name);

            return await _dbContext.Members
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<Member> GetByNationalId(string nationalId)
        {
            FilterDefinition<Member> filter = Builders<Member>.Filter.ElemMatch(p => p.NationalCode, nationalId);

            return await _dbContext.Members
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Member member)
        {
            var updateResult = await _dbContext.Members
                                      .ReplaceOneAsync(filter: g => g.Id == member.Id, replacement: member);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
