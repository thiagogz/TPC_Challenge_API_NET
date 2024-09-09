using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class ClusterRepository : IClusterRepository
    {
        private readonly DataContext dbContext;

        public ClusterRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbCluster>> GetClusters()
        {
            return await dbContext.Clusters.ToListAsync();
        }

        public async Task<TbCluster> GetCluster(decimal clusterId)
        {
            return await dbContext.Clusters.FirstOrDefaultAsync(c => c.Clusterid == clusterId);
        }

        public async Task<TbCluster> AddCluster(TbCluster cluster)
        {
            var result = await dbContext.Clusters.AddAsync(cluster);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCluster> UpdateCluster(TbCluster cluster)
        {
            var result = await dbContext.Clusters.FirstOrDefaultAsync(c => c.Clusterid == cluster.Clusterid);
            if (result != null)
            {
                result.Name = cluster.Name;
                result.Descricao = cluster.Descricao;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async void DeleteCluster(decimal clusterId)
        {
            var result = await dbContext.Clusters.FirstOrDefaultAsync(c => c.Clusterid == clusterId);
            if (result != null)
            {
                dbContext.Clusters.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

