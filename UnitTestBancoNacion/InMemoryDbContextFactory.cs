using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiBancoNacion.Models;

namespace UnitTestBancoNacion
{
    public class InMemoryDbContextFactory
    {
        public ApplicationDbContext GetCotizacionDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryBancoNacionDatabase")
                            .Options;


            var dbContext = new ApplicationDbContext(options);

            return dbContext;
        }
    }
}
