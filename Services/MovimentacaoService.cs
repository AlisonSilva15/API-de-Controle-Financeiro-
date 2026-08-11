using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasApi.Data;
using FinancasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancasApi.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly AppDbContext _appDbContext;

        public MovimentacaoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Movimentacao>> GetMovimentacoes()
        {
            return await _appDbContext.Movimentacoes.ToListAsync();
        }

        public async Task<Movimentacao?> GetMovimentacao(int id)
        {
            return await _appDbContext.Movimentacoes.FindAsync(id);
        }

        public async Task<Movimentacao> AddMovimentacao(Movimentacao movimentacao)
        {
            _appDbContext.Movimentacoes.Add(movimentacao);

            await _appDbContext.SaveChangesAsync();

            return movimentacao;
        }

        public async Task<Movimentacao?> UpdateMovimentacao(int id, Movimentacao movimentacaoAtualizada)
        {
            var movimentacaoExistente = await _appDbContext.Movimentacoes.FindAsync(id);

            if (movimentacaoExistente == null)
            {
                return null;
            }

            _appDbContext.Entry(movimentacaoExistente)
                .CurrentValues
                .SetValues(movimentacaoAtualizada);

            await _appDbContext.SaveChangesAsync();

            return movimentacaoExistente;
        }


        public async Task<bool> DeleteMovimentacao(int id)
        {
            var movimentacao = await _appDbContext.Movimentacoes.FindAsync(id);

            if (movimentacao == null)
            {
                return false;
            }

            _appDbContext.Movimentacoes.Remove(movimentacao);

            await _appDbContext.SaveChangesAsync();

            return true;
        }

    }
}