using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ILojaRepository
    {
        Task<IEnumerable<TbLoja>> GetLojas();
        Task<TbLoja> GetLoja(decimal lojaId);
        Task<TbLoja> AddLoja(TbLoja loja);
        Task<TbLoja> UpdateLoja(TbLoja loja);
        void DeleteLoja(decimal lojaId);
    }
}
