namespace UnitTestBancoNacion
{
    using System;
    using System.Collections.Generic;
    using WebApiBancoNacion.Models;
    using WebApiBancoNacion.Service;
    using Xunit;
    using WebApiBancoNacion.Modules;
    using System.Linq;

    public class BancoNacionService_GetQuotes_UnitTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IBancoNacionService _bancoNacionService;
        private readonly Endpoint _endpoint;

        public BancoNacionService_GetQuotes_UnitTests()
        {
            _context = new InMemoryDbContextFactory().GetCotizacionDbContext();
            _bancoNacionService = new BancoNacionService(_context, _endpoint);
        }
        [Fact]
        public void GetQuotesOneBillTodayOk()
        {
            // Arrange
            SetupOne();

            //Act
            JsonResponse response = _bancoNacionService.GetQuotes();

            //Assert
            Assert.True(response.Valores.Count == 1 );
        }

        [Fact]
        public void GetQuotesAllBillTodayOk()
        {
            // Arrange
            SetupAll();

            //Act
            JsonResponse response = _bancoNacionService.GetQuotes();

            //Assert
            Assert.True(response.Valores.Count == 3);
        }

        [Fact]
        public void GetQuotesZeroBillTodayOk()
        {
            // Arrange
            SetupZero();

            //Act
            JsonResponse response = _bancoNacionService.GetQuotes();

            //Assert
            Assert.True(response is null);
        }

        #region private

        private void SetupOne()
        {
            _context.Database.EnsureDeleted();
            Setup();

            _context.Cotizacion.AddRange(new List<Cotizacion> {
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "22", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "12", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "23", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = false },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "22", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now, FechaObtenido = DateTime.Now, Active = true }
            });

            _context.SaveChanges();
        }

        private void SetupAll()
        {
            _context.Database.EnsureDeleted();
            Setup();

            _context.Cotizacion.AddRange(new List<Cotizacion> {
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "22", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now, FechaObtenido = DateTime.Now, Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "12", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now, FechaObtenido = DateTime.Now, Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "22", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now, FechaObtenido = DateTime.Now, Active = true }
            });

            _context.SaveChanges();
        }
        private void SetupZero()
        {
            _context.Database.EnsureDeleted();
            Setup();

            _context.Cotizacion.AddRange(new List<Cotizacion> {
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "22", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "12", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = true },
                new Cotizacion(){ID = Guid.NewGuid().ToString(), BilleteId = "23", PrecioCompra = "111", PrecioVenta = "222", FechaGuardado = DateTime.Now.AddDays(-1), FechaObtenido = DateTime.Now.AddDays(-1), Active = true },
            });

            _context.SaveChanges();
        }

        private void Setup()
        {
            if(_context.Billete.Count() > 0)
            {
                _context.Billete.AddRange(new List<Billete> {

                    new Billete(){BilleteID = "22", Descripcion = "Dolar U.S.A"},
                    new Billete(){BilleteID = "12", Descripcion = "Euro"},
                    new Billete(){BilleteID = "23", Descripcion = "Real (*)"}

                });

                _context.SaveChanges();
            }
        }
        #endregion private
    }
}
