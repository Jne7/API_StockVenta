using API_StockVenta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_StockVenta.Controllers
{

    [ApiController]  //Permite indicar que nuestro controlador usa los verbos Http para APis
    [Route("[controller]")] //Los métodos se ejecutan por medio de rutas
    public class ClientesController : Controller
    {
        //Variable que nos permite utilizar el ORM
        private readonly DbContextPuntoVenta _context = null;

        /// <summary>
        /// Constructor con parámetros recibe la referencia del ORM
        /// Para interactuar con el servidor de base datos
        /// </summary>
        /// <param name="contextPuntoVenta"></param>

        public ClientesController(DbContextPuntoVenta contextPuntoVenta)
        {
            _context = contextPuntoVenta;
        }

        [HttpGet("Listado")]
        public List<Cliente> Listado()
        {
            //Utilizando  el ORM  para leer todos los datos en tabla usuarios
            return _context.Clientes.ToList();
        }
        //Metodod encargado de buscar un cliente por medio del email
        [HttpGet("Buscar")]
        public Cliente Buscar(string cedula)
        {
            //Buscar el usuario por medio del ORM filtrado por su email
            var temp = _context.Clientes.FirstOrDefault(x => x.cedula.Equals(cedula));

            return temp;
        }

        //Metodo encargado de guardar un usuario, el metodo recibe todo un objecto como parametro
        [HttpPut("Guardar")]

        public async Task<string> Guardar(Cliente cliente)
        {
            //se guarda el object al catalogo
            await _context.Clientes.AddAsync(cliente);

            //se aplican los cambio 
            await _context.SaveChangesAsync();
            // se retorna un mensaje
            return "Cliente Guardado correctamente..";
        }
        [HttpDelete("Eliminar")]
        public async Task<string> Delete(string cedula)
        {
            var temp = await _context.Clientes.FirstOrDefaultAsync(x => x.cedula.Equals(cedula));

            _context.Clientes.Remove(temp);
            //se aplican los cambio 
            await _context.SaveChangesAsync();

            return $"Cliente eliminado: {temp.NombreCompleto} su identificacion {temp.cedula}";

        }
        //Metodo encargado de modofocar los datos de un usuario
        [HttpPut("Modificar")]
        public async Task<string> Modificar(Cliente cliente)
        {

            _context.Clientes.Update(cliente);

            //se aplican los cambio 
            await _context.SaveChangesAsync();

            return "Cliente modoficado correctamente...";

        }


    }
}
