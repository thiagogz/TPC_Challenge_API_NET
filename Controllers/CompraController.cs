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

        [HttpPost]
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

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCompra>> DeleteCompra(decimal id)
        {
            try
            {
                var result = await compraRepository.GetCompra(id);
                if (result == null) return NotFound($"Compra com id = {id} não encontrada");

                compraRepository.DeleteCompra(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
