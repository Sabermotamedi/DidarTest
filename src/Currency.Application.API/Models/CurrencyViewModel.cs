using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Models
{
    public class CurrencyViewModel
    {
        public string CurrencyType { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTimePrice { get; set; }
        public string ErrorMessage { get; set; }
    }
}
