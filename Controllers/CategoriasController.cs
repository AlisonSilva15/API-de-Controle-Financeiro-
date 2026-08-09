using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasApi.Data;
using FinancasApi.Models;
using FinancasApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaCriada = await _categoriaService.AddCategoria(categoria);

            return Created("Categoria adicionada com sucesso!", categoria);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _categoriaService.GetCategorias();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoria = await _categoriaService
                .UpdateCategoria(id, categoriaAtualizada);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deletado = await _categoriaService.DeleteCategoria(id);

            if (!deletado)
            {
                return NotFound("Categoria não encontrada!");
            }

            return Ok("Categoria deletada com sucesso!");
        }
    }
}