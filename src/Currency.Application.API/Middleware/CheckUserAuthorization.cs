using Didar.Application.API.Service.GrpcService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Middleware
{
    public class CheckUserAuthorization
    {
        private readonly RequestDelegate _next;
        private readonly IPackagingGrpcService _packagingService;

        public CheckUserAuthorization(RequestDelegate next, IPackagingGrpcService packagingGrpcService)
        {
            _next = next;
            _packagingService = packagingGrpcService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //CheckUser Validate
            var result = await _packagingService.HasUserAccessPerRole("0080854631", "GetCurrencyPrice");

            if (!result.HasAccess)
            {
                //Return message
                return;
            }      

            await _next(httpContext);
   
            //Send message to packaging IF result is true

        }
    }

    public static class CheckUserAuthorizationExtensions
    {
        public static IApplicationBuilder UseCheckUserAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckUserAuthorization>();
        }
    }
}
