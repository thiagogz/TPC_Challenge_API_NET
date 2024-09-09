using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPdvController : ControllerBase
    {
        private readonly IUserPdvRepository userPdvRepository;

        public UserPdvController(IUserPdvRepository userPdvRepository)
        {
            this.userPdvRepository = userPdvRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUserPdv>>> GetUserPdvs()
        {
            try
            {
                return Ok(await userPdvRepository.GetUserPdvs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbUserPdv>> GetUserPdv(decimal id)
        {
            try
            {
                var result = await userPdvRepository.GetUserPdv(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TbUserPdv>> CreateUserPdv([FromBody] TbUserPdv userPdv)
        {
            try
            {
                if (userPdv == null) return BadRequest();

                var result = await userPdvRepository.AddUserPdv(userPdv);

                return CreatedAtAction(nameof(GetUserPdv), new { id = result.Userpdvid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbUserPdv>> UpdateUserPdv(decimal id, [FromBody] TbUserPdv userPdv)
        {
            try
            {
                if (userPdv == null || userPdv.Userpdvid != id) return BadRequest();

                var existingUserPdv = await userPdvRepository.GetUserPdv(id);
                if (existingUserPdv == null) return NotFound($"UserPdv com id = {id} não encontrado");

                return await userPdvRepository.UpdateUserPdv(userPdv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbUserPdv>> DeleteUserPdv(decimal id)
        {
            try
            {
                var result = await userPdvRepository.GetUserPdv(id);
                if (result == null) return NotFound($"UserPdv com id = {id} não encontrado");

                userPdvRepository.DeleteUserPdv(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
