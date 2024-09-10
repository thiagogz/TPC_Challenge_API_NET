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

        /// <summary>
        /// Retorna a tabela completa de relação entre usuários e clusteres
        /// </summary>
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

        /// <summary>
        /// Retorna a relação entre usuário e cluster com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
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

        /// <summary>
        /// Inserção de uma nova relação entre usuário e cluster
        /// </summary>
        /// <response code="201">Retorna a relação entre ponto e compra criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Altera a relação entre usuário e cluster com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
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

        /// <summary>
        /// Deleta a relação entre usuário e cluster com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
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
