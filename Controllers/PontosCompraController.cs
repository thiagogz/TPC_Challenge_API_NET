using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository;
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

        /// <summary>
        /// Retorna a tabela completa de relação entre pontos e compras
        /// </summary>
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

        /// <summary>
        /// Retorna a relação entre ponto e compra com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
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

        /// <summary>
        /// Inserção de uma nova relação entre crédito e compra
        /// </summary>
        /// <response code="201">Retorna a relação entre ponto e compra criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Altera a relação entre ponto e compra com o id especificado
        /// </summary>
        /// <remarks>
        /// Devido a ausência de chave primária, esse método é chamado utilizando dois parâmetros
        /// </remarks>
        [HttpPut("{compraId:decimal}/{pontoId:decimal}")]
        public async Task<ActionResult<TbPontosCompra>> UpdatePontosCompra(decimal compraId, decimal pontoId, [FromBody] TbPontosCompra pontosCompra)
        {
            try
            {
                if (pontosCompra == null || pontosCompra.Compraid == null || pontosCompra.Pointid == null) return BadRequest();

                var existingPontosCompra = await pontosCompraRepository.GetPontosCompraByIds(compraId, pontoId);
                if (existingPontosCompra == null) return NotFound($"PontosCompra com compraId = {compraId} e pontoId = {pontoId} não encontrado");

                return await pontosCompraRepository.UpdatePontosCompra(compraId, pontoId, pontosCompra);
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
        [HttpDelete("{compraId:decimal}/{pontoId:decimal}")]
        public async Task<ActionResult<TbPontosCompra>> DeletePontosCompra(decimal compraId, decimal pontoId)
        {
            try
            {
                var result = await pontosCompraRepository.GetPontosCompraByIds(compraId, pontoId);
                if (result == null) return NotFound($"PontosCompra com compraId = {compraId} e pontoId = {pontoId} não encontrado");

                await pontosCompraRepository.DeletePontosCompra(compraId, pontoId);

                return Ok("Relação entre pontos e compras deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
