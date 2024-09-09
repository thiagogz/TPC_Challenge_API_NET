using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ICompraRepository
    {
        Task<IEnumerable<TbCompra>> GetCompras();
        Task<TbCompra> GetCompra(decimal compraId);
        Task<TbCompra> AddCompra(TbCompra compra);
        Task<TbCompra> UpdateCompra(TbCompra compra);
        void DeleteCompra(decimal compraId);
    }
}
