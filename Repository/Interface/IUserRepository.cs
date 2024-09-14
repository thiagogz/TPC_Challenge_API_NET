using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<TbUser>> GetUsers();
        Task<TbUser> GetUser(decimal userId);
        Task<TbUser> AddUser(TbUser user);
        Task<TbUser> UpdateUser(TbUser user);
        Task DeleteUser(decimal userId);
    }
}
