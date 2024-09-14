using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IPontosCompraRepository
    {
        Task<IEnumerable<TbPontosCompra>> GetPontosCompra();
        Task<TbPontosCompra> GetPontosCompraByIds(decimal compraId, decimal pontoId);
        Task<TbPontosCompra> AddPontosCompra(TbPontosCompra pontosCompra);
        Task<TbPontosCompra> UpdatePontosCompra(decimal compraId, decimal pontoId, TbPontosCompra pontosCompra);
        Task DeletePontosCompra(decimal compraId, decimal pontoId);
    }
}
