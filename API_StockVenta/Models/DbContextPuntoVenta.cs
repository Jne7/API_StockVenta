using Microsoft.EntityFrameworkCore;
namespace API_StockVenta.Models
{
    public class DbContextPuntoVenta :DbContext
    {
        /// <summary>
        /// Constructor con parámetros recibe la referencia del ORM
        /// Permite interactura con el servidor de base datos
        /// :base(options) permite utilizar el constructor para la clase padre
        /// </summary>
        /// <param name="options"></param>
        public DbContextPuntoVenta(DbContextOptions<DbContextPuntoVenta> options) : base(options)
        {

        }


        //DbSet para manejar la tabla Productos

        public DbSet<Producto> Productos { get; set; }

        //DbSet para manejar la tabla Clientes
        public DbSet<Cliente> Clientes { get; set; }
    }
}
