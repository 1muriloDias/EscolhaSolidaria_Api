using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using helpingout.Data;
using helpingout.Interfaces;
using helpingout.Models;
using helpingout.Dtos;
using helpingout.Dtos.Usuario;
using helpingout.Mappers;

namespace helpingout.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var usuarios = await _usuarioRepo.GetAllAsync(query);
            return Ok(usuarios.Select(u => u.ToUsuarioDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioRequestDto usuarioDto)
        {
            var usuario = usuarioDto.ToUsuarioFromCreateDTO();
            await _usuarioRepo.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuario }, usuario.ToUsuarioDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario.ToUsuarioDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
