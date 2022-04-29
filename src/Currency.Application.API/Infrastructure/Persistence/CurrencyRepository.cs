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
        private readonly CurrencyBbContext _dbContext;

        public CurrencyRepository(CurrencyBbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CurrencyViewModel GetCurrencyPrice(CurrencyTypes currencyTypes, DateTime dateTime)
        {
            CurrencyViewModel currencyResponse = null;

            var currency = _dbContext.Currencies
                .FirstOrDefault(x => x.CurrencyType == currencyTypes && x.DateTimePrice.Date == dateTime.Date);

            if (currency != null)
                currencyResponse = new CurrencyViewModel()
                { CurrencyType = currency.CurrencyType.ToString(), DateTimePrice = currency.DateTimePrice, Price = currency.Price };

            return currencyResponse;
        }
    }
}
