using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasApi.Models;

namespace FinancasApi.Services
{
    public interface IMovimentacaoService
    {
        Task<List<Movimentacao>> GetMovimentacoes();
        Task<Movimentacao?> GetMovimentacao(int id);
        Task<Movimentacao> AddMovimentacao(Movimentacao movimentacao);
        Task<Movimentacao?> UpdateMovimentacao(int id, Movimentacao movimentacaoAtualizada);
        Task<bool> DeleteMovimentacao(int id);
    }
}