using Estoque.Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Interface
{
    public interface IProdutoService
    {
        Task<ProdutoDto> ObterProdutoPorId(int produtoId);
        Task<List<ProdutoDto>> ObterListaDeProdutos(int? page, int pageSize, string search);
        Task<ProdutoDto> CriarProduto(ProdutoDto dto);
        Task<ProdutoDto> AtualizarProduto(ProdutoDto dto);
        Task<int> DeletarProduto(int id);
    }
}
