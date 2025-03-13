namespace Apimedical.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apimedical.Models;
using Apimedical.Data;

[Route("usuarios")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    // Constructor correctamente definido para la inyección de dependencias
    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("El usuario es nulo.");
        }

        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, new { message = "Usuario creado exitosamente", user });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(user);
    }


    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuario eliminado correctamente" });
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
    {
        if (updatedUser == null)
        {
            return BadRequest(new { message = "Los datos del usuario son nulos" });
        }

        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        existingUser.Nombre = updatedUser.Nombre;
        existingUser.Email = updatedUser.Email;
        existingUser.Edad = updatedUser.Edad;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuario actualizado exitosamente", user = existingUser });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error al actualizar el usuario", error = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ObtenerUsuarios()
    {
        try
        {
            var users = await _context.Users.ToListAsync(); // Obtener usuarios reales de la BD
            return Ok(new { message = "Lista de usuarios", users });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener de la base de datos: {ex.Message}");
        }

    }
}
