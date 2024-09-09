using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsermasterController : ControllerBase
    {
        private readonly IUsermasterRepository usermasterRepository;

        public UsermasterController(IUsermasterRepository usermasterRepository)
        {
            this.usermasterRepository = usermasterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUsermaster>>> GetUserMasters()
        {
            try
            {
                return Ok(await usermasterRepository.GetUserMasters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbUsermaster>> GetUserMaster(decimal id)
        {
            try
            {
                var result = await usermasterRepository.GetUserMaster(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TbUsermaster>> CreateUserMaster([FromBody] TbUsermaster userMaster)
        {
            try
            {
                if (userMaster == null) return BadRequest();

                var result = await usermasterRepository.AddUserMaster(userMaster);

                return CreatedAtAction(nameof(GetUserMaster), new { id = result.Masterid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbUsermaster>> UpdateUserMaster(decimal id, [FromBody] TbUsermaster userMaster)
        {
            try
            {
                if (userMaster == null || userMaster.Masterid != id) return BadRequest();

                var existingUserMaster = await usermasterRepository.GetUserMaster(id);
                if (existingUserMaster == null) return NotFound($"UserMaster com id = {id} não encontrado");

                return await usermasterRepository.UpdateUserMaster(userMaster);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbUsermaster>> DeleteUserMaster(decimal id)
        {
            try
            {
                var result = await usermasterRepository.GetUserMaster(id);
                if (result == null) return NotFound($"UserMaster com id = {id} não encontrado");

                usermasterRepository.DeleteUserMaster(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
