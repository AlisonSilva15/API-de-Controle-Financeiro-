using FinancasApi.Models;

namespace FinancasApi.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetCategorias();
        Task<Categoria?> GetCategoria(int id);
        Task<Categoria> AddCategoria(Categoria categoria);
        Task<Categoria?> UpdateCategoria(int id, Categoria categoriaAtualizada);
        Task<bool> DeleteCategoria(int id);
    }
}