using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBancoNacion.Models
{
    public class JsonResponse
    {
        public string Fecha { get; set; }
        public List<Valor> Valores { get; set; }

    }

    public class Valor
    {
        public string Billete { get; set; }
        public string Compra { get; set; }
        public string Venta { get; set; }
    }
}
