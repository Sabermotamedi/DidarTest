using Didar.Packaging.Grpc.Models;
using Didar.Packaging.Grpc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UpgradeController : Controller
    {
        private readonly IMemberService _memberService;

        public UpgradeController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPut]
        public async Task<IActionResult> UpgradePlane([FromBody] MemberModels request)
        {
            var result = await _memberService.Upgradelane(request.NationalCode, "TEST001", request.ValidityDuration, request.Role);
            return Ok(result);
        }

        [HttpPost]
        public async Task AddPlane([FromBody] MemberModels request)
        {
            await _memberService.AddPlane(request);
        }
    }
}
