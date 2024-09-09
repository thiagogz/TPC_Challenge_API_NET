using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class UserClusterRepository : IUserClusterRepository
    {
        private readonly DataContext dbContext;

        public UserClusterRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbUserCluster>> GetUserClusters()
        {
            return await dbContext.UserClusters
                .Include(uc => uc.Cluster) // Incluindo a entidade Cluster
                .Include(uc => uc.User) // Incluindo a entidade User
                .ToListAsync();
        }

        public async Task<TbUserCluster> GetUserCluster(decimal userClusterId)
        {
            return await dbContext.UserClusters
                .Include(uc => uc.Cluster) // Incluindo a entidade Cluster
                .Include(uc => uc.User) // Incluindo a entidade User
                .FirstOrDefaultAsync(uc => uc.Userclusterid == userClusterId);
        }

        public async Task<TbUserCluster> AddUserCluster(TbUserCluster userCluster)
        {
            var result = await dbContext.UserClusters.AddAsync(userCluster);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbUserCluster> UpdateUserCluster(TbUserCluster userCluster)
        {
            var result = await dbContext.UserClusters
                .FirstOrDefaultAsync(uc => uc.Userclusterid == userCluster.Userclusterid);
            if (result != null)
            {
                result.Clusterid = userCluster.Clusterid;
                result.Userid = userCluster.Userid;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async void DeleteUserCluster(decimal userClusterId)
        {
            var result = await dbContext.UserClusters
                .FirstOrDefaultAsync(uc => uc.Userclusterid == userClusterId);
            if (result != null)
            {
                dbContext.UserClusters.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
