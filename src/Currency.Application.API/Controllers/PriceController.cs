using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Didar.Application.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly DateTime _date;

        public PriceController()
        {
            _date = DateTime.Now;
        }

        [HttpGet(Name =nameof(PriceController))]
        public int GetPrice(string priceName, DateTime? date)
        {
            date = _date;



            return 1;
        }
    }
}
