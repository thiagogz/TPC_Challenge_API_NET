using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosCompraController : ControllerBase
    {
        private readonly IPontosCompraRepository pontosCompraRepository;

        public PontosCompraController(IPontosCompraRepository pontosCompraRepository)
        {
            this.pontosCompraRepository = pontosCompraRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPontosCompra>>> GetPontosCompra()
        {
            try
            {
                return Ok(await pontosCompraRepository.GetPontosCompra());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{compraId:decimal}/{pontoId:decimal}")]
        public async Task<ActionResult<TbPontosCompra>> GetPontosCompra(decimal compraId, decimal pontoId)
        {
            try
            {
                var result = await pontosCompraRepository.GetPontosCompraByIds(compraId, pontoId);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TbPontosCompra>> CreatePontosCompra([FromBody] TbPontosCompra pontosCompra)
        {
            try
            {
                if (pontosCompra == null) return BadRequest();

                var result = await pontosCompraRepository.AddPontosCompra(pontosCompra);

                return CreatedAtAction(nameof(GetPontosCompra), new { compraId = result.Compraid, pontoId = result.Pointid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        [HttpPut("{compraId:decimal}/{pontoId:decimal}")]
        public async Task<ActionResult<TbPontosCompra>> UpdatePontosCompra(decimal compraId, decimal pontoId, [FromBody] TbPontosCompra pontosCompra)
        {
            try
            {
                if (pontosCompra == null || pontosCompra.Compraid != compraId || pontosCompra.Pointid != pontoId)
                    return BadRequest();

                var existingPontosCompra = await pontosCompraRepository.GetPontosCompraByIds(compraId, pontoId);
                if (existingPontosCompra == null) return NotFound($"PontosCompra com compraId = {compraId} e pontoId = {pontoId} não encontrado");

                return await pontosCompraRepository.UpdatePontosCompra(pontosCompra);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpDelete("{compraId:decimal}/{pontoId:decimal}")]
        public async Task<ActionResult<TbPontosCompra>> DeletePontosCompra(decimal compraId, decimal pontoId)
        {
            try
            {
                var result = await pontosCompraRepository.GetPontosCompraByIds(compraId, pontoId);
                if (result == null) return NotFound($"PontosCompra com compraId = {compraId} e pontoId = {pontoId} não encontrado");

                pontosCompraRepository.DeletePontosCompra(compraId, pontoId);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
