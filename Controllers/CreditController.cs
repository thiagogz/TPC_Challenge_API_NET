using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditRepository creditRepository;

        public CreditController(ICreditRepository creditRepository)
        {
            this.creditRepository = creditRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de créditos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCredit>>> GetCredits()
        {
            try
            {
                return Ok(await creditRepository.GetCredits());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o crédito com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbCredit>> GetCredit(decimal id)
        {
            try
            {
                var result = await creditRepository.GetCredit(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo crédito
        /// </summary>
        /// <response code="201">Retorna o crédito criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCredit>> CreateCredit([FromBody] TbCredit credit)
        {
            try
            {
                if (credit == null) return BadRequest();

                var result = await creditRepository.AddCredit(credit);

                return CreatedAtAction(nameof(GetCredit), new { id = result.Creditid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera o crédito com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbCredit>> UpdateCredit(decimal id, [FromBody] TbCredit credit)
        {
            try
            {
                if (credit == null || credit.Creditid != id) return BadRequest();

                var existingCredit = await creditRepository.GetCredit(id);
                if (existingCredit == null) return NotFound($"Crédito com id = {id} não encontrado");

                return await creditRepository.UpdateCredit(credit);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o crédito com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCredit>> DeleteCredit(decimal id)
        {
            try
            {
                var result = await creditRepository.GetCredit(id);
                if (result == null) return NotFound($"Crédito com id = {id} não encontrado");

                creditRepository.DeleteCredit(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
