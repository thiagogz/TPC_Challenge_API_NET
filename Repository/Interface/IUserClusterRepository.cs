using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IUserClusterRepository
    {
        Task<IEnumerable<TbUserCluster>> GetUserClusters();
        Task<TbUserCluster> GetUserCluster(decimal userClusterId);
        Task<TbUserCluster> AddUserCluster(TbUserCluster userCluster);
        Task<TbUserCluster> UpdateUserCluster(TbUserCluster userCluster);
        Task DeleteUserCluster(decimal userClusterId);
    }
}
