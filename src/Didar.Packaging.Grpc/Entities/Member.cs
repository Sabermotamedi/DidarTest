using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Entities
{
    public class Member
    {
        public Member()
        {

        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [BsonElement("NationalCode")]
        public string NationalCode { get; set; }
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }    
        public Dictionary<string,int> AccessCount { get; set; }
        public string PaymentInformation { get; set; }

        public Member(string name, string family, string nationalCode, Role role, int validityDuration, Dictionary<string, int> accessCount, string paymentInformation)
        {    
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            Role = role;
            StartDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(validityDuration);          
            AccessCount = accessCount;
            PaymentInformation = paymentInformation;
        }

        public void UpdateMember(Role role, int validityDuration, Dictionary<string, int> accessCount, string paymentInformation)
        {
            Role = role;
            StartDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(validityDuration);
            AccessCount = accessCount;
            PaymentInformation = paymentInformation;
        }

    }
}
