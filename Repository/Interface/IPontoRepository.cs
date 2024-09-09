using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IPontoRepository
    {
        Task<IEnumerable<TbPonto>> GetPontos();
        Task<TbPonto> GetPonto(decimal pontoId);
        Task<TbPonto> AddPonto(TbPonto ponto);
        Task<TbPonto> UpdatePonto(TbPonto ponto);
        void DeletePonto(decimal pontoId);
    }
}
