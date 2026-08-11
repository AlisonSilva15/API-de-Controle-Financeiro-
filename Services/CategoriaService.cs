using FinancasApi.Data;
using FinancasApi.DTOs;
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

        public async Task<List<CategoriaResponseDto>> GetCategorias()
        {
            var categorias = await _appDbContext.Categorias.ToListAsync();

            return categorias.Select(categoria => new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Tipo = categoria.Tipo
            }).ToList();
        }

        public async Task<CategoriaResponseDto?> GetCategoria(int id)
        {
            var categoria = await _appDbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return null;
            }

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Tipo = categoria.Tipo
            };
        }
        public async Task<Categoria> AddCategoria(CategoriaCreateDto categoriaDto)
        {
            var categoria = new Categoria
            {
                Nome = categoriaDto.Nome,
                Tipo = categoriaDto.Tipo
            };

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