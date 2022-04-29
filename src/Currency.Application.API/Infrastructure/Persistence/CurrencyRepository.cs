using Didar.Application.API.Entities;
using Didar.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Infrastructure.Persistence
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public CurrencyViewModel GetCurrencyPrice(CurrencyTypes currencyTypes, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
