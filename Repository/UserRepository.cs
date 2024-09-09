using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dbContext;

        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbUser> GetUser(decimal userId)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Usersid == userId);
        }

        public async Task<IEnumerable<TbUser>> GetUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<TbUser> AddUser(TbUser user)
        {
            var result = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbUser> UpdateUser(TbUser user)
        {
            var result = await dbContext.Users.FirstOrDefaultAsync(u => u.Usersid == user.Usersid);
            if (result != null)
            {
                result.Nome = user.Nome;
                result.Sobrenome = user.Sobrenome;
                result.Email = user.Email;
                result.Password = user.Password;
                result.Telefone = user.Telefone;
                result.Endereco = user.Endereco;
                result.Numero = user.Numero;
                result.Complemento = user.Complemento;
                result.Ativo = user.Ativo;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async void DeleteUser(decimal userId)
        {
            var result = await dbContext.Users.FirstOrDefaultAsync(u => u.Usersid == userId);
            if (result != null)
            {
                dbContext.Set<TbUser>().Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
