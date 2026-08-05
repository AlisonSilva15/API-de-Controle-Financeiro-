using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasApi.Data;
using FinancasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria([FromBody]Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _appDbContext.Categorias.Add(categoria);
           await   _appDbContext.SaveChangesAsync();
           return Created("Categoria adicionada com sucesso!",categoria);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _appDbContext.Categorias.ToListAsync();

            return Ok(categorias);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _appDbContext.Categorias.FindAsync(id);

            if(categoria == null)
            {
                return NotFound ("Categoria não encontrada!");
            }

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoriaExistente = await _appDbContext.Categorias.FindAsync(id);

             if(categoriaExistente == null)
            {
                return NotFound ("Categoria não encontrada!");
            }
            _appDbContext.Entry(categoriaExistente).CurrentValues.SetValues(categoriaAtualizada);

             await   _appDbContext.SaveChangesAsync();

             return StatusCode(201, categoriaExistente);
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _appDbContext.Categorias.FindAsync(id);

             if(categoria == null)
            {
                return NotFound ("Categoria não encontrada!");
            }
            _appDbContext.Categorias.Remove(categoria);

             await   _appDbContext.SaveChangesAsync();

             return Ok("Categoria deletada com sucesso!");
        }
    }
}