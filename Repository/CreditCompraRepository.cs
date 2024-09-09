using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class CreditCompraRepository : ICreditCompraRepository
    {
        private readonly DataContext dbContext;

        public CreditCompraRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbCreditCompra>> GetCreditCompras()
        {
            return await dbContext.CreditCompras
                                  .Include(cc => cc.Compra)
                                  .Include(cc => cc.Compra.Pdv)
                                  .Include(cc => cc.Compra.Users)
                                  .Include(cc => cc.Credit)
                                  .ToListAsync();
        }

        public async Task<TbCreditCompra> GetCreditCompra(decimal creditId, decimal compraId)
        {
            return await dbContext.CreditCompras
                                  .Include(cc => cc.Compra)
                                  .Include(cc => cc.Compra.Pdv)
                                  .Include(cc => cc.Compra.Users)
                                  .Include(cc => cc.Credit)
                                  .FirstOrDefaultAsync(cc => cc.Creditid == creditId && cc.Compraid == compraId);
        }

        public async Task<TbCreditCompra> AddCreditCompra(TbCreditCompra creditCompra)
        {
            var result = await dbContext.CreditCompras.AddAsync(creditCompra);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCreditCompra> UpdateCreditCompra(TbCreditCompra creditCompra)
        {
            var result = await dbContext.CreditCompras
                                        .FirstOrDefaultAsync(cc => cc.Creditid == creditCompra.Creditid && cc.Compraid == creditCompra.Compraid);

            if (result != null)
            {
                result.Creditid = creditCompra.Creditid;
                result.Compraid = creditCompra.Compraid;
                result.Compra = creditCompra.Compra;
                result.Credit = creditCompra.Credit;

                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteCreditCompra(decimal creditId, decimal compraId)
        {
            var result = await dbContext.CreditCompras
                                        .FirstOrDefaultAsync(cc => cc.Creditid == creditId && cc.Compraid == compraId);

            if (result != null)
            {
                dbContext.Set<TbCreditCompra>().Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
