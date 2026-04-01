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
        private readonly AppDbContext _context;

        //Aqui le pedimos a Program.cs que nos preste la conexion a DB
        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            //Equivalente a SELECT * FROM Ingredientes;
            return await _context.Ingredientes.ToListAsync();
        }
    }
}
