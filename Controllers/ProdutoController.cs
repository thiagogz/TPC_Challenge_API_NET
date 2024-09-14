using Microsoft.AspNetCore.Mvc;
using TPC_Challenge_API_NET.Models;
using TPC_Challenge_API_NET.Repository.Interface;

namespace TPC_Challenge_API_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de produtos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProduto>>> GetProdutos()
        {
            try
            {
                return Ok(await produtoRepository.GetProdutos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o produto com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbProduto>> GetProduto(decimal id)
        {
            try
            {
                var result = await produtoRepository.GetProduto(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo produto
        /// </summary>
        /// <response code="201">Retorna o produto criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbProduto>> CreateProduto([FromBody] TbProduto produto)
        {
            try
            {
                if (produto == null) return BadRequest();

                var result = await produtoRepository.AddProduto(produto);

                return CreatedAtAction(nameof(GetProduto), new { id = result.Produtoid }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        /// <summary>
        /// Altera o produto com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbProduto>> UpdateProduto(decimal id, [FromBody] TbProduto produto)
        {
            try
            {
                if (produto == null || produto.Produtoid != id) return BadRequest();

                var existingProduto = await produtoRepository.GetProduto(id);
                if (existingProduto == null) return NotFound($"Produto com id = {id} não encontrado");

                return await produtoRepository.UpdateProduto(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o produto com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbProduto>> DeleteProduto(decimal id)
        {
            try
            {
                var result = await produtoRepository.GetProduto(id);
                if (result == null) return NotFound($"Produto com id = {id} não encontrado");

                await produtoRepository.DeleteProduto(id);

                return Ok("Produto deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
