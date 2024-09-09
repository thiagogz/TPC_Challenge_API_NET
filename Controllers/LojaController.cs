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

        [HttpPost]
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
