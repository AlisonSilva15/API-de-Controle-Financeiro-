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
        public async Task<IActionResult> AddMovimentacao(Movimentacao movimentacao)
        {
           _appDbContext.Movimentacoes.Add(movimentacao);
           await   _appDbContext.SaveChangesAsync();
           return Ok(movimentacao);
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
    }
}