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
        public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente nuevoIngrediente)
        {

            //Le decimos a EF que procese la info de este objeto para la tabla ingreidientes
            _context.Ingredientes.Add(nuevoIngrediente);

            //se guarda en la tabla y es equivalente a COMMIT en SQL
            await _context.SaveChangesAsync();

            // Respondemos que se creó con éxito y mandamos el objeto de vuelta
            return CreatedAtAction(nameof(GetIngredientes), new { id = nuevoIngrediente.Idingrediente }, nuevoIngrediente);
        }


        //Equivalente a UPDATE con WHERE
        //PUT: api/Ingredientes/5
        [HttpPut("{ID}")]
        public async Task<IActionResult> PutIngrediente(int ID, Ingrediente IngredienteActualizado)
        {
            //el "id" de la url coincide con el id del modelo?
            if (ID != IngredienteActualizado.Idingrediente)
            {
                return BadRequest();
            }

            //le decimos a EF que este objeto ya ha a sido creado anteriormente y que lo prepare para sobreescribirse.
            _context.Entry(IngredienteActualizado).State = EntityState.Modified;

            try
            {
                //intentamos guardar el objeto o registro en SQL
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {

                //si no existe el ID en la DB, envia error 404 NOT FOUND
                if (!_context.Ingredientes.Any(e => e.Idingrediente == ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //retorna 204(exito sin contenido)
            return NoContent();
        }

        //Metodo DELETE
        [HttpDelete("{ID}")]
        public async Task<IActionResult>DeleteIngrediente(int ID)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(ID);

            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
