using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IClusterRepository
    {
        Task<IEnumerable<TbCluster>> GetClusters();
        Task<TbCluster> GetCluster(decimal clusterId);
        Task<TbCluster> AddCluster(TbCluster cluster);
        Task<TbCluster> UpdateCluster(TbCluster cluster);
        void DeleteCluster(decimal clusterId);
    }
}
