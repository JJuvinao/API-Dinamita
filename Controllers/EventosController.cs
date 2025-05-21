using API_Dinamita.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Dinamita.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return await _context.Eventos.Include(e => e.Tickets).ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventos>> GetEvento(int id)
        {
            var evento = await _context.Eventos.Include(e => e.Tickets)
                                               .FirstOrDefaultAsync(e => e.Id_Evento == id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Eventos>> PostEvento(Eventos evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id_Evento }, evento);
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Eventos evento)
        {
            if (id != evento.Id_Evento)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpGet("listar")]
        public async Task<ActionResult<List<EventoDto>>> GetListaEventos()
        {
            var eventos = await _context.Eventos.ToListAsync();

            var listaDto = eventos.Select(e => new EventoDto
            {
                Id_Evento = e.Id_Evento,
                Nombre_Evento = e.Nombre_Evento,
                Descripcion = e.Descripcion,
                Nombre_Lugar = e.Nombre_Lugar,
                Direccion_Lugar = e.Direccion_Lugar,
                Fecha = e.Fecha,
                Aforo_Max = e.Aforo_Max,
                Estado = e.Estado
            }).ToList();

            return Ok(listaDto);
        }


        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id_Evento == id);
        }
    }
}
