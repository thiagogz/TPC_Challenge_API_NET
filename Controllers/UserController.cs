using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de usuários
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUser>>> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o usuário com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbUser>> GetUser(decimal id)
        {
            try
            {
                var result = await userRepository.GetUser(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo usuário
        /// </summary>
        /// <response code="201">Retorna o usuário criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbUser>> CreateUser([FromBody] TbUser user)
        {
            try
            {
                if (user == null) return BadRequest();

                var result = await userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser), new { id = result.Usersid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera o usuário com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbUser>> UpdateUser(decimal id, [FromBody] TbUser user)
        {
            try
            {
                if (user == null || user.Usersid != id) return BadRequest();

                var existingUser = await userRepository.GetUser(id);
                if (existingUser == null) return NotFound($"Usuário com id = {id} não encontrado");

                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o usuário com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbUser>> DeleteUser(decimal id)
        {
            try
            {
                var result = await userRepository.GetUser(id);
                if (result == null) return NotFound($"Usuário com id = {id} não encontrado");

                await userRepository.DeleteUser(id);

                return Ok("Usuário deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
