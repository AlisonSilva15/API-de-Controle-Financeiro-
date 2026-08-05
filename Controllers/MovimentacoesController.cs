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
    public class MovimentacoesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MovimentacoesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovimentacao([FromBody]Movimentacao movimentacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _appDbContext.Movimentacoes.Add(movimentacao);
           await   _appDbContext.SaveChangesAsync();
           return Created("Movimentação adicionada com sucesso!",movimentacao);
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetMovimentacoes()
        {
            var movimentacoes = await _appDbContext.Movimentacoes.ToListAsync();

            return Ok(movimentacoes);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetMovimentacao(int id)
        {
            var movimentacao = await _appDbContext.Movimentacoes.FindAsync(id);

            if(movimentacao == null)
            {
                return NotFound ("Movimentação não encontrada!");
            }

            return Ok(movimentacao);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovimentacao(int id, [FromBody] Movimentacao movimentacaoAtualizada)
        {
            var movimentacaoExistente = await _appDbContext.Movimentacoes.FindAsync(id);

             if(movimentacaoExistente == null)
            {
                return NotFound ("Movimentacação não encontrada!");
            }
            _appDbContext.Entry(movimentacaoExistente).CurrentValues.SetValues(movimentacaoAtualizada);

             await   _appDbContext.SaveChangesAsync();

             return StatusCode(201, movimentacaoExistente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimentacao(int id)
        {
            var movimentacao = await _appDbContext.Movimentacoes.FindAsync(id);

             if(movimentacao == null)
            {
                return NotFound ("Movimentacao não encontrada!");
            }
            _appDbContext.Movimentacoes.Remove(movimentacao);

             await   _appDbContext.SaveChangesAsync();

             return Ok("Movimentação deletada com sucesso!");
        }
    }
}