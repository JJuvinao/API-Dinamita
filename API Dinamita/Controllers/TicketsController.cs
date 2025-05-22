using API_Dinamita.Helpers;
using API_Dinamita.Models;
using API_Dinamita.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Security.Claims;

namespace API_Dinamita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ContextDB _context;
        public TicketsController(ContextDB context)
        {
            _context = context;
        }

        [HttpPost("{Id_Evento}")]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult<TicketDto>> PostTicket(int Id_Evento, string categoriaTicket)
        {
            var evento = await _context.Eventos.FindAsync(Id_Evento);
            if (evento == null)
                return NotFound();
            if (evento.Aforo_Max <= evento.Tickets_Vendidos)
                return BadRequest("Se han vendido todas la boletas");

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            float precio = CalcularPrecio(evento.PrecioTicket, categoriaTicket);
            string codigo = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
            byte[] codigoQR = GenerarQR(codigo);

            var ticket = new Tickets
            {
                Precio = evento.PrecioTicket,
                Fecha_Expedicion = DateTime.UtcNow,
                Nombre_Evento = evento.Nombre_Evento,
                Categoria = categoriaTicket,
                Fecha_Entrada = evento.Fecha,
                CodigoAlfanumerico = codigo,
                CodigoQR = codigoQR,
                Estado = false,
                Id_Usuario = userId,
                Id_Evento = evento.Id_Evento
            };
            _context.Tickets.Add(ticket);
            evento.Tickets_Vendidos += 1;
            await _context.SaveChangesAsync();

            return Ok(new {
                mensaje = "Compra realizada exitosamente"
            });
        }

        private float CalcularPrecio(float precioTicket, string categoriaTicket)
        {
            return 2000;
        }

        private byte[] GenerarQR(string codigo)
        {
            var generadorQR = new QRCodeGenerator();
            var datosQR = generadorQR.CreateQrCode(codigo, QRCodeGenerator.ECCLevel.Q);
            var codigoQR = new PngByteQRCode(datosQR);
            return codigoQR.GetGraphic(20);
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

                var carrito = new CarritoDto
                {
                    Tickets = (List<Tickets>)ticketsCarrito,
                    Total = total
                };
                return Ok(carrito);
            }
            else
            {
                return BadRequest("No ha realizado compras");
            }
            
        }

        [HttpPost("ValidarQR")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> ValidarQR(string codigoAlfanumerico)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(T => T.CodigoAlfanumerico == codigoAlfanumerico);

            if (ticket == null)
                return BadRequest("Código inválido");

            if (ticket.Estado)
                return BadRequest("El ticket ya ha sido usado");

            ticket.Estado = true;
            _context.SaveChanges();

            return Ok($"Ticket válido para el evento: {ticket.Nombre_Evento}");
        }

    }
}
