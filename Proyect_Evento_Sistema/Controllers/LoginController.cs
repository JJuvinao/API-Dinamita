using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_Evento_Sistema.Helpers;
using Proyect_Evento_Sistema.Models;

namespace Proyect_Evento_Sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ContextBD _context;
        private readonly JwtHelper _jwtHelper;
        public LoginController(JwtHelper jwtHelper, ContextBD context)
        {
            _jwtHelper = jwtHelper;
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostLogin(LoginDto loginDto)
        {
            var login = await _context.Logins
                .FirstOrDefaultAsync(l => l.username == loginDto.username);
            if (login == null || !BCrypt.Net.BCrypt.Verify(loginDto.password, login.password))
            {
                return Unauthorized("Credenciales inválidas");
            }

            var token = _jwtHelper.GenerateToken(login.username);

            return Ok(new
            {
                token,
                user = new { login.username, login.nombre, login.apellido }
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (_context.Logins.Any(u => u.username == dto.username))
                return BadRequest("El usuario ya existe.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.password);

            var user = new Login
            {
                username = dto.username,
                nombre = dto.nombre,
                apellido = dto.apellido,
                password = hashedPassword
            };

            _context.Logins.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuario registrado correctamente.");
        }

    }
}
