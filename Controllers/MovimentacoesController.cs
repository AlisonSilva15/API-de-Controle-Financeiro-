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
    public class MovimentacoesController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovimentacao([FromBody] Movimentacao movimentacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movimentacaoCriada = await _movimentacaoService.AddMovimentacao(movimentacao);

            return StatusCode(201, movimentacaoCriada);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimentacao>>> GetMovimentacoes()
        {
            var movimentacoes = await _movimentacaoService.GetMovimentacoes();

            return Ok(movimentacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimentacao>> GetMovimentacao(int id)
        {
            var movimentacao = await _movimentacaoService.GetMovimentacao(id);

            if (movimentacao == null)
            {
                return NotFound("Movimentação não encontrada!");
            }

            return Ok(movimentacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovimentacao(int id, [FromBody] Movimentacao movimentacaoAtualizada)
        {
            var movimentacao = await _movimentacaoService
                .UpdateMovimentacao(id, movimentacaoAtualizada);

            if (movimentacao == null)
            {
                return NotFound("Movimentacao não encontrada!");
            }

            return Ok(movimentacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimentacao(int id)
        {
            var deletado = await _movimentacaoService.DeleteMovimentacao(id);

            if (!deletado)
            {
                return NotFound("Movimentação não encontrada!");
            }

            return Ok("Movimentação deletada com sucesso!");
        }
    }
}