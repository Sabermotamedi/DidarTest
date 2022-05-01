using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Entities
{
    public class Member
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string AccessMethod { get; set; }
        public Dictionary<string,int> AccessCount { get; set; }
    }
}
