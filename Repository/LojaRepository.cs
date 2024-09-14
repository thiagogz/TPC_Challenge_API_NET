using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext dbContext;

        public LojaRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbLoja>> GetLojas()
        {
            return await dbContext.Lojas
                .Include(l => l.TbCompras)      
                .Include(l => l.TbNotificacos)  
                .Include(l => l.TbProdutos)     
                .Include(l => l.TbUserPdvs)     
                .ToListAsync();
        }

        public async Task<TbLoja> GetLoja(decimal lojaId)
        {
            return await dbContext.Lojas
                .Include(l => l.TbCompras)
                .Include(l => l.TbNotificacos)
                .Include(l => l.TbProdutos)
                .Include(l => l.TbUserPdvs)
                .FirstOrDefaultAsync(l => l.Pdvid == lojaId);
        }

        public async Task<TbLoja> AddLoja(TbLoja loja)
        {
            var result = await dbContext.Lojas.AddAsync(loja);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbLoja> UpdateLoja(TbLoja loja)
        {
            var existingLoja = await dbContext.Lojas.FirstOrDefaultAsync(l => l.Pdvid == loja.Pdvid);
            if (existingLoja != null)
            {
                existingLoja.Nomeloja = loja.Nomeloja;
                existingLoja.Endereco = loja.Endereco;
                existingLoja.Numero = loja.Numero;
                existingLoja.Complemento = loja.Complemento;
                existingLoja.Cep = loja.Cep;
                existingLoja.Ativo = loja.Ativo;

                await dbContext.SaveChangesAsync();
                return existingLoja;
            }
            return null;
        }

        public async Task DeleteLoja(decimal lojaId)
        {
            var result = await dbContext.Lojas.FirstOrDefaultAsync(l => l.Pdvid == lojaId);
            if (result != null)
            {
                dbContext.Lojas.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
