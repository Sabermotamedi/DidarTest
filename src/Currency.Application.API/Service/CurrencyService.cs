using Didar.Application.API.Entities;
using Didar.Application.API.Infrastructure.Persistence;
using Didar.Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public CurrencyViewModel GetCurrencyPrice(CurrencyTypes currencyTypes)
        {
            var currency = _currencyRepository.GetCurrencyPrice(currencyTypes, DateTime.Now);
            return currency;
        }

        public CurrencyViewModel GetCurrencyPricePerDate(CurrencyTypes currencyTypes, DateTime dateTime)
        {
            var currency = _currencyRepository.GetCurrencyPrice(currencyTypes, dateTime);
            return currency;
        }
    }
}
