using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        public DateTime DateTimePrice { get; set; }
    }
}
