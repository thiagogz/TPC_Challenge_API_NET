using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<TbProduto>> GetProdutos();
        Task<TbProduto> GetProduto(decimal produtoId);
        Task<TbProduto> AddProduto(TbProduto produto);
        Task<TbProduto> UpdateProduto(TbProduto produto);
        void DeleteProduto(decimal produtoId);
    }
}
