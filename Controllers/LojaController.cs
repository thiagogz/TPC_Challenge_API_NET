using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly ILojaRepository lojaRepository;

        public LojaController(ILojaRepository lojaRepository)
        {
            this.lojaRepository = lojaRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de lojas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLoja>>> GetLojas()
        {
            try
            {
                return Ok(await lojaRepository.GetLojas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a loja com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbLoja>> GetLoja(decimal id)
        {
            try
            {
                var result = await lojaRepository.GetLoja(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova loja
        /// </summary>
        /// <response code="201">Retorna a loja criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbLoja>> CreateLoja([FromBody] TbLoja loja)
        {
            try
            {
                if (loja == null) return BadRequest();

                var result = await lojaRepository.AddLoja(loja);

                return CreatedAtAction(nameof(GetLoja), new { id = result.Pdvid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera a loja com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbLoja>> UpdateLoja(decimal id, [FromBody] TbLoja loja)
        {
            try
            {
                if (loja == null || loja.Pdvid != id) return BadRequest();

                var existingLoja = await lojaRepository.GetLoja(id);
                if (existingLoja == null) return NotFound($"Loja com id = {id} não encontrada");

                return await lojaRepository.UpdateLoja(loja);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a loja com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbLoja>> DeleteLoja(decimal id)
        {
            try
            {
                var result = await lojaRepository.GetLoja(id);
                if (result == null) return NotFound($"Loja com id = {id} não encontrada");

                lojaRepository.DeleteLoja(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
