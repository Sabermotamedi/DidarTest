using Didar.Application.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  

namespace Didar.Application.API.Infrastructure.Persistence
{
    public class CurrencyBbContext : DbContext
    {
        public CurrencyBbContext( DbContextOptions<CurrencyBbContext> options): base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }


    }
}
