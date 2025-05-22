using API_Dinamita.Models;
using API_Dinamita.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Dinamita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ContextDB _context;

        public EventosController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Eventos>>> GetEventos()
        {
            var eventos = await _context.Eventos.ToListAsync();
            var eventosFiltrados = eventos.Where(E => E.Estado == false);

            if (eventosFiltrados == null)
                return NotFound();

            List<EventoFront> eventosFront = new List<EventoFront>();
            foreach (var evento in eventosFiltrados)
            {
                eventosFront.Add(ParseEvento(evento));
            }

            return Ok(eventosFront);
        }

        private EventoFront ParseEvento(Eventos evento)
        {
            return new EventoFront
            {
                Id_Evento = evento.Id_Evento,
                Nombre_Evento = evento.Nombre_Evento,
                Descripcion = evento.Descripcion,
                Nombre_Lugar = evento.Nombre_Lugar,
                Direccion_Lugar = evento.Direccion_Lugar,
                Fecha = evento.Fecha,
                PrecioTicket = evento.PrecioTicket,
                Tickets_Disponibles = evento.Tickets_Disponibles,
                Id_Categoria = evento.Id_Categoria
            };
        }

        // POST: api/Eventos
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Eventos>> PostEvento(EventoDto eventoDto)
        {
            _context.Eventos.Add(new Eventos
            {
                Nombre_Evento = eventoDto.Nombre_Evento,
                Descripcion = eventoDto.Descripcion,
                Nombre_Lugar = eventoDto.Nombre_Lugar,
                Direccion_Lugar = eventoDto.Direccion_Lugar,
                Fecha = eventoDto.Fecha,
                Aforo_Max = eventoDto.Aforo_Max,
                PrecioTicket = eventoDto.PrecioTicket,
                Tickets_Disponibles = eventoDto.Aforo_Max,
                Estado = false,
                Id_Categoria = eventoDto.Id_Categoria
            });
            await _context.SaveChangesAsync();

            return Ok("Evento guardado correctamente");
        }

        [HttpPut("{Id_Evento}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ModificarEvento(int Id_Evento)
        {
            var evento = await _context.Eventos.FindAsync(Id_Evento);
            if (evento == null)
                return NotFound();

            evento.Estado = true;
            _context.SaveChanges();

            return Ok($"Estado del evento {evento.Nombre_Evento} cambiado exitosamente");
        }


        [HttpDelete("{Id_Evento}")]
        public async Task<IActionResult> DeleteEvento(int Id_Evento)
        {
            var evento = await _context.Eventos.FindAsync(Id_Evento);
            if (evento == null)
                return NotFound();

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok("Evento eliminado exitosamente");
        }
    }
}
