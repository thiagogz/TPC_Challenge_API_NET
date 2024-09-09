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

        [HttpPost]
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

        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbProduto>> DeleteProduto(decimal id)
        {
            try
            {
                var result = await produtoRepository.GetProduto(id);
                if (result == null) return NotFound($"Produto com id = {id} não encontrado");

                produtoRepository.DeleteProduto(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
