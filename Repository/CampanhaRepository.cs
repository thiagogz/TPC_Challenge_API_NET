using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly DataContext dbContext;

        public CampanhaRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbCampanha> GetCampanha(decimal campanhaId)
        {
            return await dbContext.Campanhas
                .Include(c => c.Cluster)
                .Include(c => c.Master)
                .FirstOrDefaultAsync(c => c.Campanhaid == campanhaId);
        }

        public async Task<IEnumerable<TbCampanha>> GetCampanhas()
        {
            return await dbContext.Campanhas
                .Include(c => c.Cluster)
                .Include(c => c.Master)
                .ToListAsync();
        }

        public async Task<TbCampanha> AddCampanha(TbCampanha campanha)
        {
            var result = await dbContext.Campanhas.AddAsync(campanha);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCampanha> UpdateCampanha(TbCampanha campanha)
        {
            var result = await dbContext.Campanhas.FirstOrDefaultAsync(c => c.Campanhaid == campanha.Campanhaid);
            if (result != null)
            {
                result.Titulo = campanha.Titulo;
                result.Conteudo = campanha.Conteudo;
                result.Descricao = campanha.Descricao;
                result.Canaltipo = campanha.Canaltipo;
                result.Clusterid = campanha.Clusterid;
                result.Masterid = campanha.Masterid;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteCampanha(decimal campanhaId)
        {
            var result = await dbContext.Campanhas.FirstOrDefaultAsync(c => c.Campanhaid == campanhaId);
            if (result != null)
            {
                dbContext.Campanhas.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
