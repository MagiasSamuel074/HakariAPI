using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HakariAPI.Data;
using HakariAPI.Models;

namespace HakariAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        //inyrccion de dependencia de la clase AppDbContext a la clase PlatillosController.
        private readonly AppDbContext _context;


        public PlatillosController(AppDbContext context)
        {
            _context = context;
        }
    }
}
