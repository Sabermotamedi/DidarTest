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

        public CurrencyViewModel GetCurrencyPrice(string currencyTypes)
        {
            try
            {
                var currency = _currencyRepository.GetCurrencyPrice(Enum.Parse<CurrencyTypes>(currencyTypes.ToUpper()), DateTime.Now);
                return currency;
            }
            catch (Exception ex)
            {
                return new CurrencyViewModel() { ErrorMessage = ex.Message };
            }

        }

        public CurrencyViewModel GetCurrencyPricePerDate(string currencyTypes, DateTime dateTime)
        {
            try
            {
                var currency = _currencyRepository.GetCurrencyPrice(Enum.Parse<CurrencyTypes>(currencyTypes.ToUpper()), dateTime);
                return currency;
            }
            catch (Exception ex)
            {
                return new CurrencyViewModel() { ErrorMessage = ex.Message };
            }
        }
    }
}
