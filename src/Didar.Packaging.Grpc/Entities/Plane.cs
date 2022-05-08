using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Packaging.Grpc.Entities
{
    public class Plan
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public Dictionary<string, int> AccessCount { get; set; }        
    }
}
