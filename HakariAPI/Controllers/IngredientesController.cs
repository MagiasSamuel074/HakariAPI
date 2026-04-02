using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HakariAPI.Data; //carpeta de conexion a DB
using HakariAPI.Models; //obteniendo datos de las tablas
using Microsoft.EntityFrameworkCore;

namespace HakariAPI.Controllers
{
    [Route("api/[controller]")] //la direccion en internet sera: api/ingredientes.
    [ApiController]
    public class IngredientesController : ControllerBase
    {
       //se declara aqui el campo privado para almacenar el contexto de la base de datos.
        private readonly AppDbContext _context;

        //Aqui le pedimos a Program.cs que nos preste la conexion a DB para almacenarlo o inyectarlo al campo
        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/ingredientes
        //Equivalente a SELECT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            //Equivalente a SELECT * FROM Ingredientes;
            return await _context.Ingredientes.ToListAsync();
        }

        //Equivalente a INSERT INTO
        //POST: api/ingredientes
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente (Ingrediente nuevoIngrediente)
        {

            //Le decimos a EF que procese la info de este objeto para la tabla ingreidientes
            _context.Ingredientes.Add(nuevoIngrediente);

            //se guarda en la tabla y es equivalente a COMMIT en SQL
            await _context.SaveChangesAsync();

           // Respondemos que se creó con éxito y mandamos el objeto de vuelta
            return CreatedAtAction(nameof(GetIngredientes), new { id = nuevoIngrediente.Idingrediente }, nuevoIngrediente);
        }
    }
}
