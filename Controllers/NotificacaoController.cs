using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoRepository notificacaoRepository;

        public NotificacaoController(INotificacaoRepository notificacaoRepository)
        {
            this.notificacaoRepository = notificacaoRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de notificações
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNotificaco>>> GetNotificacoes()
        {
            try
            {
                return Ok(await notificacaoRepository.GetNotificacoes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a notificação com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbNotificaco>> GetNotificacao(decimal id)
        {
            try
            {
                var result = await notificacaoRepository.GetNotificacao(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova notificação
        /// </summary>
        /// <response code="201">Retorna a notificação criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbNotificaco>> CreateNotificacao([FromBody] TbNotificaco notificacao)
        {
            try
            {
                if (notificacao == null) return BadRequest();

                var result = await notificacaoRepository.AddNotificacao(notificacao);

                return CreatedAtAction(nameof(GetNotificacao), new { id = result.Notificacoesid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera a notificação com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbNotificaco>> UpdateNotificacao(decimal id, [FromBody] TbNotificaco notificacao)
        {
            try
            {
                if (notificacao == null || notificacao.Notificacoesid != id) return BadRequest();

                var existingNotificacao = await notificacaoRepository.GetNotificacao(id);
                if (existingNotificacao == null) return NotFound($"Notificação com id = {id} não encontrada");

                return await notificacaoRepository.UpdateNotificacao(notificacao);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a notificação com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbNotificaco>> DeleteNotificacao(decimal id)
        {
            try
            {
                var result = await notificacaoRepository.GetNotificacao(id);
                if (result == null) return NotFound($"Notificação com id = {id} não encontrada");

                notificacaoRepository.DeleteNotificacao(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
