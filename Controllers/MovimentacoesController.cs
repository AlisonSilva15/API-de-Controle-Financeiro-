using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasApi.Data;
using FinancasApi.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}