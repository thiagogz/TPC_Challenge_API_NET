using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de categorias
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCategoria>>> GetCategorias()
        {
            try
            {
                return Ok(await categoriaRepository.GetCategorias());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a categoria com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbCategoria>> GetCategoria(decimal id)
        {
            try
            {
                var result = await categoriaRepository.GetCategoria(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova categoria
        /// </summary>
        /// <response code="201">Retorna a categoria criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbCategoria>> CreateCategoria([FromBody] TbCategoria categoria)
        {
            try
            {
                if (categoria == null) return BadRequest();

                var result = await categoriaRepository.AddCategoria(categoria);

                return CreatedAtAction(nameof(GetCategoria), new { id = result.Categoriaid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera a categoria com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbCategoria>> UpdateCategoria(decimal id, [FromBody] TbCategoria categoria)
        {
            try
            {
                if (categoria == null || categoria.Categoriaid != id) return BadRequest();

                var existingCategoria = await categoriaRepository.GetCategoria(id);
                if (existingCategoria == null) return NotFound($"Categoria com id = {id} não encontrada");

                return await categoriaRepository.UpdateCategoria(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a categoria com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
         
        public async Task<ActionResult<TbCategoria>> DeleteCategoria(decimal id)
        {
            try
            {
                var result = await categoriaRepository.GetCategoria(id);
                if (result == null) return NotFound($"Categoria com id = {id} não encontrada");

                await categoriaRepository.DeleteCategoria(id);

                return Ok("Categoria deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
