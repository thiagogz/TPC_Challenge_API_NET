using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IUserPdvRepository
    {
        Task<IEnumerable<TbUserPdv>> GetUserPdvs();
        Task<TbUserPdv> GetUserPdv(decimal userPdvId);
        Task<TbUserPdv> AddUserPdv(TbUserPdv userPdv);
        Task<TbUserPdv> UpdateUserPdv(TbUserPdv userPdv);
        Task DeleteUserPdv(decimal userPdvId);
    }
}
