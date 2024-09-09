using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ICreditCompraRepository
    {
        Task<IEnumerable<TbCreditCompra>> GetCreditCompras();
        Task<TbCreditCompra> GetCreditCompra(decimal creditId, decimal compraId);
        Task<TbCreditCompra> AddCreditCompra(TbCreditCompra creditCompra);
        Task<TbCreditCompra> UpdateCreditCompra(TbCreditCompra creditCompra);
        void DeleteCreditCompra(decimal creditId, decimal compraId);
    }
}
