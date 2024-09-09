using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DataContext dbContext;

        public NotificacaoRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbNotificaco>> GetNotificacoes()
        {
            return await dbContext.Notificacoes
                .Include(n => n.Pdv)
                .ToListAsync();
        }

        public async Task<TbNotificaco> GetNotificacao(decimal notificacaoId)
        {
            return await dbContext.Notificacoes
                .Include(n => n.Pdv) 
                .FirstOrDefaultAsync(n => n.Notificacoesid == notificacaoId);
        }

        public async Task<TbNotificaco> AddNotificacao(TbNotificaco notificacao)
        {
            var result = await dbContext.Notificacoes.AddAsync(notificacao);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbNotificaco> UpdateNotificacao(TbNotificaco notificacao)
        {
            var existingNotificacao = await dbContext.Notificacoes
                .FirstOrDefaultAsync(n => n.Notificacoesid == notificacao.Notificacoesid);

            if (existingNotificacao != null)
            {
                existingNotificacao.Pdvid = notificacao.Pdvid;
                existingNotificacao.Titulo = notificacao.Titulo;
                existingNotificacao.Mensagem = notificacao.Mensagem;
                existingNotificacao.Dataenvio = notificacao.Dataenvio;

                await dbContext.SaveChangesAsync();

                return existingNotificacao;
            }
            return null;
        }

        public async void DeleteNotificacao(decimal notificacaoId)
        {
            var notificacao = await dbContext.Notificacoes
                .FirstOrDefaultAsync(n => n.Notificacoesid == notificacaoId);
            if (notificacao != null)
            {
                dbContext.Notificacoes.Remove(notificacao);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
