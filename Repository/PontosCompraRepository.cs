using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class PontosCompraRepository : IPontosCompraRepository
    {
        private readonly DataContext dbContext;

        public PontosCompraRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbPontosCompra>> GetPontosCompra()
        {
            return await dbContext.PontosCompra
                .Include(pc => pc.Compra)
                .Include(pc => pc.Compra.Pdv)
                .Include(pc => pc.Compra.Users)
                .Include(pc => pc.Point)
                .ToListAsync();
        }

        public async Task<TbPontosCompra> GetPontosCompraByIds(decimal compraId, decimal pontoId)
        {
            return await dbContext.PontosCompra
                .Include(pc => pc.Compra)
                .Include(pc => pc.Compra.Pdv)
                .Include(pc => pc.Compra.Users)
                .Include(pc => pc.Point)
                .FirstOrDefaultAsync(pc => pc.Compraid == compraId && pc.Pointid == pontoId);
        }

        public async Task<TbPontosCompra> AddPontosCompra(TbPontosCompra pontosCompra)
        {
            var result = await dbContext.PontosCompra.AddAsync(pontosCompra);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbPontosCompra> UpdatePontosCompra(TbPontosCompra pontosCompra)
        {
            var result = await dbContext.PontosCompra
                .FirstOrDefaultAsync(pc => pc.Compraid == pontosCompra.Compraid && pc.Pointid == pontosCompra.Pointid);
            if (result != null)
            {
                // Atualize os campos conforme necessário

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async void DeletePontosCompra(decimal compraId, decimal pontoId)
        {
            var result = await dbContext.PontosCompra
                .FirstOrDefaultAsync(pc => pc.Compraid == compraId && pc.Pointid == pontoId);
            if (result != null)
            {
                dbContext.PontosCompra.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
