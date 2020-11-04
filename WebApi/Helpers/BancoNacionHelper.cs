namespace WebApiBancoNacion.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiBancoNacion.Models;

    public class BancoNacionHelper
    {
        private readonly ApplicationDbContext _context;
        public BancoNacionHelper( ApplicationDbContext context)
        {
            _context = context;
    }
        public Billete GetBilleteById(string id)
        {
            Billete billete = _context.Billete.Where(x => x.BilleteID == id).FirstOrDefault();

            return billete;
        }

        public List<Cotizacion> SetCotizacion(JsonBancoNacion json)
        {
            List<Cotizacion> lstCotizaciones = new List<Cotizacion>();



            json.Billetes.ForEach(delegate (BilleteBancoNacion billete) {

                UpdateCotizacionActive(billete.id_billete);

                lstCotizaciones.Add(new Cotizacion
                {
                    ID = Guid.NewGuid().ToString(),
                    BilleteId = billete.id_billete,
                    PrecioCompra = billete.compra,
                    PrecioVenta = billete.venta,
                    FechaGuardado = DateTime.Now,
                    FechaObtenido = FormatDate(json.FechaBilletes),
                    Active = true
                });
            });

            return lstCotizaciones;
        }

        public void UpdateCotizacionActive(string BilleteID)
        {
            Cotizacion cotizacion = _context.Cotizacion.Where(x => x.Active == true && x.BilleteId == BilleteID).FirstOrDefault();

            if(cotizacion != null)
            {
                cotizacion.Active = false;
                _context.Cotizacion.Update(cotizacion);
                _context.SaveChanges();
            }

        }

        private DateTime FormatDate (string stringDate)
        {
            DateTime date = new DateTime();

            string strDate = stringDate.Split('-', StringSplitOptions.RemoveEmptyEntries).First().Trim();
            if(strDate.Count() < 10)
            {
                string day = strDate.Split('/', StringSplitOptions.RemoveEmptyEntries).First().Trim();
                string month = strDate.Split('/')[1];
                
                if (day.Count() < 2)
                    day = string.Concat("0", day);

                if (month.Count() < 2)
                    month = string.Concat("0", month);

                string dayMonth = string.Concat(day, "/", month);

                strDate = string.Concat(dayMonth,"/", strDate.Split('/')[2]);

            }

            string strTime = stringDate.Split('-')[1];

            stringDate = string.Concat(strDate, strTime);
            stringDate = stringDate.Substring(0, stringDate.Count() - 3);
            stringDate = stringDate.Replace('/', '-');

            date = DateTime.ParseExact(stringDate, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            return date;
        }

    }
}
