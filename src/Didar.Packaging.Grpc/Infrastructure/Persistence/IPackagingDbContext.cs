using Didar.Packaging.Grpc.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Infrastructure.Persistence
{
    public interface IPackagingDbContext
    {
        public IMongoCollection<Member> Members { get; }
    }
}
