using Estoque.Application.Interface;
using Estoque.Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Controllers
{    
    [Route("api/Controller")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;        

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet("ObterProdutoPorId")]
        public async Task<ProdutoDto> ObterProdutoPorId(int produtoId)
        {
            var response = await _service.ObterProdutoPorId(produtoId);
            return response;
        }

        [HttpGet("ObterListaDeProdutos")]
        public async Task<List<ProdutoDto>> ObterListaDeProdutos(int? page, int pageSize, string search)
        {
            var response = await _service.ObterListaDeProdutos(page, pageSize, search); 
            return response;
        }

        [HttpPost("CriarProduto")]
        public async Task<ProdutoDto> CriarProduto(ProdutoDto dto)
        {
            var response = await _service.CriarProduto(dto);
            return response;
        }

        [HttpPut("AtualizaProduto")]
        public async Task<ProdutoDto> AtualizaProduto(ProdutoDto dto)
        {
            var response = await _service.AtualizarProduto(dto);
            return response;
        }

        [HttpDelete("DeletarProdutoPorId")]
        public async Task<int> Delete(int produtoId)
        {
            var response = await _service.DeletarProduto(produtoId);
            return response;
        }
    }
}
