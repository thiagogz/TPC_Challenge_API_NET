using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCompraController : ControllerBase
    {
        private readonly ICreditCompraRepository creditCompraRepository;

        public CreditCompraController(ICreditCompraRepository creditCompraRepository)
        {
            this.creditCompraRepository = creditCompraRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de relação entre créditos e compras
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCreditCompra>>> GetCreditCompras()
        {
            try
            {
                return Ok(await creditCompraRepository.GetCreditCompras());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a relação entre crédito e compra com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
        [HttpGet("{creditId:decimal}/{compraId:decimal}")]
        public async Task<ActionResult<TbCreditCompra>> GetCreditCompra(decimal creditId, decimal compraId)
        {
            try
            {
                var result = await creditCompraRepository.GetCreditCompra(creditId, compraId);
                if (result == null) return NotFound($"Crédito com id = {creditId} e Compra com id = {compraId} não encontrado");

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova relação entre crédito e compra
        /// </summary>
        /// <response code="201">Retorna a relação entre crédito e compra criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCreditCompra>> CreateCreditCompra([FromBody] TbCreditCompra creditCompra)
        {
            try
            {
                if (creditCompra == null) return BadRequest();

                var result = await creditCompraRepository.AddCreditCompra(creditCompra);

                return CreatedAtAction(nameof(GetCreditCompra), new { creditId = result.Creditid, compraId = result.Compraid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera a relação entre crédito e compra com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
        [HttpPut("{creditId:decimal}/{compraId:decimal}")]
        public async Task<ActionResult<TbCreditCompra>> UpdateCreditCompra(decimal creditId, decimal compraId, [FromBody] TbCreditCompra creditCompra)
        {
            try
            {
                if (creditCompra == null || creditCompra.Creditid != creditId || creditCompra.Compraid != compraId) return BadRequest();

                var existingCreditCompra = await creditCompraRepository.GetCreditCompra(creditId, compraId);
                if (existingCreditCompra == null) return NotFound($"Crédito com id = {creditId} e Compra com id = {compraId} não encontrado");

                return await creditCompraRepository.UpdateCreditCompra(creditCompra);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a relação entre crédito e compra com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
        [HttpDelete("{creditId:decimal}/{compraId:decimal}")]
        public async Task<ActionResult<TbCreditCompra>> DeleteCreditCompra(decimal creditId, decimal compraId)
        {
            try
            {
                var result = await creditCompraRepository.GetCreditCompra(creditId, compraId);
                if (result == null) return NotFound($"Crédito com id = {creditId} e Compra com id = {compraId} não encontrado");

                creditCompraRepository.DeleteCreditCompra(creditId, compraId);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
