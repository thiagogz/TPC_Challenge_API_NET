using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class PontoRepository : IPontoRepository
    {
        private readonly DataContext dbContext;

        public PontoRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbPonto> GetPonto(decimal pontoId)
        {
            return await dbContext.Pontos.FirstOrDefaultAsync(p => p.Pointid == pontoId);
        }

        public async Task<IEnumerable<TbPonto>> GetPontos()
        {
            return await dbContext.Pontos.ToListAsync();
        }

        public async Task<TbPonto> AddPonto(TbPonto ponto)
        {
            var result = await dbContext.Pontos.AddAsync(ponto);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbPonto> UpdatePonto(TbPonto ponto)
        {
            var result = await dbContext.Pontos.FirstOrDefaultAsync(p => p.Pointid == ponto.Pointid);
            if (result != null)
            {
                result.Valor = ponto.Valor;
                result.Datacreditado = ponto.Datacreditado;
                result.Dataexpirado = ponto.Dataexpirado;
                result.Utilizado = ponto.Utilizado;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeletePonto(decimal pontoId)
        {
            var result = await dbContext.Pontos.FirstOrDefaultAsync(p => p.Pointid == pontoId);
            if (result != null)
            {
                dbContext.Pontos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
