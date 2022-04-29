using Didar.Application.API.Entities;
using Didar.Application.API.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Service
{
    public class CurrencyService
    {
        private readonly CurrencyBbContext _dbContext;

        public CurrencyService(CurrencyBbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Currency GetCurrencyPrice(CurrencyTypes currencyTypes, DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                dateTime = DateTime.Now;
            
            var currency =  _dbContext.Currencies
                .FirstOrDefault(x => x.CurrencyType == currencyTypes && x.DateTimePrice == dateTime);

            return currency;            
        }
    }
}
