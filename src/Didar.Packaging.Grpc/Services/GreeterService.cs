using Didar.Packaging.Grpc.Entities;
using Didar.Packaging.Grpc.Infrastructure;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc
{
    public class GreeterService : PackagingProtoService.PackagingProtoServiceBase
    {
        private readonly IMemberRepository _memberRepository;

        public GreeterService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public override async Task<AccessStatusResponse> HasUserAccessPerRole(UserRequest request, ServerCallContext context)
        {
            var result = new AccessStatusResponse() { HasAccess = false };
            Member member = await _memberRepository.GetByNationalId(request.NationalCode);

            if (member != null)
            {
                var methodName = member.AccessCount.FirstOrDefault(x => x.Key == request.MethodName);

                if (member.Role == Role.Free)
                {
                    if (methodName.Key == "GetCurrencyPrice" && methodName.Value <= 10)
                    {
                        result.HasAccess = true;
                    }
                    if (methodName.Key == "GetCurrencyPricePerDate")
                    {
                        result.HasAccess = false;
                    }
                }
                else if (member.Role == Role.Bronze)
                {
                    if (methodName.Key == "GetCurrencyPrice" && methodName.Value <= 100)
                    {
                        result.HasAccess = true;
                    }
                    if (methodName.Key == "GetCurrencyPricePerDate")
                    {
                        result.HasAccess = false;
                    }
                }
                else if (member.Role == Role.Silver)
                {
                    if (methodName.Key == "GetCurrencyPrice" && methodName.Value <= 500)
                    {
                        result.HasAccess = true;
                    }
                    if (methodName.Key == "GetCurrencyPricePerDate" && methodName.Value <= 1000)
                    {
                        result.HasAccess = true;
                    }
                }
                else if (member.Role == Role.Gold)
                {
                    if (methodName.Key == "GetCurrencyPrice" && methodName.Value <= 1000)
                    {
                        result.HasAccess = true;
                    }
                    if (methodName.Key == "GetCurrencyPricePerDate" && methodName.Value <= 2000)
                    {
                        result.HasAccess = true;
                    }
                }
            }
            else
            {
                result.HasAccess = false;
            }
            return result;
        }
    }
}
