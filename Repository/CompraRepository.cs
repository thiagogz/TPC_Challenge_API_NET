using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly DataContext dbContext;

        public CompraRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbCompra>> GetCompras()
        {
            return await dbContext.Compras
                .Include(c => c.Pdv)
                .Include(c => c.Users)
                .ToListAsync();
        }

        public async Task<TbCompra> GetCompra(decimal compraId)
        {
            return await dbContext.Compras
                .Include(c => c.Pdv) 
                .Include(c => c.Users) 
                .FirstOrDefaultAsync(c => c.Compraid == compraId);
        }

        public async Task<TbCompra> AddCompra(TbCompra compra)
        {
            var result = await dbContext.Compras.AddAsync(compra);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCompra> UpdateCompra(TbCompra compra)
        {
            var result = await dbContext.Compras.FirstOrDefaultAsync(c => c.Compraid == compra.Compraid);
            if (result != null)
            {
                result.Valor = compra.Valor;
                result.Datacompra = compra.Datacompra;
                result.Pdvid = compra.Pdvid;
                result.Usersid = compra.Usersid;

                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task DeleteCompra(decimal compraId)
        {
            var result = await dbContext.Compras.FirstOrDefaultAsync(c => c.Compraid == compraId);
            if (result != null)
            {
                dbContext.Compras.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
