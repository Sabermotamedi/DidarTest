using Didar.Packaging.Grpc.Entities;
using Didar.Packaging.Grpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Services.Interfaces
{
    public interface IMemberService
    {
        Task AddPlane(MemberModels memberModels);
        Task<bool> Upgradelane(string nationalCode, string payment, int validityDuration, Role role);
    }
}
