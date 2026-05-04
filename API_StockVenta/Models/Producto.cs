using System.ComponentModel.DataAnnotations;

namespace API_StockVenta.Models
{
    public class Producto
    {
        [Key]
        public string codigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal Impuesto { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaRegistro { get; set; }

        public char Estado { get; set; }
    }
}
