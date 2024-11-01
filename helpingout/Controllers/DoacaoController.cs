using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using helpingout.Data;
using helpingout.Interfaces;
using helpingout.Models;
using helpingout.Dtos;
using helpingout.Repositories;

namespace helpingout.Controllers
{
    [Route("api/doacao")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        private readonly IDoacaoRepository _doacaoRepo;
        private readonly IUsuarioRepository _usuarioRepo;

        public DoacaoController(IDoacaoRepository doacaoRepo, IUsuarioRepository usuarioRepo)
        {
            _doacaoRepo = doacaoRepo;
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doacoes = await _doacaoRepo.GetAllAsync();
            return Ok(doacoes);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(int userId, [FromBody] CreateDoacaoDto doacaoDto)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(userId);
            if (usuario == null) return NotFound("Usuário não encontrado");

            var doacao = doacaoDto.ToDoacao();
            doacao.UsuarioId = userId;

            await _doacaoRepo.CreateAsync(doacao);
            return CreatedAtAction(nameof(GetById), new { id = doacao.Id }, doacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doacao = await _doacaoRepo.GetByIdAsync(id);
            if (doacao == null) return NotFound();
            return Ok(doacao);
        }
    }
}
