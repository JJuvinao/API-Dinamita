﻿using API_Dinamita.Migrations;
using API_Dinamita.Models;
using API_Dinamita.ModelsDto;
using Microsoft.AspNetCore.Mvc;
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

            return CreatedAtAction(nameof(PostEvento), new { id = evento.Id_Evento }, evento);
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

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id_Evento == id);
        }
    }
}
