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
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria(Categoria categoria)
        {
           _appDbContext.Categorias.Add(categoria);
           await   _appDbContext.SaveChangesAsync();
           return Ok(categoria);
        }
    }
}