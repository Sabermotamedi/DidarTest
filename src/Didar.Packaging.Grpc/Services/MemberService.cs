using Didar.Packaging.Grpc.Entities;
using Didar.Packaging.Grpc.Infrastructure;
using Didar.Packaging.Grpc.Models;
using Didar.Packaging.Grpc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task AddPlane(MemberModels memberModels)
        {
            var dtNow = DateTime.Now;
            var plan = GetPlaneByRoel(memberModels.Role);
            Member member = new Member(memberModels.Name,
                memberModels.Family,
                memberModels.NationalCode,
                memberModels.Role,
                memberModels.ValidityDuration,
                plan.AccessCount, "");
            var res = _memberRepository.GetAll();
            await _memberRepository.Create(member);

        }
        public async Task<bool> Upgradelane(string nationalCode, string payment, int validityDuration, Role role)
        {
           // var res = await _memberRepository.GetAll();

            var member = await _memberRepository.GetByNationalId(nationalCode);

            var plan = GetPlaneByRoel(role);
            member.UpdateMember(role, validityDuration, plan.AccessCount, payment);
            var result = await _memberRepository.Update(member);
            return result;
        }

        private Plan GetPlaneByRoel(Role role)
        {
            //It can generate from database 
            Plan plan = role switch
            {
                Role.Free => new Plan() { Id = 0, Name = "Free", AccessCount = new Dictionary<string, int>() { { "GetCurrencyPrice", 10 }, { "GetCurrencyPricePerDate", 0 } } },
                Role.Bronze => new Plan() { Id = 1, Name = "Bronze", AccessCount = new Dictionary<string, int>() { { "GetCurrencyPrice", 100 }, { "GetCurrencyPricePerDate", 0 } } },
                Role.Silver => new Plan() { Id = 2, Name = "Silver", AccessCount = new Dictionary<string, int>() { { "GetCurrencyPrice", 500 }, { "GetCurrencyPricePerDate", 1000 } } },
                Role.Gold => new Plan() { Id = 3, Name = "Gold", AccessCount = new Dictionary<string, int>() { { "GetCurrencyPrice", 1000 }, { "GetCurrencyPricePerDate", 2000 } } },
                _ => new Plan() { Id = 0, Name = "Free", AccessCount = new Dictionary<string, int>() { { "GetCurrencyPrice", 10 }, { "GetCurrencyPricePerDate", 0 } } },
            };
            return plan;
        }
    }
}
