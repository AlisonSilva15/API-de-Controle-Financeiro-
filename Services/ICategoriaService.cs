using FinancasApi.DTOs;
using FinancasApi.Models;

namespace FinancasApi.Services
{
    public interface ICategoriaService
    {
        Task<List<CategoriaResponseDto>> GetCategorias();
        Task<CategoriaResponseDto?> GetCategoria(int id);
        Task<Categoria> AddCategoria(CategoriaCreateDto categoriaDto);
        Task<Categoria?> UpdateCategoria(int id, Categoria categoriaAtualizada);
        Task<bool> DeleteCategoria(int id);
    }
}