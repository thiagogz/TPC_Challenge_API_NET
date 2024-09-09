using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext dbContext;

        public CategoriaRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbCategoria> GetCategoria(decimal categoriaId)
        {
            return await dbContext.Categorias
                .Include(c => c.TbProdutos) 
                .FirstOrDefaultAsync(c => c.Categoriaid == categoriaId);
        }

        public async Task<IEnumerable<TbCategoria>> GetCategorias()
        {
            return await dbContext.Categorias
                .Include(c => c.TbProdutos) 
                .ToListAsync();
        }

        public async Task<TbCategoria> AddCategoria(TbCategoria categoria)
        {
            var result = await dbContext.Categorias.AddAsync(categoria);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbCategoria> UpdateCategoria(TbCategoria categoria)
        {
            var result = await dbContext.Categorias.FirstOrDefaultAsync(c => c.Categoriaid == categoria.Categoriaid);
            if (result != null)
            {
                result.Nome = categoria.Nome;
                result.Descricao = categoria.Descricao;
                result.Ativo = categoria.Ativo;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async void DeleteCategoria(decimal categoriaId)
        {
            var result = await dbContext.Categorias.FirstOrDefaultAsync(c => c.Categoriaid == categoriaId);
            if (result != null)
            {
                dbContext.Set<TbCategoria>().Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
