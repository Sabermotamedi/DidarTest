using Didar.Application.API.Models;
using Didar.Packaging.Grpc;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Service.GrpcService
{
    public class PackagingGrpcService : IPackagingGrpcService
    {
        private readonly PackagingProtoService.PackagingProtoServiceClient _packagingService;

        public PackagingGrpcService(PackagingProtoService.PackagingProtoServiceClient packagingService)
        {
            _packagingService = packagingService;
        }

        public async Task<AccessStatusResponse> HasUserAccessPerRole(string nationalCode, string methodName)
        {
            var requestModel = new UserRequest() { NationalCode = nationalCode, MethodName = methodName };

            var result =  _packagingService.HasUserAccessPerRole(requestModel, null);
            return result;
        }


    }
}
