using Estoque.Domain.Entities;
using Estoque.Domain.Repository.Interface;
using Estoque.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _produtoContext;

        public ProdutoRepository(ProdutoContext produtoContext) { _produtoContext = produtoContext; }

        public async Task<Produto> ObterProdutoPorId(int produtoId)
        {
            var entity = await _produtoContext.Produto
                .FirstOrDefaultAsync(item => item.ProdutoId == produtoId && item.SituacaoProduto == true);
            return entity;
        }

        public async Task<List<Produto>> ObterListaDeProdutos(int page, int pageSize, string search)
        {
            var entity = await _produtoContext.Produto
            .Where(x => x.DescricaoProduto.Trim().ToLower().Contains(search) && x.SituacaoProduto == true)
            .OrderByDescending(x => x.ProdutoId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return entity;
        }

        public async Task CriarProduto(Produto produto)
        {
            await _produtoContext.Produto.AddAsync(produto);
            _produtoContext.SaveChanges();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var entity = await _produtoContext.Produto.FirstOrDefaultAsync(item => item.ProdutoId == produto.ProdutoId);
            _produtoContext.Entry(entity).CurrentValues.SetValues(produto);
            _produtoContext.SaveChanges();
        }

        public async Task DeletarProduto(int produtoId)
        {
            var entity = await _produtoContext.Produto.FirstOrDefaultAsync(item => item.ProdutoId == produtoId);
            entity.SituacaoProduto = false;
            _produtoContext.SaveChanges();
        }
    }    
}
