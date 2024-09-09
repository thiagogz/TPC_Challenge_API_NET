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

        [HttpPost]
        public async Task<ActionResult<TbCampanha>> CreateCampanha([FromBody] TbCampanha campanha)
        {
            try
            {
                if (campanha == null) return BadRequest();

                var result = await campanhaRepository.AddCampanha(campanha);

                return CreatedAtAction(nameof(GetCampanha), new { id = result.Campanhaid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

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

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbCampanha>> DeleteCampanha(decimal id)
        {
            try
            {
                var result = await campanhaRepository.GetCampanha(id);
                if (result == null) return NotFound($"Campanha com id = {id} não encontrada");

                campanhaRepository.DeleteCampanha(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
