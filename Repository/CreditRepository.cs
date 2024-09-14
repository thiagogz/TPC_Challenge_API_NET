using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly DataContext dbContext;

        public CreditRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbCredit>> GetCredits()
        {
            return await dbContext.Credits.ToListAsync();
        }

        public async Task<TbCredit> GetCredit(decimal creditId)
        {
            return await dbContext.Credits.FirstOrDefaultAsync(c => c.Creditid == creditId);
        }

        public async Task<TbCredit> AddCredit(TbCredit credit)
        {
            var result = await dbContext.Credits.AddAsync(credit);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCredit> UpdateCredit(TbCredit credit)
        {
            var result = await dbContext.Credits.FirstOrDefaultAsync(c => c.Creditid == credit.Creditid);
            if (result != null)
            {
                result.Valor = credit.Valor;
                result.Datacredito = credit.Datacredito;
                result.Dataexpiracao = credit.Dataexpiracao;
                result.Utilizado = credit.Utilizado;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteCredit(decimal creditId)
        {
            var result = await dbContext.Credits.FirstOrDefaultAsync(c => c.Creditid == creditId);
            if (result != null)
            {
                dbContext.Credits.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
