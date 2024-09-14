using Microsoft.EntityFrameworkCore;
using TPC_Challenge_API_NET.Data;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Repository
{
    public class UsermasterRepository : IUsermasterRepository
    {
        private readonly DataContext dbContext;

        public UsermasterRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TbUsermaster>> GetUserMasters()
        {
            return await dbContext.UserMasters
                .Include(um => um.TbCampanhas) // Incluindo as campanhas relacionadas
                .ToListAsync();
        }

        public async Task<TbUsermaster> GetUserMaster(decimal masterId)
        {
            return await dbContext.UserMasters
                .Include(um => um.TbCampanhas) // Incluindo as campanhas relacionadas
                .FirstOrDefaultAsync(um => um.Masterid == masterId);
        }

        public async Task<TbUsermaster> AddUserMaster(TbUsermaster userMaster)
        {
            var result = await dbContext.UserMasters.AddAsync(userMaster);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbUsermaster> UpdateUserMaster(TbUsermaster userMaster)
        {
            var result = await dbContext.UserMasters
                .FirstOrDefaultAsync(um => um.Masterid == userMaster.Masterid);
            if (result != null)
            {
                result.Nome = userMaster.Nome;
                result.Sobrenome = userMaster.Sobrenome;
                result.Email = userMaster.Email;
                result.Password = userMaster.Password;
                result.Dataregistro = userMaster.Dataregistro;
                result.Ativo = userMaster.Ativo;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteUserMaster(decimal masterId)
        {
            var result = await dbContext.UserMasters
                .FirstOrDefaultAsync(um => um.Masterid == masterId);
            if (result != null)
            {
                dbContext.UserMasters.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
