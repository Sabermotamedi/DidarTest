using Didar.Application.API.Entities;
using Didar.Application.API.Models;
using System;

namespace Didar.Application.API.Service
{
    public interface ICurrencyService
    {
        public CurrencyViewModel GetCurrencyPrice(string currencyTypes);
        public CurrencyViewModel GetCurrencyPricePerDate(string currencyTypes, DateTime dateTime);
    }
}