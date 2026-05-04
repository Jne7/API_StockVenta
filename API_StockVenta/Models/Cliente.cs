using System.ComponentModel.DataAnnotations;

namespace API_StockVenta.Models
{
    public class Cliente
    {
        [Key]
        public string cedula { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public decimal LimiteCredito { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public char Estado { get; set; }
    }
}
