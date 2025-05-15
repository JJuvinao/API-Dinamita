using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_Evento_Sistema.Models;
using static Proyect_Evento_Sistema.Models.Persona;

namespace Proyect_Evento_Sistema.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ContextBD _context;

        public PersonasController(ContextBD context)
        {
            _context = context;
        }

        // GET: api/Personas
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<PersonaDTO>>> GetPersonas()
        {
            var personas = await _context.Personas.ToListAsync();

            var personaDTO = personas.Select(p => new PersonaDTO
            {
                Id_usuario = p.Id_usuario,
                Cc_usuario = p.Cc_usuario,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                F_nacimiento = p.F_nacimiento,
                Sexo = p.Sexo

            }).ToList();

            return Ok(personaDTO);
        }

        // GET: api/Personas/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id_usuario)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id_usuario }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id_usuario == id);
        }
    }
}
