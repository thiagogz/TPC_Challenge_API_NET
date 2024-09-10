using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        private readonly IClusterRepository clusterRepository;

        public ClusterController(IClusterRepository clusterRepository)
        {
            this.clusterRepository = clusterRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de clusters
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCluster>>> GetClusters()
        {
            try
            {
                return Ok(await clusterRepository.GetClusters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o cluster com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbCluster>> GetCluster(decimal id)
        {
            try
            {
                var result = await clusterRepository.GetCluster(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo cluster
        /// </summary>
        /// <response code="201">Retorna o cluster criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCluster>> CreateCluster([FromBody] TbCluster cluster)
        {
            try
            {
                if (cluster == null) return BadRequest();

                var result = await clusterRepository.AddCluster(cluster);

                return CreatedAtAction(nameof(GetCluster), new { id = result.Clusterid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera o cluster com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbCluster>> UpdateCluster(decimal id, [FromBody] TbCluster cluster)
        {
            try
            {
                if (cluster == null || cluster.Clusterid != id) return BadRequest();

                var existingCluster = await clusterRepository.GetCluster(id);
                if (existingCluster == null) return NotFound($"Cluster com id = {id} não encontrado");

                return await clusterRepository.UpdateCluster(cluster);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o cluster com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCluster>> DeleteCluster(decimal id)
        {
            try
            {
                var result = await clusterRepository.GetCluster(id);
                if (result == null) return NotFound($"Cluster com id = {id} não encontrado");

                clusterRepository.DeleteCluster(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
