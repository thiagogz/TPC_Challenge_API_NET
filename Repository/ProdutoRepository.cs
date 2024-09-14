using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dbContext;

        public ProdutoRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbProduto>> GetProdutos()
        {
            return await dbContext.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Pdv)
                .ToListAsync();
        }

        public async Task<TbProduto> GetProduto(decimal produtoId)
        {
            return await dbContext.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Pdv) 
                .FirstOrDefaultAsync(p => p.Produtoid == produtoId);
        }

        public async Task<TbProduto> AddProduto(TbProduto produto)
        {
            var result = await dbContext.Produtos.AddAsync(produto);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbProduto> UpdateProduto(TbProduto produto)
        {
            var result = await dbContext.Produtos
                .FirstOrDefaultAsync(p => p.Produtoid == produto.Produtoid);
            if (result != null)
            {
                result.Nome = produto.Nome;
                result.Descricao = produto.Descricao;
                result.Valor = produto.Valor;
                result.Ativo = produto.Ativo;
                result.Categoriaid = produto.Categoriaid;
                result.Pdvid = produto.Pdvid;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteProduto(decimal produtoId)
        {
            var result = await dbContext.Produtos
                .FirstOrDefaultAsync(p => p.Produtoid == produtoId);
            if (result != null)
            {
                dbContext.Produtos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
