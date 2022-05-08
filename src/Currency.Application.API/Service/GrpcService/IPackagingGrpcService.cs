using Didar.Packaging.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Service.GrpcService
{
    public interface IPackagingGrpcService
    {
        public Task<AccessStatusResponse> HasUserAccessPerRole(string nationalCode, string methodName);
    }
}
