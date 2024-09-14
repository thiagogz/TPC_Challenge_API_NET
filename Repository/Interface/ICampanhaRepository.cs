using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ICampanhaRepository
    {
        Task<IEnumerable<TbCampanha>> GetCampanhas();
        Task<TbCampanha> GetCampanha(decimal campanhaId);
        Task<TbCampanha> AddCampanha(TbCampanha campanha);
        Task<TbCampanha> UpdateCampanha(TbCampanha campanha);
        Task DeleteCampanha(decimal campanhaId);
    }
}

