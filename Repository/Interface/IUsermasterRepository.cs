using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IUsermasterRepository
    {
        Task<IEnumerable<TbUsermaster>> GetUserMasters();
        Task<TbUsermaster> GetUserMaster(decimal masterId);
        Task<TbUsermaster> AddUserMaster(TbUsermaster userMaster);
        Task<TbUsermaster> UpdateUserMaster(TbUsermaster userMaster);
        Task DeleteUserMaster(decimal masterId);
    }
}
