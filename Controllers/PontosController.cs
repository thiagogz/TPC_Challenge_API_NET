using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly IPontoRepository pontoRepository;

        public PontoController(IPontoRepository pontoRepository)
        {
            this.pontoRepository = pontoRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de pontos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPonto>>> GetPontos()
        {
            try
            {
                return Ok(await pontoRepository.GetPontos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o ponto com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbPonto>> GetPonto(decimal id)
        {
            try
            {
                var result = await pontoRepository.GetPonto(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo ponto
        /// </summary>
        /// <response code="201">Retorna o ponto criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbPonto>> CreatePonto([FromBody] TbPonto ponto)
        {
            try
            {
                if (ponto == null) return BadRequest();

                var result = await pontoRepository.AddPonto(ponto);

                return CreatedAtAction(nameof(GetPonto), new { id = result.Pointid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera o ponto com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbPonto>> UpdatePonto(decimal id, [FromBody] TbPonto ponto)
        {
            try
            {
                if (ponto == null || ponto.Pointid != id) return BadRequest();

                var existingPonto = await pontoRepository.GetPonto(id);
                if (existingPonto == null) return NotFound($"Ponto com id = {id} não encontrado");

                return await pontoRepository.UpdatePonto(ponto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o ponto com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbPonto>> DeletePonto(decimal id)
        {
            try
            {
                var result = await pontoRepository.GetPonto(id);
                if (result == null) return NotFound($"Ponto com id = {id} não encontrado");

                await pontoRepository.DeletePonto(id);

                return Ok("Pontos deletados com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
