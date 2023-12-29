using AutoMapper;
using Estoque.Application.Interface;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository.Interface;
using Estoque.Infra.CrossCutting.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Application.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
            IMapper mapper) 
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> ObterProdutoPorId(int produtoId)
        {
            if (produtoId == default)
                return null;

            var entity = await _produtoRepository.ObterProdutoPorId(produtoId);
            var dto = _mapper.Map<ProdutoDto>(entity);

            return dto;
        }

        public async Task<List<ProdutoDto>> ObterListaDeProdutos(int? page, int pageSize, string search)
        {
            var response = new List<Produto>();

            if (!string.IsNullOrWhiteSpace(search))
                response = await _produtoRepository
                    .ObterListaDeProdutos(page ?? 1, pageSize, search.Trim().ToLower());

            if (response == null)
                return new List<ProdutoDto>();

            var dto = _mapper.Map<List<ProdutoDto>>(response);

            return dto;
        }

        public async Task<ProdutoDto> CriarProduto(ProdutoDto dto)
        {
            if (dto == null) return null;

            if (dto.DataFabricacao < dto.DataValidade
                && dto.DataFabricacao != dto.DataValidade)
            {
                var entity = _mapper.Map<Produto>(dto);
                await _produtoRepository.CriarProduto(entity);
                dto.ProdutoId = entity.ProdutoId;
            }

            return dto;
        }

        public async Task<ProdutoDto> AtualizarProduto(ProdutoDto dto)
        {
            if (dto == null) return null;

            if (dto.DataFabricacao < dto.DataValidade
                && dto.DataFabricacao != dto.DataValidade)
            {
                var entity = _mapper.Map<Produto>(dto);
                await _produtoRepository.AtualizarProduto(entity);
                dto.ProdutoId = entity.ProdutoId;
            }

            return dto;
        }

        public async Task<int> DeletarProduto(int id)
        {
            if (id == 0) return default;

            await _produtoRepository.DeletarProduto(id);

            return id;
        }

    }
}
