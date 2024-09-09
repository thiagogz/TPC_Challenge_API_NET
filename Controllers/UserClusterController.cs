using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClusterController : ControllerBase
    {
        private readonly IUserClusterRepository userClusterRepository;

        public UserClusterController(IUserClusterRepository userClusterRepository)
        {
            this.userClusterRepository = userClusterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUserCluster>>> GetUserClusters()
        {
            try
            {
                return Ok(await userClusterRepository.GetUserClusters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbUserCluster>> GetUserCluster(decimal id)
        {
            try
            {
                var result = await userClusterRepository.GetUserCluster(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TbUserCluster>> CreateUserCluster([FromBody] TbUserCluster userCluster)
        {
            try
            {
                if (userCluster == null) return BadRequest();

                var result = await userClusterRepository.AddUserCluster(userCluster);

                return CreatedAtAction(nameof(GetUserCluster), new { id = result.Userclusterid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbUserCluster>> UpdateUserCluster(decimal id, [FromBody] TbUserCluster userCluster)
        {
            try
            {
                if (userCluster == null || userCluster.Userclusterid != id) return BadRequest();

                var existingUserCluster = await userClusterRepository.GetUserCluster(id);
                if (existingUserCluster == null) return NotFound($"UserCluster com id = {id} não encontrado");

                return await userClusterRepository.UpdateUserCluster(userCluster);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbUserCluster>> DeleteUserCluster(decimal id)
        {
            try
            {
                var result = await userClusterRepository.GetUserCluster(id);
                if (result == null) return NotFound($"UserCluster com id = {id} não encontrado");

                userClusterRepository.DeleteUserCluster(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
