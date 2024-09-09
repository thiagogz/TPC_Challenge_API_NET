using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ICreditRepository
    {
        Task<IEnumerable<TbCredit>> GetCredits();
        Task<TbCredit> GetCredit(decimal creditId);
        Task<TbCredit> AddCredit(TbCredit credit);
        Task<TbCredit> UpdateCredit(TbCredit credit);
        void DeleteCredit(decimal creditId);
    }
}
