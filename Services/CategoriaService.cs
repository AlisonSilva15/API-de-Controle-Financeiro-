using FinancasApi.Data;
using FinancasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancasApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _appDbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetCategoria(int id)
        {
            return await _appDbContext.Categorias.FindAsync(id);
        }

        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            _appDbContext.Categorias.Add(categoria);

            await _appDbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> UpdateCategoria(int id, Categoria categoriaAtualizada)
        {
            var categoriaExistente = await _appDbContext.Categorias.FindAsync(id);

            if (categoriaExistente == null)
            {
                return null;
            }

            _appDbContext.Entry(categoriaExistente)
                .CurrentValues
                .SetValues(categoriaAtualizada);

            await _appDbContext.SaveChangesAsync();

            return categoriaExistente;
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            var categoria = await _appDbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return false;
            }

            _appDbContext.Categorias.Remove(categoria);

            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}