using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        private readonly ICampanhaRepository campanhaRepository;

        public CampanhaController(ICampanhaRepository campanhaRepository)
        {
            this.campanhaRepository = campanhaRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de campanhas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCampanha>>> GetCampanhas()
        {
            try
            {
                return Ok(await campanhaRepository.GetCampanhas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a campanha com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbCampanha>> GetCampanha(decimal id)
        {
            try
            {
                var result = await campanhaRepository.GetCampanha(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova campanha
        /// </summary>
        /// <response code="201">Retorna a campanha criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCampanha>> CreateCampanha([FromBody] TbCampanha campanha)
        {
            try
            {
                if (campanha == null) return BadRequest();

                var result = await campanhaRepository.AddCampanha(campanha);

                return CreatedAtAction("GetCampanha", new { id = campanha.Campanhaid }, campanha);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera a campanha com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbCampanha>> UpdateCampanha(decimal id, [FromBody] TbCampanha campanha)
        {
            try
            {
                if (campanha == null || campanha.Campanhaid != id) return BadRequest();

                var existingCampanha = await campanhaRepository.GetCampanha(id);
                if (existingCampanha == null) return NotFound($"Campanha com id = {id} não encontrada");

                return await campanhaRepository.UpdateCampanha(campanha);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a campanha com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCampanha>> DeleteCampanha(decimal id)
        {
            try
            {
                var result = await campanhaRepository.GetCampanha(id);
                if (result == null) return NotFound($"Campanha com id = {id} não encontrada");

                await campanhaRepository.DeleteCampanha(id);

                return Ok("Campanha deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
