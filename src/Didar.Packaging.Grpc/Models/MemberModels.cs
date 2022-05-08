using Didar.Packaging.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Models
{
    public class MemberModels
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public Role  Role { get; set; }
        public int ValidityDuration { get;  set; }
    }
}
