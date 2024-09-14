using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            this.compraRepository = compraRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de compras
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCompra>>> GetCompras()
        {
            try
            {
                return Ok(await compraRepository.GetCompras());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a compra com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbCompra>> GetCompra(decimal id)
        {
            try
            {
                var result = await compraRepository.GetCompra(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova compra
        /// </summary>
        /// <response code="201">Retorna a compra criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCompra>> CreateCompra([FromBody] TbCompra compra)
        {
            try
            {
                if (compra == null) return BadRequest();

                var result = await compraRepository.AddCompra(compra);

                return CreatedAtAction(nameof(GetCompra), new { id = result.Compraid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera a compra com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbCompra>> UpdateCompra(decimal id, [FromBody] TbCompra compra)
        {
            try
            {
                if (compra == null || compra.Compraid != id) return BadRequest();

                var existingCompra = await compraRepository.GetCompra(id);
                if (existingCompra == null) return NotFound($"Compra com id = {id} não encontrada");

                return await compraRepository.UpdateCompra(compra);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a compra com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCompra>> DeleteCompra(decimal id)
        {
            try
            {
                var result = await compraRepository.GetCompra(id);
                if (result == null) return NotFound($"Compra com id = {id} não encontrada");

                await compraRepository.DeleteCompra(id);

                return Ok("Compra deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
