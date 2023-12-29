using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterProdutoPorId(int produtoId);
        Task<List<Produto>> ObterListaDeProdutos(int page, int pageSize, string search);
        Task CriarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task DeletarProduto(int produtoId);
    }
}
