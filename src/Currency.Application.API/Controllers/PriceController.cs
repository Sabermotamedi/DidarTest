using Didar.Application.API.Entities;
using Didar.Application.API.Models;
using Didar.Application.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Didar.Application.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PriceController : ControllerBase
    {

        private readonly ICurrencyService _currencyService;

        public PriceController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet(Name = nameof(GetCurrencyPrice))]        
        public ActionResult<CurrencyViewModel> GetCurrencyPrice(string priceName)
        {
            var result = _currencyService.GetCurrencyPrice(priceName);
            if (result != null)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet(Name = nameof(GetCurrencyPricePerDate))]
        public ActionResult<CurrencyViewModel> GetCurrencyPricePerDate(string priceName, DateTime dateTime)
        {
            var result = _currencyService.GetCurrencyPricePerDate(priceName, dateTime);
            if (result != null)
                return Ok(result);
            return NotFound(result);
        }

    }
}
