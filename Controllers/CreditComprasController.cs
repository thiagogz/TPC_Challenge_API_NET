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

        [HttpPost]
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
