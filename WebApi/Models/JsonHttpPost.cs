using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBancoNacion.Models
{
    public class JsonHttpPost
    {
        public string id { get; set; }
        public decimal compra { get; set; }
        public decimal venta { get; set; }
    }
}
