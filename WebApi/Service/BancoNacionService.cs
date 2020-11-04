namespace WebApiBancoNacion.Modules
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using WebApiBancoNacion.Models;
    using WebApiBancoNacion.Service;
    using WebApiBancoNacion.Helpers;

    public class BancoNacionService : IBancoNacionService
    {
        private readonly ApplicationDbContext _context;
        private readonly Endpoint _endpoint;

        public BancoNacionService(ApplicationDbContext context, Endpoint endpoint) 
        {
            _context = context;
            _endpoint = endpoint;
        }

        public async Task<string> UpdateQuotesAsync()
        {
            try
            {
                List<Cotizacion> cotizaciones = new List<Cotizacion>();
                HttpClient client = new HttpClient();
                JsonBancoNacion json = new JsonBancoNacion();
                BancoNacionHelper helper = new BancoNacionHelper(_context);

                HttpResponseMessage response = await client.GetAsync(_endpoint.Url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    json = JsonConvert.DeserializeObject<JsonBancoNacion>(result);

                    cotizaciones = helper.SetCotizacion(json);
                    _context.Cotizacion.AddRange(cotizaciones);
                    _context.SaveChanges();


                    return "OK";    
                }
                else
                {
                    return "Ocurrió un error al guardar la cotización";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string InsertQuote(JsonHttpPost cotizacion)
        {
            try
            {
                BancoNacionHelper helper = new BancoNacionHelper(_context);

                Billete billete = helper.GetBilleteById(cotizacion.id);

                if (billete is null)
                {
                    return "ZERO";
                }
                else
                {
                    helper.UpdateCotizacionActive(billete.BilleteID);

                    Cotizacion _cotizacion = new Cotizacion()
                    {
                        BilleteId = cotizacion.id,
                        PrecioCompra = string.Format("{0:0.00}", cotizacion.compra),
                        PrecioVenta = string.Format("{0:0.00}", cotizacion.venta),
                        FechaGuardado = DateTime.Now,
                        FechaObtenido = DateTime.Now,
                        Active = true
                    };

                    _context.Cotizacion.Add(_cotizacion);
                    _context.SaveChanges();

                    string json = JsonConvert.SerializeObject(_cotizacion);

                    return json;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public JsonResponse GetQuotes()
        {
            try
            {
                List<Cotizacion> cotizacion = new List<Cotizacion>();
                List<Valor> lstValor = new List<Valor>();
                BancoNacionHelper helper = new BancoNacionHelper(_context);
                DateTime fecha = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:SS"), "yyyy-MM-dd HH:mm:SS", null);

                cotizacion = _context.Cotizacion.Where(x => x.Active == true && x.FechaGuardado.Date == fecha.Date).ToList();

                if (cotizacion?.Any() != true)
                {
                    return null;           
                }
                else
                {
                    cotizacion.ForEach(delegate (Cotizacion num) {
                        lstValor.Add(new Valor()
                        {
                            Billete = helper.GetBilleteById(num.BilleteId).Descripcion,
                            Compra = string.Format("{0:0.00}", num.PrecioCompra),
                            Venta = string.Format("{0:0.00}", num.PrecioVenta)
                        });
                    });

                    JsonResponse json = new JsonResponse()
                    {
                        Fecha = fecha.ToString("dd-MM-yyyy"),
                        Valores = lstValor
                    };

                    return json;
                }                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
