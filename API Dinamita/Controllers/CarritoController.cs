using API_Dinamita.Helpers;
using API_Dinamita.Models;
using API_Dinamita.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Dinamita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ContextDB _context;
        private readonly JwtHelper _jwtHelper;
        public CarritoController(JwtHelper jwtHelper, ContextDB context)
        {
            _jwtHelper = jwtHelper;
            _context = context;
        }

        [Authorize]
        [HttpGet("{Id_Usuario}")]
        public async Task<ActionResult<CarritoDto>> GetCarrito(int Id_Usuario) {

            var tickets = await _context.Tickets.ToListAsync();
            var ticketsCarrito = tickets.Where(T => T.Id_Usuario == Id_Usuario);

            float total = 0;
            if (ticketsCarrito != null)
            {
                foreach (var ticket in ticketsCarrito)
                {
                    total = total + ticket.Precio;
                }

            }

            var carrito = new CarritoDto
            {
                Tickets = (List<Tickets>)ticketsCarrito,
                Total = total
            };

            return carrito;
        }
    }
}
