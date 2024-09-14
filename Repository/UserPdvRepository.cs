using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class UserPdvRepository : IUserPdvRepository
    {
        private readonly DataContext dbContext;

        public UserPdvRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbUserPdv>> GetUserPdvs()
        {
            return await dbContext.UserPdvs
                .Include(up => up.Pdv) // Incluindo a loja relacionada
                .ToListAsync();
        }

        public async Task<TbUserPdv> GetUserPdv(decimal userPdvId)
        {
            return await dbContext.UserPdvs
                .Include(up => up.Pdv)
                .FirstOrDefaultAsync(up => up.Userpdvid == userPdvId);
        }

        public async Task<TbUserPdv> AddUserPdv(TbUserPdv userPdv)
        {
            var result = await dbContext.UserPdvs.AddAsync(userPdv);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbUserPdv> UpdateUserPdv(TbUserPdv userPdv)
        {
            var result = await dbContext.UserPdvs
                .FirstOrDefaultAsync(up => up.Userpdvid == userPdv.Userpdvid);
            if (result != null)
            {
                result.Nome = userPdv.Nome;
                result.Sobrenome = userPdv.Sobrenome;
                result.Email = userPdv.Email;
                result.Password = userPdv.Password;
                result.Dataregistro = userPdv.Dataregistro;
                result.Ativo = userPdv.Ativo;
                result.Pdvid = userPdv.Pdvid; // Atualiza a loja associada

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteUserPdv(decimal userPdvId)
        {
            var result = await dbContext.UserPdvs
                .FirstOrDefaultAsync(up => up.Userpdvid == userPdvId);
            if (result != null)
            {
                dbContext.UserPdvs.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
