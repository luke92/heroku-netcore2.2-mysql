namespace UnitTestBancoNacion
{
    using System;
    using System.Collections.Generic;
    using WebApiBancoNacion.Models;
    using WebApiBancoNacion.Service;
    using Xunit;
    using WebApiBancoNacion.Modules;
    using Newtonsoft.Json;
    using System.Linq;

    public class BancoNacionService_InsertQuote_UnitTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IBancoNacionService _bancoNacionService;
        private readonly Endpoint endpoint;

        public BancoNacionService_InsertQuote_UnitTests()
        {
            _context = new InMemoryDbContextFactory().GetCotizacionDbContext();
            _bancoNacionService = new BancoNacionService(_context, endpoint);
        }

        [Fact]
        public void InsertCotizacionOk()
        {
            // Arrange
            JsonHttpPost json = SetJson();

            //Act
            string response = _bancoNacionService.InsertQuote(json);

            //Assert
            Assert.True(response == SetJsonResponse());
        }

        [Fact]
        public void InsertCotizacionIdBilleteErroneo()
        {
            // Arrange
            JsonHttpPost json = SetJsonErroneo();

            //Act
            string response = _bancoNacionService.InsertQuote(json);

            //Assert
            Assert.True(response == "ZERO");
        }

        private JsonHttpPost SetJson()
        {
            JsonHttpPost json = new JsonHttpPost()
            {
                id = "22",
                compra = 222,
                venta = 333
            };

            return json;
        }
        private JsonHttpPost SetJsonErroneo()
        {
            _context.Database.EnsureDeleted();
            Setup();
            _context.SaveChanges();

            JsonHttpPost json = new JsonHttpPost()
            {
                id = "25",
                compra = 333,
                venta = 222
            };

            return json;
        }

        private string SetJsonResponse()
        {
            _context.Database.EnsureDeleted();
            Setup();
            _context.SaveChanges();

            Cotizacion _cotizacion = new Cotizacion()
            {
                BilleteId = "22",
                PrecioCompra = string.Format("{0:0.00}", "222"),
                PrecioVenta = string.Format("{0:0.00}", "333"),
                FechaGuardado = DateTime.Now,
                FechaObtenido = DateTime.Now,
                Active = true
            };

            string json = JsonConvert.SerializeObject(_cotizacion);

            return json;
        }

        private void Setup()
        {
            if (_context.Billete.Count() > 0)
            {
                _context.Billete.AddRange(new List<Billete> {

                    new Billete(){BilleteID = "22", Descripcion = "Dolar U.S.A"},
                    new Billete(){BilleteID = "12", Descripcion = "Euro"},
                    new Billete(){BilleteID = "23", Descripcion = "Real (*)"}

                });

                _context.SaveChanges();
            }
        }

    }
}
