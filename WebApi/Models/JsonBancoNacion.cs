using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBancoNacion.Models
{
    public class JsonBancoNacion
    {
        public bool PestaniaBilletesActiva { get; set; }
        public string FechaDivizas { get; set; }
        public string Divizas { get; set; }
        public List<BilleteBancoNacion> Billetes { get; set; }
        public string UltimaActualizacion { get; set; }
        public string FechaBilletes { get; set; }
    }

    public class BilleteBancoNacion
    {
        public string id_billete { get; set; }
        public string descripcion { get; set; }
        public string compra { get; set; }
        public string venta { get; set; }
        public bool home { get; set; }
        public bool historico { get; set; }
    }
}
