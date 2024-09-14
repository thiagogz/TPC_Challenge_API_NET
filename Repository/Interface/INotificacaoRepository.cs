using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface INotificacaoRepository
    {
        Task<IEnumerable<TbNotificaco>> GetNotificacoes();
        Task<TbNotificaco> GetNotificacao(decimal notificacaoId);
        Task<TbNotificaco> AddNotificacao(TbNotificaco notificacao);
        Task<TbNotificaco> UpdateNotificacao(TbNotificaco notificacao);
        Task DeleteNotificacao(decimal notificacaoId);
    }
}
