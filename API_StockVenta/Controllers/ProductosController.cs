using API_StockVenta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_StockVenta.Controllers
{
    [ApiController]  //Permite indicar que nuestro controlador usa los verbos Http para APis
    [Route("[controller]")] //Los métodos se ejecutan por medio de rutas
    public class ProductosController : Controller
    {
        //Variable que nos permite utilizar el ORM
        private readonly DbContextPuntoVenta _context = null;

        /// <summary>
        /// Constructor con parámetros recibe la referencia del ORM
        /// Para interactuar con el servidor de base datos
        /// </summary>
        /// <param name="contextPuntoVenta"></param>
        public ProductosController(DbContextPuntoVenta contextPuntoVenta)
        {
            _context = contextPuntoVenta;
        }

        /// <summary>
        /// Método encargado de  extraer los productos almacenados en la DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listado")]
        public List<Producto> Listado()
        {
            //Utilizando  el ORM  para leer todos los datos en tabla usuarios
            return _context.Productos.ToList();
        }
        //Metodod encargado de buscar un usuario por medio del email
        [HttpGet("Buscar")]
        public Producto Buscar(string codigobarra)
        {
            //Buscar el usuario por medio del ORM filtrado por su email
            var temp = _context.Productos.FirstOrDefault(x => x.codigoBarra.Equals(codigobarra));

            return temp;
        }
        //Metodo encargado de guardar un usuario, el metodo recibe todo un objecto como parametro
        [HttpPut("Guardar")]

        public async Task<string> Guardar(Producto producto)
        {
            //se guarda el object al catalogo
            await _context.Productos.AddAsync(producto);

            //se aplican los cambio 
            await _context.SaveChangesAsync();
            // se retorna un mensaje
            return "Producto almacenado correctamente..";
        }

        [HttpDelete("Eliminar")]
        public async Task<string> Delete(string codigobarra)
        {
            var temp = await _context.Productos.FirstOrDefaultAsync(x => x.codigoBarra.Equals(codigobarra));

            _context.Productos.Remove(temp);
            //se aplican los cambio 
            await _context.SaveChangesAsync();

            return $"Producto eliminado: {temp.Descripcion} su codigo {temp.codigoBarra}";

        }
        //Metodo encargado de modofocar los datos de un usuario
        [HttpPut("Modificar")]
        public async Task<string> Modificar(Producto producto)
        {

            _context.Productos.Update(producto);

            //se aplican los cambio 
            await _context.SaveChangesAsync();

            return "Producto modoficado correctamente...";

        }
    }
}
