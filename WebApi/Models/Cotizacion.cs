namespace WebApiBancoNacion.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Cotizacion
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string BilleteId { get; set; }

        [Required]
        public string PrecioCompra { get; set; }

        [Required]
        public string PrecioVenta { get; set; }

        [Required]
        public DateTime FechaObtenido { get; set; }

        [Required]
        public DateTime FechaGuardado { get; set; }

        public bool Active { get; set; }

        public Cotizacion()
        {

        }
    }
}
