using API_Dinamita.Models;
using API_Dinamita.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Eventos = API_Dinamita.Models.Eventos;

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
     [HttpGet]
     public async Task<ActionResult<IEnumerable<Eventos>>> GetEventos()
     {
         return await _context.Eventos.ToListAsync();
     }

     // GET: api/Eventos/5
     [HttpGet("{id}")]
     public async Task<ActionResult<Eventos>> GetEvento(int id)
     {
         var evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id_Evento == id);

         if (evento == null)
         {
             return NotFound();
         }

         return evento;
     }

        // POST: api/Eventos
        [Authorize (Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<Eventos>> PostEvento(EventosDto eventodto)
        {
            if (eventodto == null)
            {
                return BadRequest("Los datos del reporte no son válidos.");
            }

         var evento = new Eventos
         {
             Nombre_Evento = eventodto.Nombre_Evento,
             Descripcion = eventodto.Descripcion,
             Nombre_Lugar = eventodto.Nombre_Lugar,
             Direccion_Lugar = eventodto.Direccion_Lugar,
             Fecha = DateTime.Now,
             Aforo_Max = eventodto.Aforo_Max,
             PrecioTicket = eventodto.PrecioTicket,
             Tickets_Vendidos = 0,
             Estado = true,
             Categoria = eventodto.Categoria
         };

         _context.Eventos.Add(evento);
         await _context.SaveChangesAsync();

         return  Ok("Evento guardado correctamente");
     }

        // PUT: api/Eventos/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, EventosDto evento)
        {
            var eventoExistente = await _context.Eventos.FindAsync(id);
            if (eventoExistente == null)
            {
                return NotFound("Evento no existe");
            }

            eventoExistente.Nombre_Evento = evento.Nombre_Evento;
            eventoExistente.Descripcion = evento.Descripcion;
            eventoExistente.Nombre_Lugar = evento.Nombre_Lugar;
            eventoExistente.Direccion_Lugar = evento.Direccion_Lugar;
            eventoExistente.Aforo_Max = evento.Aforo_Max;
            eventoExistente.PrecioTicket = evento.PrecioTicket;
            eventoExistente.Tickets_Vendidos = evento.Tickets_Vendidos;
            eventoExistente.Estado = evento.Estado;
            eventoExistente.Categoria = evento.Categoria;


            _context.Entry(eventoExistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound("Fallo la modificacion en base de datos");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Modificado");
        }

        // DELETE: api/Eventos/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            evento.Estado = true;
            _context.SaveChanges();

            return Ok($"Estado del evento {evento.Nombre_Evento} cambiado exitosamente");
        }


        [HttpDelete("{Id_Evento}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvento(int Id_Evento)
        {
            var evento = await _context.Eventos.FindAsync(Id_Evento);

            if (evento == null)
                return NotFound();

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok("Evento eliminado exitosamente");
     }

     private bool EventoExists(int id)
     {
         return _context.Eventos.Any(e => e.Id_Evento == id);
     }
    }
}
