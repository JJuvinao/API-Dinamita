using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Dinamita.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_Dinamita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ContextDB _context;

        public CategoriasController(ContextDB context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCategorias(int id, Categorias categoria)
        {
            if (id != categoria.Id_Categoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasExists(id))
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

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Categorias>> PostCategorias(Categorias categorias)
        {
            _context.Categorias.Add(categorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorias", new { id = categorias.Id_Categoria }, categorias);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categorias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriasExists(int id)
        {
            return _context.Categorias.Any(e => e.Id_Categoria == id);
        }
    }
}
