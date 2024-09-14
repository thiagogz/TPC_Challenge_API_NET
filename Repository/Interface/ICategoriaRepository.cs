using TPC_Challenge_API_NET.Models;

namespace TPC_Challenge_API_NET.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<TbCategoria>> GetCategorias();
        Task<TbCategoria> GetCategoria(decimal categoriaId);
        Task<TbCategoria> AddCategoria(TbCategoria categoria);
        Task<TbCategoria> UpdateCategoria(TbCategoria categoria);
        Task DeleteCategoria(decimal categoriaId);
    }
}
